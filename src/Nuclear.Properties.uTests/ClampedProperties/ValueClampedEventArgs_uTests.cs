using System;
using System.Collections.Generic;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ValueClampedEventArgs_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.IsSubClass<ValueClampedEventArgs<String>, EventArgs>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        [TestData(nameof(ConstructorData))]
        void Constructor<TValue>(TValue input1, TValue input2, TValue inpu3, (Boolean hasChanged, Boolean hasBeenClamped) expected) {

            ValueClampedEventArgs<TValue> e = null;

            Test.IfNot.Action.ThrowsException(() => e = new ValueClampedEventArgs<TValue>(input1, input2, inpu3), out Exception ex);

            Test.IfNot.Object.IsNull(e);
            Test.If.Value.IsEqual(e.Set, input1);
            Test.If.Value.IsEqual(e.Old, input2);
            Test.If.Value.IsEqual(e.New, inpu3);
            Test.If.Value.IsEqual(e.HasChanged, expected.hasChanged);
            Test.If.Value.IsEqual(e.HasBeenClamped, expected.hasBeenClamped);

        }

        IEnumerable<Object[]> ConstructorData() {
            return new List<Object[]>() {
                new Object[] { typeof(Int32?), null, null, null, (false, false) },
                new Object[] { typeof(Int32?), null, 5, 6, (true, false) },
                new Object[] { typeof(Int32?), 6, null, 6, (true, false) },
                new Object[] { typeof(Int32?), 6, 5, null, (true, false) },
                new Object[] { typeof(Int32?), 6, 5, 6, (true, false) },
                new Object[] { typeof(Int32?), 7, 5, 6, (true, true) },
                new Object[] { typeof(Int32?), 6, 6, 6, (false, false) },

                new Object[] { typeof(Int32), 6, 5, 6, (true, false) },
                new Object[] { typeof(Int32), 7, 5, 6, (true, true) },
                new Object[] { typeof(Int32), 6, 6, 6, (false, false) },
            };
        }

    }
}
