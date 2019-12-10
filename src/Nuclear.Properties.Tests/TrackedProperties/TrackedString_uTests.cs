﻿using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedString_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<ITrackedString<Object>, ITrackedProperty<Object, String>>();
            Test.If.Type.Implements<TrackedString<Object>, ITrackedString<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedString<Object> prop = null;
            Object owner = new Object();
            String value = "testDefault";

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedString<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedString<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}