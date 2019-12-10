using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedVersion_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedVersion, IClampedPropertyT<Version>>();
            Test.If.Type.Implements<ClampedVersion, IClampedVersion>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedVersion prop = null;
            Version value = new Version(2, 0);
            Version min = new Version(1, 8);
            Version max = new Version(2, 3);

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedVersion(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}
