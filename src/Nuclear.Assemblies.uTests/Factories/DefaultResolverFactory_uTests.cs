using System.IO;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<DefaultResolverFactory, ICreator<IDefaultResolver, VersionMatchingStrategies, SearchOption>>();
            Test.If.Type.Implements<DefaultResolverFactory, ICreator<IDefaultResolverData, FileInfo>>();

        }

    }
}
