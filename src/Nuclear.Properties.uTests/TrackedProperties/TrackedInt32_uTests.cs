using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedInt32_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedInt32<Object>, ITrackedProperty<Object, Int32>>();
            Test.If.Type.Implements<TrackedInt32<Object>, ITrackedInt32<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedInt32<Object> prop = null;
            Object owner = new Object();
            Int32 value = 42;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedInt32<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedInt32<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
