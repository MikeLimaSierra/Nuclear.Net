using System;

using Nuclear.TestSite;

namespace Nuclear.Exceptions.Extensions {

    class StringExceptionSuite_uTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        #region IsHello

        [TestMethod]
        void ThrowIfIsHello() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello(null, _paramName, _message), out ArgumentException ex);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello(String.Empty, _paramName, _message), out ex);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello(" ", _paramName, _message), out ex);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello("STRING", _paramName, _message), out ex);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsHello("Hello", _paramName, _message), out ex);
            Test.If.Value.IsEqual(_paramName, ex.ParamName);
            Test.If.String.StartsWith(ex.Message, _message);

        }

        [TestMethod]
        void ThrowIfNotIsHello() {

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello(null, _paramName, _message), out ArgumentException ex);
            Test.If.Value.IsEqual(_paramName, ex.ParamName);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello(String.Empty, _paramName, _message), out ex);
            Test.If.Value.IsEqual(_paramName, ex.ParamName);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello(" ", _paramName, _message), out ex);
            Test.If.Value.IsEqual(_paramName, ex.ParamName);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello("STRING", _paramName, _message), out ex);
            Test.If.Value.IsEqual(_paramName, ex.ParamName);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello("Hello", _paramName, _message), out ex);

        }

        #endregion

        #region IsHelloGeneric

        [TestMethod]
        void ThrowIfIsHelloGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello<NotImplementedException>(null, _message), out NotImplementedException ex);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello<NotImplementedException>(String.Empty, _message), out ex);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello<NotImplementedException>(" ", _message), out ex);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsHello<NotImplementedException>("STRING", _message), out ex);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsHello<NotImplementedException>("Hello", _message), out ex);
            Test.If.String.StartsWith(ex.Message, _message);

        }

        [TestMethod]
        void ThrowIfNotIsHelloGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello<NotImplementedException>(null, _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello<NotImplementedException>(String.Empty, _message), out ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello<NotImplementedException>(" ", _message), out ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello<NotImplementedException>("STRING", _message), out ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsHello<NotImplementedException>("Hello", _message), out ex);

        }

        #endregion

    }
}
