using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedChar_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedChar, IClampedPropertyT<Char>>();
            Test.If.Type.Implements<ClampedChar, IClampedChar>();

        }

        [TestMethod]
        void Constructors() {

            IClampedChar prop = null;
            Char value = 'x';
            Char min = Char.MinValue;
            Char max = Char.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedChar(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
