using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedTimeSpanTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedTimeSpan<Object>, ITrackedProperty<Object, TimeSpan>>();
            Test.If.TypeImplements<TrackedTimeSpan<Object>, ITrackedTimeSpan<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedTimeSpan<Object> prop = null;
            Object owner = new Object();
            TimeSpan value = DateTime.Now.TimeOfDay;

            Test.IfNot.ThrowsException(() => prop = new TrackedTimeSpan<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedTimeSpan<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
