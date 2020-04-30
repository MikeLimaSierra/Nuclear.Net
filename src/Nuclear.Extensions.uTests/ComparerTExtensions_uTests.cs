using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class ComparerTExtensions_uTests {

        #region static resources

        static readonly Comparer<Dummy> _throwingComparer = new ThrowingComparer();

        #endregion

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.IsEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsEqualData))]
        void IsEqual(Comparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsEqual(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsEqualData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, 0, true },
                new Object[] { new DummyComparerT(), 0, 1, false },
            };
        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThanThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.IsLessThan<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanData))]
        void LessThan(Comparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThan(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, 0, false },
                new Object[] { new DummyComparerT(), 0, 1, true },
                new Object[] { new DummyComparerT(), 1, 0, false },
            };
        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.IsLessThanOrEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEqualsData))]
        void LessThanOrEquals(Comparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThanOrEqual(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, 0, true },
                new Object[] { new DummyComparerT(), 0, 1, true },
                new Object[] { new DummyComparerT(), 1, 0, false },
            };
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThanThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.IsGreaterThan<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanData))]
        void GreaterThan(Comparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThan(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, 0, false },
                new Object[] { new DummyComparerT(), 0, 1, false },
                new Object[] { new DummyComparerT(), 1, 0, true },
            };
        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.IsGreaterThanOrEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEqualsData))]
        void GreaterThanOrEquals(Comparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThanOrEqual(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, 0, true },
                new Object[] { new DummyComparerT(), 0, 1, false },
                new Object[] { new DummyComparerT(), 1, 0, true },
            };
        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClampedThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.IsClamped<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedData))]
        void IsClamped(Comparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClamped(v, min, max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, null, null, true },
                new Object[] { new DummyComparerT(), 0, null, 1, true },
                new Object[] { new DummyComparerT(), 0, -1, null, true },
                new Object[] { new DummyComparerT(), 0, -1, 1, true },
                new Object[] { new DummyComparerT(), 0, 1, -1, true },
                new Object[] { new DummyComparerT(), 0, 0, 1, true },
                new Object[] { new DummyComparerT(), 0, -1, 0, true },
                new Object[] { new DummyComparerT(), 0, 0, 0, true },
                new Object[] { new DummyComparerT(), 0, 1, 2, false },
                new Object[] { new DummyComparerT(), 0, -2, -1, false },
            };
        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusiveThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.IsClampedExclusive<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusiveData))]
        void IsClampedExclusive(Comparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClampedExclusive(v, min, max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedExclusiveData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, null, null, true },
                new Object[] { new DummyComparerT(), 0, null, 1, true },
                new Object[] { new DummyComparerT(), 0, -1, null, true },
                new Object[] { new DummyComparerT(), 0, -1, 1, true },
                new Object[] { new DummyComparerT(), 0, 1, -1, true },
                new Object[] { new DummyComparerT(), 0, 0, 1, false },
                new Object[] { new DummyComparerT(), 0, -1, 0, false },
                new Object[] { new DummyComparerT(), 0, 0, 0, false },
                new Object[] { new DummyComparerT(), 0, 1, 2, false },
                new Object[] { new DummyComparerT(), 0, -2, -1, false },
            };
        }

        #endregion

        #region Clamp

        [TestMethod]
        void ClampThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.Clamp<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(ClampData))]
        void Clamp(Comparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Int32 expected) {

            Dummy result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Clamp(v, min, max), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> ClampData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, null, null, 0 },
                new Object[] { new DummyComparerT(), 0, null, 1, 0 },
                new Object[] { new DummyComparerT(), 0, -1, null, 0 },
                new Object[] { new DummyComparerT(), 0, -1, 1, 0 },
                new Object[] { new DummyComparerT(), 0, 1, -1, 0 },
                new Object[] { new DummyComparerT(), 0, 0, 1, 0 },
                new Object[] { new DummyComparerT(), 0, -1, 0, 0 },
                new Object[] { new DummyComparerT(), 0, 0, 0, 0 },
                new Object[] { new DummyComparerT(), 0, 1, 2, 1 },
                new Object[] { new DummyComparerT(), 0, -2, -1, -1 },
            };
        }

        #endregion

        #region Min

        [TestMethod]
        void MinThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.Min<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(MinData))]
        void Min(Comparer<Dummy> comparer, Int32? x, Int32? y, Int32 expected) {

            Dummy result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Min(x, y), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> MinData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, 0, 0 },
                new Object[] { new DummyComparerT(), 0, 1, 0 },
                new Object[] { new DummyComparerT(), 1, 0, 0 },
            };
        }

        #endregion

        #region Max

        [TestMethod]
        void MaxThrows() {

            Test.If.Action.ThrowsException(() => ComparerTExtensions.Max<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(MaxData))]
        void Max(Comparer<Dummy> comparer, Int32? x, Int32? y, Int32 expected) {

            Dummy result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Max(x, y), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected);

        }

        IEnumerable<Object[]> MaxData() {
            return new List<Object[]>() {
                new Object[] { new DummyComparerT(), 0, 0, 0 },
                new Object[] { new DummyComparerT(), 0, 1, 1 },
                new Object[] { new DummyComparerT(), 1, 0, 1 },
            };
        }

        #endregion

    }
}
