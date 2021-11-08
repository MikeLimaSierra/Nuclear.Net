using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparableExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqual_Throws() {

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsEqual(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsEqual_Data))]
        void IsEqual(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsLessThan(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThan_Data))]
        void LessThan(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsLessThanOrEqual(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEquals_Data))]
        void LessThanOrEquals(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsGreaterThan(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThan_Data))]
        void GreaterThan(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsGreaterThanOrEqual(null, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEquals_Data))]
        void GreaterThanOrEquals(IComparable x, Object y, Boolean expected) {

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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsClamped(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClamped_Data))]
        void IsClamped(IComparable v, Object min, Object max, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = v.IsClamped(min, max), out Exception ex);
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

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsClampedExclusive(null, 0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusive_Data))]
        void IsClampedExclusive(IComparable v, Object min, Object max, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = v.IsClampedExclusive(min, max), out Exception ex);
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

            Test.If.Action.ThrowsException(() => IComparableExtensions.Clamp<DummyIComparable>(null, 0, 0), out ArgumentNullException ex);

        }

        [TestMethod]
        [TestData(nameof(Clamp_Data))]
        void Clamp(IComparable v, IComparable min, IComparable max, IComparable expected) {

            IComparable result = default;

            Test.IfNot.Action.ThrowsException(() => result = v.Clamp(min, max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

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
