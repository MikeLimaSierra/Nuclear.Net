using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDecimalTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedDecimal, IClampedPropertyT<Decimal>>();
            Test.If.TypeImplements<ClampedDecimal, IClampedDecimal>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedDecimal prop = null;
            Decimal value = 42;
            Decimal min = Decimal.MinValue;
            Decimal max = Decimal.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedDecimal(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
