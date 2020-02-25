using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedUInt64_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedUInt64<Object>, ITrackedProperty<Object, UInt64>>();
            Test.If.Type.Implements<TrackedUInt64<Object>, ITrackedUInt64<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedUInt64<Object> prop = null;
            Object owner = new Object();
            UInt64 value = 42ul;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedUInt64<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedUInt64<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
