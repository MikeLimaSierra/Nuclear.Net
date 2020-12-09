using System;
using System.ComponentModel;
using Nuclear.Exceptions.ExceptionSuites.Base;

namespace Nuclear.Exceptions.ExceptionSuites {

    /// <summary>
    /// Provides conditional probing instructions for strings.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StringExceptionSuite : BaseExceptionSuite {

        #region ctors

        internal StringExceptionSuite(ExceptionSuiteCollection parent) : base(parent) { }

        #endregion

        #region IsNullOrEmpty

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="string"/> is empty.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.String.IsNullOrEmpty(fileName, nameof(fileName), "The file name must be set.");
        /// </code>
        /// </example>
        public void IsNullOrEmpty(String @string, String paramName, String message = "") {
            if(!Parent.Invert) {
                Throw.If.Object.IsNull(@string, paramName, message);
            }

            IsNullOrEmpty<ArgumentException>(@string, message, paramName);
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the <paramref name="string"/> is null or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.String.IsNullOrEmpty&lt;ArgumentException&gt;(fileName, "The file name must be set.", nameof(fileName));
        /// </code>
        /// </example>
        public void IsNullOrEmpty<TException>(String @string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrEmpty(@string), args);

        #endregion

        #region IsNullOrWhiteSpace

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="string"/> is white space or empty.
        /// </summary>
        /// <param name="string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.String.IsNullOrWhiteSpace&lt;NotImplementedException&gt;(fileName, nameof(fileName), "Implementation does not support file names without content.");
        /// </code>
        /// </example>
        public void IsNullOrWhiteSpace(String @string, String paramName, String message = "") {
            if(!Parent.Invert) {
                Throw.If.Object.IsNull(@string, paramName, message);
            }

            IsNullOrWhiteSpace<ArgumentException>(@string, message, paramName);
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="string"/> is null or white space or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.String.IsNullOrWhiteSpace&lt;NotImplementedException>(fileName, "Implementation does not support file names without content.");
        /// </code>
        /// </example>
        public void IsNullOrWhiteSpace<TException>(String @string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrWhiteSpace(@string), args);

        #endregion

    }
}
