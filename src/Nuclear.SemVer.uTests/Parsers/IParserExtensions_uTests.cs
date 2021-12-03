using System;

using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.SemVer.Parsers {
    class IParserExtensions_uTests {

        #region SemVer

        [TestMethod]
        public void SemVer() {

            ICreator<SemanticVersion, String> fac1 = default;
            ICreator<SemanticVersion, String> fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Parser.Instance.SemVer(), out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Parser.Instance.SemVer(), out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

        #endregion

        #region Create

        [TestMethod]
        void Create_Throws() {

            var creator = Parser.Instance.SemVer();

            Test.If.Action.ThrowsException(() => creator.Create(out _, "01.2.3"), out FormatException ex);

            Test.If.Value.IsEqual(ex.Message, "Parameter 'input' has an incorrect format: '01.2.3'");

        }

        [TestMethod]
        void Create() {

            var creator = Parser.Instance.SemVer();
            SemanticVersion obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, "1.2.3"), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.Major, 1u);
            Test.If.Value.IsEqual(obj.Minor, 2u);
            Test.If.Value.IsEqual(obj.Patch, 3u);

        }

        #endregion

        #region TryCreate

        [TestMethod]
        void TryCreate_DoesNotThrow() {

            var creator = Parser.Instance.SemVer();
            Boolean result = default;
            SemanticVersion obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, "01.2.3"), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreate() {

            var creator = Parser.Instance.SemVer();
            Boolean result = default;
            SemanticVersion obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, "1.2.3"), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.Major, 1u);
            Test.If.Value.IsEqual(obj.Minor, 2u);
            Test.If.Value.IsEqual(obj.Patch, 3u);

        }

        #endregion

        #region TryCreateWithExOut

        [TestMethod]
        void TryCreateWithExOut_DoesNotThrow() {

            var creator = Parser.Instance.SemVer();
            Boolean result = default;
            SemanticVersion obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, "01.2.3", out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsNull(obj);
            Test.If.Object.IsOfExactType<FormatException>(ex);
            Test.If.Value.IsEqual(((FormatException) ex).Message, "Parameter 'input' has an incorrect format: '01.2.3'");

        }

        [TestMethod]
        void TryCreateWithExOut() {

            var creator = Parser.Instance.SemVer();
            Boolean result = default;
            SemanticVersion obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, "1.2.3", out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.Major, 1u);
            Test.If.Value.IsEqual(obj.Minor, 2u);
            Test.If.Value.IsEqual(obj.Patch, 3u);

        }

        #endregion

    }
}
