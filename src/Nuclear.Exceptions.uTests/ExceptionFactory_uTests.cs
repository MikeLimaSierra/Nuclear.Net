using System;

using Nuclear.TestSite;

namespace Nuclear.Exceptions {

    class ExceptionFactory_uTests {

        [TestMethod]
        void Implementation() {

            ExceptionFactory ef1 = ExceptionFactory.Instance;
            ExceptionFactory ef2 = ExceptionFactory.Instance;

            Test.IfNot.Object.IsNull(ef1);
            Test.IfNot.Object.IsNull(ef2);
            Test.If.Reference.IsEqual(ef1, ef2);

        }

        [TestMethod]
        void Create() {

            ArgumentNullException argNullEx = ExceptionFactory.Instance.Create<ArgumentNullException>("this_is_a_parameter_name", "this_is_a_test_message");

            Test.If.Object.IsNull(argNullEx.InnerException);
            Test.If.String.StartsWith(argNullEx.Message, "this_is_a_test_message");
            Test.If.Value.IsEqual(argNullEx.ParamName, "this_is_a_parameter_name");

            ArgumentException argEx = ExceptionFactory.Instance.Create<ArgumentException>("this_is_another_test_message", "this_is_another_parameter_name", argNullEx);

            Test.If.String.StartsWith(argEx.Message, "this_is_another_test_message");
            Test.If.Value.IsEqual(argEx.ParamName, "this_is_another_parameter_name");
            Test.If.Reference.IsEqual(argNullEx, argEx.InnerException);

        }
    }
}
