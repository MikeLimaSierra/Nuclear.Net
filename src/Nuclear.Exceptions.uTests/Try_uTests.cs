using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Exceptions {
    class Try_uTests {

        #region DoAction

        [TestMethod]
        [TestData(nameof(DoActionData))]
        void DoAction(Action action, (Boolean result, Type exType) expected) {

            Boolean result = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = Try.Do(action, out ex), out Exception _);

            Test.If.Value.IsEqual(result, expected.result);

            if(expected.result || result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoActionData() {
            return new List<Object[]>() {
                new Object[] { null, (true, typeof( NullReferenceException)) },
                new Object[] { new Action(() => { }), (false, null as Type) },
                new Object[] { new Action(() => throw new ArgumentNullException()), (true, typeof(ArgumentNullException)) },
                new Object[] { new Action(() => throw new NotImplementedException()), (true, typeof(NotImplementedException)) }
            };
        }

        [TestMethod]
        [TestData(nameof(DoActionWithFinallyData))]
        void DoActionWithFinally((Action action, Action @finally) input, (Boolean result, Type exType) expected) {

            Boolean result = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = Try.Do(input.action, input.@finally, out ex), out Exception _);

            Test.If.Value.IsEqual(result, expected.result);

            if(expected.result || result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoActionWithFinallyData() {
            return new List<Object[]>() {
                new Object[] { (null as Action, null as Action), (true, typeof( NullReferenceException)) },
                new Object[] { (new Action(() => { }), null as Action), (false, null as Type) },
                new Object[] { (null as Action, new Action(() => { })), (true, typeof( NullReferenceException)) },
                new Object[] { (new Action(() => { }), new Action(() => { })), (false, null as Type) },
                new Object[] { (new Action(() => throw new ArgumentNullException()), new Action(() => { })), (true, typeof(ArgumentNullException)) },
                new Object[] { (new Action(() => throw new NotImplementedException()), new Action(() => { })), (true, typeof(NotImplementedException)) }
            };
        }

        [TestMethod]
        void DoActionWithFinallyThrows() {

            Exception exOut = default;

            Test.If.Action.ThrowsException(() => Try.Do(() => throw new NotImplementedException(), () => throw new ArgumentException(), out exOut), out Exception ex);

            Test.If.Object.IsOfExactType<NotImplementedException>(exOut);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);

        }

        #endregion

    }
}
