using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class GenericExtensions_uTests {

        #region Format

        [TestMethod]
        void Format() {

            DDTFormat<Object>(null, "'null'");
            DDTFormat("some string", "'some string'");
            DDTFormat(42, "'42'");
            DDTFormat(0x42, "'66'");
            DDTFormat((Byte) 0x42, "'0x42'");
            DDTFormat(42.GetType(), "'System.Int32'");
            DDTFormat(typeof(Int32), "'System.Int32'");
            DDTFormat(Enumerable.Empty<Int32>(), "[]");
            DDTFormat(new DictionaryEntry(42, 'v'), "['42'] => 'v'"); ;
            DDTFormat(new KeyValuePair<Int32, Char>(42, 'v'), "['42'] => 'v'");
            DDTFormat(new KeyValuePair<Int32, String>(42, "v"), "['42'] => 'v'");
            DDTFormat(new KeyValuePair<String, Int32>("v", 42), "['v'] => '42'");
            DDTFormat(new KeyValuePair<Dummy, Dummy>(1, 2), "['1'] => '2'");
            DDTFormat((1, '2', "3"), "('1', '2', '3')");
            DDTFormat((1, new Dummy(2), '3', "4"), "('1', '2', '3', '4')");
            DDTFormat(new List<Int32>() { 1, 2, 3 }, "['1', '2', '3']");
            DDTFormat(new Dictionary<Int32, String>() { { 1, "A" }, { 2, "B" }, { 3, "C" } },
                "[['1'] => 'A', ['2'] => 'B', ['3'] => 'C']");
            DDTFormat(new Dictionary<(Int32, Byte), String>() { { (1, 1), "A" }, { (2, 16), "B" }, { (3, 42), "C" } },
                "[[('1', '0x01')] => 'A', [('2', '0x10')] => 'B', [('3', '0x2A')] => 'C']");

        }

        void DDTFormat<T>(T @object, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String result = null;

            Test.Note($"{@object.Format()}.Format<{typeof(T).Format()}>() == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = @object.Format(), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region FormatType

        [TestMethod]
        void FormatType() {

            DDTFormatType<Object>(null, "'null'");
            DDTFormatType("some string", "'System.String'");
            DDTFormatType(42, "'System.Int32'");
            DDTFormatType(42.GetType(), "'System.RuntimeType'");
            DDTFormatType(typeof(Int32), "'System.RuntimeType'");

        }

        void DDTFormatType<T>(T @object, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String result = null;

            Test.IfNot.Action.ThrowsException(() => result = @object.FormatType(), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region Equals

        [TestMethod]
        void Equals() {

            DDTEquals<DummyIEquatableT>((null, null), true);
            DDTEquals((null, new DummyIEquatableT(0)), false);
            DDTEquals((new DummyIEquatableT(0), null), false);
            DDTEquals((new DummyIEquatableT(5), new DummyIEquatableT(0)), false);
            DDTEquals((new DummyIEquatableT(5), new DummyIEquatableT(5)), true);

            DDTEquals<DummyIComparableT>((null, null), true);
            DDTEquals((null, new DummyIComparableT(0)), false);
            DDTEquals((new DummyIComparableT(0), null), false);
            DDTEquals((new DummyIComparableT(5), new DummyIComparableT(0)), false);
            DDTEquals((new DummyIComparableT(5), new DummyIComparableT(5)), true);

            DDTEquals<DummyIComparable>((null, null), true);
            DDTEquals((null, new DummyIComparable(0)), false);
            DDTEquals((new DummyIComparable(0), null), false);
            DDTEquals((new DummyIComparable(5), new DummyIComparable(0)), false);
            DDTEquals((new DummyIComparable(5), new DummyIComparable(5)), true);

            DDTEquals<Dummy>((null, null), true);
            DDTEquals((null, new Dummy(0)), false);
            DDTEquals((new Dummy(0), null), false);
            DDTEquals((new Dummy(5), new Dummy(0)), false);
            DDTEquals((new Dummy(5), new Dummy(5)), false);

        }

        void DDTEquals<T>((T left, T right) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.left.Format()}.Equals({input.right.Format()})", _file, _method);
            Test.IfNot.Action.ThrowsException(() => result = input.left.IsEqual<T>(input.right), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

    }
}
