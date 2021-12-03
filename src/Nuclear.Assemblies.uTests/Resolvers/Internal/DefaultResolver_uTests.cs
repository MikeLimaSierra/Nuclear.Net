using Nuclear.Assemblies.ResolverData;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Internal {
    class DefaultResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<DefaultResolver, AssemblyResolver<IDefaultResolverData>>();
            Test.If.Type.Implements<DefaultResolver, IDefaultResolver>();

        }

    }
}
