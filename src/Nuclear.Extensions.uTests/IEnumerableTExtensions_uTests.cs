using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IEnumerableTExtensions_uTests {

        #region ForEach

        [TestMethod]
        void Foreach_ThrowsException() {

            IEnumerable<Int32> enumerable = Enumerable.Empty<Int32>();

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Foreach<Int32>(null, null), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Foreach<Int32>(null, (value) => { }), out ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => enumerable.Foreach(null), out ex);
            Test.If.Value.IsEqual(ex.ParamName, "action");

        }

        [TestMethod]
        void Foreach() {

            IEnumerable<Int32> enumerable = Enumerable.Range(1, 10);
            Int32 result = 0;

            Test.IfNot.Action.ThrowsException(() => enumerable.Foreach((value) => result += value), out Exception ex);
            Test.If.Value.IsEqual(result, 55);

        }

        #endregion

        #region Min

        [TestMethod]
        void Min_ThrowsException() {

            IEnumerable<DummyIComparable> empty = Enumerable.Empty<DummyIComparable>();
            IEnumerable<DummyIComparable> nulls = new DummyIComparable[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Minimum<DummyIComparable>(null), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.Minimum(), out ArgumentException argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Minimum(), out argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void Min() {

            IEnumerable<DummyIComparable> nullEnumerable = new DummyIComparable[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparable result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.Minimum(), out Exception ex);
            Test.If.Value.IsEqual(result, -1);

        }

        #endregion

        #region MinT

        [TestMethod]
        void MinT_ThrowsException() {

            IEnumerable<DummyIComparableT> empty = Enumerable.Empty<DummyIComparableT>();
            IEnumerable<DummyIComparableT> nulls = new DummyIComparableT[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.MinimumT<DummyIComparableT>(null), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.MinimumT(), out ArgumentException argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.MinimumT(), out argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinT() {

            IEnumerable<DummyIComparableT> nullEnumerable = new DummyIComparableT[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparableT result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.MinimumT(), out Exception ex);
            Test.If.Value.IsEqual(result, -1);

        }

        #endregion

        #region MinComparerT

        [TestMethod]
        void MinComparerT_ThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Minimum<Dummy>(null, null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Minimum(null, Comparer<Dummy>.Default), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Minimum(null), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Minimum(Comparer<Dummy>.Default), out ArgumentException ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Minimum(Comparer<Dummy>.Default), out ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinComparerT() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Minimum(new DummyComparerT()), out Exception ex);
            Test.If.Value.IsEqual(result, -1, new DummyComparerT());

        }

        #endregion

        #region MinIComparer

        [TestMethod]
        void MinIComparer_ThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Minimum<Dummy>(null, null as IComparer), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Minimum<Dummy>(null, DynamicComparer.FromDelegate((x, y) => 0)), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Minimum(null as IComparer), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Minimum(DynamicComparer.FromDelegate((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Minimum(DynamicComparer.FromDelegate((x, y) => 0)), out ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinIComparer() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Minimum(new DummyIComparer()), out Exception ex);
            Test.If.Value.IsEqual(result, -1, new DummyIComparer());

        }

        #endregion

        #region MinIComparerT

        [TestMethod]
        void MinIComparerT_ThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Minimum(null, null as IComparer<Dummy>), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Minimum(null, DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Minimum(null as IComparer<Dummy>), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Minimum(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Minimum(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MinIComparerT() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Minimum(new DummyIComparerT()), out Exception ex);
            Test.If.Value.IsEqual(result, -1, new DummyIComparerT());

        }

        #endregion

        #region Max

        [TestMethod]
        void Max_ThrowsException() {

            IEnumerable<DummyIComparable> empty = Enumerable.Empty<DummyIComparable>();
            IEnumerable<DummyIComparable> nulls = new DummyIComparable[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Maximum<DummyIComparable>(null), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.Maximum(), out ArgumentException argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Maximum(), out argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void Max() {

            IEnumerable<DummyIComparable> nullEnumerable = new DummyIComparable[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparable result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.Maximum(), out Exception ex);
            Test.If.Value.IsEqual(result, 1);

        }

        #endregion

        #region MaxT

        [TestMethod]
        void MaxT_ThrowsException() {

            IEnumerable<DummyIComparableT> empty = Enumerable.Empty<DummyIComparableT>();
            IEnumerable<DummyIComparableT> nulls = new DummyIComparableT[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.MaximumT<DummyIComparableT>(null), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => empty.MaximumT(), out ArgumentException argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.MaximumT(), out argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "_this");
            Test.If.String.StartsWith(argEx.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxT() {

            IEnumerable<DummyIComparableT> nullEnumerable = new DummyIComparableT[] { null, -1, -1, null, 0, 1, 1 };
            DummyIComparableT result = null;

            Test.IfNot.Action.ThrowsException(() => result = nullEnumerable.MaximumT(), out Exception ex);
            Test.If.Value.IsEqual(result, 1);

        }

        #endregion

        #region MaxComparerT

        [TestMethod]
        void MaxComparerT_ThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Maximum<Dummy>(null, null), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Maximum(null, Comparer<Dummy>.Default), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Maximum(null), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Maximum(Comparer<Dummy>.Default), out ArgumentException ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Maximum(Comparer<Dummy>.Default), out ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxComparerT() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Maximum(new DummyComparerT()), out Exception ex);
            Test.If.Value.IsEqual(result, 1, new DummyComparerT());

        }

        #endregion

        #region MaxIComparer

        [TestMethod]
        void MaxIComparer_ThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Maximum<Dummy>(null, null as IComparer), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Maximum<Dummy>(null, DynamicComparer.FromDelegate((x, y) => 0)), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Maximum(null as IComparer), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Maximum(DynamicComparer.FromDelegate((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Maximum(DynamicComparer.FromDelegate((x, y) => 0)), out ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxIComparer() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Maximum(new DummyIComparer()), out Exception ex);
            Test.If.Value.IsEqual(result, 1, new DummyIComparer());

        }

        #endregion

        #region MaxIComparerT

        [TestMethod]
        void MaxIComparerT_ThrowsException() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            IEnumerable<Dummy> empty = Enumerable.Empty<Dummy>();
            IEnumerable<Dummy> nulls = new Dummy[] { null, null };

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Maximum(null, null as IComparer<Dummy>), out ArgumentNullException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => IEnumerableTExtensions.Maximum(null, DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_this");

            Test.If.Action.ThrowsException(() => notEmpty.Maximum(null as IComparer<Dummy>), out ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "comparer");

            Test.If.Action.ThrowsException(() => empty.Maximum(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ArgumentException ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration is empty.");

            Test.If.Action.ThrowsException(() => nulls.Maximum(DynamicComparer.FromDelegate<Dummy>((x, y) => 0)), out ex2);
            Test.If.Value.IsEqual(ex2.ParamName, "_this");
            Test.If.String.StartsWith(ex2.Message, "The enumeration only contains null values.");

        }

        [TestMethod]
        void MaxIComparerT() {

            IEnumerable<Dummy> notEmpty = new Dummy[] { null, -1, -1, null, 0, 1, 1 };
            Dummy result = null;

            Test.IfNot.Action.ThrowsException(() => result = notEmpty.Maximum(new DummyIComparerT()), out Exception ex);
            Test.If.Value.IsEqual(result, 1, new DummyIComparerT());

        }

        #endregion

    }
}
