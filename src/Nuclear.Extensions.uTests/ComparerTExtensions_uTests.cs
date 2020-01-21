using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class ComparerTExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => (null as Comparer<Dummy>).IsEqual(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsEqual() {

            DDTIsEqual((new DummyComparerT(), 0, 0), true);
            DDTIsEqual((new DummyComparerT(), 0, 1), false);

        }

        void DDTIsEqual<T>((Comparer<T> comparer, T x, T y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).IsLessThan(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().IsLessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void LessThan() {

            DDTLessThan((new DummyComparerT(), 0, 0), false);
            DDTLessThan((new DummyComparerT(), 0, 1), true);
            DDTLessThan((new DummyComparerT(), 1, 0), false);

        }

        void DDTLessThan<T>((Comparer<T> comparer, T x, T y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).IsLessThanOrEqual(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().IsLessThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void LessThanOrEquals() {

            DDTLessThanOrEquals((new DummyComparerT(), 0, 0), true);
            DDTLessThanOrEquals((new DummyComparerT(), 0, 1), true);
            DDTLessThanOrEquals((new DummyComparerT(), 1, 0), false);

        }

        void DDTLessThanOrEquals<T>((Comparer<T> comparer, T x, T y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).IsGreaterThan(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().IsGreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void GreaterThan() {

            DDTGreaterThan((new DummyComparerT(), 0, 0), false);
            DDTGreaterThan((new DummyComparerT(), 0, 1), false);
            DDTGreaterThan((new DummyComparerT(), 1, 0), true);

        }

        void DDTGreaterThan<T>((Comparer<T> comparer, T x, T y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).IsGreaterThanOrEqual(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().IsGreaterThanOrEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void GreaterThanOrEquals() {

            DDTGreaterThanOrEquals((new DummyComparerT(), 0, 0), true);
            DDTGreaterThanOrEquals((new DummyComparerT(), 0, 1), false);
            DDTGreaterThanOrEquals((new DummyComparerT(), 1, 0), true);

        }

        void DDTGreaterThanOrEquals<T>((Comparer<T> comparer, T x, T y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).IsClamped(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsClamped() {

            DDTIsClamped((new DummyComparerT(), 0, null, null), true);
            DDTIsClamped((new DummyComparerT(), 0, null, 1), true);
            DDTIsClamped((new DummyComparerT(), 0, -1, null), true);
            DDTIsClamped((new DummyComparerT(), 0, -1, 1), true);
            DDTIsClamped((new DummyComparerT(), 0, 1, -1), true);
            DDTIsClamped((new DummyComparerT(), 0, 0, 1), true);
            DDTIsClamped((new DummyComparerT(), 0, -1, 0), true);
            DDTIsClamped((new DummyComparerT(), 0, 0, 0), true);
            DDTIsClamped((new DummyComparerT(), 0, 1, 2), false);
            DDTIsClamped((new DummyComparerT(), 0, -2, -1), false);

        }

        void DDTIsClamped<T>((Comparer<T> comparer, T v, T min, T max) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).IsClampedExclusive(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsClampedExclusive() {

            DDTIsClampedExclusive((new DummyComparerT(), 0, null, null), true);
            DDTIsClampedExclusive((new DummyComparerT(), 0, null, 1), true);
            DDTIsClampedExclusive((new DummyComparerT(), 0, -1, null), true);
            DDTIsClampedExclusive((new DummyComparerT(), 0, -1, 1), true);
            DDTIsClampedExclusive((new DummyComparerT(), 0, 1, -1), true);
            DDTIsClampedExclusive((new DummyComparerT(), 0, 0, 1), false);
            DDTIsClampedExclusive((new DummyComparerT(), 0, -1, 0), false);
            DDTIsClampedExclusive((new DummyComparerT(), 0, 0, 0), false);
            DDTIsClampedExclusive((new DummyComparerT(), 0, 1, 2), false);
            DDTIsClampedExclusive((new DummyComparerT(), 0, -2, -1), false);

        }

        void DDTIsClampedExclusive<T>((Comparer<T> comparer, T v, T min, T max) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).Clamp(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Clamp() {

            DDTClamp((new DummyComparerT(), 0, null, null), 0);
            DDTClamp((new DummyComparerT(), 0, null, 1), 0);
            DDTClamp((new DummyComparerT(), 0, -1, null), 0);
            DDTClamp((new DummyComparerT(), 0, -1, 1), 0);
            DDTClamp((new DummyComparerT(), 0, 1, -1), 0);
            DDTClamp((new DummyComparerT(), 0, 0, 1), 0);
            DDTClamp((new DummyComparerT(), 0, -1, 0), 0);
            DDTClamp((new DummyComparerT(), 0, 0, 0), 0);
            DDTClamp((new DummyComparerT(), 0, 1, 2), 1);
            DDTClamp((new DummyComparerT(), 0, -2, -1), -1);

        }

        void DDTClamp<T>((Comparer<T> comparer, T v, T min, T max) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            T result = input.v;

            Test.Note($"{input.comparer.Format()}.Clamp({input.v.Format()}, {input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Clamp(input.v, input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, input.comparer, _file, _method);

        }

        #endregion

        #region Min

        [TestMethod]
        void MinThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).Min(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Min() {

            DDTMin((new DummyComparerT(), 0, 0), 0);
            DDTMin((new DummyComparerT(), 0, 1), 0);
            DDTMin((new DummyComparerT(), 1, 0), 0);

        }

        void DDTMin<T>((Comparer<T> comparer, T x, T y) input, T expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyComparerT).Max(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => new ThrowingComparer().Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Max() {

            DDTMax((new DummyComparerT(), 0, 0), 0);
            DDTMax((new DummyComparerT(), 0, 1), 1);
            DDTMax((new DummyComparerT(), 1, 0), 1);

        }

        void DDTMax<T>((Comparer<T> comparer, T x, T y) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            T result = default;

            Test.Note($"{input.comparer.Format()}.Max({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Max(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, input.comparer, _file, _method);

        }

        #endregion

    }
}
