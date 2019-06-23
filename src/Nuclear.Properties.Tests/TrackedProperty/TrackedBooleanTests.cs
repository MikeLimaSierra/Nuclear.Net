using System;
using Nuclear.Properties.TrackedProperty.Base;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperty {
    class TrackedBooleanTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedBoolean<Object>, ITrackedProperty<Object, Boolean>>();
            Test.If.TypeImplements<TrackedBoolean<Object>, ITrackedBoolean<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedBoolean<Object> prop = null;
            Object owner = new Object();

            Test.IfNot.ThrowsException(() => prop = new TrackedBoolean<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, false);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedBoolean<Object>(owner, true), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, true);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
