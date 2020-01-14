using System;
using Nuclear.TestSite;

namespace Nuclear.Exceptions {

    class ObjectExceptionSuite_uTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        #region Null

        [TestMethod]
        void ThrowIfNull() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsNull(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.Value.Equals(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsNull(new Object(), _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void ThrowIfNotNull() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull(null, _paramName, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull(new Object(), _paramName, _message), out ArgumentNullException ex2);
            Test.If.Value.Equals(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void ThrowIfNullGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsNull<NotImplementedException>(null, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsNull<NotImplementedException>(new Object(), _message), out Exception ex2);

        }

        [TestMethod]
        void ThrowIfNotNullGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull<NotImplementedException>(null, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull<NotImplementedException>(new Object(), _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        #endregion

        #region OfType

        [TestMethod]
        void ThrowIfOfType() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<String>("STRING", _paramName, _message), out ArgumentException ex1);
            Test.If.Value.Equals(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<String>(42, _paramName, _message), out Exception ex2);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<String>(null, _paramName, _message), out ArgumentNullException ex3);

        }

        [TestMethod]
        void ThrowIfNotOfType() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<String>("STRING", _paramName, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<String>(42, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.Equals(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<String>(null, _paramName, _message), out ArgumentNullException ex3);

        }

        [TestMethod]
        void ThrowIfOfTypeGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>("STRING", _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>(42, _message), out Exception ex2);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>(null, _message), out ArgumentNullException ex3);

        }

        [TestMethod]
        void ThrowIfNotOfTypeGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>("STRING", _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>(42, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>(null, _message), out ArgumentNullException ex3);

        }

        #endregion

    }
}
