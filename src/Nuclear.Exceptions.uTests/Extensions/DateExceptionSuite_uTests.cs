using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Exceptions.Extensions {

    class DateExceptionSuite_uTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        private static readonly DateTime _monday = new DateTime(2020, 5, 4);

        private static readonly DateTime _tuesday = new DateTime(2020, 5, 5);

        private static readonly DateTime _wednesday = new DateTime(2020, 5, 6);

        private static readonly DateTime _thursday = new DateTime(2020, 5, 7);

        private static readonly DateTime _friday = new DateTime(2020, 5, 8);

        private static readonly DateTime _saturday = new DateTime(2020, 5, 9);

        private static readonly DateTime _sunday = new DateTime(2020, 5, 10);

        #region IsMonday

        [TestMethod]
        void ThrowIfMondayIsMonday() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Date().IsMonday(_monday, _paramName, _message), out ArgumentException ex1);
            Test.If.Value.IsEqual(_paramName, ex1.ParamName);
            Test.If.String.StartsWith(ex1.Message, _message);

        }

        [TestMethod]
        [TestData(nameof(ThrowIfNotMondayIsMonday_Data))]
        void ThrowIfNotMondayIsMonday(DateTime date) {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Date().IsMonday(date, _paramName, _message), out Exception ex2);

        }

        IEnumerable<Object[]> ThrowIfNotMondayIsMonday_Data() {
            return new List<Object[]>() {
                new Object[] { _tuesday },
                new Object[] { _wednesday },
                new Object[] { _thursday },
                new Object[] { _friday },
                new Object[] { _saturday },
                new Object[] { _sunday },
            };
        }

        [TestMethod]
        void ThrowIfMondayIsNotMonday() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Date().IsMonday(_monday, _paramName, _message), out Exception ex1);

        }

        [TestMethod]
        [TestData(nameof(ThrowIfNotMondayIsNotMonday_Data))]
        void ThrowIfNotMondayIsNotMonday(DateTime date) {

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Date().IsMonday(date, _paramName, _message), out ArgumentException ex2);
            Test.If.Value.IsEqual(_paramName, ex2.ParamName);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        IEnumerable<Object[]> ThrowIfNotMondayIsNotMonday_Data() {
            return new List<Object[]>() {
                new Object[] { _tuesday },
                new Object[] { _wednesday },
                new Object[] { _thursday },
                new Object[] { _friday },
                new Object[] { _saturday },
                new Object[] { _sunday },
            };
        }

        #endregion

        #region IsMondayGeneric

        [TestMethod]
        void ThrowIfMondayIsMonday_Generic() {

            Test.If.Action.ThrowsException(() =>
                Throw.If.Date().IsMonday<NotImplementedException>(_monday, _message), out NotImplementedException ex1);
            Test.If.String.StartsWith(ex1.Message, _message);

        }

        [TestMethod]
        [TestData(nameof(ThrowIfNotMondayIsMonday_Data))]
        void ThrowIfNotMondayIsMonday_Generic(DateTime date) {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.If.Date().IsMonday<NotImplementedException>(date, _message), out Exception ex2);

        }

        [TestMethod]
        void ThrowIfMondayIsNotMonday_Generic() {

            Test.IfNot.Action.ThrowsException(() =>
                Throw.IfNot.Date().IsMonday<NotImplementedException>(_monday, _message), out Exception ex1);

        }

        [TestMethod]
        [TestData(nameof(ThrowIfNotMondayIsNotMonday_Data))]
        void ThrowIfNotMondayIsNotMonday_Generic(DateTime date) {

            Test.If.Action.ThrowsException(() =>
                Throw.IfNot.Date().IsMonday<NotImplementedException>(date, _message), out NotImplementedException ex2);
            Test.If.String.StartsWith(ex2.Message, _message);

        }

        #endregion

    }
}
