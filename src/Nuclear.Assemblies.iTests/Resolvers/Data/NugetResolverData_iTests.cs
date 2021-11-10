using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Creation;
using Nuclear.Extensions;
using Nuclear.SemVer;
using Nuclear.SemVer.Parsers;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Data {
    class NugetResolverData_iTests {

        #region ctors

        [TestMethod]
        void Ctor_Throws() {

            INugetResolverData data = default;
            FileInfo file = new FileInfo(@"C:\NonExistentFile.txt");

            Test.If.Action.ThrowsException(() => data = new NugetResolverData(file), out ArgumentException ex);

            Test.If.String.StartsWith(ex.Message, $"Could not resolve the AssemblyName of file {file.Format()}.");

        }

        [TestMethod]
        [TestData(nameof(Ctor_SimpleFakePackage_Data))]
        [TestData(nameof(Ctor_ComplexFakePackage_Data))]
        void Ctor(FileInfo input, (Boolean isValid, String pN, SemanticVersion pV, ProcessorArchitecture pA, RuntimeInfo pF) expected) {

            INugetResolverData data = default;

            Test.IfNot.Action.ThrowsException(() => data = new NugetResolverData(input), out Exception ex);

            Test.IfNot.Object.IsNull(data.Name);
            Test.If.Value.IsEqual(data.IsValid, expected.isValid);
            Test.If.Value.IsEqual(data.PackageName, expected.pN);
            Test.If.Value.IsEqual(data.PackageVersion, expected.pV);
            Test.If.Value.IsEqual(data.PackageArchitecture, expected.pA);
            Test.If.Value.IsEqual(data.PackageTargetFramework, expected.pF);

        }

        IEnumerable<Object[]> Ctor_SimpleFakePackage_Data() {
            var packageName = Statics.SimpleFakePackageName;
            var packageRoot = Path.Combine(Statics.FakeNugetCache.FullName, packageName);

            foreach(var version in Statics.SimpleFakePackageVersions) {
                Parser.Instance.SemVer().Create(out SemanticVersion semVer, version);

                foreach(var tfm in Statics.SimpleFakePackageTfms) {
                    RuntimesHelper.TryParseTFM(tfm, out RuntimeInfo ri);

                    yield return new Object[] { new FileInfo(Path.Combine(packageRoot, version, "lib", tfm, $"{packageName}.dll")), (true, packageName, semVer, ProcessorArchitecture.MSIL, ri) };
                    yield return new Object[] { new FileInfo(Path.Combine(packageRoot, version, "lib", "x86", tfm, $"{packageName}.dll")), (true, packageName, semVer, ProcessorArchitecture.X86, ri) };
                    yield return new Object[] { new FileInfo(Path.Combine(packageRoot, version, "lib", "x64", tfm, $"{packageName}.dll")), (true, packageName, semVer, ProcessorArchitecture.Amd64, ri) };
                }
            }
        }

        IEnumerable<Object[]> Ctor_ComplexFakePackage_Data() {
            var packageName = Statics.ComplexFakePackageName;
            var packageRoot = Path.Combine(Statics.FakeNugetCache.FullName, packageName);

            foreach(var version in Statics.ComplexFakePackageVersions) {
                Parser.Instance.SemVer().Create(out SemanticVersion semVer, version);

                foreach(var tfm in Statics.ComplexFakePackageTfms) {
                    RuntimesHelper.TryParseTFM(tfm, out RuntimeInfo ri);

                    yield return new Object[] { new FileInfo(Path.Combine(packageRoot, version, "lib", tfm, $"{packageName}.dll")), (true, packageName, semVer, ProcessorArchitecture.MSIL, ri) };
                    yield return new Object[] { new FileInfo(Path.Combine(packageRoot, version, "lib", "x86", tfm, $"{packageName}.dll")), (true, packageName, semVer, ProcessorArchitecture.X86, ri) };
                    yield return new Object[] { new FileInfo(Path.Combine(packageRoot, version, "lib", "x64", tfm, $"{packageName}.dll")), (true, packageName, semVer, ProcessorArchitecture.Amd64, ri) };
                }
            }
        }

        #endregion

    }

}
