using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.TestSite;

using static System.Environment;

namespace Nuclear.Assemblies.Resolvers {
    class NugetResolver_iTests {

        #region TryResolve

        [TestMethod]
        void TryResolve() {

            DirectoryInfo cache = NugetResolver.GetCaches().First();

            Test.Note("Requires Microsoft.CSharp v4.7.0 and v4.3.0 to be installed via NuGet.");

            DDTTryResolve((ResolveEventArgs) null, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs(null, null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs("", null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs("some name", null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs(typeof(DefaultResolver_iTests).Assembly.FullName, null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs("Microsoft.CSharp, Version=4.0.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", null), (true, new FileInfo[] {
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll")),
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.3.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll"))
            }));
            DDTTryResolve(new ResolveEventArgs("Microsoft.CSharp, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", null), (true, new FileInfo[] {
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard2.0", "Microsoft.CSharp.dll"))
            }));

            DDTTryResolve((String) null, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve("", (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve("some name", (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(typeof(DefaultResolver_iTests).Assembly.FullName, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve("Microsoft.CSharp, Version=4.0.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", (true, new FileInfo[] {
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll")),
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.3.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll"))
            }));
            DDTTryResolve("Microsoft.CSharp, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", (true, new FileInfo[] {
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard2.0", "Microsoft.CSharp.dll"))
            }));

            DDTTryResolve((AssemblyName) null, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(typeof(DefaultResolver_iTests).Assembly.GetName(), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new AssemblyName("Microsoft.CSharp, Version=4.0.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), (true, new FileInfo[] {
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll")),
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.3.0", "lib", "netstandard1.3", "Microsoft.CSharp.dll"))
            }));
            DDTTryResolve(new AssemblyName("Microsoft.CSharp, Version=4.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), (true, new FileInfo[] {
                new FileInfo(Path.Combine(cache.FullName, "microsoft.csharp", "4.7.0", "lib", "netstandard2.0", "Microsoft.CSharp.dll"))
            }));

        }

        void DDTTryResolve(ResolveEventArgs input, (Boolean result, IEnumerable<FileInfo> files) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            INugetResolver instance = NugetResolver.Instance;
            Boolean result = false;
            IEnumerable<FileInfo> files = null;

            Test.Note($"NugetResolver.TryResolve({input.Format()}, out {expected.files.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out files), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.MatchesExactly(files, expected.files, Statics.FileInfoComparer, _file, _method);

        }

        void DDTTryResolve(String input, (Boolean result, IEnumerable<FileInfo> files) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            INugetResolver instance = NugetResolver.Instance;
            Boolean result = false;
            IEnumerable<FileInfo> files = null;

            Test.Note($"NugetResolver.TryResolve({input.Format()}, out {expected.files.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out files), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.MatchesExactly(files, expected.files, Statics.FileInfoComparer, _file, _method);

        }

        void DDTTryResolve(AssemblyName input, (Boolean result, IEnumerable<FileInfo> files) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            INugetResolver instance = NugetResolver.Instance;
            Boolean result = default;
            IEnumerable<FileInfo> files = default;

            Test.Note($"NugetResolver.TryResolve({input.Format()}, out {expected.files.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out files), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.MatchesExactly(files, expected.files, Statics.FileInfoComparer, _file, _method);

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
        void GetAssemblyCandidates() {

            DirectoryInfo fakeCache = Statics.GetFakeNugetCache();
            IEnumerable<DirectoryInfo> caches = new List<DirectoryInfo>() { fakeCache };
            NugetResolver.TryGetPackage("Awesome.Nuget.Package", fakeCache, out DirectoryInfo package);
            String packagePath = package.FullName;
            String arch = Is64BitProcess ? "x64" : "x86";

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                Enumerable.Empty<FileInfo>());
            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                Enumerable.Empty<FileInfo>());

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=2.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                Enumerable.Empty<FileInfo>());

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))),
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
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidates((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), caches, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))),
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
                });

        }

        void DDTGetAssemblyCandidates((AssemblyName assemblyName, IEnumerable<DirectoryInfo> nugetCaches, RuntimeInfo current) input, IEnumerable<FileInfo> expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IEnumerable<FileInfo> files = default;

            Test.Note($"NugetResolver.GetAssemblyCandidates({input.assemblyName.Format()}, {input.nugetCaches.Format()}, {input.current.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => files = NugetResolver.GetAssemblyCandidates(input.assemblyName, input.nugetCaches, input.current), out Exception ex, _file, _method);

            Test.IfNot.Object.IsNull(files, _file, _method);
            Test.If.Enumerable.MatchesExactly(files, expected, Statics.FileInfoComparer, _file, _method);

        }

        #endregion

        #region GetAssemblyCandidatesFromCache

        [TestMethod]
        void GetAssemblyCandidatesFromCache() {

            DirectoryInfo fakeCache = Statics.GetFakeNugetCache();
            NugetResolver.TryGetPackage("Awesome.Nuget.Package", fakeCache, out DirectoryInfo package);
            String packagePath = package.FullName;
            String arch = Is64BitProcess ? "x64" : "x86";

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                Enumerable.Empty<FileInfo>());
            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                Enumerable.Empty<FileInfo>());

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=2.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                Enumerable.Empty<FileInfo>());

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "2.1.0", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net46", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net46", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "net45", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))),
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
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))),
                new List<FileInfo>() {
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard2.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netcoreapp1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", "netstandard1.0", "Awesome.Nuget.Package.dll")),
                    new FileInfo(Path.Combine(packagePath, "3.1.1", "lib", arch, "netstandard1.0", "Awesome.Nuget.Package.dll")),
                });

            DDTGetAssemblyCandidatesFromCache((new AssemblyName("Awesome.Nuget.Package, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null"), fakeCache, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))),
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
                });

        }

        void DDTGetAssemblyCandidatesFromCache((AssemblyName assemblyName, DirectoryInfo nugetCache, RuntimeInfo current) input, IEnumerable<FileInfo> expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IEnumerable<FileInfo> files = default;
            RuntimesHelper.TryGetLoadableRuntimes(input.current, out IEnumerable<RuntimeInfo> validRuntimes);

            Test.Note($"NugetResolver.GetAssemblyCandidatesFromCache({input.assemblyName.Format()}, {input.nugetCache.Format()}, {validRuntimes.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => files = NugetResolver.GetAssemblyCandidatesFromCache(input.assemblyName, input.nugetCache, validRuntimes), out Exception ex, _file, _method);

            Test.IfNot.Object.IsNull(files, _file, _method);
            Test.If.Enumerable.MatchesExactly(files, expected, Statics.FileInfoComparer, _file, _method);

        }

        #endregion

        #region TryGetPackage

        [TestMethod]
        void TryGetPackage() {

            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage("some.assembly", new DirectoryInfo(@"C:\Temp\invalid\path"), out DirectoryInfo dir), out ArgumentException aex);

            DirectoryInfo cache = NugetResolver.GetCaches().First();
            DirectoryInfo fakeCache = Statics.GetFakeNugetCache();

            DDTTryGetPackage(("microsoft.csharp", cache), (true, Path.Combine(cache.FullName, "microsoft.csharp")));
            DDTTryGetPackage(("netstandard.library", cache), (true, Path.Combine(cache.FullName, "netstandard.library")));
            DDTTryGetPackage(("non.existent.library", cache), (false, null));
            DDTTryGetPackage(("Awesome.Nuget.Package", fakeCache), (true, Path.Combine(fakeCache.FullName, "Awesome.Nuget.Package")));

        }

        void DDTTryGetPackage((String name, DirectoryInfo cache) input, (Boolean result, String dir) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;
            DirectoryInfo dir = default;

            Test.Note($"NugetResolver.TryGetPackage({input.name.Format()}, {input.cache.FullName.Format()}, out {expected.dir.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = NugetResolver.TryGetPackage(input.name, input.cache, out dir), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);

            if(expected.dir != null) {
                Test.If.Value.IsEqual(dir.FullName, expected.dir, _file, _method);
            } else {
                Test.If.Object.IsNull(dir);
            }
        }

        #endregion

        #region GetPackageVersions

        [TestMethod]
        void GetPackageVersions() {

            DirectoryInfo fakeCache = Statics.GetFakeNugetCache();
            NugetResolver.TryGetPackage("Simple.Nuget.Package", fakeCache, out DirectoryInfo package);

            DDTGetPackageVersions(new DirectoryInfo(@"C:\non\existent\path"), new Dictionary<(Version, RuntimeInfo, ProcessorArchitecture), DirectoryInfo>());
            DDTGetPackageVersions(package, new Dictionary<(Version, RuntimeInfo, ProcessorArchitecture), DirectoryInfo>() {

                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), ProcessorArchitecture.MSIL), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "net48")) },
                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), ProcessorArchitecture.MSIL), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "netcoreapp3.0")) },
                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), ProcessorArchitecture.MSIL), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "netstandard2.1")) },

                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), ProcessorArchitecture.X86), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x86", "net48")) },
                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), ProcessorArchitecture.X86), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x86", "netcoreapp3.0")) },
                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), ProcessorArchitecture.X86), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x86", "netstandard2.1")) },

                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), ProcessorArchitecture.Amd64), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x64", "net48")) },
                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), ProcessorArchitecture.Amd64), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x64", "netcoreapp3.0")) },
                { (new Version(1, 1, 0), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), ProcessorArchitecture.Amd64), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x64", "netstandard2.1")) },

            });

        }

        void DDTGetPackageVersions(DirectoryInfo input, Dictionary<(Version version, RuntimeInfo runtime, ProcessorArchitecture arch), DirectoryInfo> expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IDictionary<(Version version, RuntimeInfo runtime, ProcessorArchitecture arch), DirectoryInfo> versions = default;

            Test.Note($"NugetResolver.GetPackageVersions({input.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => versions = NugetResolver.GetPackageVersions(input), out Exception ex, _file, _method);

            Test.IfNot.Object.IsNull(versions, _file, _method);
            Test.If.Enumerable.Matches(versions.Keys, expected.Keys, _file, _method);
            Test.If.Enumerable.Matches(versions.Values.Select(v => v.FullName), expected.Values.Select(v => v.FullName), _file, _method);

        }

        #endregion

        #region GetPackageVersionRuntimes

        [TestMethod]
        void GetPackageVersionRuntimes() {

            DirectoryInfo fakeCache = Statics.GetFakeNugetCache();
            NugetResolver.TryGetPackage("Simple.Nuget.Package", fakeCache, out DirectoryInfo package);

            DDTGetPackageVersionRuntimes(new DirectoryInfo(@"C:\non\existent\path"), new Dictionary<RuntimeInfo, DirectoryInfo>());

            DDTGetPackageVersionRuntimes(new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib")), new Dictionary<RuntimeInfo, DirectoryInfo>() {
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "net48")) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "netcoreapp3.0")) },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "netstandard2.1")) },
            });

            DDTGetPackageVersionRuntimes(new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x86")), new Dictionary<RuntimeInfo, DirectoryInfo>() {
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x86", "net48")) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x86", "netcoreapp3.0")) },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x86", "netstandard2.1")) },
            });

            DDTGetPackageVersionRuntimes(new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x64")), new Dictionary<RuntimeInfo, DirectoryInfo>() {
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x64", "net48")) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x64", "netcoreapp3.0")) },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), new DirectoryInfo(Path.Combine(package.FullName, "1.1.0", "lib", "x64", "netstandard2.1")) },
            });

        }

        void DDTGetPackageVersionRuntimes(DirectoryInfo input, Dictionary<RuntimeInfo, DirectoryInfo> expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IDictionary<RuntimeInfo, DirectoryInfo> versions = default;

            Test.Note($"NugetResolver.GetPackageVersionRuntimes({input.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => versions = NugetResolver.GetPackageVersionRuntimes(input), out Exception ex, _file, _method);

            Test.IfNot.Object.IsNull(versions, _file, _method);
            Test.If.Enumerable.Matches(versions.Keys, expected.Keys, _file, _method);
            Test.If.Enumerable.Matches(versions.Values.Select(v => v.FullName), expected.Values.Select(v => v.FullName), _file, _method);

        }

        #endregion

    }
}
