using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedDateTime_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<ITrackedDateTime<Object>, ITrackedProperty<Object, DateTime>>();
            Test.If.Type.Implements<TrackedDateTime<Object>, ITrackedDateTime<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedDateTime<Object> prop = null;
            Object owner = new Object();
            DateTime value = DateTime.Now;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedDateTime<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedDateTime<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
