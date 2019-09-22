using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedInt32Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedInt32<Object>, ITrackedProperty<Object, Int32>>();
            Test.If.TypeImplements<TrackedInt32<Object>, ITrackedInt32<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedInt32<Object> prop = null;
            Object owner = new Object();

            Test.IfNot.ThrowsException(() => prop = new TrackedInt32<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 0);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedInt32<Object>(owner, 42), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 42);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
