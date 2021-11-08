using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factory;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.TestSite;

using static System.Environment;

namespace Nuclear.Assemblies.Resolvers {
    [TestClass("todo")]
    class NugetResolver_iTests {

        #region TryResolve

        [TestMethod]
        [TestData(nameof(TryResolveArgsData))]
        void TryResolveArgs(ResolveEventArgs input, Boolean result, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance);
            Boolean _result = false;
            IEnumerable<INugetResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveArgsData() {
            DirectoryInfo cache = NugetResolver.GetCaches().First();

            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs(null, null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs("", null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs("some name", null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs(typeof(DefaultResolver_iTests).Assembly.FullName, null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs("Microsoft.CSharp, Version=4.0.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", null), true, new FileInfo[] {
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll")),
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.3.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll"))
                } },
                new Object[] { new ResolveEventArgs("Microsoft.CSharp, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", null), true, new FileInfo[] {
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard2.0", "Microsoft.CSharp.dll"))
                } },
            };
        }

        [TestMethod]
        [TestData(nameof(TryResolveStringData))]
        void TryResolveString(String input, Boolean result, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance);
            Boolean _result = false;
            IEnumerable<INugetResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveStringData() {
            DirectoryInfo cache = NugetResolver.GetCaches().First();

            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<FileInfo>() },
                new Object[] { "", false, Enumerable.Empty<FileInfo>() },
                new Object[] { "some name", false, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(DefaultResolver_iTests).Assembly.FullName, false, Enumerable.Empty<FileInfo>() },
                new Object[] { "Microsoft.CSharp, Version=4.0.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true, new FileInfo[] {
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll")),
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.3.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll"))
                } },
                new Object[] { "Microsoft.CSharp, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", true, new FileInfo[] {
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard2.0", "Microsoft.CSharp.dll"))
                } },
            };
        }

        [TestMethod]
        [TestData(nameof(TryResolveNameData))]
        void TryResolveName(AssemblyName input, Boolean result, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance);
            Boolean _result = default;
            IEnumerable<INugetResolverData> _files = default;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveNameData() {
            DirectoryInfo cache = NugetResolver.GetCaches().First();

            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(DefaultResolver_iTests).Assembly.GetName(), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new AssemblyName("Microsoft.CSharp, Version=4.0.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), true, new FileInfo[] {
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll")),
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.3.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll"))
                } },
                new Object[] { new AssemblyName("Microsoft.CSharp, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), true, new FileInfo[] {
                    new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard2.0", "Microsoft.CSharp.dll"))
                } },
            };
        }

        #endregion

        #region GetCaches

        [TestMethod]
        void GetCaches() {

            IEnumerable<DirectoryInfo> caches = default;

            String userPath = Path.Combine(GetFolderPath(SpecialFolder.UserProfile), ".nuget", "packages");

            Test.IfNot.Action.ThrowsException(() => caches = NugetResolver.GetCaches(), out Exception ex);

            Test.If.Value.IsEqual(caches.Count(), 1);
            Test.If.Value.IsEqual(caches.First().FullName, userPath);

        }

        #endregion

        #region GetAssemblyCandidates

        [TestMethod]
        [TestData(nameof(GetAssemblyCandidatesData))]
        void GetAssemblyCandidates(AssemblyName input1, IEnumerable<DirectoryInfo> input2, RuntimeInfo input3, IEnumerable<FileInfo> expected) {

            IEnumerable<INugetResolverData> files = default;

            Test.IfNot.Action.ThrowsException(() => files = NugetResolver.GetAssemblyCandidates(input1, input2, input3), out Exception ex);

            Test.IfNot.Object.IsNull(files);
            Test.If.Enumerable.MatchesExactly(files.Select(_ => _.File), expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> GetAssemblyCandidatesData() {
            IEnumerable<DirectoryInfo> caches = new List<DirectoryInfo>() { Statics.FakeNugetCache };
            NugetResolver.TryGetPackage("Awesome.Nuget.Package", Statics.FakeNugetCache, out DirectoryInfo package);
            String packagePath = package.FullName;
            String arch = Is64BitProcess ? "x64" : "x86";

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
        [TestData(nameof(GetAssemblyCandidatesFromCacheData))]
        void GetAssemblyCandidatesFromCache(AssemblyName input1, DirectoryInfo input2, RuntimeInfo input3, IEnumerable<FileInfo> expected) {

            IEnumerable<INugetResolverData> files = default;
            RuntimesHelper.TryGetLoadableRuntimes(input3, out IEnumerable<RuntimeInfo> validRuntimes);

            Test.IfNot.Action.ThrowsException(() => files = NugetResolver.GetAssemblyCandidatesFromCache(input1, input2, validRuntimes), out Exception ex);

            Test.IfNot.Object.IsNull(files);
            Test.If.Enumerable.MatchesExactly(files.Select(_ => _.File), expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> GetAssemblyCandidatesFromCacheData() {
            NugetResolver.TryGetPackage("Awesome.Nuget.Package", Statics.FakeNugetCache, out DirectoryInfo package);
            String packagePath = package.FullName;
            String arch = Is64BitProcess ? "x64" : "x86";

            return new List<Object[]>() {
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
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
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
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
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
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
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
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
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
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
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
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
                    } },

                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), Enumerable.Empty<FileInfo>() },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
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
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
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
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
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
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
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
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
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
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
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

                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
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
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new List<FileInfo>() {
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                        new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    } },
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
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
                new Object[] { new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), Statics.FakeNugetCache,
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
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

        #region TryGetPackage

        [TestMethod]
        void TryGetPackageThrows() {

            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage("some.assembly", new DirectoryInfo(@"C:\Temp\invalid\path"), out DirectoryInfo dir), out ArgumentException aex);

        }

        [TestMethod]
        [TestData(nameof(TryGetPackageData))]
        void TryGetPackage(String input1, DirectoryInfo input2, Boolean result, String dir) {

            Boolean _result = default;
            DirectoryInfo _dir = default;

            Test.IfNot.Action.ThrowsException(() => _result = NugetResolver.TryGetPackage(input1, input2, out _dir), out Exception ex);

            Test.If.Value.IsEqual(_result, result);

            if(dir != null) {
                Test.If.Value.IsEqual(_dir.FullName, dir);

            } else {
                Test.If.Object.IsNull(_dir);
            }
        }

        IEnumerable<Object[]> TryGetPackageData() {
            DirectoryInfo cache = NugetResolver.GetCaches().First();

            return new List<Object[]>() {
                new Object[] { "microsoft.csharp", cache, true, Path.Combine(cache.FullName, "microsoft.csharp") },
                new Object[] { "netstandard.library", cache, true, Path.Combine(cache.FullName, "netstandard.library") },
                new Object[] { "non.existent.library", cache, false, null },
                new Object[] { "Awesome.Nuget.Package", Statics.FakeNugetCache, true, Path.Combine(Statics.FakeNugetCache.FullName, "Awesome.Nuget.Package") },
            };
        }

        #endregion

    }
}
