using System;

using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.SemVer.Parser {
    class IParserExtensions_uTests {

        #region SemVer

        [TestMethod]
        public void MyTestMethod() {

            ICreator<SemanticVersion, String> fac1 = default;
            ICreator<SemanticVersion, String> fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Creation.Parser.Instance.SemVer(), out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Creation.Parser.Instance.SemVer(), out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

        #endregion

    }
}
