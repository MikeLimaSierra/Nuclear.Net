using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers {
    internal class NugetResolver : AssemblyResolver, INugetResolver {

        #region fields

        private static readonly String _nugetDirName = ".nuget";

        private static readonly String _packagesDirName = "packages";

        private readonly IEnumerable<DirectoryInfo> _nugetCaches = null;

        #endregion

        #region properties

        internal static INugetResolver Instance { get; } = new NugetResolver();

        #endregion

        #region ctors

        internal NugetResolver() {
            Throw.IfNot.Object.IsNull<AccessViolationException>(Instance, "Constructor must not be called twice.");

            _nugetCaches = GetCaches();
        }

        #endregion

        #region public methods

        public override Boolean TryResolve(ResolveEventArgs e, out IEnumerable<FileInfo> files) {
            files = Enumerable.Empty<FileInfo>();

            return AssemblyHelper.TryGetAssemblyName(e, out AssemblyName assemblyName) && TryResolve(assemblyName, out files);
        }

        public override Boolean TryResolve(String fullName, out IEnumerable<FileInfo> files) {
            files = Enumerable.Empty<FileInfo>();

            return AssemblyHelper.TryGetAssemblyName(fullName, out AssemblyName assemblyName) && TryResolve(assemblyName, out files);
        }

        public override Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<FileInfo> files) {
            files = Enumerable.Empty<FileInfo>();

            if(assemblyName != null && RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo current)) {
                files = GetAssemblyCandidates(assemblyName, _nugetCaches, current);
            }

            return files != null && files.Count() > 0;
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

        internal static IEnumerable<FileInfo> GetAssemblyCandidates(AssemblyName assemblyName, IEnumerable<DirectoryInfo> nugetCaches, RuntimeInfo current) {
            Throw.If.Object.IsNull(assemblyName, nameof(assemblyName));
            Throw.If.Object.IsNull(nugetCaches, nameof(nugetCaches));
            Throw.If.Object.IsNull(current, nameof(current));

            List<FileInfo> candidates = new List<FileInfo>();

            if(RuntimesHelper.TryGetLoadableRuntimes(current, out IEnumerable<RuntimeInfo> validRuntimes)) {
                nugetCaches.Foreach(cache => candidates.AddRange(GetAssemblyCandidatesFromCache(assemblyName, cache, validRuntimes)));
            }

            return candidates;
        }

        internal static IEnumerable<FileInfo> GetAssemblyCandidatesFromCache(AssemblyName assemblyName, DirectoryInfo nugetCache, IEnumerable<RuntimeInfo> validRuntimes) {
            Throw.If.Object.IsNull(assemblyName, nameof(assemblyName));
            Throw.If.Object.IsNull(nugetCache, nameof(nugetCache));
            Throw.If.Object.IsNull(validRuntimes, nameof(validRuntimes));

            List<FileInfo> candidates = new List<FileInfo>();
            IComparer<RuntimeInfo> comparer = new RuntimeInfoFeatureComparer();

            if(TryGetPackage(assemblyName.Name, nugetCache, out DirectoryInfo package)) {
                IOrderedEnumerable<KeyValuePair<(Version, String, RuntimeInfo, ProcessorArchitecture), DirectoryInfo>> packageVersions =
                    GetPackageVersions(package)
                        .Where(pv => validRuntimes.Contains(pv.Key.runtime))
                        .OrderByDescending(pv => pv.Key.version)
                        .ThenByDescending(pv => pv.Key.runtime, comparer);

                foreach(KeyValuePair<(Version version, String label, RuntimeInfo runtime, ProcessorArchitecture arch), DirectoryInfo> packageVersion in packageVersions) {
                    candidates.AddRange(FilterCandidates(assemblyName, packageVersion.Value.EnumerateFiles($"{assemblyName.Name}.dll", SearchOption.AllDirectories)));
                }
            }

            return candidates;
        }

        internal static IEnumerable<FileInfo> FilterCandidates(AssemblyName assemblyName, IEnumerable<FileInfo> candidates)
            => candidates.Where(c => AssemblyHelper.TryGetAssemblyName(c, out AssemblyName asmName) && AssemblyHelper.ValidateByName(assemblyName, asmName) && AssemblyHelper.ValidateArchitecture(asmName));

        internal static Boolean TryGetPackage(String name, DirectoryInfo cache, out DirectoryInfo package) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));
            Throw.If.Object.IsNull(cache, nameof(cache));
            Throw.If.Value.IsFalse(cache.Exists, nameof(cache), $"{cache.FullName.Format()} doesn't exist!");

            package = null;

            try {
                package = cache.EnumerateDirectories(name, SearchOption.TopDirectoryOnly).FirstOrDefault();

            } catch { /* Don't worry about exceptions here! */ }

            return package != null && package.Exists;
        }

        internal static IDictionary<(Version version, String label, RuntimeInfo runtime, ProcessorArchitecture arch), DirectoryInfo> GetPackageVersions(DirectoryInfo package) {
            Dictionary<(Version, String, RuntimeInfo, ProcessorArchitecture), DirectoryInfo> packageVersions = new Dictionary<(Version, String, RuntimeInfo, ProcessorArchitecture), DirectoryInfo>();

            if(package != null && package.Exists) {
                foreach(DirectoryInfo semVer in package.EnumerateDirectories("*", SearchOption.TopDirectoryOnly)) {
                    String versionString = semVer.Name;
                    String label = String.Empty;
                    Int32 indexOfDash = semVer.Name.IndexOf('-');

                    if(indexOfDash >= 0) {
                        versionString = semVer.Name.Substring(0, indexOfDash);
                        label = semVer.Name.Substring(indexOfDash + 1);
                    }

                    if(Version.TryParse(semVer.Name, out Version version)) {
                        GetPackageVersionRuntimes(new DirectoryInfo(Path.Combine(semVer.FullName, "lib")))
                            .Foreach(kvp => packageVersions.Add((version, label, kvp.Key, ProcessorArchitecture.MSIL), kvp.Value));

                        GetPackageVersionRuntimes(new DirectoryInfo(Path.Combine(semVer.FullName, "lib", "x86")))
                            .Foreach(kvp => packageVersions.Add((version, label, kvp.Key, ProcessorArchitecture.X86), kvp.Value));

                        GetPackageVersionRuntimes(new DirectoryInfo(Path.Combine(semVer.FullName, "lib", "x64")))
                            .Foreach(kvp => packageVersions.Add((version, label, kvp.Key, ProcessorArchitecture.Amd64), kvp.Value));
                    }
                }
            }

            return packageVersions;
        }

        internal static IDictionary<RuntimeInfo, DirectoryInfo> GetPackageVersionRuntimes(DirectoryInfo lib) {
            Dictionary<RuntimeInfo, DirectoryInfo> packageVersions = new Dictionary<RuntimeInfo, DirectoryInfo>();

            if(lib != null && lib.Exists) {
                foreach(DirectoryInfo targetFramework in lib.EnumerateDirectories("*", SearchOption.TopDirectoryOnly)) {

                    if(RuntimesHelper.TryParseTFM(targetFramework.Name, out RuntimeInfo runtime)) {
                        packageVersions.Add(runtime, targetFramework);
                    }
                }
            }

            return packageVersions;
        }

        #endregion

    }
}
