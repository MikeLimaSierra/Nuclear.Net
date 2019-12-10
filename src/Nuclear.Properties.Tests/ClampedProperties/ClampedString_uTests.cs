using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedString_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedString, IClampedPropertyT<String>>();
            Test.If.Type.Implements<ClampedString, IClampedString>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedString prop = null;
            String value = "b";
            String min = "a";
            String max = "c";

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedString(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
