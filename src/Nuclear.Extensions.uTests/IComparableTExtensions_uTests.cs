using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparableTExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => IComparableTExtensions.IsEqual((null as DummyIComparableT), 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void IsEqual() {

            DDTIsEqual(((DummyIComparableT) 0, 0), true);
            DDTIsEqual(((DummyIComparableT) 0, 1), false);

        }

        void DDTIsEqual<T>((IComparable<T> x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;

            Test.Note($"{input.x.Format()}.IsEqual({input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.x.IsEqual(input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThanThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyIComparableT).IsLessThan(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void LessThan() {

            DDTLessThan(((DummyIComparableT) 0, 0), false);
            DDTLessThan(((DummyIComparableT) 0, 1), true);
            DDTLessThan(((DummyIComparableT) 1, 0), false);

        }

        void DDTLessThan<T>((IComparable<T> x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;

            Test.Note($"{input.x.Format()}.LessThan({input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.x.IsLessThan(input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyIComparableT).IsLessThanOrEqual(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void LessThanOrEquals() {

            DDTLessThanOrEquals(((DummyIComparableT) 0, 0), true);
            DDTLessThanOrEquals(((DummyIComparableT) 0, 1), true);
            DDTLessThanOrEquals(((DummyIComparableT) 1, 0), false);

        }

        void DDTLessThanOrEquals<T>((IComparable<T> x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;

            Test.Note($"{input.x.Format()}.LessThanOrEquals({input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.x.IsLessThanOrEqual(input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThanThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyIComparableT).IsGreaterThan(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void GreaterThan() {

            DDTGreaterThan(((DummyIComparableT) 0, 0), false);
            DDTGreaterThan(((DummyIComparableT) 0, 1), false);
            DDTGreaterThan(((DummyIComparableT) 1, 0), true);

        }

        void DDTGreaterThan<T>((IComparable<T> x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;

            Test.Note($"{input.x.Format()}.GreaterThan({input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.x.IsGreaterThan(input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyIComparableT).IsGreaterThanOrEqual(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void GreaterThanOrEquals() {

            DDTGreaterThanOrEquals(((DummyIComparableT) 0, 0), true);
            DDTGreaterThanOrEquals(((DummyIComparableT) 0, 1), false);
            DDTGreaterThanOrEquals(((DummyIComparableT) 1, 0), true);

        }

        void DDTGreaterThanOrEquals<T>((IComparable<T> x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;

            Test.Note($"{input.x.Format()}.GreaterThanOrEquals({input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.x.IsGreaterThanOrEqual(input.y), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClampedThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyIComparableT).IsClamped(0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void IsClamped() {

            DDTIsClamped(((DummyIComparableT) 0, null, null), true);
            DDTIsClamped(((DummyIComparableT) 0, null, 1), true);
            DDTIsClamped(((DummyIComparableT) 0, -1, null), true);
            DDTIsClamped(((DummyIComparableT) 0, -1, 1), true);
            DDTIsClamped(((DummyIComparableT) 0, 1, -1), false);
            DDTIsClamped(((DummyIComparableT) 0, 0, 1), true);
            DDTIsClamped(((DummyIComparableT) 0, -1, 0), true);
            DDTIsClamped(((DummyIComparableT) 0, 0, 0), true);
            DDTIsClamped(((DummyIComparableT) 0, 1, 2), false);
            DDTIsClamped(((DummyIComparableT) 0, -2, -1), false);

        }

        void DDTIsClamped<T>((IComparable<T> v, T min, T max) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;

            Test.Note($"{input.v.Format()}.IsClamped({input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.v.IsClamped(input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusiveThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyIComparableT).IsClampedExclusive(0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void IsClampedExclusive() {

            DDTIsClampedExclusive(((DummyIComparableT) 0, null, null), true);
            DDTIsClampedExclusive(((DummyIComparableT) 0, null, 1), true);
            DDTIsClampedExclusive(((DummyIComparableT) 0, -1, null), true);
            DDTIsClampedExclusive(((DummyIComparableT) 0, -1, 1), true);
            DDTIsClampedExclusive(((DummyIComparableT) 0, 1, -1), false);
            DDTIsClampedExclusive(((DummyIComparableT) 0, 0, 1), false);
            DDTIsClampedExclusive(((DummyIComparableT) 0, -1, 0), false);
            DDTIsClampedExclusive(((DummyIComparableT) 0, 0, 0), false);
            DDTIsClampedExclusive(((DummyIComparableT) 0, 1, 2), false);
            DDTIsClampedExclusive(((DummyIComparableT) 0, -2, -1), false);

        }

        void DDTIsClampedExclusive<T>((IComparable<T> v, T min, T max) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;

            Test.Note($"{input.v.Format()}.IsClampedExclusive({input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.v.IsClampedExclusive(input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region Clamp

        [TestMethod]
        void ClampThrows() {

            Test.If.Action.ThrowsException(() => (null as DummyIComparableT).Clamp(0, 0), out ArgumentNullException ex);

        }

        [TestMethod]
        void Clamp() {

            DDTClamp<DummyIComparableT>((0, null, null), 0);
            DDTClamp<DummyIComparableT>((0, null, 1), 0);
            DDTClamp<DummyIComparableT>((0, -1, null), 0);
            DDTClamp<DummyIComparableT>((0, -1, 1), 0);
            DDTClamp<DummyIComparableT>((0, 1, -1), 0);
            DDTClamp<DummyIComparableT>((0, 0, 1), 0);
            DDTClamp<DummyIComparableT>((0, -1, 0), 0);
            DDTClamp<DummyIComparableT>((0, 0, 0), 0);
            DDTClamp<DummyIComparableT>((0, 1, 2), 1);
            DDTClamp<DummyIComparableT>((0, -2, -1), -1);

        }

        void DDTClamp<T>((T v, T min, T max) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable<T> {

            T result = default;

            Test.Note($"{input.v.Format()}.Clamp({input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.v.Clamp(input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

    }

}
