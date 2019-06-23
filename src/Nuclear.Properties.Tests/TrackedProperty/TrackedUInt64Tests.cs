using System;
using Nuclear.Properties.TrackedProperty.Base;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperty {
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

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt64<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 0ul);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt64<Object>(owner, 42ul), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 42ul);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
