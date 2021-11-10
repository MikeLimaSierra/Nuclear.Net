using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies {
    class TestArtefacts {

        [TestMethod]
        [TestData(nameof(ArtefactExists_SimplePackage_Data))]
        [TestData(nameof(ArtefactExists_ComplexPackage_Data))]
        void ArtefactExists(String path) {

            Test.If.File.Exists(path, $"Test artefact {path.Format()} is missing, rebuild fake NuGet cache and repeat.");

        }

        IEnumerable<Object[]> ArtefactExists_SimplePackage_Data() {
            var packageRoot = Path.Combine(Statics.FakeNugetCache.FullName, Statics.SimpleFakePackageName);

            foreach(var version in Statics.SimpleFakePackageVersions) {
                foreach(var tfm in Statics.SimpleFakePackageTfms) {
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", tfm, $"{Statics.SimpleFakePackageName}.dll") };
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", "x86", tfm, $"{Statics.SimpleFakePackageName}.dll") };
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", "x64", tfm, $"{Statics.SimpleFakePackageName}.dll") };
                }
            }
        }

        IEnumerable<Object[]> ArtefactExists_ComplexPackage_Data() {
            var packageRoot = Path.Combine(Statics.FakeNugetCache.FullName, Statics.ComplexFakePackageName);
            var versions = new List<String>() {
                "1.1.0",
                "1.1.0-beta",
                "1.1.0-beta+meta",
                "1.1.1",
                "1.2.0",
                "1.3.0",
                "2.1.0",
                "2.1.1",
                "2.2.0",
                "2.3.0",
                "3.1.0",
                "3.1.1",
                "3.2.0",
                "3.3.0"
            };
            var tfms = new List<String>() {
                "net45",
                "net46",
                "net48",
                "netcoreapp1.0",
                "netcoreapp2.0",
                "netcoreapp3.0",
                "netcoreapp3.1",
                "net5.0",
                "netstandard1.0",
                "netstandard2.0",
                "netstandard2.1"
            };

            foreach(var version in versions) {
                foreach(var tfm in tfms) {
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", tfm, $"{Statics.ComplexFakePackageName}.dll") };
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", "x86", tfm, $"{Statics.ComplexFakePackageName}.dll") };
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", "x64", tfm, $"{Statics.ComplexFakePackageName}.dll") };
                }
            }
        }

    }
}
