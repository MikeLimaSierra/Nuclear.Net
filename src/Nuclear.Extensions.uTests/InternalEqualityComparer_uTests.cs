using System;
using System.Collections;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class InternalEqualityComparer_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.Implements<InternalEqualityComparer, IEqualityComparer>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void Ctor() {

            IEqualityComparer comp = null;
            Boolean result = false;
            Int32 hash = 0;

            Test.If.Action.ThrowsException(() => comp = new InternalEqualityComparer(null, null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = new InternalEqualityComparer(null, (obj) => 42), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "equals");

            Test.If.Action.ThrowsException(() => comp = new InternalEqualityComparer((x, y) => true, null), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "getHashCode");

            Test.IfNot.Action.ThrowsException(() => comp = new InternalEqualityComparer((x, y) => true, (obj) => 42), out Exception ex2);

            result = comp.Equals(0, 1);
            Test.If.Value.IsEqual(result, true);

            hash = comp.GetHashCode(0);
            Test.If.Value.IsEqual(hash, 42);

        }

        [TestMethod]
        void ComparisonInvokes() {

            IEqualityComparer comp = null;
            Boolean result = false;
            Int32 hash = 0;

            comp = DynamicEqualityComparer.FromDelegate((x, y) => throw new NotImplementedException(), (obj) => throw new NotImplementedException());
            Test.If.Action.ThrowsException(() => result = comp.Equals(0, 1), out NotImplementedException ex1);
            Test.If.Action.ThrowsException(() => hash = comp.GetHashCode(0), out ex1);

            comp = DynamicEqualityComparer.FromDelegate((x, y) => true, (obj) => 42);
            Test.IfNot.Action.ThrowsException(() => result = comp.Equals(0, 1), out Exception ex2);
            Test.If.Value.IsEqual(result, true);

            Test.IfNot.Action.ThrowsException(() => hash = comp.GetHashCode(0), out ex2);
            Test.If.Value.IsEqual(hash, 42);

        }

    }
}
