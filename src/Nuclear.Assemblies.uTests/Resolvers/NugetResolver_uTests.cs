using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class NugetResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<NugetResolver, AssemblyResolver>();
            Test.If.Type.Implements<NugetResolver, INugetResolver>();
            Test.If.Type.Implements<INugetResolver, IAssemblyResolver>();

            INugetResolver instance1 = null;
            INugetResolver instance2 = null;

            Test.IfNot.Action.ThrowsException(() => instance1 = NugetResolver.Instance, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => instance2 = NugetResolver.Instance, out ex);

            Test.If.Reference.IsEqual(instance1, instance2);

        }

        [TestMethod]
        void ConstructorThrows() {

            INugetResolver instance = NugetResolver.Instance;

            Test.If.Action.ThrowsException(() => instance = new NugetResolver(), out AccessViolationException ex);

            Test.If.Value.IsEqual(ex.Message, "Constructor must not be called twice.");

        }

        [TestMethod]
        void GetAssemblyCandidates() {

            Test.If.Action.ThrowsException(() => NugetResolver.GetAssemblyCandidates(null, null, null), out ArgumentNullException anex);
            Test.If.Action.ThrowsException(() => NugetResolver.GetAssemblyCandidates(typeof(NugetResolver).Assembly.GetName(), null, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), out anex);
            Test.If.Action.ThrowsException(() => NugetResolver.GetAssemblyCandidates(typeof(NugetResolver).Assembly.GetName(), Enumerable.Empty<DirectoryInfo>(), null), out anex);

        }

        [TestMethod]
        void TryGetPackage() {

            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage(null, null, out DirectoryInfo dir), out ArgumentNullException anex);
            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage("", null, out DirectoryInfo dir), out ArgumentException aex);
            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage(" ", null, out DirectoryInfo dir), out aex);
            Test.If.Action.ThrowsException(() => NugetResolver.TryGetPackage("some.assembly", null, out DirectoryInfo dir), out anex);

        }

        [TestMethod]
        void GetPackageVersions() {

            IDictionary<(Version version, String label, RuntimeInfo runtime, ProcessorArchitecture arch), DirectoryInfo> versions = default;

            Test.IfNot.Action.ThrowsException(() => versions = NugetResolver.GetPackageVersions(null), out Exception ex);

            Test.If.Enumerable.IsEmpty(versions);

        }

        [TestMethod]
        void GetRuntimeVersions() {

            IDictionary<RuntimeInfo, DirectoryInfo> versions = default;

            Test.IfNot.Action.ThrowsException(() => versions = NugetResolver.GetPackageVersionRuntimes(null), out Exception ex);

            Test.If.Enumerable.IsEmpty(versions);

        }

    }
}
