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
                Throw.If.Object.IsNull(null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual(_paramName, argNullEx.ParamName);
            Test.If.String.StartsWith(argNullEx.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsNull(new Object(), _paramName, _message), out Exception _);

        }

        [TestMethod]
        void ThrowIfNotNull() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull(null, _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull(new Object(), _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual(_paramName, argNullEx.ParamName);
            Test.If.String.StartsWith(argNullEx.Message, _message);

        }

        [TestMethod]
        void ThrowIfNullGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsNull<NotImplementedException>(null, _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsNull<NotImplementedException>(new Object(), _message), out Exception _);

        }

        [TestMethod]
        void ThrowIfNotNullGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull<NotImplementedException>(null, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsNull<NotImplementedException>(new Object(), _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

        }

        #endregion

        #region IsOfType

        [TestMethod]
        void ThrowIfOfType() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType("STRING", typeof(String), _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType(42, typeof(String), _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType(null, null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType(null, typeof(String), _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType("STRING", null, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotOfType() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType("STRING", typeof(String), _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType(42, typeof(String), _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType(null, null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType(null, typeof(String), _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType("STRING", null, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfOfTypeGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException>("STRING", typeof(String), _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException>(42, typeof(String), _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException>(null, (Type) null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException>(null, typeof(String), _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException>("STRING", (Type) null, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotOfTypeGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException>("STRING", typeof(String), _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException>(42, typeof(String), _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException>(null, (Type) null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException>(null, typeof(String), _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException>("STRING", (Type) null, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        #endregion

        #region IsOfTypeT

        [TestMethod]
        void ThrowIfOfTypeT() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<String>("STRING", _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<String>(42, _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<String>(null, _paramName, _message), out ArgumentNullException argNullEx);

        }

        [TestMethod]
        void ThrowIfNotOfTypeT() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<String>("STRING", _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<String>(42, _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<String>(null, _paramName, _message), out ArgumentNullException argNullEx);

        }

        [TestMethod]
        void ThrowIfOfTypeGenericT() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>("STRING", _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>(42, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfType<NotImplementedException, String>(null, _message), out ArgumentNullException argNullEx);

        }

        [TestMethod]
        void ThrowIfNotOfTypeGenericT() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>("STRING", _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>(42, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfType<NotImplementedException, String>(null, _message), out ArgumentNullException argNullEx);

        }

        #endregion

        #region IsOfExactType

        [TestMethod]
        void ThrowIfOfExactType() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType("STRING", typeof(String), _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType("STRING", typeof(Object), _paramName, _message), out Exception _);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType(42, typeof(String), _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType(null, null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType(null, typeof(String), _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType("STRING", null, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotOfExactType() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType("STRING", typeof(String), _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType("STRING", typeof(Object), _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType(42, typeof(String), _paramName, _message), out argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType(null, null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType(null, typeof(String), _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType("STRING", null, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfOfExactTypeGeneric() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException>("STRING", typeof(String), _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException>("STRING", typeof(Object), _message), out Exception _);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException>(42, typeof(String), _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException>(null, (Type) null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException>(null, typeof(String), _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException>("STRING", (Type) null, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotOfExactTypeGeneric() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException>("STRING", typeof(String), _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException>("STRING", typeof(Object), _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException>(42, typeof(String), _message), out ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException>(null, (Type) null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException>(null, typeof(String), _message), out argNullEx);
            Test.If.Value.IsEqual("object", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException>("STRING", (Type) null, _message), out argNullEx);
            Test.If.Value.IsEqual("type", argNullEx.ParamName);

        }

        #endregion

        #region IsOfExactTypeT

        [TestMethod]
        void ThrowIfOfExactTypeT() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<String>("STRING", _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<Object>("STRING", _paramName, _message), out Exception _);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<String>(42, _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<String>(null, _paramName, _message), out ArgumentNullException argNullEx);

        }

        [TestMethod]
        void ThrowIfNotOfExactTypeT() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<String>("STRING", _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<Object>("STRING", _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<String>(42, _paramName, _message), out argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<String>(null, _paramName, _message), out ArgumentNullException argNullEx);

        }

        [TestMethod]
        void ThrowIfOfExactTypeGenericT() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException, String>("STRING", _message), exception: out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException, Object>("STRING", _message), out Exception _);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException, String>(42, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Object.IsOfExactType<NotImplementedException, String>(null, _message), out ArgumentNullException argNullEx);

        }

        [TestMethod]
        void ThrowIfNotOfExactTypeGenericT() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException, String>("STRING", _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException, Object>("STRING", _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException, String>(42, _message), out ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Object.IsOfExactType<NotImplementedException, String>(null, _message), out ArgumentNullException argNullEx);

        }

        #endregion

    }
}
