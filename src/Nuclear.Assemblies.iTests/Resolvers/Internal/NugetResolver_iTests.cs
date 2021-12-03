using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Creation;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Internal {
    class NugetResolver_iTests {

        #region TryResolve

        [TestMethod]
        [TestData(nameof(TryResolveArgs_Data))]
        void TryResolveArgs(ResolveEventArgs input, Boolean expected, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict, new DirectoryInfo[] { Statics.FakeNugetCache });
            Boolean result = false;
            IEnumerable<INugetResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveArgs_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs(null, null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs("", null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs("some name", null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs(Statics.TestAsm.FullName, null), false, Enumerable.Empty<FileInfo>() };
        }

        [TestMethod]
        [TestData(nameof(TryResolveString_Data))]
        void TryResolveString(String input, Boolean expected, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict, new DirectoryInfo[] { Statics.FakeNugetCache });
            Boolean result = false;
            IEnumerable<INugetResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveString_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { "", false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { "some name", false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.FullName, false, Enumerable.Empty<FileInfo>() };
        }

        [TestMethod]
        [TestData(nameof(TryResolveName_Data))]
        void TryResolveName(AssemblyName input, Boolean expected, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict, new DirectoryInfo[] { Statics.FakeNugetCache });
            Boolean result = default;
            IEnumerable<INugetResolverData> _files = default;

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveName_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), false, Enumerable.Empty<FileInfo>() };
        }

        #endregion

        #region InternalResolver_Wiring

        [TestMethod]
        void TryResolveArgs_Wiring() {

            Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer);
            var internalResolver = new DummyCoreResolver();
            ((NugetResolver) instance).CoreResolver = internalResolver;
            RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo current);
            IEnumerable<INugetResolverData> data = default;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(new ResolveEventArgs(Statics.TestAsm.FullName, null), out data), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Enumerable.MatchesExactly(internalResolver.CacheDir, NugetResolver.GetCaches(), Statics.DirectoryInfoComparer);
            Test.If.Value.IsEqual(internalResolver.Current, current);
            Test.If.Value.IsEqual(internalResolver.AssemblyMatchingStrategy, VersionMatchingStrategies.SemVer);
            Test.If.Value.IsEqual(internalResolver.PackageMatchingStrategy, VersionMatchingStrategies.SemVer);
            Test.IfNot.Object.IsNull(data);
            Test.If.Enumerable.MatchesExactly(data, new IDefaultResolverData[] { null });

        }

        [TestMethod]
        void TryResolveArgsWithPath_Wiring() {

            Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer);
            var internalResolver = new DummyCoreResolver();
            ((NugetResolver) instance).CoreResolver = internalResolver;
            RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo current);
            IEnumerable<INugetResolverData> data = default;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(new ResolveEventArgs(Statics.TestAsm.FullName, Statics.TestAsm), out data), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Enumerable.MatchesExactly(internalResolver.CacheDir, NugetResolver.GetCaches(), Statics.DirectoryInfoComparer);
            Test.If.Value.IsEqual(internalResolver.Current, current);
            Test.If.Value.IsEqual(internalResolver.AssemblyMatchingStrategy, VersionMatchingStrategies.SemVer);
            Test.If.Value.IsEqual(internalResolver.PackageMatchingStrategy, VersionMatchingStrategies.SemVer);
            Test.IfNot.Object.IsNull(data);
            Test.If.Enumerable.MatchesExactly(data, new IDefaultResolverData[] { null });

        }

        [TestMethod]
        void TryResolveString_Wiring() {

            Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer);
            var internalResolver = new DummyCoreResolver();
            ((NugetResolver) instance).CoreResolver = internalResolver;
            RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo current);
            IEnumerable<INugetResolverData> data = default;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(Statics.TestAsm.FullName, out data), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Enumerable.MatchesExactly(internalResolver.CacheDir, NugetResolver.GetCaches(), Statics.DirectoryInfoComparer);
            Test.If.Value.IsEqual(internalResolver.Current, current);
            Test.If.Value.IsEqual(internalResolver.AssemblyMatchingStrategy, VersionMatchingStrategies.SemVer);
            Test.If.Value.IsEqual(internalResolver.PackageMatchingStrategy, VersionMatchingStrategies.SemVer);
            Test.IfNot.Object.IsNull(data);
            Test.If.Enumerable.MatchesExactly(data, new IDefaultResolverData[] { null });

        }

        [TestMethod]
        void TryResolveName_Wiring() {

            Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict);
            var internalResolver = new DummyCoreResolver();
            ((NugetResolver) instance).CoreResolver = internalResolver;
            RuntimesHelper.TryGetCurrentRuntime(out RuntimeInfo current);
            IEnumerable<INugetResolverData> data = default;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(Statics.TestAsm.GetName(), out data), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Enumerable.MatchesExactly(internalResolver.CacheDir, NugetResolver.GetCaches(), Statics.DirectoryInfoComparer);
            Test.If.Value.IsEqual(internalResolver.Current, current);
            Test.If.Value.IsEqual(internalResolver.AssemblyMatchingStrategy, VersionMatchingStrategies.Strict);
            Test.If.Value.IsEqual(internalResolver.PackageMatchingStrategy, VersionMatchingStrategies.Strict);
            Test.IfNot.Object.IsNull(data);
            Test.If.Enumerable.MatchesExactly(data, new IDefaultResolverData[] { null });

        }

        #endregion

        private class DummyCoreResolver : ICoreNugetResolver {

            internal AssemblyName AssemblyName { get; private set; }
            internal IEnumerable<DirectoryInfo> CacheDir { get; private set; }
            internal RuntimeInfo Current { get; private set; }
            internal VersionMatchingStrategies AssemblyMatchingStrategy { get; private set; }
            internal VersionMatchingStrategies PackageMatchingStrategy { get; private set; }

            public IEnumerable<INugetResolverData> Resolve(AssemblyName assemblyName, IEnumerable<DirectoryInfo> cacheDirs, RuntimeInfo current, VersionMatchingStrategies assemblyMatchingStrategy, VersionMatchingStrategies packageMatchingStrategy) {
                AssemblyName = assemblyName;
                CacheDir = cacheDirs;
                Current = current;
                AssemblyMatchingStrategy = assemblyMatchingStrategy;
                PackageMatchingStrategy = packageMatchingStrategy;

                return new INugetResolverData[] { null };
            }

        }

        #region GetCaches

        [TestMethod]
        void GetCaches() {

            IEnumerable<DirectoryInfo> caches = default;

            String userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages");

            Test.IfNot.Action.ThrowsException(() => caches = NugetResolver.GetCaches(), out Exception ex);

            Test.If.Value.IsEqual(caches.Count(), 1);
            Test.If.Value.IsEqual(caches.First().FullName, userPath);

        }

        #endregion

    }
}
