using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedInt32_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedInt32, IClampedPropertyT<Int32>>();
            Test.If.Type.Implements<ClampedInt32, IClampedInt32>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedInt32 prop = null;
            Int32 value = 42;
            Int32 min = Int32.MinValue;
            Int32 max = Int32.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedInt32(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
