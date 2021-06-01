using System;
using System.IO;
using System.Linq;

using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class NugetResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<NugetResolver, AssemblyResolver<INugetResolverData>>();
            Test.If.Type.Implements<NugetResolver, INugetResolver>();
            Test.If.Type.Implements<INugetResolver, IAssemblyResolver<INugetResolverData>>();

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

    }
}
