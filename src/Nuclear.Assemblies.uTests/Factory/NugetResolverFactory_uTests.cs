using System.IO;

using Nuclear.Assemblies.Factory;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class NugetResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<INugetResolverFactory, ICreator<INugetResolver>>();
            Test.If.Type.Implements<INugetResolverFactory, ICreator<INugetResolverData, FileInfo>>();

            Test.If.Type.Implements<NugetResolverFactory, INugetResolverFactory>();

        }

    }
}
