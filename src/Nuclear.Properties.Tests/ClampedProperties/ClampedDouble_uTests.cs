using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDouble_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedDouble, IClampedPropertyT<Double>>();
            Test.If.Type.Implements<ClampedDouble, IClampedDouble>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedDouble prop = null;
            Double value = 42;
            Double min = Double.MinValue;
            Double max = Double.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedDouble(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
