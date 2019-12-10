using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedInt16_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<ITrackedInt16<Object>, ITrackedProperty<Object, Int16>>();
            Test.If.Type.Implements<TrackedInt16<Object>, ITrackedInt16<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedInt16<Object> prop = null;
            Object owner = new Object();
            Int16 value = 42;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedInt16<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedInt16<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
