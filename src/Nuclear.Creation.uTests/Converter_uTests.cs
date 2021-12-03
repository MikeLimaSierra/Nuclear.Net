using System;

using Nuclear.TestSite;

namespace Nuclear.Creation {
    class Converter_uTests {

        [TestMethod]
        void New() {

            IConverter converter1 = default;
            IConverter converter2 = default;

            Test.IfNot.Action.ThrowsException(() => converter1 = Converter.New, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => converter2 = Converter.New, out ex);

            Test.IfNot.Object.IsNull(converter1);
            Test.IfNot.Object.IsNull(converter2);
            Test.IfNot.Reference.IsEqual(converter1, converter2);

        }

        [TestMethod]
        void Instance() {

            IConverter converter1 = default;
            IConverter converter2 = default;

            Test.IfNot.Action.ThrowsException(() => converter1 = Converter.Instance, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => converter2 = Converter.Instance, out ex);

            Test.IfNot.Object.IsNull(converter1);
            Test.IfNot.Object.IsNull(converter2);
            Test.If.Reference.IsEqual(converter1, converter2);

        }

    }
}
