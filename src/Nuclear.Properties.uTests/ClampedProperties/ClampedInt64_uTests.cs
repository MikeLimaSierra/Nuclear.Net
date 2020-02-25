using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedInt64_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedInt64, IClampedPropertyT<Int64>>();
            Test.If.Type.Implements<ClampedInt64, IClampedInt64>();

        }

        [TestMethod]
        void Constructors() {

            IClampedInt64 prop = null;
            Int64 value = 42;
            Int64 min = Int64.MinValue;
            Int64 max = Int64.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedInt64(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
