
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<DefaultResolver, AssemblyResolver<IDefaultResolverData>>();
            Test.If.Type.Implements<DefaultResolver, IDefaultResolver>();
            Test.If.Type.Implements<IDefaultResolver, IAssemblyResolver<IDefaultResolverData>>();

        }

    }
}
