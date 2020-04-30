using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparableExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsEqual(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsEqualData))]
        void IsEqual(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsLessThan(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThanData))]
        void LessThan(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsLessThanOrEqual(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEqualsData))]
        void LessThanOrEquals(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsGreaterThan(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanData))]
        void GreaterThan(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsGreaterThanOrEqual(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEqualsData))]
        void GreaterThanOrEquals(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsClamped(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClampedData))]
        void IsClamped(IComparable v, Object min, Object max, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = v.IsClamped(min, max), out Exception ex);
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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsClampedExclusive(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusiveData))]
        void IsClampedExclusive(IComparable v, Object min, Object max, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = v.IsClampedExclusive(min, max), out Exception ex);
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

            Test.If.Action.ThrowsException(() => IComparableExtensions.Clamp<DummyIComparable>(null, 0, 0), out ArgumentNullException ex);

        }

        [TestMethod]
        [TestData(nameof(ClampData))]
        void Clamp(IComparable v, IComparable min, IComparable max, IComparable expected) {

            IComparable result = default;

            Test.IfNot.Action.ThrowsException(() => result = v.Clamp(min, max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

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
