using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Creation;
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers.Internal {
    internal class NugetResolver : AssemblyResolver<INugetResolverData>, INugetResolver {

        #region fields

        private static readonly ICreator<INugetResolverData, FileInfo> _factory = Factory.Instance.NugetResolver();

        private static readonly String _nugetDirName = ".nuget";

        private static readonly String _packagesDirName = "packages";

        #endregion

        #region properties

        public IEnumerable<DirectoryInfo> NugetCaches { get; }

        #endregion

        #region ctors

        internal NugetResolver(MatchingStrategies strategy) : this(strategy, null) { }

        internal NugetResolver(MatchingStrategies strategy, IEnumerable<DirectoryInfo> caches) : base(strategy) {
            NugetCaches = caches ?? GetCaches();
        }

        #endregion

        #region public methods

        public override Boolean TryResolve(ResolveEventArgs e, out IEnumerable<INugetResolverData> data) {
            data = Enumerable.Empty<INugetResolverData>();

            return AssemblyHelper.TryGetAssemblyName(e, out AssemblyName assemblyName) && TryResolve(assemblyName, out data);
        }

        public override Boolean TryResolve(String fullName, out IEnumerable<INugetResolverData> data) {
            data = Enumerable.Empty<INugetResolverData>();

            return AssemblyHelper.TryGetAssemblyName(fullName, out AssemblyName assemblyName) && TryResolve(assemblyName, out data);
        }

        public override Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<INugetResolverData> data) {
            data = Enumerable.Empty<INugetResolverData>();

            if(assemblyName != null && RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo current)) {
                data = GetAssemblyCandidates(assemblyName, NugetCaches, current);
            }

            return data != null && data.Count() > 0;
        }

        #endregion

        #region internal methods

        internal static IEnumerable<DirectoryInfo> GetCaches() {
            List<DirectoryInfo> caches = new List<DirectoryInfo>();

            DirectoryInfo userProfileDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            DirectoryInfo usersDir = userProfileDir.Parent;

            String userNugetDir = Path.Combine(userProfileDir.FullName, _nugetDirName, _packagesDirName);

            if(Directory.Exists(userNugetDir)) {
                caches.Add(new DirectoryInfo(userNugetDir));
            }

            foreach(DirectoryInfo userDir in usersDir.EnumerateDirectories()) {
                try {
                    String secondaryNugetDir = Path.Combine(userDir.FullName, _nugetDirName, _packagesDirName);

                    if(Directory.Exists(secondaryNugetDir) && secondaryNugetDir != userNugetDir) {
                        caches.Add(new DirectoryInfo(secondaryNugetDir));
                    }

                } catch { /* Don't care if we can't access drectories */ }

            }

            return caches;
        }

        internal static IEnumerable<INugetResolverData> GetAssemblyCandidates(AssemblyName assemblyName, IEnumerable<DirectoryInfo> cacheDirs, RuntimeInfo current) {
            Throw.If.Object.IsNull(assemblyName, nameof(assemblyName));
            Throw.If.Object.IsNull(cacheDirs, nameof(cacheDirs));
            Throw.If.Object.IsNull(current, nameof(current));

            List<INugetResolverData> candidates = new List<INugetResolverData>();

            if(RuntimesHelper.TryGetLoadableRuntimes(current, out IEnumerable<RuntimeInfo> validRuntimes)) {
                cacheDirs.Foreach(cache => candidates.AddRange(GetAssemblyCandidatesFromCache(assemblyName, cache, validRuntimes)));
            }

            return candidates;
        }

        internal static IEnumerable<INugetResolverData> GetAssemblyCandidatesFromCache(AssemblyName asmName, DirectoryInfo cacheDir, IEnumerable<RuntimeInfo> validRuntimes) {
            Throw.If.Object.IsNull(asmName, nameof(asmName));
            Throw.If.Object.IsNull(cacheDir, nameof(cacheDir));
            Throw.If.Object.IsNull(validRuntimes, nameof(validRuntimes));

            List<INugetResolverData> candidates = new List<INugetResolverData>();

            if(TryGetPackage(asmName.Name, cacheDir, out DirectoryInfo packageDir)) {
                candidates.AddRange(packageDir
                    .EnumerateFiles($"{asmName.Name}.dll", SearchOption.AllDirectories)
                    .Select(_ => {
                        _factory.Create(out INugetResolverData data, _);
                        return data;
                    })
                    .Where(d => AssemblyHelper.ValidateByName(asmName, d.Name))
                    .Where(d => AssemblyHelper.ValidateArchitecture(d.Name))
                    .Where(d => validRuntimes.Contains(d.PackageTargetFramework))
                    .OrderByDescending(d => d.PackageVersion)
                    .ThenByDescending(d => d.PackageTargetFramework, new RuntimeInfoFeatureComparer()));
            }

            return candidates;
        }

        internal static Boolean TryGetPackage(String name, DirectoryInfo cache, out DirectoryInfo packageDir) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(cache, nameof(cache));
            Throw.If.Value.IsFalse(cache.Exists, nameof(cache), $"{cache.FullName.Format()} doesn't exist!");

            packageDir = null;

            try {
                packageDir = cache.EnumerateDirectories(name, SearchOption.TopDirectoryOnly).FirstOrDefault();

            } catch { /* Don't worry about exceptions here! */ }

            return packageDir != null && packageDir.Exists;
        }

        #endregion

    }
}
