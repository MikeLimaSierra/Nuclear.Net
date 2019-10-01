using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedDateTimeTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedDateTime, IClampedPropertyT<DateTime>>();
            Test.If.TypeImplements<ClampedDateTime, IClampedDateTime>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedDateTime prop = null;
            DateTime value = DateTime.Now;
            DateTime min = DateTime.MinValue;
            DateTime max = DateTime.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedDateTime(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
