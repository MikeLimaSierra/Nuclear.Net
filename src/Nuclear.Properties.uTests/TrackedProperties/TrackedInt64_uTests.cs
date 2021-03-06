﻿using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedInt64_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedInt64<Object>, ITrackedProperty<Object, Int64>>();
            Test.If.Type.Implements<TrackedInt64<Object>, ITrackedInt64<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedInt64<Object> prop = null;
            Object owner = new Object();
            Int64 value = 42L;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedInt64<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedInt64<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
