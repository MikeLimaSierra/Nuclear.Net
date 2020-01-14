using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IEnumerableTExtensions_uTests {

        #region ForEach

        [TestMethod]
        void ForeachThrowsException() {

            IEnumerable<Int32> enumerable = Enumerable.Empty<Int32>();

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Int32>).ForEach(null), out ArgumentNullException ex);
            Test.If.Value.Equals(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Int32>).ForEach((value) => { }), out ex);
            Test.If.Value.Equals(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => enumerable.ForEach(null), out ex);
            Test.If.Value.Equals(ex.ParamName, "action");

        }

        [TestMethod]
        void ForeachAppliesAction() {

            IEnumerable<Int32> enumerable = Enumerable.Range(1, 10);
            Int32 result = 0;

            Test.IfNot.Action.ThrowsException(() => enumerable.ForEach((value) => { result += value; }), out Exception ex);
            Test.If.Value.Equals(result, 55);

        }

        #endregion

        #region Min

        [TestMethod]
        void MinThrowsException() {

            IEnumerable<DummyIComparable> empty = Enumerable.Empty<DummyIComparable>();
            IEnumerable<DummyIComparable> nulls = new DummyIComparable[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<DummyIComparable>).Min(), out ArgumentNullException ex);
            Test.If.Value.Equals(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.Min(), out ArgumentException argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Min(), out argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinGetsMin() {

            IEnumerable<DummyIComparable> nullEnumerable = new DummyIComparable[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparable result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.Min(), out Exception ex);
            Test.If.Value.Equals(result, -1);

        }

        #endregion

        #region MinT

        [TestMethod]
        void MinTThrowsException() {

            IEnumerable<DummyIComparableT> empty = Enumerable.Empty<DummyIComparableT>();
            IEnumerable<DummyIComparableT> nulls = new DummyIComparableT[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<DummyIComparableT>).MinT(), out ArgumentNullException ex);
            Test.If.Value.Equals(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.MinT(), out ArgumentException argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.MinT(), out argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinTGetsMin() {

            IEnumerable<DummyIComparableT> nullEnumerable = new DummyIComparableT[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparableT result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.MinT(), out Exception ex);
            Test.If.Value.Equals(result, -1);

        }

        #endregion

        #region MinComparerT

        [TestMethod]
        void MinComparerTThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Min(null as Comparer<Dummy>), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Min(Comparer<Dummy>.Default), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Min(null), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Min(Comparer<Dummy>.Default), out ArgumentException ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Min(Comparer<Dummy>.Default), out ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinComparerTGetsMin() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Min(new DummyComparerT()), out Exception ex);
            Test.If.Value.Equals(result, -1, new DummyComparerT());

        }

        #endregion

        #region MinIComparer

        [TestMethod]
        void MinIComparerThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Min(null as IComparer), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Min(DynamicComparer.FromDelegate((x, y) => 0)), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Min(null as IComparer), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Min(DynamicComparer.FromDelegate((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Min(DynamicComparer.FromDelegate((x, y) => 0)), out ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinIComparerGetsMin() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Min(new DummyIComparer()), out Exception ex);
            Test.If.Value.Equals(result, -1, new DummyIComparer());

        }

        #endregion

        #region MinIComparerT

        [TestMethod]
        void MinIComparerTThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Min(null as IComparer<Dummy>), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Min(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Min(null as IComparer<Dummy>), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Min(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Min(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinIComparerTGetsMin() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Min(new DummyIComparerT()), out Exception ex);
            Test.If.Value.Equals(result, -1, new DummyIComparerT());

        }

        #endregion

        #region Max

        [TestMethod]
        void MaxThrowsException() {

            IEnumerable<DummyIComparable> empty = Enumerable.Empty<DummyIComparable>();
            IEnumerable<DummyIComparable> nulls = new DummyIComparable[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<DummyIComparable>).Max(), out ArgumentNullException ex);
            Test.If.Value.Equals(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.Max(), out ArgumentException argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Max(), out argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxGetsMax() {

            IEnumerable<DummyIComparable> nullEnumerable = new DummyIComparable[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparable result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.Max(), out Exception ex);
            Test.If.Value.Equals(result, 1);

        }

        #endregion

        #region MaxT

        [TestMethod]
        void MaxTThrowsException() {

            IEnumerable<DummyIComparableT> empty = Enumerable.Empty<DummyIComparableT>();
            IEnumerable<DummyIComparableT> nulls = new DummyIComparableT[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<DummyIComparableT>).MaxT(), out ArgumentNullException ex);
            Test.If.Value.Equals(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.MaxT(), out ArgumentException argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.MaxT(), out argEx);
            Test.If.Value.Equals(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxTGetsMax() {

            IEnumerable<DummyIComparableT> nullEnumerable = new DummyIComparableT[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparableT result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.MaxT(), out Exception ex);
            Test.If.Value.Equals(result, 1);

        }

        #endregion

        #region MaxComparerT

        [TestMethod]
        void MaxComparerTThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Max(null as Comparer<Dummy>), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Max(Comparer<Dummy>.Default), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Max(null), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Max(Comparer<Dummy>.Default), out ArgumentException ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Max(Comparer<Dummy>.Default), out ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxComparerTGetsMin() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Max(new DummyComparerT()), out Exception ex);
            Test.If.Value.Equals(result, 1, new DummyComparerT());

        }

        #endregion

        #region MaxIComparer

        [TestMethod]
        void MaxIComparerThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Max(null as IComparer), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Max(DynamicComparer.FromDelegate((x, y) => 0)), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Max(null as IComparer), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Max(DynamicComparer.FromDelegate((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Max(DynamicComparer.FromDelegate((x, y) => 0)), out ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxIComparerGetsMin() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Max(new DummyIComparer()), out Exception ex);
            Test.If.Value.Equals(result, 1, new DummyIComparer());

        }

        #endregion

        #region MaxIComparerT

        [TestMethod]
        void MaxIComparerTThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Max(null as IComparer<Dummy>), out ArgumentNullException ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => (null as IEnumerable<Dummy>).Max(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Max(null as IComparer<Dummy>), out ex1);
            Test.If.Value.Equals(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Max(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Max(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex2);
            Test.If.Value.Equals(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxIComparerTGetsMin() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Max(new DummyIComparerT()), out Exception ex);
            Test.If.Value.Equals(result, 1, new DummyIComparerT());

        }

        #endregion

    }
}
