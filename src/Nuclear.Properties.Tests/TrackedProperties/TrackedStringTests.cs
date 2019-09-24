using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedStringTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedString<Object>, ITrackedProperty<Object, String>>();
            Test.If.TypeImplements<TrackedString<Object>, ITrackedString<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedString<Object> prop = null;
            Object owner = new Object();

            Test.IfNot.ThrowsException(() => prop = new TrackedString<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, null);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedString<Object>(owner, "testDefault"), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, "testDefault");
            Test.If.False(prop.HasValueChanged);

        }

    }
}
