using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparableTExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqual_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsEqual<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsEqual_Data))]
        void IsEqual(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsEqual(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsEqual_Data() {
            return new List<Object[]>() {
                new Object[] { 0, 0, true },
                new Object[] { 0, 1, false },
            };
        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThan_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsLessThan<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThan_Data))]
        void LessThan(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsLessThan(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThan_Data() {
            return new List<Object[]>() {
                new Object[] { 0, 0, false },
                new Object[] { 0, 1, true },
                new Object[] { 1, 0, false },
            };
        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEquals_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsLessThanOrEqual<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEquals_Data))]
        void LessThanOrEquals(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsLessThanOrEqual(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanOrEquals_Data() {
            return new List<Object[]>() {
                new Object[] { 0, 0, true },
                new Object[] { 0, 1, true },
                new Object[] { 1, 0, false },
            };
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThan_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsGreaterThan<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThan_Data))]
        void GreaterThan(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsGreaterThan(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThan_Data() {
            return new List<Object[]>() {
                new Object[] { 0, 0, false },
                new Object[] { 0, 1, false },
                new Object[] { 1, 0, true },
            };
        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEquals_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsGreaterThanOrEqual<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEquals_Data))]
        void GreaterThanOrEquals(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsGreaterThanOrEqual(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanOrEquals_Data() {
            return new List<Object[]>() {
                new Object[] { 0, 0, true },
                new Object[] { 0, 1, false },
                new Object[] { 1, 0, true },
            };
        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClamped_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsClamped<DummyIComparableT>(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClamped_Data))]
        void IsClamped(Int32 v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = default;
            DummyIComparableT _v = new DummyIComparableT(v);
            DummyIComparableT _min = min.HasValue ? new DummyIComparableT(min.Value) : null;
            DummyIComparableT _max = max.HasValue ? new DummyIComparableT(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = _v.IsClamped(_min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClamped_Data() {
            return new List<Object[]>() {
                new Object[] { 0, null, null, true },
                new Object[] { 0, null, 1, true },
                new Object[] { 0, -1, null, true },
                new Object[] { 0, -1, 1, true },
                new Object[] { 0, 1, -1, false },
                new Object[] { 0, 0, 1, true },
                new Object[] { 0, -1, 0, true },
                new Object[] { 0, 0, 0, true },
                new Object[] { 0, 1, 2, false },
                new Object[] { 0, -2, -1, false },
            };
        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusive_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsClampedExclusive<DummyIComparableT>(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusive_Data))]
        void IsClampedExclusive(Int32 v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = default;
            DummyIComparableT _v = new DummyIComparableT(v);
            DummyIComparableT _min = min.HasValue ? new DummyIComparableT(min.Value) : null;
            DummyIComparableT _max = max.HasValue ? new DummyIComparableT(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = _v.IsClampedExclusive(_min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedExclusive_Data() {
            return new List<Object[]>() {
                new Object[] { 0, null, null, true },
                new Object[] { 0, null, 1, true },
                new Object[] { 0, -1, null, true },
                new Object[] { 0, -1, 1, true },
                new Object[] { 0, 1, -1, false },
                new Object[] { 0, 0, 1, false },
                new Object[] { 0, -1, 0, false },
                new Object[] { 0, 0, 0, false },
                new Object[] { 0, 1, 2, false },
                new Object[] { 0, -2, -1, false },
            };
        }

        #endregion

        #region Clamp

        [TestMethod]
        void Clamp_Throws() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.Clamp<DummyIComparableT>(null, 0, 0), out ArgumentNullException ex);

        }

        [TestMethod]
        [TestData(nameof(Clamp_Data))]
        void Clamp(Int32 v, Int32? min, Int32? max, Int32 expected) {

            DummyIComparableT result = default;
            DummyIComparableT _v = new DummyIComparableT(v);
            DummyIComparableT _min = min.HasValue ? new DummyIComparableT(min.Value) : null;
            DummyIComparableT _max = max.HasValue ? new DummyIComparableT(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = _v.Clamp(_min, _max), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> Clamp_Data() {
            return new List<Object[]>() {
                new Object[] { 0, null, null, 0 },
                new Object[] { 0, null, 1, 0 },
                new Object[] { 0, -1, null, 0 },
                new Object[] { 0, -1, 1, 0 },
                new Object[] { 0, 1, -1, 0 },
                new Object[] { 0, 0, 1, 0 },
                new Object[] { 0, -1, 0, 0 },
                new Object[] { 0, 0, 0, 0 },
                new Object[] { 0, 1, 2, 1 },
                new Object[] { 0, -2, -1, -1 },
            };
        }

        #endregion

    }

}
