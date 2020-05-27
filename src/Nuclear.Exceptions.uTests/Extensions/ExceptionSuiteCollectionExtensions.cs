using Nuclear.Exceptions.ExceptionSuites;

namespace Nuclear.Exceptions.Extensions {
    internal static class ExceptionSuiteCollectionExtensions {

        internal static DateExceptionSuite Date(this ExceptionSuiteCollection _this) => new DateExceptionSuite(_this);

    }
}
