using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedTimeSpan_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedTimeSpan<Object>, ITrackedProperty<Object, TimeSpan>>();
            Test.If.Type.Implements<TrackedTimeSpan<Object>, ITrackedTimeSpan<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedTimeSpan<Object> prop = null;
            Object owner = new Object();
            TimeSpan value = DateTime.Now.TimeOfDay;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedTimeSpan<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedTimeSpan<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
