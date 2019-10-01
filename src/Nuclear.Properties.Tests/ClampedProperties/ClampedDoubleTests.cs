using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDoubleTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedDouble, IClampedPropertyT<Double>>();
            Test.If.TypeImplements<ClampedDouble, IClampedDouble>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedDouble prop = null;
            Double value = 42;
            Double min = Double.MinValue;
            Double max = Double.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedDouble(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
