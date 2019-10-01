using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedInt64Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedInt64<Object>, ITrackedProperty<Object, Int64>>();
            Test.If.TypeImplements<TrackedInt64<Object>, ITrackedInt64<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedInt64<Object> prop = null;
            Object owner = new Object();
            Int64 value = 42L;

            Test.IfNot.ThrowsException(() => prop = new TrackedInt64<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedInt64<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
