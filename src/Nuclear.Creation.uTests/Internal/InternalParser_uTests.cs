using Nuclear.TestSite;

namespace Nuclear.Creation.Internal {
    class InternalParser_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<InternalParser, IParser>();

        }

    }
}
