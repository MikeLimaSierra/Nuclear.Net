using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {

    class StringExtensions_uTests {

        #region StartsWith

        [TestMethod]
        [TestParameters("xyzabc", "xYz", StringComparison.InvariantCultureIgnoreCase, true)]
        void StartsWithComparison(String value, String match, StringComparison comparison, Boolean expected) {

            String _value = value;
            Boolean _result = false;

            Test.IfNot.Action.ThrowsException(() => _result = _value.StartsWith(match, comparison), out Exception ex);
            Test.If.Value.IsEqual(_result, expected);
            Test.If.Value.IsEqual(_value, value);

        }

        [TestMethod]
        [TestParameters("xyzabc", "", true)]
        [TestParameters("xyzabc", "xyz", true)]
        [TestParameters("xyzabc", "xYz", false)]
        [TestParameters("xyzabc", "abc", false)]
        void StartsWith(String value, String match, Boolean expected) {

            String _value = value;
            Boolean _result = false;

            Test.IfNot.Action.ThrowsException(() => _result = _value.StartsWith(match), out Exception ex);
            Test.If.Value.IsEqual(_result, expected);
            Test.If.Value.IsEqual(_value, value);

        }

        #endregion

        #region EndsWith

        [TestMethod]
        [TestParameters("abcxyz", "xYz", StringComparison.InvariantCultureIgnoreCase, true)]
        void EndsWithComparison(String value, String match, StringComparison comparison, Boolean expected) {

            String _value = value;
            Boolean _result = false;

            Test.IfNot.Action.ThrowsException(() => _result = _value.EndsWith(match, comparison), out Exception ex);
            Test.If.Value.IsEqual(_result, expected);
            Test.If.Value.IsEqual(_value, value);

        }

        [TestMethod]
        [TestParameters("abcxyz", "", true)]
        [TestParameters("abcxyz", "xyz", true)]
        [TestParameters("abcxyz", "xYz", false)]
        [TestParameters("abcxyz", "abc", false)]
        void EndsWith(String value, String match, Boolean expected) {

            String _value = value;
            Boolean _result = false;

            Test.IfNot.Action.ThrowsException(() => _result = _value.EndsWith(match), out Exception ex);
            Test.If.Value.IsEqual(_result, expected);
            Test.If.Value.IsEqual(_value, value);

        }

        #endregion

        #region Contains

        [TestMethod]
        [TestParameters("abcxyzabc", "", StringComparison.InvariantCulture, true)]
        [TestParameters("abcxyzabc", "xyz", StringComparison.InvariantCulture, true)]
        [TestParameters("abcxyzabc", "xYz", StringComparison.InvariantCulture, false)]
        [TestParameters("abcxyzabc", "xyyz", StringComparison.InvariantCulture, false)]
        [TestParameters("abcxyzabc", "", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("abcxyzabc", "xyz", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("abcxyzabc", "xYz", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("abcxyzabc", "xyyz", StringComparison.InvariantCultureIgnoreCase, false)]
        [TestParameters("xyzabc", "", StringComparison.InvariantCulture, true)]
        [TestParameters("xyzabc", "xyz", StringComparison.InvariantCulture, true)]
        [TestParameters("xyzabc", "xYz", StringComparison.InvariantCulture, false)]
        [TestParameters("xyzabc", "xyyz", StringComparison.InvariantCulture, false)]
        [TestParameters("xyzabc", "", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("xyzabc", "xyz", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("xyzabc", "xYz", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("xyzabc", "xyyz", StringComparison.InvariantCultureIgnoreCase, false)]
        [TestParameters("abcxyz", "", StringComparison.InvariantCulture, true)]
        [TestParameters("abcxyz", "xyz", StringComparison.InvariantCulture, true)]
        [TestParameters("abcxyz", "xYz", StringComparison.InvariantCulture, false)]
        [TestParameters("abcxyz", "xyyz", StringComparison.InvariantCulture, false)]
        [TestParameters("abcxyz", "", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("abcxyz", "xyz", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("abcxyz", "xYz", StringComparison.InvariantCultureIgnoreCase, true)]
        [TestParameters("abcxyz", "xyyz", StringComparison.InvariantCultureIgnoreCase, false)]
        void Contains(String value, String match, StringComparison comparison, Boolean expected) {

            String _value = value;
            Boolean _result = false;

            Test.IfNot.Action.ThrowsException(() => _result = _value.Contains(match, comparison), out Exception ex);
            Test.If.Value.IsEqual(_result, expected);
            Test.If.Value.IsEqual(_value, value);

        }

        #endregion

        #region TrimOnce

        [TestMethod]
        [TestParameters("xyzxyzabcxyzxyz", null, "xyzxyzabcxyzxyz")]
        [TestParameters("xyzxyzabcxyzxyz", "xyz", "xyzabcxyz")]
        [TestParameters("zyxabczyx", "xyz", "zyxabczyx")]
        void TrimOnce(String value, String trim, String expected) {

            String _value = value;
            String _result = null;

            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimOnce(trim), out Exception ex);
            Test.If.Value.IsEqual(_value, value);
            Test.If.Value.IsEqual(_result, expected);

        }

        [TestMethod]
        [TestParameters("xxabcxx", 'x', "xabcx")]
        [TestParameters("abc", 'x', "abc")]
        void TrimOnceChar(String value, Char trim, String expected) {

            String _value = value;
            String _result = null;

            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimOnce(trim), out Exception ex);
            Test.If.Value.IsEqual(_value, value);
            Test.If.Value.IsEqual(_result, expected);

        }

        #endregion

        #region TrimStartOnce

        [TestMethod]
        [TestParameters("xyzxyzabcxyz", null, "xyzxyzabcxyz")]
        [TestParameters("xyzxyzabcxyz", "xyz", "xyzabcxyz")]
        [TestParameters("zyxabcxyz", "xyz", "zyxabcxyz")]
        void TrimStartOnce(String value, String trim, String expected) {

            String _value = value;
            String _result = null;

            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimStartOnce(trim), out Exception ex);
            Test.If.Value.IsEqual(_value, value);
            Test.If.Value.IsEqual(_result, expected);

        }

        [TestMethod]
        [TestParameters("xxabcx", 'x', "xabcx")]
        [TestParameters("abcx", 'x', "abcx")]
        void TrimStartOnceChar(String value, Char trim, String expected) {

            String _value = value;
            String _result = null;

            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimStartOnce(trim), out Exception ex);
            Test.If.Value.IsEqual(_value, value);
            Test.If.Value.IsEqual(_result, expected);

        }

        #endregion

        #region TrimEndOnce

        [TestMethod]
        [TestParameters("xyzabcxyzxyz", null, "xyzabcxyzxyz")]
        [TestParameters("xyzabcxyzxyz", "xyz", "xyzabcxyz")]
        [TestParameters("xyzabczyx", "xyz", "xyzabczyx")]
        void TrimEndOnce(String value, String trim, String expected) {

            String _value = value;
            String _result = null;

            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimEndOnce(trim), out Exception ex);
            Test.If.Value.IsEqual(_value, value);
            Test.If.Value.IsEqual(_result, expected);

        }

        [TestMethod]
        [TestParameters("xabcxx", 'x', "xabcx")]
        [TestParameters("xabc", 'x', "xabc")]
        void TrimEndOnceChar(String value, Char trim, String expected) {

            String _value = value;
            String _result = null;

            Test.IfNot.Action.ThrowsException(() => _result = _value.TrimEndOnce(trim), out Exception ex);
            Test.If.Value.IsEqual(_value, value);
            Test.If.Value.IsEqual(_result, expected);

        }

        #endregion

    }
}
