using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IComparerExtensions_uTests {

        #region IsEqual

        [TestMethod]
        void IsEqualThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).IsEqual(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).IsEqual(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsEqual() {

            DDTIsEqual<Dummy>((new DummyIComparer(), 0, 0), true);
            DDTIsEqual<Dummy>((new DummyIComparer(), 0, 1), false);

        }

        void DDTIsEqual<T>((IComparer comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.IsEqual({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsEqual(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, _file, _method);

        }

        #endregion

        #region LessThan

        [TestMethod]
        void LessThanThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).LessThan(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).LessThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void LessThan() {

            DDTLessThan<Dummy>((new DummyIComparer(), 0, 0), false);
            DDTLessThan<Dummy>((new DummyIComparer(), 0, 1), true);
            DDTLessThan<Dummy>((new DummyIComparer(), 1, 0), false);

        }

        void DDTLessThan<T>((IComparer comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.LessThan({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.LessThan(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, _file, _method);

        }

        #endregion

        #region LessThanOrEquals

        [TestMethod]
        void LessThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).LessThanOrEquals(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).LessThanOrEquals(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void LessThanOrEquals() {

            DDTLessThanOrEquals<Dummy>((new DummyIComparer(), 0, 0), true);
            DDTLessThanOrEquals<Dummy>((new DummyIComparer(), 0, 1), true);
            DDTLessThanOrEquals<Dummy>((new DummyIComparer(), 1, 0), false);

        }

        void DDTLessThanOrEquals<T>((IComparer comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.LessThanOrEquals({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.LessThanOrEquals(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, _file, _method);

        }

        #endregion

        #region GreaterThan

        [TestMethod]
        void GreaterThanThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).GreaterThan(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).GreaterThan(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void GreaterThan() {

            DDTGreaterThan<Dummy>((new DummyIComparer(), 0, 0), false);
            DDTGreaterThan<Dummy>((new DummyIComparer(), 0, 1), false);
            DDTGreaterThan<Dummy>((new DummyIComparer(), 1, 0), true);

        }

        void DDTGreaterThan<T>((IComparer comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.GreaterThan({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.GreaterThan(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, _file, _method);

        }

        #endregion

        #region GreaterThanOrEquals

        [TestMethod]
        void GreaterThanOrEqualsThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).GreaterThanOrEquals(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).GreaterThanOrEquals(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void GreaterThanOrEquals() {

            DDTGreaterThanOrEquals<Dummy>((new DummyIComparer(), 0, 0), true);
            DDTGreaterThanOrEquals<Dummy>((new DummyIComparer(), 0, 1), false);
            DDTGreaterThanOrEquals<Dummy>((new DummyIComparer(), 1, 0), true);

        }

        void DDTGreaterThanOrEquals<T>((IComparer comparer, T x, T y) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.GreaterThanOrEquals({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.GreaterThanOrEquals(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, _file, _method);

        }

        #endregion

        #region IsClamped

        [TestMethod]
        void IsClampedThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).IsClamped(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).IsClamped(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsClamped() {

            DDTIsClamped<Dummy>((new DummyIComparer(), 0, null, null), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, null, 1), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, -1, null), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, -1, 1), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, 1, -1), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, 0, 1), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, -1, 0), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, 0, 0), true);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, 1, 2), false);
            DDTIsClamped<Dummy>((new DummyIComparer(), 0, -2, -1), false);

        }

        void DDTIsClamped<T>((IComparer comparer, T v, T min, T max) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.IsClamped({input.v.Format()}, {input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsClamped(input.v, input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, _file, _method);

        }

        #endregion

        #region IsClampedExclusive

        [TestMethod]
        void IsClampedExclusiveThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).IsClampedExclusive(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).IsClampedExclusive(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void IsClampedExclusive() {

            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, null, null), true);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, null, 1), true);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, -1, null), true);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, -1, 1), true);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, 1, -1), true);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, 0, 1), false);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, -1, 0), false);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, 0, 0), false);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, 1, 2), false);
            DDTIsClampedExclusive<Dummy>((new DummyIComparer(), 0, -2, -1), false);

        }

        void DDTIsClampedExclusive<T>((IComparer comparer, T v, T min, T max) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.comparer.Format()}.IsClampedExclusive({input.v.Format()}, {input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.IsClampedExclusive(input.v, input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, _file, _method);

        }

        #endregion

        #region Clamp

        [TestMethod]
        void ClampThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).Clamp(0, 0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).Clamp(0, 0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Clamp() {

            DDTClamp<Dummy>((new DummyIComparer(), 0, null, null), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, null, 1), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, -1, null), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, -1, 1), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, 1, -1), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, 0, 1), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, -1, 0), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, 0, 0), 0);
            DDTClamp<Dummy>((new DummyIComparer(), 0, 1, 2), 1);
            DDTClamp<Dummy>((new DummyIComparer(), 0, -2, -1), -1);

        }

        void DDTClamp<T>((IComparer comparer, T v, T min, T max) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Object result = input.v;

            Test.Note($"{input.comparer.Format()}.Clamp({input.v.Format()}, {input.min.Format()}, {input.max.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Clamp(input.v, input.min, input.max), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, input.comparer, _file, _method);

        }

        #endregion

        #region Min

        [TestMethod]
        void MinThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).Min(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).Min(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Min() {

            DDTMin<Dummy>((new DummyIComparer(), 0, 0), 0);
            DDTMin<Dummy>((new DummyIComparer(), 0, 1), 0);
            DDTMin<Dummy>((new DummyIComparer(), 1, 0), 0);

        }

        void DDTMin<T>((IComparer comparer, T x, T y) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Object result = default;

            Test.Note($"{input.comparer.Format()}.Min({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Min(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, input.comparer, _file, _method);

        }

        #endregion

        #region Max

        [TestMethod]
        void MaxThrows() {

            Test.If.Action.ThrowsException(() => (null as IComparer).Max(0, 0), out ArgumentNullException ex1);
            Test.If.Action.ThrowsException(() => DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException()).Max(0, 0), out NotImplementedException ex2);

        }

        [TestMethod]
        void Max() {

            DDTMax<Dummy>((new DummyIComparer(), 0, 0), 0);
            DDTMax<Dummy>((new DummyIComparer(), 0, 1), 1);
            DDTMax<Dummy>((new DummyIComparer(), 1, 0), 1);

        }

        void DDTMax<T>((IComparer comparer, T x, T y) input, T expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Object result = default;

            Test.Note($"{input.comparer.Format()}.Max({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.comparer.Max(input.x, input.y), out Exception ex, _file, _method);
            Test.If.Value.Equals(result, expected, input.comparer, _file, _method);

        }

        #endregion

    }
}
