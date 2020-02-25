using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedVersion_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedVersion, IClampedPropertyT<Version>>();
            Test.If.Type.Implements<ClampedVersion, IClampedVersion>();

        }

        [TestMethod]
        void Constructors() {

            IClampedVersion prop = null;
            Version value = new Version(2, 0);
            Version min = new Version(1, 8);
            Version max = new Version(2, 3);

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedVersion(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
