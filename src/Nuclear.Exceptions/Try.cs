using System;
using System.ComponentModel;

namespace Nuclear.Exceptions {

    /// <summary>
    /// Supplies easy try-catch implementations.
    /// </summary>
    public static class Try {

        #region Action

        /// <summary>
        /// Invokes <paramref name="action"/> and catches all thrown exceptions.
        /// Any thrown exception is returned in <paramref name="ex"/>.
        /// </summary>
        /// <param name="action">The <see cref="Action"/> that is invoked.</param>
        /// <param name="ex">Any exception that was thrown during invokation.</param>
        /// <returns>True if <paramref name="action"/> was invoked without exception.</returns>
        public static Boolean Do(Action action, out Exception ex) => Do(action, null, out ex);

        /// <summary>
        /// Invokes <paramref name="action"/> and catches all thrown exceptions.
        /// The <see cref="Action"/> given in <paramref name="finally"/> is invoked in the finally block would.
        /// Any thrown exception is returned in <paramref name="ex"/>.
        /// </summary>
        /// <param name="action">The <see cref="Action"/> that is invoked.</param>
        /// <param name="finally">The <see cref="Action"/> that is invoked in the finally block.</param>
        /// <param name="ex">Any exception that was thrown during invokation.</param>
        /// <returns>True if <paramref name="action"/> was invoked without exception.</returns>
        public static Boolean Do(Action action, Action @finally, out Exception ex) {
            ex = default;

            try {
                action();

            } catch(Exception _) { ex = _; } finally { @finally?.Invoke(); }

            return ex == null;
        }

        #endregion

        #region Func

        /// <summary>
        /// Invokes <paramref name="func"/> and catches all thrown exceptions.
        /// The result of <paramref name="func"/> is returned in <paramref name="result"/>.
        /// Any thrown exception is returned in <paramref name="ex"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The <see cref="Func{T}"/> that is invoked.</param>
        /// <param name="result">The result of <paramref name="func"/>.</param>
        /// <param name="ex">Any exception that was thrown during invokation.</param>
        /// <returns>True if <paramref name="func"/> was invoked without exception.</returns>
        public static Boolean Do<T>(Func<T> func, out T result, out Exception ex) => Do(func, null, out result, out ex);

        /// <summary>
        /// Invokes <paramref name="func"/> and catches all thrown exceptions.
        /// The result of <paramref name="func"/> is returned in <paramref name="result"/>.
        /// The <see cref="Action"/> given in <paramref name="finally"/> is invoked in the finally block would.
        /// Any thrown exception is returned in <paramref name="ex"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The <see cref="Func{T}"/> that is invoked.</param>
        /// <param name="finally">The <see cref="Action"/> that is invoked in the finally block.</param>
        /// <param name="result">The result of <paramref name="func"/>.</param>
        /// <param name="ex">Any exception that was thrown during invokation.</param>
        /// <returns>True if <paramref name="func"/> was invoked without exception.</returns>
        public static Boolean Do<T>(Func<T> func, Action @finally, out T result, out Exception ex) {
            result = default;
            ex = default;

            try {
                result = func();

            } catch(Exception _) { ex = _; } finally { @finally?.Invoke(); }

            return ex == null;
        }

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
