using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedSByte_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedSByte, IClampedPropertyT<SByte>>();
            Test.If.Type.Implements<ClampedSByte, IClampedSByte>();

        }

        [TestMethod]
        void Constructors() {

            IClampedSByte prop = null;
            SByte value = 42;
            SByte min = SByte.MinValue;
            SByte max = SByte.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedSByte(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
