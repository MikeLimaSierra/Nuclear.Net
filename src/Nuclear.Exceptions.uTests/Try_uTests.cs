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
                new Object[] { null, (true, typeof(NullReferenceException)) },
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
                new Object[] { (null as Action, null as Action), (true, typeof(NullReferenceException)) },
                new Object[] { (new Action(() => { }), null as Action), (false, null as Type) },
                new Object[] { (null as Action, new Action(() => { })), (true, typeof(NullReferenceException)) },
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

            if(expected.result || result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoFuncData() {
            return new List<Object[]>() {
                new Object[] { typeof(Boolean), null, (true, false, typeof(NullReferenceException)) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => false), (false, false, null as Type) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => true), (false, true, null as Type) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => throw new ArgumentNullException()), (true, false, typeof(ArgumentNullException)) },
                new Object[] { typeof(Boolean), new Func<Boolean>(() => throw new NotImplementedException()), (true, false, typeof(NotImplementedException)) }
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

            if(expected.result || result) {
                Test.If.Object.IsOfExactType(ex, expected.exType);
            }

        }

        IEnumerable<Object[]> DoFuncWithFinallyData() {
            return new List<Object[]>() {
                new Object[] { typeof(Boolean), (null as Func<Boolean>, null as Action), (true, false, typeof(NullReferenceException)) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => false), null as Action), (false, false, null as Type) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => true), null as Action), (false, true, null as Type) },
                new Object[] { typeof(Boolean), (null as Func<Boolean>, new Action(() => { })), (true, false, typeof(NullReferenceException)) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => false), new Action(() => { })), (false, false, null as Type) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => true), new Action(() => { })), (false, true, null as Type) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => throw new ArgumentNullException()), new Action(() => { })), (true, false, typeof(ArgumentNullException)) },
                new Object[] { typeof(Boolean), (new Func<Boolean>(() => throw new NotImplementedException()), new Action(() => { })), (true, false, typeof(NotImplementedException)) }
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
