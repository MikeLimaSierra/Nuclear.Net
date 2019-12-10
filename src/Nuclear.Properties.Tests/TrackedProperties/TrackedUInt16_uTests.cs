using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedUInt16_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<ITrackedUInt16<Object>, ITrackedProperty<Object, UInt16>>();
            Test.If.Type.Implements<TrackedUInt16<Object>, ITrackedUInt16<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedUInt16<Object> prop = null;
            Object owner = new Object();
            UInt16 value = 42;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedUInt16<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedUInt16<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
