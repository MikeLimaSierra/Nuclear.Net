﻿using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedSingle_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<ITrackedSingle<Object>, ITrackedProperty<Object, Single>>();
            Test.If.Type.Implements<TrackedSingle<Object>, ITrackedSingle<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedSingle<Object> prop = null;
            Object owner = new Object();
            Single value = 42.0815f;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedSingle<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedSingle<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
