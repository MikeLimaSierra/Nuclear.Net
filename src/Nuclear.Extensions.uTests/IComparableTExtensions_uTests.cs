using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparableTExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsEqual<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsEqualData))]
        void IsEqual(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsEqual(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsEqualData() {
            return new List<Object[]>() {
                new Object[] { 0, 0, true },
                new Object[] { 0, 1, false },
            };
        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThanThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsLessThan<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThanData))]
        void LessThan(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsLessThan(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanData() {
            return new List<Object[]>() {
                new Object[] { 0, 0, false },
                new Object[] { 0, 1, true },
                new Object[] { 1, 0, false },
            };
        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsLessThanOrEqual<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEqualsData))]
        void LessThanOrEquals(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsLessThanOrEqual(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { 0, 0, true },
                new Object[] { 0, 1, true },
                new Object[] { 1, 0, false },
            };
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThanThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsGreaterThan<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanData))]
        void GreaterThan(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsGreaterThan(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanData() {
            return new List<Object[]>() {
                new Object[] { 0, 0, false },
                new Object[] { 0, 1, false },
                new Object[] { 1, 0, true },
            };
        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsGreaterThanOrEqual<DummyIComparableT>(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEqualsData))]
        void GreaterThanOrEquals(Int32 x, Int32 y, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = x.IsGreaterThanOrEqual(y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { 0, 0, true },
                new Object[] { 0, 1, false },
                new Object[] { 1, 0, true },
            };
        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClampedThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsClamped<DummyIComparableT>(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClampedData))]
        void IsClamped(Int32 v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = default;
            DummyIComparableT _v = new DummyIComparableT(v);
            DummyIComparableT _min = min.HasValue ? new DummyIComparableT(min.Value) : null;
            DummyIComparableT _max = max.HasValue ? new DummyIComparableT(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = _v.IsClamped(_min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedData() {
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
        void IsClampedExclusiveThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsClampedExclusive<DummyIComparableT>(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusiveData))]
        void IsClampedExclusive(Int32 v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = default;
            DummyIComparableT _v = new DummyIComparableT(v);
            DummyIComparableT _min = min.HasValue ? new DummyIComparableT(min.Value) : null;
            DummyIComparableT _max = max.HasValue ? new DummyIComparableT(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = _v.IsClampedExclusive(_min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedExclusiveData() {
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
        void ClampThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.Clamp<DummyIComparableT>(null, 0, 0), out ArgumentNullException ex);

        }

        [TestMethod]
        [TestData(nameof(ClampData))]
        void Clamp(Int32 v, Int32? min, Int32? max, Int32 expected) {

            DummyIComparableT result = default;
            DummyIComparableT _v = new DummyIComparableT(v);
            DummyIComparableT _min = min.HasValue ? new DummyIComparableT(min.Value) : null;
            DummyIComparableT _max = max.HasValue ? new DummyIComparableT(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = _v.Clamp(_min, _max), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> ClampData() {
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
