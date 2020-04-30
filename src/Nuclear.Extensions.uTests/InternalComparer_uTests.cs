using System;
using System.Collections;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class InternalComparer_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.Implements<InternalComparer, IComparer>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void Ctor() {

            IComparer comp = null;
            Int32 result = 0;

            Test.If.Action.ThrowsException(() => comp = new InternalComparer(null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "compare");

            Test.IfNot.Action.ThrowsException(() => comp = new InternalComparer((x, y) => 42), out Exception ex2);

            result = comp.Compare(0, 1);
            Test.If.Value.IsEqual(result, 42);

        }

        [TestMethod]
        void ComparisonInvokes() {

            IComparer comp = null;
            Int32 result = 0;

            comp = DynamicComparer.FromDelegate((x, y) => throw new NotImplementedException());
            Test.If.Action.ThrowsException(() => result = comp.Compare(0, 1), out NotImplementedException ex1);

            comp = DynamicComparer.FromDelegate((x, y) => 42);
            Test.IfNot.Action.ThrowsException(() => result = comp.Compare(0, 1), out Exception ex2);
            Test.If.Value.IsEqual(result, 42);

        }

    }
}
