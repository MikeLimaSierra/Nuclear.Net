using System;
using System.ComponentModel;

using Nuclear.Exceptions.ExceptionSuites;

namespace Nuclear.Exceptions {

    /// <summary>
    /// Supplies conditional throw implementation.
    /// </summary>
    public static class Throw {

        #region properties

        /// <summary>
        /// Gets conditional throw functionality.
        /// </summary>
        public static ExceptionSuiteCollection If { get; private set; } = new ExceptionSuiteCollection();

        /// <summary>
        /// Gets conditional throw functionality with inverted results.
        /// </summary>
        public static ExceptionSuiteCollection IfNot { get; private set; } = new ExceptionSuiteCollection(invert: true);

        #endregion

        #region hidden methods
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable IDE0060 // Remove unused parameter

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new Boolean ReferenceEquals(Object objA, Object objB) => throw new NotImplementedException("This method is currently out of order.");

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new Boolean Equals(Object objA, Object objB) => throw new NotImplementedException("This method is currently out of order.");

#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        #endregion

    }
}
