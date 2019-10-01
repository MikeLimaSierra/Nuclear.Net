using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedInt32Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedInt32, IClampedPropertyT<Int32>>();
            Test.If.TypeImplements<ClampedInt32, IClampedInt32>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedInt32 prop = null;
            Int32 value = 42;
            Int32 min = Int32.MinValue;
            Int32 max = Int32.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedInt32(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
