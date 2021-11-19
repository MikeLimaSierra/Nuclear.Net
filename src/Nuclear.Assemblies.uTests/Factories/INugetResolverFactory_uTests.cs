using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class INugetResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<INugetResolverFactory, ICreator<INugetResolver, MatchingStrategies>>();
            Test.If.Type.Implements<INugetResolverFactory, ICreator<INugetResolver, MatchingStrategies, IEnumerable<DirectoryInfo>>>();
            Test.If.Type.Implements<INugetResolverFactory, ICreator<INugetResolverData, FileInfo>>();

        }

    }
}
