using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedSingleTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedSingle<Object>, ITrackedProperty<Object, Single>>();
            Test.If.TypeImplements<TrackedSingle<Object>, ITrackedSingle<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedSingle<Object> prop = null;
            Object owner = new Object();
            Single value = 42.0815f;

            Test.IfNot.ThrowsException(() => prop = new TrackedSingle<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedSingle<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
