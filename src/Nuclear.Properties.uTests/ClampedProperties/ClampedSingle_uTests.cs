using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedSingle_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedSingle, IClampedPropertyT<Single>>();
            Test.If.Type.Implements<ClampedSingle, IClampedSingle>();

        }

        [TestMethod]
        void Constructors() {

            IClampedSingle prop = null;
            Single value = 42;
            Single min = Single.MinValue;
            Single max = Single.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedSingle(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
