using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedUInt16_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedUInt16, IClampedPropertyT<UInt16>>();
            Test.If.Type.Implements<ClampedUInt16, IClampedUInt16>();

        }

        [TestMethod]
        void Constructors() {

            IClampedUInt16 prop = null;
            UInt16 value = 42;
            UInt16 min = UInt16.MinValue;
            UInt16 max = UInt16.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedUInt16(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
