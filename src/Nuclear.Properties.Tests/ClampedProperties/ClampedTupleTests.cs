using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedTupleTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.TypeImplements<IClampedTuple<Byte>, IClampedProperty<Tuple<Byte>>>();
            Test.If.TypeImplements<IClampedTuple<Byte, Byte>, IClampedProperty<Tuple<Byte, Byte>>>();
            Test.If.TypeImplements<IClampedTuple<Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte>>>();
            Test.If.TypeImplements<IClampedTuple<Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte>>>();
            Test.If.TypeImplements<IClampedTuple<Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte>>>();
            Test.If.TypeImplements<IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte, Byte>>>();
            Test.If.TypeImplements<IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>>>();
            Test.If.TypeImplements<IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedProperty<Tuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>>>();

            Test.If.TypeImplements<ClampedTuple<Byte>, IClampedTuple<Byte>>();
            Test.If.TypeImplements<ClampedTuple<Byte, Byte>, IClampedTuple<Byte, Byte>>();
            Test.If.TypeImplements<ClampedTuple<Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte>>();
            Test.If.TypeImplements<ClampedTuple<Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte>>();
            Test.If.TypeImplements<ClampedTuple<Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte>>();
            Test.If.TypeImplements<ClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte>>();
            Test.If.TypeImplements<ClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte>>();
            Test.If.TypeImplements<ClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>, IClampedTuple<Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte>>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedByte prop = null;
            Byte value = 42;
            Byte min = Byte.MinValue;
            Byte max = Byte.MaxValue;

            Test.IfNot.ThrowsException(() => prop = new ClampedByte(value, min, max), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, value);
            Test.If.ValuesEqual(prop.Minimum, min);
            Test.If.ValuesEqual(prop.Maximum, max);

        }

    }
}
