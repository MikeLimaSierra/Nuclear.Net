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

            foreach(var version in Statics.ComplexFakePackageVersions) {
                foreach(var tfm in Statics.ComplexFakePackageTfms) {
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", tfm, $"{Statics.ComplexFakePackageName}.dll") };
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", "x86", tfm, $"{Statics.ComplexFakePackageName}.dll") };
                    yield return new Object[] { Path.Combine(packageRoot, version, "lib", "x64", tfm, $"{Statics.ComplexFakePackageName}.dll") };
                }
            }
        }

    }
}
