using System;

using Nuclear.TestSite;

namespace Nuclear.Exceptions {

    class EnumExceptionSuite_uTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        #region IsDefined

        [TestMethod]
        void ThrowIfIsDefined() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined(typeof(DummyEnum), DummyEnum.Value1, _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined(typeof(DummyEnum), (DummyEnum) 42, _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined(null, null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined(null, DummyEnum.Value1, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined(typeof(DummyEnum), null, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotIsDefined() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined(typeof(DummyEnum), DummyEnum.Value1, _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined(typeof(DummyEnum), (DummyEnum) 42, _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined(null, null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined(null, DummyEnum.Value1, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined(typeof(DummyEnum), null, _paramName, _message), out argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfIsDefined_Generic() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException>(typeof(DummyEnum), DummyEnum.Value1, _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException>(typeof(DummyEnum), (DummyEnum) 42, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException>(null, null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException>(null, DummyEnum.Value1, _message), out argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException>(typeof(DummyEnum), null, _message), out argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotIsDefined_Generic() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException>(typeof(DummyEnum), DummyEnum.Value1, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException>(typeof(DummyEnum), (DummyEnum) 42, _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException>(null, null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException>(null, DummyEnum.Value1, _message), out argNullEx);
            Test.If.Value.IsEqual("enum", argNullEx.ParamName);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException>(typeof(DummyEnum), null, _message), out argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        #endregion

        #region IsDefinedT

        [TestMethod]
        void ThrowIfIsDefinedT() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<DummyEnum>(DummyEnum.Value1, _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<DummyEnum>((DummyEnum) 42, _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<DummyEnum>(null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotIsDefinedT() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<DummyEnum>(DummyEnum.Value1, _paramName, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<DummyEnum>((DummyEnum) 42, _paramName, _message), out ArgumentException argEx);
            Test.If.Value.IsEqual(_paramName, argEx.ParamName);
            Test.If.String.StartsWith(argEx.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<DummyEnum>(null, _paramName, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfIsDefined_GenericT() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException, DummyEnum>(DummyEnum.Value1, _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException, DummyEnum>((DummyEnum) 42, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.If.Enum.IsDefined<NotImplementedException, DummyEnum>(null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        [TestMethod]
        void ThrowIfNotIsDefined_GenericT() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException, DummyEnum>(DummyEnum.Value1, _message), out Exception _);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException, DummyEnum>((DummyEnum) 42, _message), out NotImplementedException ex);
            Test.If.String.StartsWith(ex.Message, _message);

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Enum.IsDefined<NotImplementedException, DummyEnum>(null, _message), out ArgumentNullException argNullEx);
            Test.If.Value.IsEqual("value", argNullEx.ParamName);

        }

        #endregion

    }
}
