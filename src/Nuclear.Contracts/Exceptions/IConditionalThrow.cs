using System;

namespace Nuclear.Exceptions {
    public interface IConditionalThrow {

        #region references

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        void Null(Object _object, String paramName, String message = "");

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> target type if <paramref name="_object"/> is null.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        void Null<TException>(Object _object, params Object[] args) where TException : Exception;

        #endregion

        #region types

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="_object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="_object"/> to be checked against.</typeparam>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        void OfType<TType>(Object _object, String paramName, String message = "");

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <typeparam name="TType">The type of <paramref name="_object"/> to be checked against.</typeparam>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        void OfType<TException, TType>(Object _object, params Object[] args) where TException : Exception;

        #endregion

        #region string

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="_string"/> is empty.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        void NullOrEmpty(String _string, String paramName, String message = "");

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="_string"/> is white space or empty.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        void NullOrWhiteSpace(String _string, String paramName, String message = "");

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the <paramref name="_string"/> is null or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        void NullOrEmpty<TException>(String _string, params Object[] args) where TException : Exception;

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_string"/> is null or white space or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        void NullOrWhiteSpace<TException>(String _string, params Object[] args) where TException : Exception;

        #endregion

        #region boolean

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        void True(Boolean condition, String paramName, String message = "");

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        void False(Boolean condition, String paramName, String message = "");

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        void True<TException>(Boolean condition, params Object[] args) where TException : Exception;

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        void False<TException>(Boolean condition, params Object[] args) where TException : Exception;

        #endregion

    }
}
