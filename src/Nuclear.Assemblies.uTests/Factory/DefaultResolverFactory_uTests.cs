using System.IO;

using Nuclear.Assemblies.Factory;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IDefaultResolverFactory, ICreator<IDefaultResolver>>();
            Test.If.Type.Implements<IDefaultResolverFactory, ICreator<IDefaultResolverData, FileInfo>>();

            Test.If.Type.Implements<DefaultResolverFactory, IDefaultResolverFactory>();

        }

    }
}
