using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedDateTimeTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedDateTime<Object>, ITrackedProperty<Object, DateTime>>();
            Test.If.TypeImplements<TrackedDateTime<Object>, ITrackedDateTime<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedDateTime<Object> prop = null;
            Object owner = new Object();
            DateTime value = DateTime.Now;

            Test.IfNot.ThrowsException(() => prop = new TrackedDateTime<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedDateTime<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
