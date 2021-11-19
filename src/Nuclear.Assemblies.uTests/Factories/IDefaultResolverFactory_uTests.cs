using System.IO;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class IDefaultResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IDefaultResolverFactory, ICreator<IDefaultResolver, MatchingStrategies, SearchOption>>();
            Test.If.Type.Implements<IDefaultResolverFactory, ICreator<IDefaultResolverData, FileInfo>>();

        }

    }
}
