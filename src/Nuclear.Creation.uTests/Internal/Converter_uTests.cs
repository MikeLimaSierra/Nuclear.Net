using Nuclear.TestSite;

namespace Nuclear.Creation.Internal {
    class Converter_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<Converter, IConverter>();

        }

    }
}
