using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Extensions {
    class ListExtensions_uTests {

        [TestMethod]
        void TryTakeThrows() {

            Test.If.Action.ThrowsException(() => ((List<Object>) null).TryTake(_ => _ != null, out Object element), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "this");

            Test.If.Action.ThrowsException(() => new List<Object>().TryTake((Predicate<Object>) null, out Object element), out ex);
            Test.If.Value.IsEqual(ex.ParamName, "match");

        }

        [TestMethod]
        void TryTake() {

            DDTTryTake((new List<String>() { "the quick fox", "jumps over", "the lazy dog" }, _ => _.StartsWith("jumps")), (true, "jumps over", new List<String>() { "the quick fox", "the lazy dog" }));
            DDTTryTake((new List<String>() { "the quick fox", " jumps over", "the lazy dog" }, _ => _.StartsWith("jumps")), (false, null, new List<String>() { "the quick fox", " jumps over", "the lazy dog" }));
            DDTTryTake((new List<String>() { "the quick fox", "jumps over", "the lazy dog" }, _ => _.StartsWith(" jumps")), (false, null, new List<String>() { "the quick fox", "jumps over", "the lazy dog" }));

        }

        void DDTTryTake<T>((List<T> list, Predicate<T> match) input, (Boolean result, T element, List<T> list) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            T element = default;

            Test.Note($"{input.list.Format()}.TryTake(match, out {expected.element.Format()}) == {expected.result.Format()} => {expected.list.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = input.list.TryTake(input.match, out element), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(element, expected.element, _file, _method);
            Test.If.Enumerable.Matches(input.list, expected.list, _file, _method);

        }

    }
}
