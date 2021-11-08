using System;

using Nuclear.TestSite;

namespace Nuclear.Exceptions {

    class ValueExceptionSuite_uTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        #region True

        [TestMethod]
        void ThrowIfTrue() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue(true, _paramName, _message), out ArgumentException ex1);
            Test.If.Value.IsEqual(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue(false, _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void ThrowIfNotTrue() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue(true, _paramName, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue(false, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.IsEqual(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void ThrowIfTrue_Generic() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue<NotImplementedException>(true, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue<NotImplementedException>(false, _message), out Exception ex2);

        }

        [TestMethod]
        void ThrowIfNotTrue_Generic() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue<NotImplementedException>(true, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue<NotImplementedException>(false, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        #endregion

        #region False

        [TestMethod]
        void ThrowIfFalse() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse(false, _paramName, _message), out ArgumentException ex1);
            Test.If.Value.IsEqual(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse(true, _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void ThrowIfNotFalse() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse(false, _paramName, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse(true, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.IsEqual(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void ThrowIfFalse_Generic() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse<NotImplementedException>(false, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse<NotImplementedException>(true, _message), out Exception ex2);

        }

        [TestMethod]
        void ThrowIfNotFalse_Generic() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse<NotImplementedException>(false, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse<NotImplementedException>(true, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        #endregion

    }
}
