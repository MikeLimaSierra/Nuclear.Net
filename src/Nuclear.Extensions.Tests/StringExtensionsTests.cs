using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Extensions {

    class StringExtensionsTests {

        #region StartsWith

        [TestMethod]
        void TestStartsWith() {

            String value = "xyzabc";
            Boolean result = false;

            Test.Note("StartsWith(xYz, InvariantCultureIgnoreCase)");
            Test.IfNot.ThrowsException(() => result = value.StartsWith("xYz", StringComparison.InvariantCultureIgnoreCase), out Exception ex);
            Test.If.True(result);
            Test.If.ValuesEqual(value, "xyzabc");

            DDTestStartsWith("xyzabc", String.Empty, true);
            DDTestStartsWith("xyzabc", "xyz", true);
            DDTestStartsWith("xyzabc", "xYz", false);
            DDTestStartsWith("xyzabc", "abc", false);

        }

        void DDTestStartsWith(String value, String match, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            Boolean _result = false;

            Test.Note($"{_value}.StartsWith({match})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.StartsWith(match), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);

        }

        #endregion

        #region EndsWith

        [TestMethod]
        void TestEndsWith() {

            String value = "abcxyz";
            Boolean result = false;

            Test.Note("EndsWith(xYz, InvariantCultureIgnoreCase)");
            Test.IfNot.ThrowsException(() => result = value.EndsWith("xYz", StringComparison.InvariantCultureIgnoreCase), out Exception ex);
            Test.If.True(result);
            Test.If.ValuesEqual(value, "abcxyz");

            DDTestEndsWith("abcxyz", String.Empty, true);
            DDTestEndsWith("abcxyz", "xyz", true);
            DDTestEndsWith("abcxyz", "xYz", false);
            DDTestEndsWith("abcxyz", "abc", false);

        }

        void DDTestEndsWith(String value, String match, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            Boolean _result = false;

            Test.Note($"{_value}.EndsWith({match})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.EndsWith(match), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);

        }

        #endregion

        #region TrimOnce

        [TestMethod]
        void TestTrimOnce() {

            DDTestTrimOnce("xyzxyzabcxyzxyz", null, "xyzxyzabcxyzxyz");
            DDTestTrimOnce("xyzxyzabcxyzxyz", "xyz", "xyzabcxyz");
            DDTestTrimOnce("zyxabczyx", "xyz", "zyxabczyx");

            DDTestTrimOnce("xxabcxx", 'x', "xabcx");
            DDTestTrimOnce("abc", 'x', "abc");

        }

        void DDTestTrimOnce(String value, String trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimOnce({trim})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.TrimOnce(trim), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        void DDTestTrimOnce(String value, Char trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimOnce({trim})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.TrimOnce(trim), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        #endregion

        #region TrimStartOnce

        [TestMethod]
        void TestTrimStartOnce() {

            DDTestTrimStartOnce("xyzxyzabcxyz", null, "xyzxyzabcxyz");
            DDTestTrimStartOnce("xyzxyzabcxyz", "xyz", "xyzabcxyz");
            DDTestTrimStartOnce("zyxabcxyz", "xyz", "zyxabcxyz");

            DDTestTrimStartOnce("xxabcx", 'x', "xabcx");
            DDTestTrimStartOnce("abcx", 'x', "abcx");

        }

        void DDTestTrimStartOnce(String value, String trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimStartOnce({trim})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.TrimStartOnce(trim), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        void DDTestTrimStartOnce(String value, Char trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimStartOnce({trim})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.TrimStartOnce(trim), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        #endregion

        #region TrimEndOnce

        [TestMethod]
        void TestTrimEndOnce() {

            DDTestTrimEndOnce("xyzabcxyzxyz", null, "xyzabcxyzxyz");
            DDTestTrimEndOnce("xyzabcxyzxyz", "xyz", "xyzabcxyz");
            DDTestTrimEndOnce("xyzabczyx", "xyz", "xyzabczyx");

            DDTestTrimEndOnce("xabcxx", 'x', "xabcx");
            DDTestTrimEndOnce("xabc", 'x', "xabc");

        }

        void DDTestTrimEndOnce(String value, String trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimEndOnce({trim})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.TrimEndOnce(trim), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        void DDTestTrimEndOnce(String value, Char trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimEndOnce({trim})", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.TrimEndOnce(trim), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value, value, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        #endregion

    }
}
