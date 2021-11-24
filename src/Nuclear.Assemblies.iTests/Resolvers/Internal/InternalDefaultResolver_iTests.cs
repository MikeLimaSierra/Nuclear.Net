using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.ResolverData;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Internal {
    class InternalDefaultResolver_iTests {

        private static readonly FileInfo _nonExistentAssembly = new FileInfo(@"C:\NonExistent.dll");

        #region ResolveInternal

        [TestMethod]
        [TestData(nameof(Resolve_Data))]
        void Resolve(AssemblyName input1, DirectoryInfo input2, IEnumerable<FileInfo> expected) {

            IEnumerable<IDefaultResolverData> files = null;

            Test.IfNot.Action.ThrowsException(() => files = new InternalDefaultResolver().Resolve(input1, input2, SearchOption.AllDirectories, VersionMatchingStrategies.Strict), out Exception ex);

            Test.If.Enumerable.Matches(files.Select(_ => _.File), expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> Resolve_Data() {
            yield return new Object[] { null, null, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), null, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), Statics.EntryPath.Directory, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), Statics.TestPath.Directory, new FileInfo[] { Statics.TestPath } };
        }

        [TestMethod]
        [TestData(nameof(ResolveByStrategies_1_1_0_Data))]
        [TestData(nameof(ResolveByStrategies_2_1_0_Data))]
        [TestData(nameof(ResolveByStrategies_2_1_1_Data))]
        [TestData(nameof(ResolveByStrategies_3_1_0_Data))]
        [TestData(nameof(ResolveByStrategies_3_1_1_Data))]
        void ResolveByStrategies(AssemblyName input1, DirectoryInfo input2, SearchOption input3, VersionMatchingStrategies input4, (IEnumerable<FileInfo> contained, IEnumerable<FileInfo> notcontained) expected) {

            IEnumerable<IDefaultResolverData> files = null;

            Test.IfNot.Action.ThrowsException(() => files = new InternalDefaultResolver().Resolve(input1, input2, input3, input4), out Exception ex);

            Test.If.Enumerable.ContainsRange(files.Select(_ => _.File), expected.contained, Statics.FileInfoComparer);
            Test.IfNot.Enumerable.ContainsRange(files.Select(_ => _.File), expected.notcontained, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> ResolveByStrategies_1_1_0_Data() {
            var assemblyPath = new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, "1.1.0", "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll"));
            AssemblyHelper.TryGetAssemblyName(assemblyPath, out AssemblyName assemblyName);
            List<FileInfo> relevantAssemblies = new List<FileInfo>();

            foreach(var version in Statics.ComplexFakePackageVersions) {
                relevantAssemblies.Add(new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, version, "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll")));
            }

            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.Strict, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.SemVer, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.Strict,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\2.") || _.FullName.Contains(@"\3.")))};
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.SemVer,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\2.") || _.FullName.Contains(@"\3.")))};
        }

        IEnumerable<Object[]> ResolveByStrategies_2_1_0_Data() {
            var assemblyPath = new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, "2.1.0", "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll"));
            AssemblyHelper.TryGetAssemblyName(assemblyPath, out AssemblyName assemblyName);
            List<FileInfo> relevantAssemblies = new List<FileInfo>();

            foreach(var version in Statics.ComplexFakePackageVersions) {
                relevantAssemblies.Add(new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, version, "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll")));
            }

            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.Strict, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.SemVer, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.Strict,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\2.1.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\2.2.")  || _.FullName.Contains(@"\2.3.") || _.FullName.Contains(@"\3.")))};
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.SemVer,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\2.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\3.")))};
        }

        IEnumerable<Object[]> ResolveByStrategies_2_1_1_Data() {
            var assemblyPath = new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, "2.1.1", "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll"));
            AssemblyHelper.TryGetAssemblyName(assemblyPath, out AssemblyName assemblyName);
            List<FileInfo> relevantAssemblies = new List<FileInfo>();

            foreach(var version in Statics.ComplexFakePackageVersions) {
                relevantAssemblies.Add(new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, version, "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll")));
            }

            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.Strict, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.SemVer, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.Strict,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\2.1.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\2.2.")  || _.FullName.Contains(@"\2.3.") || _.FullName.Contains(@"\3.")))};
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.SemVer,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\2.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\3.")))};
        }

        IEnumerable<Object[]> ResolveByStrategies_3_1_0_Data() {
            var assemblyPath = new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, "3.1.0", "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll"));
            AssemblyHelper.TryGetAssemblyName(assemblyPath, out AssemblyName assemblyName);
            List<FileInfo> relevantAssemblies = new List<FileInfo>();

            foreach(var version in Statics.ComplexFakePackageVersions) {
                relevantAssemblies.Add(new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, version, "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll")));
            }

            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.Strict, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.SemVer, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.Strict,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\3.1.0")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\2.") || _.FullName.Contains(@"\3.1.1") || _.FullName.Contains(@"\3.2.") || _.FullName.Contains(@"\3.3.")))};
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.SemVer,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\3.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\2.")))};
        }

        IEnumerable<Object[]> ResolveByStrategies_3_1_1_Data() {
            var assemblyPath = new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, "3.1.1", "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll"));
            AssemblyHelper.TryGetAssemblyName(assemblyPath, out AssemblyName assemblyName);
            List<FileInfo> relevantAssemblies = new List<FileInfo>();

            foreach(var version in Statics.ComplexFakePackageVersions) {
                relevantAssemblies.Add(new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName, version, "lib", "netstandard1.0", $"{Statics.ComplexFakePackageName}.dll")));
            }

            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.Strict, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.TopDirectoryOnly, VersionMatchingStrategies.SemVer, (Enumerable.Empty<FileInfo>(), relevantAssemblies.AsEnumerable()) };
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.Strict,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\3.1.1")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\2.") || _.FullName.Contains(@"\3.1.0") || _.FullName.Contains(@"\3.2.") || _.FullName.Contains(@"\3.3.")))};
            yield return new Object[] { assemblyName, Statics.FakeNugetCache, SearchOption.AllDirectories, VersionMatchingStrategies.SemVer,
                (relevantAssemblies.Where(_ => _.FullName.Contains(@"\3.1.1") || _.FullName.Contains(@"\3.2.") || _.FullName.Contains(@"\3.3.")),
                relevantAssemblies.Where(_ => _.FullName.Contains(@"\1.") || _.FullName.Contains(@"\2.") || _.FullName.Contains(@"\3.1.0")))};
        }

        #endregion

    }
}
