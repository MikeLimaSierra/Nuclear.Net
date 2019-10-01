using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedDecimalTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedDecimal<Object>, ITrackedProperty<Object, Decimal>>();
            Test.If.TypeImplements<TrackedDecimal<Object>, ITrackedDecimal<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedDecimal<Object> prop = null;
            Object owner = new Object();
            Decimal value = 42.0815m;

            Test.IfNot.ThrowsException(() => prop = new TrackedDecimal<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedDecimal<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
