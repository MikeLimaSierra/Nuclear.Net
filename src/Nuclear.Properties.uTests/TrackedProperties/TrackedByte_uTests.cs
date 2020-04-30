using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedByte_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedByte<Object>, ITrackedProperty<Object, Byte>>();
            Test.If.Type.Implements<TrackedByte<Object>, ITrackedByte<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedByte<Object> prop = null;
            Object owner = new Object();
            Byte value = Byte.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedByte<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedByte<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
