using Nuclear.TestSite;

namespace Nuclear.Creation {
    class InternalFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<InternalFactory, IFactory>();

        }

    }
}
