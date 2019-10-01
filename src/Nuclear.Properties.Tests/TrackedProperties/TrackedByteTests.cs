using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedByteTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedByte<Object>, ITrackedProperty<Object, Byte>>();
            Test.If.TypeImplements<TrackedByte<Object>, ITrackedByte<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedByte<Object> prop = null;
            Object owner = new Object();
            Byte value = Byte.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new TrackedByte<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedByte<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
