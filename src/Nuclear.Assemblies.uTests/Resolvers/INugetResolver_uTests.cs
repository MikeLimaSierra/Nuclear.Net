using Nuclear.Assemblies.ResolverData;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class INugetResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<INugetResolver, IAssemblyResolver<INugetResolverData>>();

        }

    }
}
