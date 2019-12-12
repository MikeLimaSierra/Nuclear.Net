using System;
using Nuclear.TestSite;

namespace Nuclear.Exceptions {

    class ConditionalThrow_uTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        #region Null

        [TestMethod]
        void TestThrowIfNull() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsNull(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.Value.Equals(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsNull(new Object(), _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotNull() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull(null, _paramName, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull(new Object(), _paramName, _message), out ArgumentNullException ex2);
            Test.If.Value.Equals(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void TestThrowIfNullGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsNull<NotImplementedException>(null, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsNull<NotImplementedException>(new Object(), _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotNullGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull<NotImplementedException>(null, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull<NotImplementedException>(new Object(), _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        #endregion

        #region OfType

        [TestMethod]
        void TestThrowIfOfType() {

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
        void TestThrowIfNotOfType() {

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
        void TestThrowIfOfTypeGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>("STRING", _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>(42, _message), out Exception ex2);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>(null, _message), out ArgumentNullException ex3);

        }

        [TestMethod]
        void TestThrowIfNotOfTypeGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>("STRING", _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>(42, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>(null, _message), out ArgumentNullException ex3);

        }

        #endregion

        #region NullOrEmpty

        [TestMethod]
        void TestThrowIfNullOrEmpty() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.Value.Equals(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty(String.Empty, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.Equals(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty(" ", _paramName, _message), out Exception ex3);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrEmpty("STRING", _paramName, _message), out Exception ex4);

        }

        [TestMethod]
        void TestThrowIfNotNullOrEmpty() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty(null, _paramName, _message), out Exception ex1);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty(String.Empty, _paramName, _message), out Exception ex2);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty(" ", _paramName, _message), out ArgumentException ex3);
            Test.If.Value.Equals(_paramName, ex3.ParamName);
            Test.If.String.StartsWith(ex3.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrEmpty("STRING", _paramName, _message), out ArgumentException ex4);
            Test.If.Value.Equals(_paramName, ex4.ParamName);
            Test.If.String.StartsWith(ex4.Message, _message);

        }

        [TestMethod]
        void TestThrowIfNullOrEmptyGeneric() {

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
        void TestThrowIfNotNullOrEmptyGeneric() {

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
        void TestThrowIfNullOrWhiteSpace() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.Value.Equals(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace(String.Empty, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.Equals(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace(" ", _paramName, _message), out ArgumentException ex3);
            Test.If.Value.Equals(_paramName, ex3.ParamName);
            Test.If.String.StartsWith(ex3.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.String.IsNullOrWhiteSpace("STRING", _paramName, _message), out Exception ex4);

        }

        [TestMethod]
        void TestThrowIfNotNullOrWhiteSpace() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace(null, _paramName, _message), out Exception ex1);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace(String.Empty, _paramName, _message), out Exception ex2);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace(" ", _paramName, _message), out Exception ex3);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.String.IsNullOrWhiteSpace("STRING", _paramName, _message), out ArgumentException ex4);
            Test.If.Value.Equals(_paramName, ex4.ParamName);
            Test.If.String.StartsWith(ex4.Message, _message);

        }

        [TestMethod]
        void TestThrowIfNullOrWhiteSpaceGeneric() {

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
        void TestThrowIfNotNullOrWhiteSpaceGeneric() {

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

        #region True

        [TestMethod]
        void TestThrowIfTrue() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue(true, _paramName, _message), out ArgumentException ex1);
            Test.If.Value.Equals(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue(false, _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotTrue() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue(true, _paramName, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue(false, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.Equals(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void TestThrowIfTrueGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue<NotImplementedException>(true, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsTrue<NotImplementedException>(false, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotTrueGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue<NotImplementedException>(true, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsTrue<NotImplementedException>(false, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        #endregion

        #region False

        [TestMethod]
        void TestThrowIfFalse() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse(false, _paramName, _message), out ArgumentException ex1);
            Test.If.Value.Equals(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse(true, _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotFalse() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse(false, _paramName, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse(true, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.Equals(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void TestThrowIfFalseGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse<NotImplementedException>(false, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Value.IsFalse<NotImplementedException>(true, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotFalseGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse<NotImplementedException>(false, _message), out Exception ex1);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Value.IsFalse<NotImplementedException>(true, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        #endregion

    }
}
