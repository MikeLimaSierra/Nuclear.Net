using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedTimeSpanTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedTimeSpan, IClampedPropertyT<TimeSpan>>();
            Test.If.TypeImplements<ClampedTimeSpan, IClampedTimeSpan>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedTimeSpan prop = null;
            TimeSpan value = DateTime.Now.TimeOfDay;
            TimeSpan min = TimeSpan.MinValue;
            TimeSpan max = TimeSpan.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedTimeSpan(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
