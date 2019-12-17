using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedUInt64_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedUInt64, IClampedPropertyT<UInt64>>();
            Test.If.Type.Implements<ClampedUInt64, IClampedUInt64>();

        }

        [TestMethod]
        void Constructors() {

            IClampedUInt64 prop = null;
            UInt64 value = 42;
            UInt64 min = UInt64.MinValue;
            UInt64 max = UInt64.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedUInt64(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
