using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDateTime_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedDateTime, IClampedPropertyT<DateTime>>();
            Test.If.Type.Implements<ClampedDateTime, IClampedDateTime>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedDateTime prop = null;
            DateTime value = DateTime.Now;
            DateTime min = DateTime.MinValue;
            DateTime max = DateTime.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedDateTime(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
