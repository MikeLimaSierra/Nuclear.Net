using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedByteTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedByte, IClampedPropertyT<Byte>>();
            Test.If.TypeImplements<ClampedByte, IClampedByte>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedByte prop = null;
            Byte value = 42;
            Byte min = Byte.MinValue;
            Byte max = Byte.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedByte(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
