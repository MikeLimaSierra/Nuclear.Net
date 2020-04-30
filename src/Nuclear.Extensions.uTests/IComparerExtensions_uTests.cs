using System;
using System.Collections;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparerExtensions_uTests {

        #region static resources

        static readonly IComparer _throwingComparer = DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException());

        #endregion

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsEqual(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsEqualData))]
        void IsEqual(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsEqual((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsEqualData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, true },
                new Object[] { new DummyIComparer(), 0, 1, false },
            };
        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThanThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsLessThan(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanData))]
        void LessThan(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThan((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, false },
                new Object[] { new DummyIComparer(), 0, 1, true },
                new Object[] { new DummyIComparer(), 1, 0, false },
            };
        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsLessThanOrEqual(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEqualsData))]
        void LessThanOrEquals(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThanOrEqual((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, true },
                new Object[] { new DummyIComparer(), 0, 1, true },
                new Object[] { new DummyIComparer(), 1, 0, false },
            };
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThanThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsGreaterThan(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanData))]
        void GreaterThan(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThan((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, false },
                new Object[] { new DummyIComparer(), 0, 1, false },
                new Object[] { new DummyIComparer(), 1, 0, true },
            };
        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsGreaterThanOrEqual(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEqualsData))]
        void GreaterThanOrEquals(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThanOrEqual((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanOrEqualsData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, true },
                new Object[] { new DummyIComparer(), 0, 1, false },
                new Object[] { new DummyIComparer(), 1, 0, true },
            };
        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClampedThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsClamped(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedData))]
        void IsClamped(IComparer comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClamped(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, null, null, true },
                new Object[] { new DummyIComparer(), 0, null, 1, true },
                new Object[] { new DummyIComparer(), 0, -1, null, true },
                new Object[] { new DummyIComparer(), 0, -1, 1, true },
                new Object[] { new DummyIComparer(), 0, 1, -1, true },
                new Object[] { new DummyIComparer(), 0, 0, 1, true },
                new Object[] { new DummyIComparer(), 0, -1, 0, true },
                new Object[] { new DummyIComparer(), 0, 0, 0, true },
                new Object[] { new DummyIComparer(), 0, 1, 2, false },
                new Object[] { new DummyIComparer(), 0, -2, -1, false },
            };
        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusiveThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsClampedExclusive(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusiveData))]
        void IsClampedExclusive(IComparer comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClampedExclusive(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedExclusiveData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, null, null, true },
                new Object[] { new DummyIComparer(), 0, null, 1, true },
                new Object[] { new DummyIComparer(), 0, -1, null, true },
                new Object[] { new DummyIComparer(), 0, -1, 1, true },
                new Object[] { new DummyIComparer(), 0, 1, -1, true },
                new Object[] { new DummyIComparer(), 0, 0, 1, false },
                new Object[] { new DummyIComparer(), 0, -1, 0, false },
                new Object[] { new DummyIComparer(), 0, 0, 0, false },
                new Object[] { new DummyIComparer(), 0, 1, 2, false },
                new Object[] { new DummyIComparer(), 0, -2, -1, false },
            };
        }

        #endregion

        #region Clamp

        [TestMethod]
        void ClampThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.Clamp(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(ClampData))]
        void Clamp(IComparer comparer, Int32? v, Int32? min, Int32? max, Int32 expected) {

            Object result = default;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Clamp(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, (Dummy) expected, comparer);

        }

        IEnumerable<Object[]> ClampData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, null, null, 0 },
                new Object[] { new DummyIComparer(), 0, null, 1, 0 },
                new Object[] { new DummyIComparer(), 0, -1, null, 0 },
                new Object[] { new DummyIComparer(), 0, -1, 1, 0 },
                new Object[] { new DummyIComparer(), 0, 1, -1, 0 },
                new Object[] { new DummyIComparer(), 0, 0, 1, 0 },
                new Object[] { new DummyIComparer(), 0, -1, 0, 0 },
                new Object[] { new DummyIComparer(), 0, 0, 0, 0 },
                new Object[] { new DummyIComparer(), 0, 1, 2, 1 },
                new Object[] { new DummyIComparer(), 0, -2, -1, -1 },
            };
        }

        #endregion

        #region Min

        [TestMethod]
        void MinThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.Min(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(MinData))]
        void Min(IComparer comparer, Int32 x, Int32 y, Int32 expected) {

            Object result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Min((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, (Dummy) expected, comparer);

        }

        IEnumerable<Object[]> MinData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, 0 },
                new Object[] { new DummyIComparer(), 0, 1, 0 },
                new Object[] { new DummyIComparer(), 1, 0, 0 },
            };
        }

        #endregion

        #region Max

        [TestMethod]
        void MaxThrows() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.Max(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(MaxData))]
        void Max(IComparer comparer, Int32 x, Int32 y, Int32 expected) {

            Object result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Max((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, (Dummy) expected, comparer);

        }

        IEnumerable<Object[]> MaxData() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, 0 },
                new Object[] { new DummyIComparer(), 0, 1, 1 },
                new Object[] { new DummyIComparer(), 1, 0, 1 },
            };
        }

        #endregion

    }
}
