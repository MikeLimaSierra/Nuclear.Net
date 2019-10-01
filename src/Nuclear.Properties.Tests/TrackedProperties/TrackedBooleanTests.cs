using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
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
            Boolean value = true;

            Test.IfNot.ThrowsException(() => prop = new TrackedBoolean<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedBoolean<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
