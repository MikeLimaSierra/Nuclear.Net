using System;
using Nuclear.Properties.TrackedProperty.Base;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperty {
    class TrackedInt64Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedInt64<Object>, ITrackedProperty<Object, Int64>>();
            Test.If.TypeImplements<TrackedInt64<Object>, ITrackedInt64<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedInt64<Object> prop = null;
            Object owner = new Object();

            Test.IfNot.ThrowsException(() => prop = new TrackedInt64<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 0L);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedInt64<Object>(owner, 42L), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, 42L);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
