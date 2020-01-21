using System;
using Nuclear.TestSite;

namespace Nuclear.Exceptions {

    class StringExceptionSuite_uTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        #region NullOrEmpty

        [TestMethod]
        void ThrowIfNullOrEmpty() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty(String.Empty, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.IsEqual(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty(" ", _paramName, _message), out Exception ex3);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty("STRING", _paramName, _message), out Exception ex4);

        }

        [TestMethod]
        void ThrowIfNotNullOrEmpty() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty(null, _paramName, _message), out Exception ex1);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty(String.Empty, _paramName, _message), out Exception ex2);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty(" ", _paramName, _message), out ArgumentException ex3);
            Test.If.Value.IsEqual(_paramName, ex3.ParamName);
            Test.If.String.StartsWith(ex3.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty("STRING", _paramName, _message), out ArgumentException ex4);
            Test.If.Value.IsEqual(_paramName, ex4.ParamName);
            Test.If.String.StartsWith(ex4.Message, _message);

        }

        [TestMethod]
        void ThrowIfNullOrEmptyGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty<NotImplementedException>(null, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty<NotImplementedException>(String.Empty, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty<NotImplementedException>(" ", _message), out Exception ex3);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty<NotImplementedException>("STRING", _message), out Exception ex4);

        }

        [TestMethod]
        void ThrowIfNotNullOrEmptyGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty<NotImplementedException>(null, _message), out Exception ex1);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty<NotImplementedException>(String.Empty, _message), out Exception ex2);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty<NotImplementedException>(" ", _message), out NotImplementedException ex3);
            Test.If.String.StartsWith(ex3.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty<NotImplementedException>("STRING", _message), out NotImplementedException ex4);
            Test.If.String.StartsWith(ex4.Message, _message);

        }

        #endregion

        #region NullOrWhiteSpace

        [TestMethod]
        void ThrowIfNullOrWhiteSpace() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace(String.Empty, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.IsEqual(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace(" ", _paramName, _message), out ArgumentException ex3);
            Test.If.Value.IsEqual(_paramName, ex3.ParamName);
            Test.If.String.StartsWith(ex3.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace("STRING", _paramName, _message), out Exception ex4);

        }

        [TestMethod]
        void ThrowIfNotNullOrWhiteSpace() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace(null, _paramName, _message), out Exception ex1);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace(String.Empty, _paramName, _message), out Exception ex2);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace(" ", _paramName, _message), out Exception ex3);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace("STRING", _paramName, _message), out ArgumentException ex4);
            Test.If.Value.IsEqual(_paramName, ex4.ParamName);
            Test.If.String.StartsWith(ex4.Message, _message);

        }

        [TestMethod]
        void ThrowIfNullOrWhiteSpaceGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace<NotImplementedException>(null, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace<NotImplementedException>(String.Empty, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace<NotImplementedException>(" ", _message), out NotImplementedException ex3);
            Test.If.String.StartsWith(ex3.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace<NotImplementedException>("STRING", _message), out Exception ex4);

        }

        [TestMethod]
        void ThrowIfNotNullOrWhiteSpaceGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace<NotImplementedException>(null, _message), out Exception ex1);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace<NotImplementedException>(String.Empty, _message), out Exception ex2);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace<NotImplementedException>(" ", _message), out Exception ex3);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace<NotImplementedException>("STRING", _message), out NotImplementedException ex4);
            Test.If.String.StartsWith(ex4.Message, _message);

        }

        #endregion

    }
}
