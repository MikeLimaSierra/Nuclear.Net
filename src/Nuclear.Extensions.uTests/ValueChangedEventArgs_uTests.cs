using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class ValueChangedEventArgs_uTests {

        [TestMethod]
        [TestParameters(typeof(String), null, null, false)]
        [TestParameters(typeof(String), null, "new", true)]
        [TestParameters(typeof(String), "old", null, true)]
        [TestParameters(typeof(String), "old", "new", true)]
        [TestParameters(typeof(String), "old", "old", false)]
        [TestParameters(typeof(Int32), 5, 6, true)]
        [TestParameters(typeof(Int32), 5, 5, false)]
        void Constructor<TValue>(TValue oldValue, TValue newValue, Boolean hasChanged) {

            ValueChangedEventArgs<TValue> e = null;

            Test.IfNot.Action.ThrowsException(() => e = new ValueChangedEventArgs<TValue>(oldValue, newValue), out Exception ex);
            Test.IfNot.Object.IsNull(e);
            Test.If.Value.IsEqual(e.Old, oldValue);
            Test.If.Value.IsEqual(e.New, newValue);
            Test.If.Value.IsEqual(e.HasChanged, hasChanged);

        }

    }
}
