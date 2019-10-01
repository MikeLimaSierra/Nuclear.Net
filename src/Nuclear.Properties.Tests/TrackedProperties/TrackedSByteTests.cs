using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedSByteTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedSByte<Object>, ITrackedProperty<Object, SByte>>();
            Test.If.TypeImplements<TrackedSByte<Object>, ITrackedSByte<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedSByte<Object> prop = null;
            Object owner = new Object();
            SByte value = SByte.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new TrackedSByte<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedSByte<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
