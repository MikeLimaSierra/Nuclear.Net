using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedUInt16Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedUInt16, IClampedPropertyT<UInt16>>();
            Test.If.TypeImplements<ClampedUInt16, IClampedUInt16>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedUInt16 prop = null;
            UInt16 value = 42;
            UInt16 min = UInt16.MinValue;
            UInt16 max = UInt16.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedUInt16(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
