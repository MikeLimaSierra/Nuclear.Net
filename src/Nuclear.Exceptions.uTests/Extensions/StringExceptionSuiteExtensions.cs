using System;

using Nuclear.Exceptions.ExceptionSuites;

namespace Nuclear.Exceptions.Extensions {
    internal static class StringExceptionSuiteExtensions {

        public static void IsHello(this StringExceptionSuite _this, String _string, String paramName, String message = "")
            => _this.IsHello<ArgumentException>(_string, message, paramName);

        public static void IsHello<TException>(this StringExceptionSuite _this, String _string, params Object[] args) where TException : Exception
            => _this.InternalThrow<TException>(_string == "Hello", args);

    }
}
