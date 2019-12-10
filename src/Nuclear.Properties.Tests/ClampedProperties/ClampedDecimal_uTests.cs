using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDecimal_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedDecimal, IClampedPropertyT<Decimal>>();
            Test.If.Type.Implements<ClampedDecimal, IClampedDecimal>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedDecimal prop = null;
            Decimal value = 42;
            Decimal min = Decimal.MinValue;
            Decimal max = Decimal.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedDecimal(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
