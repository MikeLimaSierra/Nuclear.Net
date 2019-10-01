using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedSingleTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedSingle, IClampedPropertyT<Single>>();
            Test.If.TypeImplements<ClampedSingle, IClampedSingle>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedSingle prop = null;
            Single value = 42;
            Single min = Single.MinValue;
            Single max = Single.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedSingle(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
