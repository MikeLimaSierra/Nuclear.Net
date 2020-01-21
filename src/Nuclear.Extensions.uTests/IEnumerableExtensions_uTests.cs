using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class IEnumerableExtensions_uTests {

        #region ForEach

        [TestMethod]
        void ForeachThrowsException() {

            IEnumerable enumerable = new List<Object>();

            Test.If.Action.ThrowsException(() => ((IEnumerable) null).ForEach(null), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => ((IEnumerable) null).ForEach((value) => { }), out ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

            Test.If.Action.ThrowsException(() => enumerable.ForEach(null), out ex);
            Test.If.Value.IsEqual(ex.ParamName, "action");

        }

        [TestMethod]
        void ForeachAppliesAction() {

            IEnumerable enumerable = Enumerable.Range(1, 10);
            Int32 result = 0;

            Test.IfNot.Action.ThrowsException(() => enumerable.ForEach((value) => { result += (Int32) value; }), out Exception ex);
            Test.If.Value.IsEqual(result, 55);

        }

        #endregion

        #region Count

        [TestMethod]
        void CountThrowsException() {

            Test.If.Action.ThrowsException(() => ((IEnumerable) null).Count(), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

        }

        [TestMethod]
        void CountGetsCount() {

            IEnumerable enumerable = Enumerable.Range(1, 10);
            Int32 result = 0;

            Test.IfNot.Action.ThrowsException(() => result = enumerable.Count(), out Exception ex);
            Test.If.Value.IsEqual(result, 10);

        }

        #endregion

        #region LongCount

        [TestMethod]
        void LongCountThrowsException() {

            Test.If.Action.ThrowsException(() => ((IEnumerable) null).LongCount(), out ArgumentNullException ex);
            Test.If.Value.IsEqual(ex.ParamName, "_this");

        }

        [TestMethod]
        void LongCountGetsCount() {

            IEnumerable enumerable = Enumerable.Range(1, 10);
            Int64 result = 0;

            Test.IfNot.Action.ThrowsException(() => result = enumerable.LongCount(), out Exception ex);
            Test.If.Value.IsEqual(result, 10);

        }

        #endregion

    }
}
