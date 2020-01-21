using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDateTime_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedDateTime, IClampedPropertyT<DateTime>>();
            Test.If.Type.Implements<ClampedDateTime, IClampedDateTime>();

        }

        [TestMethod]
        void Constructors() {

            IClampedDateTime prop = null;
            DateTime value = DateTime.Now;
            DateTime min = DateTime.MinValue;
            DateTime max = DateTime.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedDateTime(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
