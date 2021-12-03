using Nuclear.Assemblies.ResolverData;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class IDefaultResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IDefaultResolver, IAssemblyResolver<IDefaultResolverData>>();

        }

    }
}
