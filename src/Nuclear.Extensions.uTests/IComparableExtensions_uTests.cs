using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparableExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => IComparableExtensions.IsEqual((null as DummyIComparable), 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void IsEqual() {

            DDTIsEqual(((DummyIComparable) 0, (DummyIComparable) 0), true);
            DDTIsEqual(((DummyIComparable) 0, (DummyIComparable) 1), false);

        }

        void DDTIsEqual((IComparable x, Object y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyIComparable).IsLessThan(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void LessThan() {

            DDTLessThan(((DummyIComparable) 0, (DummyIComparable) 0), false);
            DDTLessThan(((DummyIComparable) 0, (DummyIComparable) 1), true);
            DDTLessThan(((DummyIComparable) 1, (DummyIComparable) 0), false);

        }

        void DDTLessThan((IComparable x, Object y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyIComparable).IsLessThanOrEqual(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void LessThanOrEquals() {

            DDTLessThanOrEquals(((DummyIComparable) 0, (DummyIComparable) 0), true);
            DDTLessThanOrEquals(((DummyIComparable) 0, (DummyIComparable) 1), true);
            DDTLessThanOrEquals(((DummyIComparable) 1, (DummyIComparable) 0), false);

        }

        void DDTLessThanOrEquals((IComparable x, Object y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyIComparable).IsGreaterThan(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void GreaterThan() {

            DDTGreaterThan(((DummyIComparable) 0, (DummyIComparable) 0), false);
            DDTGreaterThan(((DummyIComparable) 0, (DummyIComparable) 1), false);
            DDTGreaterThan(((DummyIComparable) 1, (DummyIComparable) 0), true);

        }

        void DDTGreaterThan((IComparable x, Object y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyIComparable).IsGreaterThanOrEqual(0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void GreaterThanOrEquals() {

            DDTGreaterThanOrEquals(((DummyIComparable) 0, (DummyIComparable) 0), true);
            DDTGreaterThanOrEquals(((DummyIComparable) 0, (DummyIComparable) 1), false);
            DDTGreaterThanOrEquals(((DummyIComparable) 1, (DummyIComparable) 0), true);

        }

        void DDTGreaterThanOrEquals((IComparable x, Object y) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyIComparable).IsClamped(0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void IsClamped() {

            DDTIsClamped(((DummyIComparable) 0, null, null), true);
            DDTIsClamped(((DummyIComparable) 0, null, (DummyIComparable) 1), true);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) (-1), null), true);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) (-1), (DummyIComparable) 1), true);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) 1, (DummyIComparable) (-1)), false);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) 0, (DummyIComparable) 1), true);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) (-1), (DummyIComparable) 0), true);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) 0, (DummyIComparable) 0), true);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) 1, (DummyIComparable) 2), false);
            DDTIsClamped(((DummyIComparable) 0, (DummyIComparable) (-2), (DummyIComparable) (-1)), false);

        }

        void DDTIsClamped((IComparable v, Object min, Object max) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyIComparable).IsClampedExclusive(0, 0), out ArgumentNullException ex1);

        }

        [TestMethod]
        void IsClampedExclusive() {

            DDTIsClampedExclusive(((DummyIComparable) 0, null, null), true);
            DDTIsClampedExclusive(((DummyIComparable) 0, null, (DummyIComparable) 1), true);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) (-1), null), true);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) (-1), (DummyIComparable) 1), true);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) 1, (DummyIComparable) (-1)), false);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) 0, (DummyIComparable) 1), false);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) (-1), (DummyIComparable) 0), false);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) 0, (DummyIComparable) 0), false);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) 1, (DummyIComparable) 2), false);
            DDTIsClampedExclusive(((DummyIComparable) 0, (DummyIComparable) (-2), (DummyIComparable) (-1)), false);

        }

        void DDTIsClampedExclusive((IComparable v, Object min, Object max) input, Boolean expected,
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

            Test.If.Action.ThrowsException(() => (null as DummyIComparable).Clamp(0, 0), out ArgumentNullException ex);

        }

        [TestMethod]
        void Clamp() {

            DDTClamp<DummyIComparable>((0, null, null), 0);
            DDTClamp<DummyIComparable>((0, null, 1), 0);
            DDTClamp<DummyIComparable>((0, -1, null), 0);
            DDTClamp<DummyIComparable>((0, -1, 1), 0);
            DDTClamp<DummyIComparable>((0, 0, 1), 0);
            DDTClamp<DummyIComparable>((0, -1, 0), 0);
            DDTClamp<DummyIComparable>((0, 0, 0), 0);
            DDTClamp<DummyIComparable>((0, 1, 2), 1);
            DDTClamp<DummyIComparable>((0, -2, -1), -1);

        }

        void DDTClamp<T>((T v, T min, T max) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where T : IComparable {

            T result = default;

            Test.Note($"{input.v.Format()}.Clamp({input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.v.Clamp(input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

    }

}
