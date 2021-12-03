
using Nuclear.Assemblies.ResolverData;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Internal {
    class NugetResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<NugetResolver, AssemblyResolver<INugetResolverData>>();
            Test.If.Type.Implements<NugetResolver, INugetResolver>();

        }

    }
}
