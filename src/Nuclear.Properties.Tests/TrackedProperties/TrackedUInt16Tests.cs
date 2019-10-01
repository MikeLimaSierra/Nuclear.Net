﻿using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedUInt16Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedUInt16<Object>, ITrackedProperty<Object, UInt16>>();
            Test.If.TypeImplements<TrackedUInt16<Object>, ITrackedUInt16<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedUInt16<Object> prop = null;
            Object owner = new Object();
            UInt16 value = 42;

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt16<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt16<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
