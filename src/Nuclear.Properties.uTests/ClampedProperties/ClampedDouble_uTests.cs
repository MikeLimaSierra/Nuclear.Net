using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDouble_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedDouble, IClampedPropertyT<Double>>();
            Test.If.Type.Implements<ClampedDouble, IClampedDouble>();

        }

        [TestMethod]
        void Constructors() {

            IClampedDouble prop = null;
            Double value = 42;
            Double min = Double.MinValue;
            Double max = Double.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedDouble(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
