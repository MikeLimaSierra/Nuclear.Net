using System;

using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedTuple_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IClampedTuple<Byte>, IClampedProperty<Tuple<Byte>>>();
            Test.If.Type.Implements<IClampedTuple<Byte, Byte>, IClampedProperty<Tuple<Byte, Byte>>>();
            Test.If.Type.Implements<IClampedTuple<Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte>>>();
            Test.If.Type.Implements<IClampedTuple<Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte>>>();
            Test.If.Type.Implements<IClampedTuple<Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte>>>();
            Test.If.Type.Implements<IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte, Byte>>>();
            Test.If.Type.Implements<IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>>>();
            Test.If.Type.Implements<IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>>>();

            Test.If.Type.Implements<ClampedTuple<Byte>, IClampedTuple<Byte>>();
            Test.If.Type.Implements<ClampedTuple<Byte, Byte>, IClampedTuple<Byte, Byte>>();
            Test.If.Type.Implements<ClampedTuple<Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte>>();
            Test.If.Type.Implements<ClampedTuple<Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte>>();
            Test.If.Type.Implements<ClampedTuple<Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte>>();
            Test.If.Type.Implements<ClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte>>();
            Test.If.Type.Implements<ClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>>();
            Test.If.Type.Implements<ClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>>();

        }

        [TestMethod]
        void Constructors() {

            IClampedByte prop = null;
            Byte value = 42;
            Byte min = Byte.MinValue;
            Byte max = Byte.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedByte(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);

        }

    }
}
