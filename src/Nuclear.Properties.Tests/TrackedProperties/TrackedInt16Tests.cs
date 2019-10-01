using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedInt16Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedInt16<Object>, ITrackedProperty<Object, Int16>>();
            Test.If.TypeImplements<TrackedInt16<Object>, ITrackedInt16<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedInt16<Object> prop = null;
            Object owner = new Object();
            Int16 value = 42;

            Test.IfNot.ThrowsException(() => prop = new TrackedInt16<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedInt16<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
