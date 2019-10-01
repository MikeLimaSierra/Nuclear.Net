using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedInt16Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedInt16, IClampedPropertyT<Int16>>();
            Test.If.TypeImplements<ClampedInt16, IClampedInt16>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedInt16 prop = null;
            Int16 value = 42;
            Int16 min = Int16.MinValue;
            Int16 max = Int16.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedInt16(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
