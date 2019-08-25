using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Extensions {

    class StringExtensionsTests {

        #region TrimOnce

        [TestMethod]
        void TestTrimOnce() {

            String value = "xyzxyzabcxyzxyz";
            String remainder = value.TrimOnce("xyz");
            Test.If.ValuesEqual(value, "xyzxyzabcxyzxyz");
            Test.If.ValuesEqual(remainder, "xyzabcxyz");

            value = "zyxabczyx";
            remainder = value.TrimOnce("xyz");
            Test.If.ValuesEqual(value, "zyxabczyx");
            Test.If.ValuesEqual(remainder, "zyxabczyx");

            value = "xxabcxx";
            remainder = value.TrimOnce('x');
            Test.If.ValuesEqual(value, "xxabcxx");
            Test.If.ValuesEqual(remainder, "xabcx");

            value = "abc";
            remainder = value.TrimOnce('x');
            Test.If.ValuesEqual(value, "abc");
            Test.If.ValuesEqual(remainder, "abc");

        }

        [TestMethod]
        void TestTrimStartOnce() {

            String value = "xyzxyzabcxyz";
            String remainder = value.TrimStartOnce("xyz");
            Test.If.ValuesEqual(value, "xyzxyzabcxyz");
            Test.If.ValuesEqual(remainder, "xyzabcxyz");

            value = "zyxabcxyz";
            remainder = value.TrimStartOnce("xyz");
            Test.If.ValuesEqual(value, "zyxabcxyz");
            Test.If.ValuesEqual(remainder, "zyxabcxyz");

            value = "xxabcx";
            remainder = value.TrimStartOnce('x');
            Test.If.ValuesEqual(value, "xxabcx");
            Test.If.ValuesEqual(remainder, "xabcx");

            value = "abcx";
            remainder = value.TrimStartOnce('x');
            Test.If.ValuesEqual(value, "abcx");
            Test.If.ValuesEqual(remainder, "abcx");

        }

        [TestMethod]
        void TestTrimEndOnce() {

            String value = "xyzabcxyzxyz";
            String remainder = value.TrimEndOnce("xyz");
            Test.If.ValuesEqual(value, "xyzabcxyzxyz");
            Test.If.ValuesEqual(remainder, "xyzabcxyz");

            value = "xyzabczyx";
            remainder = value.TrimEndOnce("xyz");
            Test.If.ValuesEqual(value, "xyzabczyx");
            Test.If.ValuesEqual(remainder, "xyzabczyx");

            value = "xabcxx";
            remainder = value.TrimEndOnce('x');
            Test.If.ValuesEqual(value, "xabcxx");
            Test.If.ValuesEqual(remainder, "xabcx");

            value = "xabc";
            remainder = value.TrimEndOnce('x');
            Test.If.ValuesEqual(value, "xabc");
            Test.If.ValuesEqual(remainder, "xabc");

        }

        #endregion

    }
}
