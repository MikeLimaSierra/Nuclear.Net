using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedSByte_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<ITrackedSByte<Object>, ITrackedProperty<Object, SByte>>();
            Test.If.Type.Implements<TrackedSByte<Object>, ITrackedSByte<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedSByte<Object> prop = null;
            Object owner = new Object();
            SByte value = SByte.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedSByte<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedSByte<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
