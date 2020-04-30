using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparerTExtensions_uTests {

        IEnumerable<Object[]> Data() {
            return new List<Object[]>() {
                new Object[] {  },
            };
        }

        #region static resources

        static readonly IComparer<Dummy> _throwingComparer = DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException());

        #endregion

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsEqualData))]
        void IsEqual(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsEqual(new Dummy(x), new Dummy(y)), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsEqualData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, true },
                new Object[] { new DummyIComparerT(), 0, 1, false },
            };
        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThanThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsLessThan<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanData))]
        void LessThan(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThan(new Dummy(x), new Dummy(y)), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, false },
                new Object[] { new DummyIComparerT(), 0, 1, true },
                new Object[] { new DummyIComparerT(), 1, 0, false },
            };
        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsLessThanOrEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEqualsData))]
        void LessThanOrEquals(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThanOrEqual(new Dummy(x), new Dummy(y)), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, true },
                new Object[] { new DummyIComparerT(), 0, 1, true },
                new Object[] { new DummyIComparerT(), 1, 0, false },
            };
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThanThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsGreaterThan<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanData))]
        void GreaterThan(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThan(new Dummy(x), new Dummy(y)), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, false },
                new Object[] { new DummyIComparerT(), 0, 1, false },
                new Object[] { new DummyIComparerT(), 1, 0, true },
            };
        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsGreaterThanOrEqual<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEqualsData))]
        void GreaterThanOrEquals(IComparer<Dummy> comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThanOrEqual(new Dummy(x), new Dummy(y)), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, 0, true },
                new Object[] { new DummyIComparerT(), 0, 1, false },
                new Object[] { new DummyIComparerT(), 1, 0, true },
            };
        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClampedThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsClamped<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedData))]
        void IsClamped(IComparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClamped(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedData() {
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
        void IsClampedExclusiveThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.IsClampedExclusive<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusiveData))]
        void IsClampedExclusive(IComparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClampedExclusive(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedExclusiveData() {
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
        void ClampThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.Clamp<Dummy>(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(ClampData))]
        void Clamp(IComparer<Dummy> comparer, Int32? v, Int32? min, Int32? max, Int32 expected) {

            Dummy result = default;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Clamp(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result.Value, expected, comparer);

        }

        IEnumerable<Object[]> ClampData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparerT(), 0, null, null, 0 },
                new Object[] { new DummyIComparerT(), 0, null, 1, 0 },
                new Object[] { new DummyIComparerT(), 0, (-1), null, 0 },
                new Object[] { new DummyIComparerT(), 0, (-1), 1, 0 },
                new Object[] { new DummyIComparerT(), 0, 1, (-1), 0 },
                new Object[] { new DummyIComparerT(), 0, 0, 1, 0 },
                new Object[] { new DummyIComparerT(), 0, (-1), 0, 0 },
                new Object[] { new DummyIComparerT(), 0, 0, 0, 0 },
                new Object[] { new DummyIComparerT(), 0, 1, 2, 1 },
                new Object[] { new DummyIComparerT(), 0, (-2), (-1), (-1) },
            };
        }

        #endregion

        #region Min

        [TestMethod]
        void MinThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.Min<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(MinData))]
        void Min<T>(IComparer<T> comparer, T x, T y, T expected) {

            T result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Min(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected, comparer);

        }

        IEnumerable<Object[]> MinData() {
            return new List<Object[]>() {
                new Object[] { typeof(Dummy), new DummyIComparerT(), (Dummy) 0, (Dummy) 0, (Dummy) 0 },
                new Object[] { typeof(Dummy), new DummyIComparerT(), (Dummy) 0, (Dummy) 1, (Dummy) 0 },
                new Object[] { typeof(Dummy), new DummyIComparerT(), (Dummy) 1, (Dummy) 0, (Dummy) 0 },
            };
        }

        #endregion

        #region Max

        [TestMethod]
        void MaxThrows() {

            Test.If.Action.ThrowsException(() => IComparerTExtensions.Max<Dummy>(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(MaxData))]
        void Max<T>(IComparer<T> comparer, T x, T y, T expected) {

            T result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Max(x, y), out Exception ex);
            Test.If.Value.IsEqual(result, expected, comparer);

        }

        IEnumerable<Object[]> MaxData() {
            return new List<Object[]>() {
                new Object[] { typeof(Dummy), new DummyIComparerT(), (Dummy) 0, (Dummy) 0, (Dummy) 0 },
                new Object[] { typeof(Dummy), new DummyIComparerT(), (Dummy) 0, (Dummy) 1, (Dummy) 1 },
                new Object[] { typeof(Dummy), new DummyIComparerT(), (Dummy) 1, (Dummy) 0, (Dummy) 1 },
            };
        }

        #endregion

    }
}
