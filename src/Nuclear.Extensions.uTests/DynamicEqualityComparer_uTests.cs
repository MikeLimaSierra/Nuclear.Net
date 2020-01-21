using System;
using System.Collections;
using System.Collections.Generic;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class DynamicEqualityComparer_uTests {

        [TestMethod]
        void FromDelegate() {

            IEqualityComparer comp = null;

            Test.If.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate(null, null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate(null, (obj) => 42), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate((x, y) => true, null), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "getHashCode");

            Test.IfNot.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate((x, y) => true, (obj) => 42), out Exception ex2);

        }

        [TestMethod]
        void FromDelegateT() {

            IEqualityComparer<Dummy> comp = null;
            Boolean result = false;
            Int32 hash = 0;

            Test.If.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate<Dummy>(null, null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate<Dummy>(null, (obj) => 42), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate<Dummy>((x, y) => true, null), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "getHashCode");

            Test.IfNot.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromDelegate<Dummy>((x, y) => true, (obj) => 42), out Exception ex2);

            result = comp.Equals(0, 1);
            Test.If.Value.IsEqual(result, true);

            hash = comp.GetHashCode(0);
            Test.If.Value.IsEqual(hash, 42);

        }

        [TestMethod]
        void FromComparer() {

            IEqualityComparer<Dummy> comp = null;
            Boolean result = false;
            Int32 hash = 0;

            Test.If.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromComparer<Dummy>(null as IEqualityComparer), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "comparer");

            Test.IfNot.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromComparer<Dummy>(DynamicEqualityComparer.FromDelegate((x, y) => true, (obj) => 42)), out Exception ex2);

            result = comp.Equals(0, 1);
            Test.If.Value.IsEqual(result, true);

            hash = comp.GetHashCode(0);
            Test.If.Value.IsEqual(hash, 42);

        }

        [TestMethod]
        void FromIEquatable() {

            IEqualityComparer<EXDummyIEquatableT> comp = null;
            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => comp = DynamicEqualityComparer.FromIEquatable<EXDummyIEquatableT>(), out Exception ex);

            Test.IfNot.Action.ThrowsException(() => result = comp.Equals(null, null), out ArithmeticException ex2);
            Test.If.Value.IsTrue(result);

            Test.IfNot.Action.ThrowsException(() => result = comp.Equals(null, 0), out ex2);
            Test.If.Value.IsFalse(result);

            Test.IfNot.Action.ThrowsException(() => result = comp.Equals(0, null), out ex2);
            Test.If.Value.IsFalse(result);

            Test.If.Action.ThrowsException(() => result = comp.Equals(0, 1), out ex2);
            Test.If.Value.IsEqual(ex2.Message, "'1'");

        }

    }
}
