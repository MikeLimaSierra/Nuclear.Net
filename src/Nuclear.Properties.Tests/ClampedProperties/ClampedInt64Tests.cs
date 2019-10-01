using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedInt64Tests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedInt64, IClampedPropertyT<Int64>>();
            Test.If.TypeImplements<ClampedInt64, IClampedInt64>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedInt64 prop = null;
            Int64 value = 42;
            Int64 min = Int64.MinValue;
            Int64 max = Int64.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedInt64(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
