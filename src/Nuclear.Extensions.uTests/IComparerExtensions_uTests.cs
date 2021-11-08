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
        void IsEqual_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsEqual(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsEqual_Data))]
        void IsEqual(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsEqual((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsEqual_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, true },
                new Object[] { new DummyIComparer(), 0, 1, false },
            };
        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThan_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsLessThan(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThan_Data))]
        void LessThan(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThan((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThan_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, false },
                new Object[] { new DummyIComparer(), 0, 1, true },
                new Object[] { new DummyIComparer(), 1, 0, false },
            };
        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEquals_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsLessThanOrEqual(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsLessThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(LessThanOrEquals_Data))]
        void LessThanOrEquals(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsLessThanOrEqual((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> LessThanOrEquals_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, true },
                new Object[] { new DummyIComparer(), 0, 1, true },
                new Object[] { new DummyIComparer(), 1, 0, false },
            };
        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThan_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsGreaterThan(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThan_Data))]
        void GreaterThan(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThan((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThan_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, false },
                new Object[] { new DummyIComparer(), 0, 1, false },
                new Object[] { new DummyIComparer(), 1, 0, true },
            };
        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEquals_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsGreaterThanOrEqual(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsGreaterThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(GreaterThanOrEquals_Data))]
        void GreaterThanOrEquals(IComparer comparer, Int32 x, Int32 y, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsGreaterThanOrEqual((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> GreaterThanOrEquals_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, true },
                new Object[] { new DummyIComparer(), 0, 1, false },
                new Object[] { new DummyIComparer(), 1, 0, true },
            };
        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClamped_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsClamped(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClamped_Data))]
        void IsClamped(IComparer comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClamped(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClamped_Data() {
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
        void IsClampedExclusive_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.IsClampedExclusive(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(IsClampedExclusive_Data))]
        void IsClampedExclusive(IComparer comparer, Int32? v, Int32? min, Int32? max, Boolean expected) {

            Boolean result = false;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.IsClampedExclusive(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> IsClampedExclusive_Data() {
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
        void Clamp_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.Clamp(null, 0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(Clamp_Data))]
        void Clamp(IComparer comparer, Int32? v, Int32? min, Int32? max, Int32 expected) {

            Object result = default;
            Dummy _v = v.HasValue ? new Dummy(v.Value) : null;
            Dummy _min = min.HasValue ? new Dummy(min.Value) : null;
            Dummy _max = max.HasValue ? new Dummy(max.Value) : null;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Clamp(_v, _min, _max), out Exception ex);
            Test.If.Value.IsEqual(result, (Dummy) expected, comparer);

        }

        IEnumerable<Object[]> Clamp_Data() {
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
        void Min_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.Min(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(Min_Data))]
        void Min(IComparer comparer, Int32 x, Int32 y, Int32 expected) {

            Object result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Min((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, (Dummy) expected, comparer);

        }

        IEnumerable<Object[]> Min_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, 0 },
                new Object[] { new DummyIComparer(), 0, 1, 0 },
                new Object[] { new DummyIComparer(), 1, 0, 0 },
            };
        }

        #endregion

        #region Max

        [TestMethod]
        void Max_Throws() {

            Test.If.Action.ThrowsException(() => IComparerExtensions.Max(null, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => _throwingComparer.Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        [TestData(nameof(Max_Data))]
        void Max(IComparer comparer, Int32 x, Int32 y, Int32 expected) {

            Object result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Max((Dummy) x, (Dummy) y), out Exception ex);
            Test.If.Value.IsEqual(result, (Dummy) expected, comparer);

        }

        IEnumerable<Object[]> Max_Data() {
            return new List<Object[]>() {
                new Object[] { new DummyIComparer(), 0, 0, 0 },
                new Object[] { new DummyIComparer(), 0, 1, 1 },
                new Object[] { new DummyIComparer(), 1, 0, 1 },
            };
        }

        #endregion

    }
}
