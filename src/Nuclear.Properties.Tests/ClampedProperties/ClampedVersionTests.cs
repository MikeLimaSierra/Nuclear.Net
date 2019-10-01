using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedVersionTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedVersion, IClampedPropertyT<Version>>();
            Test.If.TypeImplements<ClampedVersion, IClampedVersion>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedVersion prop = null;
            Version value = new Version(2, 0);
            Version min = new Version(1, 8);
            Version max = new Version(2, 3);

            Test.IfNot.ThrowsException(() => prop = new ClampedVersion(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
