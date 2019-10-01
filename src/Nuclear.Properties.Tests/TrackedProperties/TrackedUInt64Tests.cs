using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedUInt64Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedUInt64<Object>, ITrackedProperty<Object, UInt64>>();
            Test.If.TypeImplements<TrackedUInt64<Object>, ITrackedUInt64<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedUInt64<Object> prop = null;
            Object owner = new Object();
            UInt64 value = 42ul;

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt64<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt64<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
