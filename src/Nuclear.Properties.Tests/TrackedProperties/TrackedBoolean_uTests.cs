using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedBoolean_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedBoolean<Object>, ITrackedProperty<Object, Boolean>>();
            Test.If.Type.Implements<TrackedBoolean<Object>, ITrackedBoolean<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedBoolean<Object> prop = null;
            Object owner = new Object();
            Boolean value = true;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedBoolean<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedBoolean<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
