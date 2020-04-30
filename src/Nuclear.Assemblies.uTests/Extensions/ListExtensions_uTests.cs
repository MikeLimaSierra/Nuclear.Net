using System;
using System.Collections.Generic;

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

        void TryTake() {

            TryTake(new List<String>() { "the quick fox", "jumps over", "the lazy dog" }, _ => _.StartsWith("jumps"), true, "jumps over", new List<String>() { "the quick fox", "the lazy dog" });
            TryTake(new List<String>() { "the quick fox", " jumps over", "the lazy dog" }, _ => _.StartsWith("jumps"), false, null, new List<String>() { "the quick fox", " jumps over", "the lazy dog" });
            TryTake(new List<String>() { "the quick fox", "jumps over", "the lazy dog" }, _ => _.StartsWith(" jumps"), false, null, new List<String>() { "the quick fox", "jumps over", "the lazy dog" });

        }

        [TestMethod]
        [TestData(nameof(TryTakeData))]
        void TryTake<T>(List<T> input1, Predicate<T> input2, Boolean result, T element, List<T> list) {

            Boolean _result = false;
            T _element = default;

            Test.IfNot.Action.ThrowsException(() => _result = input1.TryTake(input2, out _element), out Exception ex);
            Test.If.Value.IsEqual(_result, result);
            Test.If.Value.IsEqual(_element, element);
            Test.If.Enumerable.Matches(input1, list);

        }

        IEnumerable<Object[]> TryTakeData() {
            return new List<Object[]>() {
                new Object[] { typeof(String), new List<String>() { "the quick fox", "jumps over", "the lazy dog" }, new Predicate<String>((_) => _.StartsWith("jumps")), true, "jumps over", new List<String>() { "the quick fox", "the lazy dog" } },
                new Object[] { typeof(String), new List<String>() { "the quick fox", " jumps over", "the lazy dog" }, new Predicate<String>((_) => _.StartsWith("jumps")), false, null, new List<String>() { "the quick fox", " jumps over", "the lazy dog" } },
                new Object[] { typeof(String), new List<String>() { "the quick fox", "jumps over", "the lazy dog" }, new Predicate<String>((_) => _.StartsWith(" jumps")), false, null, new List<String>() { "the quick fox", "jumps over", "the lazy dog" } },
            };
        }

    }
}
