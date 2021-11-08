using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class GenericExtensions_uTests {

        #region Format

        [TestMethod]
        [TestData(nameof(Format_Data))]
        void Format<T>(T @object, String expected) {

            String result = null;

            Test.IfNot.Action.ThrowsException(() => result = @object.Format(), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> Format_Data() {
            return new List<Object[]>() {
                new Object[] { typeof(Object), null, "null" },
                new Object[] { typeof(String), "some string", "'some string'" },
                new Object[] { typeof(Int32), 42, "'42'" },
                new Object[] { typeof(Int32), 0x42, "'66'" },
                new Object[] { typeof(Byte), (Byte) 0x42, "'0x42'" },
                new Object[] { typeof(Type), 42.GetType(), "'System.Int32'" },
                new Object[] { typeof(Type), typeof(Int32), "'System.Int32'" },
                new Object[] { typeof(IEnumerable<Int32>), Enumerable.Empty<Int32>(), "[]" },
                new Object[] { typeof(DictionaryEntry), new DictionaryEntry(42, 'v'), "['42'] => 'v'" },
                new Object[] { typeof(KeyValuePair<Int32, Char>), new KeyValuePair<Int32, Char>(42, 'v'), "['42'] => 'v'" },
                new Object[] { typeof(KeyValuePair<Int32, String>), new KeyValuePair<Int32, String>(42, "v"), "['42'] => 'v'" },
                new Object[] { typeof(KeyValuePair<String, Int32>), new KeyValuePair<String, Int32>("v", 42), "['v'] => '42'" },
                new Object[] { typeof(KeyValuePair<Dummy, Dummy>), new KeyValuePair<Dummy, Dummy>(1, 2), "['1'] => '2'" },
                new Object[] { typeof(ValueTuple<Int32, Char, String>), (1, '2', "3"), "('1', '2', '3')" },
                new Object[] { typeof(ValueTuple<Int32, Dummy, Char, String>), (1, new Dummy(2), '3', "4"), "('1', '2', '3', '4')" },
                new Object[] { typeof(Tuple<Int32, Char, String>), Tuple.Create(1, '2', "3"), "('1', '2', '3')" },
                new Object[] { typeof(Tuple<Int32, Dummy, Char, String>), Tuple.Create(1, new Dummy(2), '3', "4"), "('1', '2', '3', '4')" },
                new Object[] { typeof(List<Int32>), new List<Int32>() { 1, 2, 3 }, "['1', '2', '3']" },
                new Object[] { typeof(Dictionary<Int32, String>), new Dictionary<Int32, String>() { { 1, "A" }, { 2, "B" }, { 3, "C" } }, "[['1'] => 'A', ['2'] => 'B', ['3'] => 'C']" },
                new Object[] { typeof(Dictionary<ValueTuple<Int32, Byte>, String>), new Dictionary<(Int32, Byte), String>() { { (1, 1), "A" }, { (2, 16), "B" }, { (3, 42), "C" } }, "[[('1', '0x01')] => 'A', [('2', '0x10')] => 'B', [('3', '0x2A')] => 'C']" },
            };
        }

        #endregion

        #region FormatType

        [TestMethod]
        [TestData(nameof(FormatType_Data))]
        void FormatType<T>(T @object, String expected) {

            String result = null;

            Test.IfNot.Action.ThrowsException(() => result = @object.FormatType(), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> FormatType_Data() {
            return new List<Object[]>() {
                new Object[] { typeof(Object), null, "null" },
                new Object[] { typeof(String), "some string", "'System.String'" },
                new Object[] { typeof(Int32), 42, "'System.Int32'" },
                new Object[] { typeof(Type), 42.GetType(), "'System.RuntimeType'" },
                new Object[] { typeof(Type), typeof(Int32), "'System.RuntimeType'" },
            };
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestData(nameof(Equals_Data))]
        void Equals<T>(T left, T right, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = left.IsEqual<T>(right), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> Equals_Data() {
            return new List<Object[]>() {
                new Object[] { typeof(DummyIEquatableT), null, null, true },
                new Object[] { typeof(DummyIEquatableT), null, new DummyIEquatableT(0), false },
                new Object[] { typeof(DummyIEquatableT), new DummyIEquatableT(0), null, false },
                new Object[] { typeof(DummyIEquatableT), new DummyIEquatableT(5), new DummyIEquatableT(0), false },
                new Object[] { typeof(DummyIEquatableT), new DummyIEquatableT(5), new DummyIEquatableT(5), true },

                new Object[] { typeof(DummyIComparableT), null, null, true },
                new Object[] { typeof(DummyIComparableT), null, new DummyIComparableT(0), false },
                new Object[] { typeof(DummyIComparableT), new DummyIComparableT(0), null, false },
                new Object[] { typeof(DummyIComparableT), new DummyIComparableT(5), new DummyIComparableT(0), false },
                new Object[] { typeof(DummyIComparableT), new DummyIComparableT(5), new DummyIComparableT(5), true },

                new Object[] { typeof(DummyIComparable), null, null, true },
                new Object[] { typeof(DummyIComparable), null, new DummyIComparable(0), false },
                new Object[] { typeof(DummyIComparable), new DummyIComparable(0), null, false },
                new Object[] { typeof(DummyIComparable), new DummyIComparable(5), new DummyIComparable(0), false },
                new Object[] { typeof(DummyIComparable), new DummyIComparable(5), new DummyIComparable(5), true },

                new Object[] { typeof(Dummy), null, null, true },
                new Object[] { typeof(Dummy), null, new Dummy(0), false },
                new Object[] { typeof(Dummy), new Dummy(0), null, false },
                new Object[] { typeof(Dummy), new Dummy(5), new Dummy(0), false },
                new Object[] { typeof(Dummy), new Dummy(5), new Dummy(5), false },
            };
        }

        #endregion

    }
}
