using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedCharTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<ITrackedChar<Object>, ITrackedProperty<Object, Char>>();
            Test.If.TypeImplements<TrackedChar<Object>, ITrackedChar<Object>>();

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedChar<Object> prop = null;
            Object owner = new Object();
            Char value = 'x';

            Test.IfNot.ThrowsException(() => prop = new TrackedChar<Object>(null), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedChar<Object>(owner, value), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.False(prop.HasValueChanged);

        }

    }
}
