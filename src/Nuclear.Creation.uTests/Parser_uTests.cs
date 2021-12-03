using System;

using Nuclear.TestSite;

namespace Nuclear.Creation {
    class Parser_uTests {

        [TestMethod]
        void New() {

            IParser parser1 = default;
            IParser parser2 = default;

            Test.IfNot.Action.ThrowsException(() => parser1 = Parser.New, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => parser2 = Parser.New, out ex);

            Test.IfNot.Object.IsNull(parser1);
            Test.IfNot.Object.IsNull(parser2);
            Test.IfNot.Reference.IsEqual(parser1, parser2);

        }

        [TestMethod]
        void Instance() {

            IParser parser1 = default;
            IParser parser2 = default;

            Test.IfNot.Action.ThrowsException(() => parser1 = Parser.Instance, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => parser2 = Parser.Instance, out ex);

            Test.IfNot.Object.IsNull(parser1);
            Test.IfNot.Object.IsNull(parser2);
            Test.If.Reference.IsEqual(parser1, parser2);

        }

    }
}
