using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Exceptions {

    class ExceptionFactoryTests {

        [TestMethod]
        void TestImplementation() {

            ExceptionFactory ef1 = ExceptionFactory.Instance;
            ExceptionFactory ef2 = ExceptionFactory.Instance;

            Test.IfNot.Null(ef1);
            Test.IfNot.Null(ef2);
            Test.If.ReferencesEqual(ef1, ef2);

        }

        [TestMethod]
        void TestCreateMethod() {

            ArgumentNullException argNullEx = ExceptionFactory.Instance.Create<ArgumentNullException>("this_is_a_parameter_name", "this_is_a_test_message");

            Test.If.Null(argNullEx.InnerException);
            Test.If.StringStartsWith(argNullEx.Message, "this_is_a_test_message");
            Test.If.ValuesEqual(argNullEx.ParamName, "this_is_a_parameter_name");

            ArgumentException argEx = ExceptionFactory.Instance.Create<ArgumentException>("this_is_another_test_message", "this_is_another_parameter_name", argNullEx);

            Test.If.StringStartsWith(argEx.Message, "this_is_another_test_message");
            Test.If.ValuesEqual(argEx.ParamName, "this_is_another_parameter_name");
            Test.If.ReferencesEqual(argNullEx, argEx.InnerException);

        }
    }
}
