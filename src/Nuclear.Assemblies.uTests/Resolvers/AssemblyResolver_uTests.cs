using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class AssemblyResolver_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<AssemblyResolver, IAssemblyResolver>();

        }

    }
}
