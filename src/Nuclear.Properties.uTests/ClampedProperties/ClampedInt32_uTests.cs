using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedInt32_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedInt32, IClampedPropertyT<Int32>>();
            Test.If.Type.Implements<ClampedInt32, IClampedInt32>();

        }

        [TestMethod]
        void Constructors() {

            IClampedInt32 prop = null;
            Int32 value = 42;
            Int32 min = Int32.MinValue;
            Int32 max = Int32.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedInt32(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
