using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedChar_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedChar, IClampedPropertyT<Char>>();
            Test.If.Type.Implements<ClampedChar, IClampedChar>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedChar prop = null;
            Char value = 'x';
            Char min = Char.MinValue;
            Char max = Char.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedChar(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
