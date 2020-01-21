using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedByte_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedByte, IClampedPropertyT<Byte>>();
            Test.If.Type.Implements<ClampedByte, IClampedByte>();

        }

        [TestMethod]
        void Constructors() {

            IClampedByte prop = null;
            Byte value = 42;
            Byte min = Byte.MinValue;
            Byte max = Byte.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedByte(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
