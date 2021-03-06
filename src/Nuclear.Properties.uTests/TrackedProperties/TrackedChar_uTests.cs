﻿using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedChar_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ITrackedChar<Object>, ITrackedProperty<Object, Char>>();
            Test.If.Type.Implements<TrackedChar<Object>, ITrackedChar<Object>>();

        }

        [TestMethod]
        void Constructors() {

            ITrackedChar<Object> prop = null;
            Object owner = new Object();
            Char value = 'x';

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedChar<Object>(null), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, default);
            Test.If.Value.IsFalse(prop.HasValueChanged);

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedChar<Object>(owner, value), out ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsFalse(prop.HasValueChanged);

        }

    }
}
