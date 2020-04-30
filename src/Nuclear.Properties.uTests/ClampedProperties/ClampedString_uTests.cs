using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedString_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedString, IClampedPropertyT<String>>();
            Test.If.Type.Implements<ClampedString, IClampedString>();

        }

        [TestMethod]
        void Constructors() {

            IClampedString prop = null;
            String value = "b";
            String min = "a";
            String max = "c";

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedString(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
