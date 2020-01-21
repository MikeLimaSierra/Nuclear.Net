using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDecimal_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedDecimal, IClampedPropertyT<Decimal>>();
            Test.If.Type.Implements<ClampedDecimal, IClampedDecimal>();

        }

        [TestMethod]
        void Constructors() {

            IClampedDecimal prop = null;
            Decimal value = 42;
            Decimal min = Decimal.MinValue;
            Decimal max = Decimal.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedDecimal(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
