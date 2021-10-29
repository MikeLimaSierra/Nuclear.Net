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

            if(!expected.result || !result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoActionData() {
            return new List<Object[]>() {
                new Object[] { null, (false, typeof(NullReferenceException)) },
                new Object[] { new Action(() => { }), (true, null as Type) },
                new Object[] { new Action(() => throw new ArgumentNullException()), (false, typeof(ArgumentNullException)) },
                new Object[] { new Action(() => throw new NotImplementedException()), (false, typeof(NotImplementedException)) }
            };
        }

        [TestMethod]
        [TestData(nameof(DoActionWithFinallyData))]
        void DoActionWithFinally((Action action, Action @finally) input, (Boolean result, Type exType) expected) {

            Boolean result = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = Try.Do(input.action, input.@finally, out ex), out Exception _);

            Test.If.Value.IsEqual(result, expected.result);

            if(!expected.result || !result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoActionWithFinallyData() {
            return new List<Object[]>() {
                new Object[] { (null as Action, null as Action), (false, typeof(NullReferenceException)) },
                new Object[] { (new Action(() => { }), null as Action), (true, null as Type) },
                new Object[] { (null as Action, new Action(() => { })), (false, typeof(NullReferenceException)) },
                new Object[] { (new Action(() => { }), new Action(() => { })), (true, null as Type) },
                new Object[] { (new Action(() => throw new ArgumentNullException()), new Action(() => { })), (false, typeof(ArgumentNullException)) },
                new Object[] { (new Action(() => throw new NotImplementedException()), new Action(() => { })), (false, typeof(NotImplementedException)) }
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

        #region DoFunc

        [TestMethod]
        [TestData(nameof(DoFuncData))]
        void DoFunc<T>(Func<T> func, (Boolean result, T returnVal, Type exType) expected) {

            Boolean result = default;
            T returnVal = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = Try.Do(func, out returnVal, out ex), out Exception _);

            Test.If.Value.IsEqual(result, expected.result);
            Test.If.Value.IsEqual(returnVal, expected.returnVal);

            if(!expected.result || !result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoFuncData() {
            return new List<Object[]>() {
                new Object[] { typeof(Boolean), null, (false, false, typeof(NullReferenceException)) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => false), (true, false, null as Type) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => true), (true, true, null as Type) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => throw new ArgumentNullException()), (false, false, typeof(ArgumentNullException)) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => throw new NotImplementedException()), (false, false, typeof(NotImplementedException)) }
            };
        }

        [TestMethod]
        [TestData(nameof(DoFuncWithFinallyData))]
        void DoFuncWithFinally<T>((Func<T> func, Action @finally) input, (Boolean result, T returnVal, Type exType) expected) {

            Boolean result = default;
            T returnVal = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = Try.Do(input.func, input.@finally, out returnVal, out ex), out Exception _);

            Test.If.Value.IsEqual(result, expected.result);
            Test.If.Value.IsEqual(returnVal, expected.returnVal);

            if(!expected.result || !result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoFuncWithFinallyData() {
            return new List<Object[]>() {
                new Object[] { typeof(Boolean), (null as Func<Boolean>, null as Action), (false, false, typeof(NullReferenceException)) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => false), null as Action), (true, false, null as Type) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => true), null as Action), (true, true, null as Type) },
                new Object[] { typeof(Boolean), (null as Func<Boolean>, new Action(() => { })), (false, false, typeof(NullReferenceException)) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => false), new Action(() => { })), (true, false, null as Type) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => true), new Action(() => { })), (true, true, null as Type) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => throw new ArgumentNullException()), new Action(() => { })), (false, false, typeof(ArgumentNullException)) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => throw new NotImplementedException()), new Action(() => { })), (false, false, typeof(NotImplementedException)) }
            };
        }

        [TestMethod]
        void DoFuncWithFinallyThrows() {

            Exception exOut = default;
            Boolean returnVal = default;

            Test.If.Action.ThrowsException(() => Try.Do(new Func<Boolean>(() => throw new NotImplementedException()), () => throw new ArgumentException(), out returnVal, out exOut), out Exception ex);

            Test.If.Object.IsOfExactType<NotImplementedException>(exOut);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);

        }

        #endregion

    }
}
