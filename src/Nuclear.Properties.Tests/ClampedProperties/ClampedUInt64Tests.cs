using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedUInt64Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedUInt64, IClampedPropertyT<UInt64>>();
            Test.If.TypeImplements<ClampedUInt64, IClampedUInt64>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedUInt64 prop = null;
            UInt64 value = 42;
            UInt64 min = UInt64.MinValue;
            UInt64 max = UInt64.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedUInt64(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
