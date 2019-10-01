using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedCharTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedChar, IClampedPropertyT<Char>>();
            Test.If.TypeImplements<ClampedChar, IClampedChar>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedChar prop = null;
            Char value = 'x';
            Char min = Char.MinValue;
            Char max = Char.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedChar(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
