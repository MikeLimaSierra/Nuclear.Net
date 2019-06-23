using System;
using Nuclear.Properties.TrackedProperty.Base;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperty {
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

            Test.IfNot.ThrowsException(() => prop = new TrackedSingle<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 0f);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedSingle<Object>(owner, 42.0815f), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 42.0815f);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
