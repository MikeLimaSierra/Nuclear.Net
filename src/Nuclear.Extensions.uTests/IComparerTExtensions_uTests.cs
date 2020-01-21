using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparerTExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).IsEqual(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsEqual() {

            DDTIsEqual((new DummyIComparerT(), 0, 0), true);
            DDTIsEqual((new DummyIComparerT(), 0, 1), false);

        }

        void DDTIsEqual<T>((IComparer<T> comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.IsEqual({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsEqual(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThanThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).IsLessThan(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).IsLessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void LessThan() {

            DDTLessThan((new DummyIComparerT(), 0, 0), false);
            DDTLessThan((new DummyIComparerT(), 0, 1), true);
            DDTLessThan((new DummyIComparerT(), 1, 0), false);

        }

        void DDTLessThan<T>((IComparer<T> comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.LessThan({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsLessThan(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).IsLessThanOrEqual(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).IsLessThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void LessThanOrEquals() {

            DDTLessThanOrEquals((new DummyIComparerT(), 0, 0), true);
            DDTLessThanOrEquals((new DummyIComparerT(), 0, 1), true);
            DDTLessThanOrEquals((new DummyIComparerT(), 1, 0), false);

        }

        void DDTLessThanOrEquals<T>((IComparer<T> comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.LessThanOrEquals({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsLessThanOrEqual(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThanThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).IsGreaterThan(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).IsGreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void GreaterThan() {

            DDTGreaterThan((new DummyIComparerT(), 0, 0), false);
            DDTGreaterThan((new DummyIComparerT(), 0, 1), false);
            DDTGreaterThan((new DummyIComparerT(), 1, 0), true);

        }

        void DDTGreaterThan<T>((IComparer<T> comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.GreaterThan({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsGreaterThan(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).IsGreaterThanOrEqual(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).IsGreaterThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void GreaterThanOrEquals() {

            DDTGreaterThanOrEquals((new DummyIComparerT(), 0, 0), true);
            DDTGreaterThanOrEquals((new DummyIComparerT(), 0, 1), false);
            DDTGreaterThanOrEquals((new DummyIComparerT(), 1, 0), true);

        }

        void DDTGreaterThanOrEquals<T>((IComparer<T> comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.GreaterThanOrEquals({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsGreaterThanOrEqual(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClampedThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).IsClamped(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsClamped() {

            DDTIsClamped((new DummyIComparerT(), 0, null, null), true);
            DDTIsClamped((new DummyIComparerT(), 0, null, 1), true);
            DDTIsClamped((new DummyIComparerT(), 0, -1, null), true);
            DDTIsClamped((new DummyIComparerT(), 0, -1, 1), true);
            DDTIsClamped((new DummyIComparerT(), 0, 1, -1), true);
            DDTIsClamped((new DummyIComparerT(), 0, 0, 1), true);
            DDTIsClamped((new DummyIComparerT(), 0, -1, 0), true);
            DDTIsClamped((new DummyIComparerT(), 0, 0, 0), true);
            DDTIsClamped((new DummyIComparerT(), 0, 1, 2), false);
            DDTIsClamped((new DummyIComparerT(), 0, -2, -1), false);

        }

        void DDTIsClamped<T>((IComparer<T> comparer, T v, T min, T max) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.IsClamped({input.v.Format()}, {input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsClamped(input.v, input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusiveThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).IsClampedExclusive(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsClampedExclusive() {

            DDTIsClampedExclusive((new DummyIComparerT(), 0, null, null), true);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, null, 1), true);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, -1, null), true);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, -1, 1), true);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, 1, -1), true);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, 0, 1), false);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, -1, 0), false);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, 0, 0), false);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, 1, 2), false);
            DDTIsClampedExclusive((new DummyIComparerT(), 0, -2, -1), false);

        }

        void DDTIsClampedExclusive<T>((IComparer<T> comparer, T v, T min, T max) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.IsClampedExclusive({input.v.Format()}, {input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsClampedExclusive(input.v, input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region Clamp

        [TestMethod]
        void ClampThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).Clamp(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Clamp() {

            DDTClamp((new DummyIComparerT(), 0, null, null), 0);
            DDTClamp((new DummyIComparerT(), 0, null, 1), 0);
            DDTClamp((new DummyIComparerT(), 0, -1, null), 0);
            DDTClamp((new DummyIComparerT(), 0, -1, 1), 0);
            DDTClamp((new DummyIComparerT(), 0, 1, -1), 0);
            DDTClamp((new DummyIComparerT(), 0, 0, 1), 0);
            DDTClamp((new DummyIComparerT(), 0, -1, 0), 0);
            DDTClamp((new DummyIComparerT(), 0, 0, 0), 0);
            DDTClamp((new DummyIComparerT(), 0, 1, 2), 1);
            DDTClamp((new DummyIComparerT(), 0, -2, -1), -1);

        }

        void DDTClamp<T>((IComparer<T> comparer, T v, T min, T max) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            T result = default;

            Test.Note($"{input.comparer.Format()}.Clamp({input.v.Format()}, {input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Clamp(input.v, input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, input.comparer, _file, _method);

        }

        #endregion

        #region Min

        [TestMethod]
        void MinThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).Min(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Min() {

            DDTMin((new DummyIComparerT(), 0, 0), 0);
            DDTMin((new DummyIComparerT(), 0, 1), 0);
            DDTMin((new DummyIComparerT(), 1, 0), 0);

        }

        void DDTMin<T>((IComparer<T> comparer, T x, T y) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            T result = default;

            Test.Note($"{input.comparer.Format()}.Min({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Min(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, input.comparer, _file, _method);

        }

        #endregion

        #region Max

        [TestMethod]
        void MaxThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer<Dummy>).Max(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException()).Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Max() {

            DDTMax((new DummyIComparerT(), 0, 0), 0);
            DDTMax((new DummyIComparerT(), 0, 1), 1);
            DDTMax((new DummyIComparerT(), 1, 0), 1);

        }

        void DDTMax<T>((IComparer<T> comparer, T x, T y) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            T result = default;

            Test.Note($"{input.comparer.Format()}.Max({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Max(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, input.comparer, _file, _method);

        }

        #endregion

    }
}
