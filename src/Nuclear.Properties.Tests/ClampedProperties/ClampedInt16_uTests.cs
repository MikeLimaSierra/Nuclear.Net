using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedInt16_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedInt16, IClampedPropertyT<Int16>>();
            Test.If.Type.Implements<ClampedInt16, IClampedInt16>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedInt16 prop = null;
            Int16 value = 42;
            Int16 min = Int16.MinValue;
            Int16 max = Int16.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedInt16(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
