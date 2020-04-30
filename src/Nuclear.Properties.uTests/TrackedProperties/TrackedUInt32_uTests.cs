using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedUInt32_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedUInt32<Object>, ITrackedProperty<Object, UInt32>>();
            Test.If.Type.Implements<TrackedUInt32<Object>, ITrackedUInt32<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedUInt32<Object> prop = null;
            Object owner = new Object();
            UInt32 value = 42u;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedUInt32<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedUInt32<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
