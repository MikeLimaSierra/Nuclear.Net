using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedUInt16Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedUInt16<Object>, ITrackedProperty<Object, UInt16>>();
            Test.If.TypeImplements<TrackedUInt16<Object>, ITrackedUInt16<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedUInt16<Object> prop = null;
            Object owner = new Object();

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt16<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 0);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedUInt16<Object>(owner, 42), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 42);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
