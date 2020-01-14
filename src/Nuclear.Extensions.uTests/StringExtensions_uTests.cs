using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {

    class StringExtensions_uTests {

        #region StartsWith

        [TestMethod]
        void StartsWith() {

            String value = "xyzabc";
            Boolean result = false;

            Test.Note("StartsWith(xYz, InvariantCultureIgnoreCase)");
            Test.IfNot.Action.ThrowsException(() => result = value.StartsWith("xYz", StringComparison.InvariantCultureIgnoreCase), out Exception ex);
            Test.If.Value.IsTrue(result);
            Test.If.Value.Equals(value, "xyzabc");

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
            Test.IfNot.Action.ThrowsException(() => _result = _value.StartsWith(match), out Exception ex, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);

        }

        #endregion

        #region EndsWith

        [TestMethod]
        void EndsWith() {

            String value = "abcxyz";
            Boolean result = false;

            Test.Note("EndsWith(xYz, InvariantCultureIgnoreCase)");
            Test.IfNot.Action.ThrowsException(() => result = value.EndsWith("xYz", StringComparison.InvariantCultureIgnoreCase), out Exception ex);
            Test.If.Value.IsTrue(result);
            Test.If.Value.Equals(value, "abcxyz");

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
            Test.IfNot.Action.ThrowsException(() => _result = _value.EndsWith(match), out Exception ex, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);

        }

        #endregion

        #region Contains

        [TestMethod]
        void Contains() {

            String value = "abcxyzabc";
            Boolean result = false;

            Test.Note("Contains(xYz, InvariantCultureIgnoreCase)");
            Test.IfNot.Action.ThrowsException(() => result = value.Contains("xYz", StringComparison.InvariantCultureIgnoreCase), out Exception ex);
            Test.If.Value.IsTrue(result);
            Test.If.Value.Equals(value, "abcxyzabc");

            DDContains("abcxyzabc", String.Empty, StringComparison.InvariantCulture, true);
            DDContains("abcxyzabc", "xyz", StringComparison.InvariantCulture, true);
            DDContains("abcxyzabc", "xYz", StringComparison.InvariantCulture, false);
            DDContains("abcxyzabc", "xyyz", StringComparison.InvariantCulture, false);
            DDContains("abcxyzabc", String.Empty, StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("abcxyzabc", "xyz", StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("abcxyzabc", "xYz", StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("abcxyzabc", "xyyz", StringComparison.InvariantCultureIgnoreCase, false);

            DDContains("xyzabc", String.Empty, StringComparison.InvariantCulture, true);
            DDContains("xyzabc", "xyz", StringComparison.InvariantCulture, true);
            DDContains("xyzabc", "xYz", StringComparison.InvariantCulture, false);
            DDContains("xyzabc", "xyyz", StringComparison.InvariantCulture, false);
            DDContains("xyzabc", String.Empty, StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("xyzabc", "xyz", StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("xyzabc", "xYz", StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("xyzabc", "xyyz", StringComparison.InvariantCultureIgnoreCase, false);

            DDContains("abcxyz", String.Empty, StringComparison.InvariantCulture, true);
            DDContains("abcxyz", "xyz", StringComparison.InvariantCulture, true);
            DDContains("abcxyz", "xYz", StringComparison.InvariantCulture, false);
            DDContains("abcxyz", "xyyz", StringComparison.InvariantCulture, false);
            DDContains("abcxyz", String.Empty, StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("abcxyz", "xyz", StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("abcxyz", "xYz", StringComparison.InvariantCultureIgnoreCase, true);
            DDContains("abcxyz", "xyyz", StringComparison.InvariantCultureIgnoreCase, false);

        }

        void DDContains(String value, String match, StringComparison comparison, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            Boolean _result = false;

            Test.Note($"{_value.Format()}.Contains({match.Format()}, {comparison.Format()})", _file, _method);
            Test.IfNot.Action.ThrowsException(() => _result = _value.Contains(match, comparison), out Exception ex, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);

        }

        #endregion

        #region TrimOnce

        [TestMethod]
        void TrimOnce() {

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
            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimOnce(trim), out Exception ex, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);

        }

        void DDTestTrimOnce(String value, Char trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimOnce({trim})", _file, _method);
            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimOnce(trim), out Exception ex, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);

        }

        #endregion

        #region TrimStartOnce

        [TestMethod]
        void TrimStartOnce() {

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
            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimStartOnce(trim), out Exception ex, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);

        }

        void DDTestTrimStartOnce(String value, Char trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimStartOnce({trim})", _file, _method);
            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimStartOnce(trim), out Exception ex, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);

        }

        #endregion

        #region TrimEndOnce

        [TestMethod]
        void TrimEndOnce() {

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
            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimEndOnce(trim), out Exception ex, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);

        }

        void DDTestTrimEndOnce(String value, Char trim, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String _value = value;
            String _result = null;

            Test.Note($"{_value}.TrimEndOnce({trim})", _file, _method);
            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimEndOnce(trim), out Exception ex, _file, _method);
            Test.If.Value.Equals(_value, value, _file, _method);
            Test.If.Value.Equals(_result, expected, _file, _method);

        }

        #endregion

    }
}
