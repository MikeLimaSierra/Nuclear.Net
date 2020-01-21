using System;
using System.Collections.Generic;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class InternalEqualityComparerT_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.Implements<InternalEqualityComparer<Dummy>, IEqualityComparer<Dummy>>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void Ctor() {

            IEqualityComparer<Dummy> comp = null;
            Boolean result = false;
            Int32 hash = 0;

            Test.If.Action.ThrowsException(() => comp = new InternalEqualityComparer<Dummy>(null, null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = new InternalEqualityComparer<Dummy>(null, (obj) => 42), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = new InternalEqualityComparer<Dummy>((x, y) => true, null), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "getHashCode");

            Test.IfNot.Action.ThrowsException(() => comp = new InternalEqualityComparer<Dummy>((x, y) => true, (obj) => 42), out Exception ex2);

            result = comp.Equals(0, 1);
            Test.If.Value.IsEqual(result, true);

            hash = comp.GetHashCode(0);
            Test.If.Value.IsEqual(hash, 42);

        }

        [TestMethod]
        void ComparisonInvokes() {

            IEqualityComparer<Dummy> comp = null;
            Boolean result = false;
            Int32 hash = 0;

            comp = DynamicEqualityComparer.FromDelegate<Dummy>((x, y) => throw new NotImplementedException(), (obj) => throw new NotImplementedException());
            Test.If.Action.ThrowsException(() => result = comp.Equals(0, 1), out NotImplementedException ex1);
            Test.If.Action.ThrowsException(() => hash = comp.GetHashCode(0), out ex1);

            comp = DynamicEqualityComparer.FromDelegate<Dummy>((x, y) => true, (obj) => 42);
            Test.IfNot.Action.ThrowsException(() => result = comp.Equals(0, 1), out Exception ex2);
            Test.If.Value.IsEqual(result, true);

            Test.IfNot.Action.ThrowsException(() => hash = comp.GetHashCode(0), out ex2);
            Test.If.Value.IsEqual(hash, 42);

        }

    }
}
