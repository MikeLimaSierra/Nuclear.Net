using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.Runtimes;
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

        #region GetAssemblyCandidates

        [TestMethod]
        [TestData(nameof(GetAssemblyCandidates_Data))]
        void GetAssemblyCandidates(AssemblyName input1, IEnumerable<DirectoryInfo> input2, RuntimeInfo input3, IEnumerable<FileInfo> expected) {

            IEnumerable<INugetResolverData> files = default;

            Test.IfNot.Action.ThrowsException(() => files = NugetResolver.GetAssemblyCandidates(input1, input2, input3), out Exception ex);

            Test.IfNot.Object.IsNull(files);
            Test.If.Enumerable.MatchesExactly(files.Select(_ => _.File), expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> GetAssemblyCandidates_Data() {
            IEnumerable<DirectoryInfo> caches = new List<DirectoryInfo>() { Statics.FakeNugetCache };
            NugetResolver.TryGetPackage("Awesome.Nuget.Package", Statics.FakeNugetCache, out DirectoryInfo package);
            String packagePath = package.FullName;
            String arch = Environment.Is64BitProcess ? "x64" : "x86";

            return new List<Object[]>() {
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch,"net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch,"net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch,"net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch,"net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },

                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch,"net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch,"net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },

                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net48", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch,"net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp3.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.1", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                } },
            };
        }

        #endregion

        #region GetAssemblyCandidatesFromCache

        [TestMethod]
        [TestData(nameof(GetAssemblyCandidatesFromCache_SimpleData))]
        [TestData(nameof(GetAssemblyCandidatesFromCache_ComplexData))]
        void GetAssemblyCandidatesFromCache(AssemblyName input1, DirectoryInfo input2, RuntimeInfo input3, IEnumerable<FileInfo> expected) {

            IEnumerable<INugetResolverData> files = default;
            RuntimesHelper.TryGetLoadableRuntimes(input3, out IEnumerable<RuntimeInfo> validRuntimes);

            Test.IfNot.Action.ThrowsException(() => files = NugetResolver.GetAssemblyCandidatesFromCache(input1, input2, validRuntimes), out Exception ex);

            Test.IfNot.Object.IsNull(files);
            Test.If.Enumerable.MatchesExactly(files.Select(_ => _.File), expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> GetAssemblyCandidatesFromCache_SimpleData() {
            NugetResolver.TryGetPackage(Statics.SimpleFakePackageName, Statics.FakeNugetCache, out DirectoryInfo package);
            String packagePath = package.FullName;
            String arch = Environment.Is64BitProcess ? "x64" : "x86";

            #region netframework 1.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net48", $"{package.Name}.dll")),
                } };

            #endregion

            #region netcore 1.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(5, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                } };

            #endregion

        }

        IEnumerable<Object[]> GetAssemblyCandidatesFromCache_ComplexData() {
            NugetResolver.TryGetPackage(Statics.ComplexFakePackageName, Statics.FakeNugetCache, out DirectoryInfo package);
            String packagePath = package.FullName;
            String arch = Environment.Is64BitProcess ? "x64" : "x86";

            #region netframework 1.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch,"net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch,"net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch,"net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch,"net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };

            #endregion

            #region netcore 1.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(5, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.3.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.2.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "1.1.0-beta+meta", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };

            #endregion

            #region netframework 2.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch,"net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch,"net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };

            #endregion

            #region netcore 2.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(5, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };

            #endregion

            #region netframework 3.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                                        } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net48", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch,"net46", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };

            #endregion

            #region netcore 3.x.x

            yield return new Object[] { new AssemblyName($"{package.Name}, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };
            yield return new Object[] { new AssemblyName($"{package.Name}, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(5, 0)),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net5.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp3.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp3.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.1", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", $"{package.Name}.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", $"{package.Name}.dll")),
                } };

            #endregion

        }

        #endregion

        #region TryGetPackage

        [TestMethod]
        void TryGetPackageThrows() {

            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage("some.assembly", new DirectoryInfo(@"C:\Temp\invalid\path"), out DirectoryInfo dir), out ArgumentException ex);

            Test.If.Value.IsEqual(ex.ParamName, "cache");
            Test.If.String.StartsWith(ex.Message, @"'C:\Temp\invalid\path' doesn't exist!");

        }

        [TestMethod]
        [TestData(nameof(TryGetPackage_Data))]
        void TryGetPackage(String input1, DirectoryInfo input2, Boolean expected, String dir) {

            Boolean result = default;
            DirectoryInfo _dir = default;

            Test.IfNot.Action.ThrowsException(() => result = NugetResolver.TryGetPackage(input1, input2, out _dir), out Exception ex);

            Test.If.Value.IsEqual(result, expected);

            if(dir != null) {
                Test.If.Value.IsEqual(_dir.FullName, dir);

            } else {
                Test.If.Object.IsNull(_dir);
            }
        }

        IEnumerable<Object[]> TryGetPackage_Data() {
            DirectoryInfo cache = NugetResolver.GetCaches().First();

            return new List<Object[]>() {
                new Object[] { "microsoft.csharp", cache, true, Path.Combine(cache.FullName, "microsoft.csharp") },
                new Object[] { "netstandard.library", cache, true, Path.Combine(cache.FullName, "netstandard.library") },
                new Object[] { "non.existent.library", cache, false, null },
                new Object[] { Statics.SimpleFakePackageName, Statics.FakeNugetCache, true, Path.Combine(Statics.FakeNugetCache.FullName, Statics.SimpleFakePackageName) },
                new Object[] { Statics.ComplexFakePackageName, Statics.FakeNugetCache, true, Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName) },
            };
        }

        #endregion

    }
}
