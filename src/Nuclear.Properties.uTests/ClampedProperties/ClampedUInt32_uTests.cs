using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedUInt32_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedUInt32, IClampedPropertyT<UInt32>>();
            Test.If.Type.Implements<ClampedUInt32, IClampedUInt32>();

        }

        [TestMethod]
        void Constructors() {

            IClampedUInt32 prop = null;
            UInt32 value = 42;
            UInt32 min = UInt32.MinValue;
            UInt32 max = UInt32.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedUInt32(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
