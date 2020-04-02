using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class ChangeTrackedEventArgs_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.IsSubClass<ChangeTrackedEventArgs<Object, String>, EventArgs>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        [TestData(nameof(ConstructorData))]
        void Constructor<TOwner, TValue>(TOwner input1, TValue input2, TValue input3, Boolean hasChanged) {

            ChangeTrackedEventArgs<TOwner, TValue> e = null;

            Test.IfNot.Action.ThrowsException(() => e = new ChangeTrackedEventArgs<TOwner, TValue>(input1, input2, input3), out Exception ex);
 
            Test.IfNot.Object.IsNull(e);
            Test.If.Value.IsEqual(e.Owner, input1);
            Test.If.Value.IsEqual(e.Old, input2);
            Test.If.Value.IsEqual(e.New, input3);
            Test.If.Value.IsEqual(e.HasChanged, hasChanged);

        }

        IEnumerable<Object[]> ConstructorData() {
            Object owner = new Object();

            return new List<Object[]>() {
                new Object[] { typeof(Object), typeof(Int32), null, 5, 6, true },
                new Object[] { typeof(Object), typeof(Int32), null, 5, 5, false },

                new Object[] { typeof(Object), typeof(String), null, null, null, false },
                new Object[] { typeof(Object), typeof(String), owner, null, "new", true },
                new Object[] { typeof(Object), typeof(String), owner, "old", null, true },
                new Object[] { typeof(Object), typeof(String), owner, "old", "new", true },
                new Object[] { typeof(Object), typeof(String), owner, "old", "old", false },
            };
        }

    }
}
