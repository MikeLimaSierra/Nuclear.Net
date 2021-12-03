using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparerTExtensions_uTests {

        #region static resources

        static readonly IComparer<Dummy> _throwingComparer = DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException());

        #endregion

        #region IsEqual

        [TestMethod]
        void IsEqual_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsEqual_Data))]
        void IsEqual(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsEqual(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsEqual_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, true },
                new Object[] { new DummyIComparerT(), 0, 1, false },
            };
        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThan_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsLessThan<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThan_Data))]
        void LessThan(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThan(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThan_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, false },
                new Object[] { new DummyIComparerT(), 0, 1, true },
                new Object[] { new DummyIComparerT(), 1, 0, false },
            };
        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEquals_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsLessThanOrEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEquals_Data))]
        void LessThanOrEquals(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThanOrEqual(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanOrEquals_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, true },
                new Object[] { new DummyIComparerT(), 0, 1, true },
                new Object[] { new DummyIComparerT(), 1, 0, false },
            };
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThan_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsGreaterThan<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThan_Data))]
        void GreaterThan(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThan(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThan_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, false },
                new Object[] { new DummyIComparerT(), 0, 1, false },
                new Object[] { new DummyIComparerT(), 1, 0, true },
            };
        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEquals_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsGreaterThanOrEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEquals_Data))]
        void GreaterThanOrEquals(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThanOrEqual(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanOrEquals_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, true },
                new Object[] { new DummyIComparerT(), 0, 1, false },
                new Object[] { new DummyIComparerT(), 1, 0, true },
            };
        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClamped_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsClamped<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClamped_Data))]
        void IsClamped(IComparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClamped(v, min, max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClamped_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, null, null, true },
                new Object[] { new DummyIComparerT(), 0, null, 1, true },
                new Object[] { new DummyIComparerT(), 0, -1, null, true },
                new Object[] { new DummyIComparerT(), 0, -1, 1, true },
                new Object[] { new DummyIComparerT(), 0, 1, -1, true },
                new Object[] { new DummyIComparerT(), 0, 0, 1, true },
                new Object[] { new DummyIComparerT(), 0, -1, 0, true },
                new Object[] { new DummyIComparerT(), 0, 0, 0, true },
                new Object[] { new DummyIComparerT(), 0, 1, 2, false },
                new Object[] { new DummyIComparerT(), 0, -2, -1, false },
            };
        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusive_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsClampedExclusive<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusive_Data))]
        void IsClampedExclusive(IComparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClampedExclusive(v, min, max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedExclusive_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, null, null, true },
                new Object[] { new DummyIComparerT(), 0, null, 1, true },
                new Object[] { new DummyIComparerT(), 0, -1, null, true },
                new Object[] { new DummyIComparerT(), 0, -1, 1, true },
                new Object[] { new DummyIComparerT(), 0, 1, -1, true },
                new Object[] { new DummyIComparerT(), 0, 0, 1, false },
                new Object[] { new DummyIComparerT(), 0, -1, 0, false },
                new Object[] { new DummyIComparerT(), 0, 0, 0, false },
                new Object[] { new DummyIComparerT(), 0, 1, 2, false },
                new Object[] { new DummyIComparerT(), 0, -2, -1, false },
            };
        }

        #endregion

        #region Clamp

        [TestMethod]
        void Clamp_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.Clamp<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(Clamp_Data))]
        void Clamp(IComparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Int32 expected) {

            Dummy result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Clamp(v, min, max), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> Clamp_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, null, null, 0 },
                new Object[] { new DummyIComparerT(), 0, null, 1, 0 },
                new Object[] { new DummyIComparerT(), 0, -1, null, 0 },
                new Object[] { new DummyIComparerT(), 0, -1, 1, 0 },
                new Object[] { new DummyIComparerT(), 0, 1, -1, 0 },
                new Object[] { new DummyIComparerT(), 0, 0, 1, 0 },
                new Object[] { new DummyIComparerT(), 0, -1, 0, 0 },
                new Object[] { new DummyIComparerT(), 0, 0, 0, 0 },
                new Object[] { new DummyIComparerT(), 0, 1, 2, 1 },
                new Object[] { new DummyIComparerT(), 0, -2, -1, -1 },
            };
        }

        #endregion

        #region Min

        [TestMethod]
        void Min_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.Min<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(Min_Data))]
        void Min(IComparer<Dummy> comparer, Int32 x, Int32 y, Int32 expected) {

            Dummy result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Min(x, y), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> Min_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, 0 },
                new Object[] { new DummyIComparerT(), 0, 1, 0 },
                new Object[] { new DummyIComparerT(), 1, 0, 0 },
            };
        }

        #endregion

        #region Max

        [TestMethod]
        void Max_Throws() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.Max<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(Max_Data))]
        void Max(IComparer<Dummy> comparer, Int32 x, Int32 y, Int32 expected) {

            Dummy result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Max(x, y), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> Max_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, 0 },
                new Object[] { new DummyIComparerT(), 0, 1, 1 },
                new Object[] { new DummyIComparerT(), 1, 0, 1 },
            };
        }

        #endregion

    }
}
