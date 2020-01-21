using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedDouble_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedDouble<Object>, ITrackedProperty<Object, Double>>();
            Test.If.Type.Implements<TrackedDouble<Object>, ITrackedDouble<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedDouble<Object> prop = null;
            Object owner = new Object();
            Double value = 42.0815d;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedDouble<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedDouble<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
