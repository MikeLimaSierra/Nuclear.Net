using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedDecimal_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedDecimal<Object>, ITrackedProperty<Object, Decimal>>();
            Test.If.Type.Implements<TrackedDecimal<Object>, ITrackedDecimal<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedDecimal<Object> prop = null;
            Object owner = new Object();
            Decimal value = 42.0815m;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedDecimal<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedDecimal<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
