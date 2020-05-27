using System;

using Nuclear.Exceptions.ExceptionSuites;
using Nuclear.Exceptions.ExceptionSuites.Base;

namespace Nuclear.Exceptions.Extensions {
    internal class DateExceptionSuite : BaseExceptionSuite {

        #region ctors

        internal DateExceptionSuite(ExceptionSuiteCollection parent) : base(parent) { }

        #endregion

        #region IsMonday

        internal void IsMonday(DateTime date, String paramName, String message = "") => IsMonday<ArgumentException>(date, message, paramName);

        internal void IsMonday<TException>(DateTime date, params Object[] args) where TException : Exception => InternalThrow<TException>(date.DayOfWeek == DayOfWeek.Monday, args);

        #endregion

    }
}
