using System;
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
            DDTFormat(42.GetType(), "'System.Int32'");
            DDTFormat(typeof(Int32), "'System.Int32'");
            DDTFormat(Enumerable.Empty<Int32>(), "[]");
            DDTFormat(new List<Int32>() { 1, 2, 3 }, "['1', '2', '3']");

        }

        void DDTFormat<T>(T @object, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String result = null;

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
