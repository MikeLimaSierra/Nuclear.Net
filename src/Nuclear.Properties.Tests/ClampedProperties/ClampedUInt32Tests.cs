using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedUInt32Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedUInt32, IClampedPropertyT<UInt32>>();
            Test.If.TypeImplements<ClampedUInt32, IClampedUInt32>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedUInt32 prop = null;
            UInt32 value = 42;
            UInt32 min = UInt32.MinValue;
            UInt32 max = UInt32.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedUInt32(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
