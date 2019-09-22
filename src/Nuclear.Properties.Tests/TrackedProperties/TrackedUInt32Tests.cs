using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedUInt32Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedUInt32<Object>, ITrackedProperty<Object, UInt32>>();
            Test.If.TypeImplements<TrackedUInt32<Object>, ITrackedUInt32<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedUInt32<Object> prop = null;
            Object owner = new Object();

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt32<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 0u);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt32<Object>(owner, 42u), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 42u);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
