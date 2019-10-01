using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedSByteTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedSByte, IClampedPropertyT<SByte>>();
            Test.If.TypeImplements<ClampedSByte, IClampedSByte>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedSByte prop = null;
            SByte value = 42;
            SByte min = SByte.MinValue;
            SByte max = SByte.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedSByte(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
