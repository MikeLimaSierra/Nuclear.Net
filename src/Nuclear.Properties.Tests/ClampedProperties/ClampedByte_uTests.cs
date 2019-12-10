using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedByte_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedByte, IClampedPropertyT<Byte>>();
            Test.If.Type.Implements<ClampedByte, IClampedByte>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedByte prop = null;
            Byte value = 42;
            Byte min = Byte.MinValue;
            Byte max = Byte.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedByte(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
