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
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="_string"/> is empty.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.NullOrEmpty(fileName, "fileName", "The file name must be set.");
        /// </code>
        /// </example>
        public void IsNullOrEmpty(String _string, String paramName, String message = "") {
            if(!Parent.Invert) {
                Throw.If.Object.IsNull(_string, paramName, message);
            }

            IsNullOrEmpty<ArgumentException>(_string, message, paramName);
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the <paramref name="_string"/> is null or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.NullOrWhiteSpace(fileName, "fileName", "The file name must be set.");
        /// </code>
        /// </example>
        public void IsNullOrEmpty<TException>(String _string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrEmpty(_string), args);

        #endregion

        #region IsNullOrWhiteSpace

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="_string"/> is white space or empty.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.NullOrEmpty&lt;NotImplementedException&gt;(fileName, "Implementation does not support file names without content.");
        /// </code>
        /// </example>
        public void IsNullOrWhiteSpace(String _string, String paramName, String message = "") {
            if(!Parent.Invert) {
                Throw.If.Object.IsNull(_string, paramName, message);
            }

            IsNullOrWhiteSpace<ArgumentException>(_string, message, paramName);
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_string"/> is null or white space or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.NullOrWhiteSpace&lt;NotImplementedException>(fileName, "Implementation does not support file names without content.");
        /// </code>
        /// </example>
        public void IsNullOrWhiteSpace<TException>(String _string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrWhiteSpace(_string), args);

        #endregion

    }
}
