using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedDoubleTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedDouble<Object>, ITrackedProperty<Object, Double>>();
            Test.If.TypeImplements<TrackedDouble<Object>, ITrackedDouble<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedDouble<Object> prop = null;
            Object owner = new Object();
            Double value = 42.0815d;

            Test.IfNot.ThrowsException(() => prop = new TrackedDouble<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedDouble<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
