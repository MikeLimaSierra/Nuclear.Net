using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Data {
    class NugetResolverData_uTests {

        #region ctors

        [TestMethod]
        [TestData(nameof(Ctor_Throws_Data))]
        void Ctor_Throws<TException>(FileInfo input, String message) where TException : Exception {

            INugetResolverData data = default;

            Test.If.Action.ThrowsException(() => data = new NugetResolverData(input), out TException ex);

            Test.IfNot.Object.IsNull(ex);
            Test.If.String.StartsWith(ex.Message, message);

        }

        IEnumerable<Object[]> Ctor_Throws_Data() {
            FileInfo file = new FileInfo(@"C:\NonExistentFile.txt");

            return new List<Object[]>() {
                new Object[] { typeof(ArgumentNullException), null, "Parameter 'file' must not be null." },
                new Object[] { typeof(ArgumentException), file, $"Could not resolve the AssemblyName of file {file.Format()}." }
            };
        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(FileInfo input, (Boolean isValid, String pN, Version pV, String pL, ProcessorArchitecture pA, RuntimeInfo pF) expected) {

            INugetResolverData data = default;

            Test.IfNot.Action.ThrowsException(() => data = new NugetResolverData(input), out Exception ex);

            Test.IfNot.Object.IsNull(data.Name);
            Test.If.Value.IsEqual(data.IsValid, expected.isValid);
            Test.If.Value.IsEqual(data.PackageName, expected.pN);
            Test.If.Value.IsEqual(data.PackageVersion, expected.pV);
            Test.If.Value.IsEqual(data.PackageVersionLabel, expected.pL);
            Test.If.Value.IsEqual(data.PackageArchitecture, expected.pA);
            Test.If.Value.IsEqual(data.PackageTargetFramework, expected.pF);

        }

        IEnumerable<Object[]> Ctor_Data() {
            DirectoryInfo fakeCache = Statics.FakeNugetCache;
            String pack = "Awesome.Nuget.Package";
            String aPack = Path.Combine(fakeCache.FullName, "Awesome.Nuget.Package");
            String sPack = Path.Combine(fakeCache.FullName, "Simple.Nuget.Package");

            Version[] vers = new Version[] {
                new Version("1.1.0"), new Version("1.1.1"), new Version("1.2.0"), new Version("1.3.0"),
                new Version("2.1.0"), new Version("2.1.1"), new Version("2.2.0"), new Version("2.3.0"),
                new Version("3.1.0"), new Version("3.1.1"), new Version("3.2.0"), new Version("3.3.0")
            };
            ProcessorArchitecture[] archs = new ProcessorArchitecture[] { ProcessorArchitecture.MSIL, ProcessorArchitecture.X86, ProcessorArchitecture.Amd64 };
            String[] tfms = new String[] { "net45", "net46", "net48", "netcoreapp1.0", "netcoreapp2.0", "netcoreapp3.0", "netcoreapp3.1", "net5.0", "netstandard1.0", "netstandard2.0", "netstandard2.1" };

            foreach(Version ver in vers) {
                foreach(ProcessorArchitecture arch in archs) {
                    foreach(String tfm in tfms) {
                        String archPath = arch switch {
                            ProcessorArchitecture.MSIL => "lib",
                            ProcessorArchitecture.X86 => Path.Combine("lib", "x86"),
                            ProcessorArchitecture.Amd64 => Path.Combine("lib", "x64"),
                            _ => default,
                        };
                        RuntimesHelper.TryParseTFM(tfm, out RuntimeInfo ri);

                        yield return new Object[] {
                            new FileInfo(Path.Combine(aPack, ver.ToString(), archPath, tfm, $"{pack}.dll")), (true, pack, ver, (String) null, arch, ri)
                        };

                        if(ver == new Version(1, 1, 0)) {
                            yield return new Object[] {
                                new FileInfo(Path.Combine(aPack, "1.1.0-beta", archPath, tfm, $"{pack}.dll")), (true, pack, ver, "beta", arch, ri)
                            };
                        }
                    }
                }
            }

            // net45; net46; net48; netcoreapp1.0; netcoreapp2.0; netcoreapp3.0; netcoreapp3.1; net5.0; netstandard1.0; netstandard2.0; netstandard2.1
            // AnyCPU; x86; x64
            // 1.1.0; 1.1.0-beta; 1.1.1; 1.2.0; 1.3.0; 2.1.0; 2.1.1; 2.2.0; 2.3.0; 3.1.0; 3.1.1; 3.2.0; 3.3.0

        }

        #endregion

    }

}
