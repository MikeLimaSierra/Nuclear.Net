using System;
using System.Collections;
using System.Collections.Generic;

namespace Nuclear.Extensions {

    #region dummy types

    internal class DummyIEquatableT : Dummy, IEquatable<DummyIEquatableT> {
        internal DummyIEquatableT(Int32 value) : base(value) { }

        public Boolean Equals(DummyIEquatableT other) {
            if(other == null) { return false; }

            return Value.Equals(other.Value);
        }

        public override Boolean Equals(Object obj) {
            if(obj is DummyIEquatableT dummy) { return this == dummy; }

            return base.Equals(obj);
        }

        public override Int32 GetHashCode() => base.GetHashCode();

        public static implicit operator DummyIEquatableT(Int32 num) => new DummyIEquatableT(num);

        public static Boolean operator ==(DummyIEquatableT left, DummyIEquatableT right) => new DummyIEqualityComparerT().Equals(left, right);

        public static Boolean operator !=(DummyIEquatableT left, DummyIEquatableT right) => !new DummyIEqualityComparerT().Equals(left, right);
    }

    internal class DummyIComparable : Dummy, IComparable {
        internal DummyIComparable(Int32 value) : base(value) { }

        public Int32 CompareTo(Object obj) => Value.CompareTo((obj as DummyIComparable).Value);

        public static implicit operator DummyIComparable(Int32 num) => new DummyIComparable(num);
    }

    internal class DummyIComparableT : Dummy, IComparable<DummyIComparableT> {
        internal DummyIComparableT(Int32 value) : base(value) { }

        public Int32 CompareTo(DummyIComparableT other) => Value.CompareTo(other.Value);

        public static implicit operator DummyIComparableT(Int32 num) => new DummyIComparableT(num);
    }

    internal class EXDummyIEquatableT : Dummy, IEquatable<EXDummyIEquatableT> {
        internal EXDummyIEquatableT(Int32 value) : base(value) { }

        public Boolean Equals(EXDummyIEquatableT other) => throw new ArithmeticException(other.Format());

        public override Int32 GetHashCode() => Value.GetHashCode();

        public static implicit operator EXDummyIEquatableT(Int32 num) => new EXDummyIEquatableT(num);
    }

    internal class ExDummyIComparable : Dummy, IComparable {
        internal ExDummyIComparable(Int32 value) : base(value) { }

        public Int32 CompareTo(Object obj) => throw new ArithmeticException(obj.Format());

        public static implicit operator ExDummyIComparable(Int32 num) => new ExDummyIComparable(num);
    }

    internal class ExDummyIComparableT : Dummy, IComparable<ExDummyIComparableT> {
        internal ExDummyIComparableT(Int32 value) : base(value) { }

        public Int32 CompareTo(ExDummyIComparableT other) => throw new ArithmeticException(other.Format());

        public static implicit operator ExDummyIComparableT(Int32 num) => new ExDummyIComparableT(num);
    }

    internal class Dummy {
        internal Int32 Value { get; private set; }

        internal Dummy(Int32 value) { Value = value; }

        public override String ToString() => Value.ToString();

        public static implicit operator Dummy(Int32 num) => new Dummy(num);
    }

    #endregion

    #region dummy comparers

    internal class DummyComparerT : Comparer<Dummy> {
        public override Int32 Compare(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? 0 : -Compare(y, x);
            }

            return y == null ? 1 : x.Value.CompareTo(y.Value);
        }
    }

    internal class DummyIComparer : IComparer {
        public Int32 Compare(Object x, Object y) {
            if(x == null) {
                return y == null ? 0 : -Compare(y, x);
            }

            return y == null ? 1 : (x as Dummy).Value.CompareTo((y as Dummy).Value);
        }
    }

    internal class DummyIComparerT : IComparer<Dummy> {
        public Int32 Compare(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? 0 : -Compare(y, x);
            }

            return y == null ? 1 : x.Value.CompareTo(y.Value);
        }
    }

    internal class ThrowingComparer : Comparer<Dummy> {
        public override Int32 Compare(Dummy x, Dummy y) => throw new NotImplementedException();
    }

    internal class DummyEqualityComparer : EqualityComparer<Dummy> {
        public override Boolean Equals(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : x.Value.Equals(y.Value);
        }

        public override Int32 GetHashCode(Dummy obj) => (obj as Dummy).Value;
    }

    internal class DummyIEqualityComparer : IEqualityComparer {
        public new Boolean Equals(Object x, Object y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : (x as Dummy).Value.Equals((y as Dummy).Value);
        }

        public Int32 GetHashCode(Object obj) => (obj as Dummy).Value;
    }

    internal class DummyIEqualityComparerT : IEqualityComparer<Dummy> {
        public Boolean Equals(Dummy x, Dummy y) {
            if(x == null) {
                return y == null ? true : y.Equals(x);
            }

            return y == null ? false : x.Value.Equals(y.Value);
        }

        public Int32 GetHashCode(Dummy obj) => obj.Value;
    }

    internal class ThrowingEqualityComparer : EqualityComparer<Dummy> {
        public override Boolean Equals(Dummy x, Dummy y) => throw new NotImplementedException();
        public override Int32 GetHashCode(Dummy obj) => throw new NotImplementedException();
    }

    #endregion

}
