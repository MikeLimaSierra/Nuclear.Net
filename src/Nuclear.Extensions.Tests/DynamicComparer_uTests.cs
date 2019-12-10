using System;
using System.Collections;
using System.Collections.Generic;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class DynamicComparer_uTests {

        [TestMethod]
        void FromDelegate() {

            IComparer comp = null;

            Test.If.Action.ThrowsException(() => comp = DynamicComparer.FromDelegate(null), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "compare");

            Test.IfNot.Action.ThrowsException(() => comp = DynamicComparer.FromDelegate((x, y) => 21), out Exception ex2);

        }

        [TestMethod]
        void FromDelegateT() {

            IComparer<Dummy> comp = null;
            Int32 result = 0;

            Test.If.Action.ThrowsException(() => comp = DynamicComparer.FromDelegate(null as Comparison<Dummy>), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "compare");

            Test.IfNot.Action.ThrowsException(() => comp = DynamicComparer.FromDelegate<Dummy>((x, y) => 42), out Exception ex2);

            result = comp.Compare(0, 1);
            Test.If.Value.Equals(result, 42);

        }

        [TestMethod]
        void FromComparer() {

            IComparer<Dummy> comp = null;
            Int32 result = 0;

            Test.If.Action.ThrowsException(() => comp = DynamicComparer.FromComparer<Dummy>(null as IComparer), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "comparer");

            Test.IfNot.Action.ThrowsException(() => comp = DynamicComparer.FromComparer<Dummy>(DynamicComparer.FromDelegate((x, y) => 42)), out Exception ex2);

            result = comp.Compare(0, 1);
            Test.If.Value.Equals(result, 42);

        }

        [TestMethod]
        void FromIComparable() {

            IComparer comp = null;
            Int32 result = 0;

            Test.IfNot.Action.ThrowsException(() => comp = DynamicComparer.FromIComparable<ExDummyIComparable>(), out Exception ex);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare(null, null), out ArithmeticException ex2);
            Test.If.Value.Equals(result, 0);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare(null, (ExDummyIComparableT) 0), out ex2);
            Test.If.Value.Equals(result, 0);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare((ExDummyIComparableT) 0, null), out ex2);
            Test.If.Value.Equals(result, 0);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare((ExDummyIComparableT) 0, (ExDummyIComparableT) 1), out ex2);
            Test.If.Value.Equals(result, 0);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare(null, (ExDummyIComparable) 0), out ex2);
            Test.If.Value.Equals(result, -1);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare((ExDummyIComparable) 0, null), out ex2);
            Test.If.Value.Equals(result, 1);

            Test.If.Action.ThrowsException(() => result = comp.Compare((ExDummyIComparable) 0, (ExDummyIComparable) 1), out ex2);
            Test.If.Value.Equals(ex2.Message, "'1'");

        }

        [TestMethod]
        void FromIComparableT() {

            IComparer<ExDummyIComparableT> comp = null;
            Int32 result = 0;

            Test.IfNot.Action.ThrowsException(() => comp = DynamicComparer.FromIComparableT<ExDummyIComparableT>(), out Exception ex);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare(null, null), out ArithmeticException ex2);
            Test.If.Value.Equals(result, 0);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare(null, 0), out ex2);
            Test.If.Value.Equals(result, -1);

            Test.IfNot.Action.ThrowsException(() => result = comp.Compare(0, null), out ex2);
            Test.If.Value.Equals(result, 1);

            Test.If.Action.ThrowsException(() => result = comp.Compare(0, 1), out ex2);
            Test.If.Value.Equals(ex2.Message, "'1'");

        }

    }
}
