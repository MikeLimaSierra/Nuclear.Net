using System;
using System.Runtime.CompilerServices;
using Nuclear.Exceptions;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Extensions {
    class IComparableExtensionsTests {

        #region IsClamped

        [TestMethod]
        void TestIsClamped() {

            Dummy obj = null;

            Test.Note("null.IsClamped(0, 0)");
            Test.If.ThrowsException(() => obj.IsClamped(new Dummy(0), new Dummy(0)), out ArgumentNullException argNullex);
            Test.If.ValuesEqual(argNullex.ParamName, "_this");

            DDTestIsClamped(0, null, null, true);
            DDTestIsClamped(0, null, 1, true);
            DDTestIsClamped(0, -1, null, true);
            DDTestIsClamped(0, -1, 1, true);
            DDTestIsClamped(0, 1, -1, true);
            DDTestIsClamped(0, 0, 1, true);
            DDTestIsClamped(0, -1, 0, true);
            DDTestIsClamped(0, 0, 0, true);
            DDTestIsClamped(0, 1, 2, false);
            DDTestIsClamped(0, -2, -1, false);

        }

        void DDTestIsClamped(Int32 value, Int32? min, Int32? max, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Dummy _value = new Dummy(value);
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;
            Boolean _result = false;

            Test.Note($"{value}.IsClamped('{min}', '{max}')", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.IsClamped(_min, _max), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value.Value, value, _file, _method);
            Test.If.ValuesEqual(_min?.Value, min, _file, _method);
            Test.If.ValuesEqual(_max?.Value, max, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void TestIsClampedExclusive() {

            Dummy obj = null;

            Test.Note("null.IsClampedExclusive(0, 0)");
            Test.If.ThrowsException(() => obj.IsClampedExclusive(new Dummy(0), new Dummy(0)), out ArgumentNullException argNullex);
            Test.If.ValuesEqual(argNullex.ParamName, "_this");

            DDTestIsClampedExclusive(0, null, null, true);
            DDTestIsClampedExclusive(0, null, 1, true);
            DDTestIsClampedExclusive(0, -1, null, true);
            DDTestIsClampedExclusive(0, -1, 1, true);
            DDTestIsClampedExclusive(0, 1, -1, true);
            DDTestIsClampedExclusive(0, 0, 1, false);
            DDTestIsClampedExclusive(0, -1, 0, false);
            DDTestIsClampedExclusive(0, 0, 0, false);
            DDTestIsClampedExclusive(0, 1, 2, false);
            DDTestIsClampedExclusive(0, -2, -1, false);

        }

        void DDTestIsClampedExclusive(Int32 value, Int32? min, Int32? max, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Dummy _value = new Dummy(value);
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;
            Boolean _result = false;

            Test.Note($"{value}.IsClampedExclusive('{min}', '{max}')", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.IsClampedExclusive(_min, _max), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value.Value, value, _file, _method);
            Test.If.ValuesEqual(_min?.Value, min, _file, _method);
            Test.If.ValuesEqual(_max?.Value, max, _file, _method);
            Test.If.ValuesEqual(_result, expected, _file, _method);

        }

        #endregion

        #region Clamp

        [TestMethod]
        void TestClamp() {

            Dummy obj = null;

            Test.Note("null.Clamp(0, 0)");
            Test.If.ThrowsException(() => obj.Clamp(new Dummy(0), new Dummy(0)), out ArgumentNullException argNullex);
            Test.If.ValuesEqual(argNullex.ParamName, "_this");

            DDTestClamp(0, null, null, 0);
            DDTestClamp(0, null, 1, 0);
            DDTestClamp(0, -1, null, 0);
            DDTestClamp(0, -1, 1, 0);
            DDTestClamp(0, 1, -1, 0);
            DDTestClamp(0, 0, 1, 0);
            DDTestClamp(0, -1, 0, 0);
            DDTestClamp(0, 0, 0, 0);
            DDTestClamp(0, 1, 2, 1);
            DDTestClamp(0, -2, -1, -1);

        }

        void DDTestClamp(Int32 value, Int32? min, Int32? max, Int32 expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Dummy _value = new Dummy(value);
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;
            Dummy _result = null;

            Test.Note($"{value}.Clamp('{min}', '{max}')", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.Clamp(_min, _max), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value.Value, value, _file, _method);
            Test.If.ValuesEqual(_min?.Value, min, _file, _method);
            Test.If.ValuesEqual(_max?.Value, max, _file, _method);
            Test.If.ValuesEqual(_result.Value, expected, _file, _method);

        }

        #endregion

        private class Dummy : IComparable {

            internal Int32 Value { get; set; } = Int32.MaxValue;

            public Dummy(Int32 value) {
                Value = value;
            }

            public Int32 CompareTo(Object obj) {
                Throw.If.Null(obj, "obj");
                Throw.IfNot.OfType<Dummy>(obj, "obj");

                return Value.CompareTo((obj as Dummy).Value);
            }
        }

    }

}
