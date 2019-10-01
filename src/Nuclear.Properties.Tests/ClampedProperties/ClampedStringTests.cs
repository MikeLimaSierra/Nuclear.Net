using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedStringTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedString, IClampedPropertyT<String>>();
            Test.If.TypeImplements<ClampedString, IClampedString>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedString prop = null;
            String value = "b";
            String min = "a";
            String max = "c";

            Test.IfNot.ThrowsException(() => prop = new ClampedString(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
