using System;
using System.Runtime.CompilerServices;
using Nuclear.Exceptions;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Extensions {
    class IComparableTExtensionsTests {

        #region IsClamped

        [TestMethod]
        void TestIsClampedT() {

            DummyT obj = null;

            Test.Note("null.IsClamped(0, 0)");
            Test.If.ThrowsException(() => obj.IsClamped(new DummyT(0), new DummyT(0)), out ArgumentNullException argNullex);
            Test.If.ValuesEqual(argNullex.ParamName, "_this");

            DDTestIsClampedT(0, null, null, true);
            DDTestIsClampedT(0, null, 1, true);
            DDTestIsClampedT(0, -1, null, true);
            DDTestIsClampedT(0, -1, 1, true);
            DDTestIsClampedT(0, 1, -1, true);
            DDTestIsClampedT(0, 0, 1, true);
            DDTestIsClampedT(0, -1, 0, true);
            DDTestIsClampedT(0, 0, 0, true);
            DDTestIsClampedT(0, 1, 2, false);
            DDTestIsClampedT(0, -2, -1, false);

        }

        void DDTestIsClampedT(Int32 value, Int32? min, Int32? max, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            DummyT _value = new DummyT(value);
            DummyT _min = min.HasValue ? new DummyT(min.Value) : null;
            DummyT _max = max.HasValue ? new DummyT(max.Value) : null;
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
        void TestIsClampedExclusiveT() {

            DummyT obj = null;

            Test.Note("null.IsClampedExclusive(0, 0)");
            Test.If.ThrowsException(() => obj.IsClampedExclusive(new DummyT(0), new DummyT(0)), out ArgumentNullException argNullex);
            Test.If.ValuesEqual(argNullex.ParamName, "_this");

            DDTestIsClampedExclusiveT(0, null, null, true);
            DDTestIsClampedExclusiveT(0, null, 1, true);
            DDTestIsClampedExclusiveT(0, -1, null, true);
            DDTestIsClampedExclusiveT(0, -1, 1, true);
            DDTestIsClampedExclusiveT(0, 1, -1, true);
            DDTestIsClampedExclusiveT(0, 0, 1, false);
            DDTestIsClampedExclusiveT(0, -1, 0, false);
            DDTestIsClampedExclusiveT(0, 0, 0, false);
            DDTestIsClampedExclusiveT(0, 1, 2, false);
            DDTestIsClampedExclusiveT(0, -2, -1, false);

        }

        void DDTestIsClampedExclusiveT(Int32 value, Int32? min, Int32? max, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            DummyT _value = new DummyT(value);
            DummyT _min = min.HasValue ? new DummyT(min.Value) : null;
            DummyT _max = max.HasValue ? new DummyT(max.Value) : null;
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
        void TestClampT() {

            DummyT obj = null;

            Test.Note("null.Clamp(0, 0)");
            Test.If.ThrowsException(() => obj.Clamp(new DummyT(0), new DummyT(0)), out ArgumentNullException argNullex);
            Test.If.ValuesEqual(argNullex.ParamName, "_this");

            DDTestClampT(0, null, null, 0);
            DDTestClampT(0, null, 1, 0);
            DDTestClampT(0, -1, null, 0);
            DDTestClampT(0, -1, 1, 0);
            DDTestClampT(0, 1, -1, 0);
            DDTestClampT(0, 0, 1, 0);
            DDTestClampT(0, -1, 0, 0);
            DDTestClampT(0, 0, 0, 0);
            DDTestClampT(0, 1, 2, 1);
            DDTestClampT(0, -2, -1, -1);

        }

        void DDTestClampT(Int32 value, Int32? min, Int32? max, Int32 expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            DummyT _value = new DummyT(value);
            DummyT _min = min.HasValue ? new DummyT(min.Value) : null;
            DummyT _max = max.HasValue ? new DummyT(max.Value) : null;
            DummyT _result = null;

            Test.Note($"{value}.Clamp('{min}', '{max}')", _file, _method);
            Test.IfNot.ThrowsException(() => _result = _value.Clamp(_min, _max), out Exception ex, _file, _method);
            Test.If.ValuesEqual(_value.Value, value, _file, _method);
            Test.If.ValuesEqual(_min?.Value, min, _file, _method);
            Test.If.ValuesEqual(_max?.Value, max, _file, _method);
            Test.If.ValuesEqual(_result.Value, expected, _file, _method);

        }

        #endregion

        private class DummyT : IComparable<DummyT> {

            internal Int32 Value { get; set; } = Int32.MaxValue;

            public DummyT(Int32 value) {
                Value = value;
            }

            public Int32 CompareTo(DummyT other) {
                Throw.If.Null(other, "other");

                return Value.CompareTo(other.Value);
            }
        }

    }

}
