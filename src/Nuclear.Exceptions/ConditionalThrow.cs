using System;

namespace Nuclear.Exceptions {

    /// <summary>
    /// Supplies conditional throw instructions.
    /// </summary>
    public class ConditionalThrow {

        #region Properties

        private Boolean Invert { get; set; } = false;

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ConditionalThrow"/> where result inversion is as specified.
        /// </summary>
        /// <param name="invert">True if result inversion is desired, false if not.</param>
        public ConditionalThrow(Boolean invert = false) {
            Invert = invert;
        }

        #endregion

        #region references

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        public void Null(Object _object, String paramName, String message = "") => Null<ArgumentNullException>(_object, paramName, message);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        public void Null<TException>(Object _object, params Object[] args) where TException : Exception => InternalThrow<TException>(_object == null, args);

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
        public void OfType<TType>(Object _object, String paramName, String message = "") {
            Throw.If.Null(_object, paramName, message);
            OfType<ArgumentException, TType>(_object, message, paramName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <typeparam name="TType">The type of <paramref name="_object"/> to be checked against.</typeparam>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        public void OfType<TException, TType>(Object _object, params Object[] args) where TException : Exception {
            Throw.If.Null<ArgumentNullException>(_object);
            InternalThrow<TException>(_object is TType, args);
        }

        #endregion

        #region string

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="_string"/> is empty.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        public void NullOrEmpty(String _string, String paramName, String message = "") {
            if(!Invert) {
                Null(_string, paramName, message);
            }

            NullOrEmpty<ArgumentException>(_string, message, paramName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_string"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="_string"/> is white space or empty.
        /// </summary>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        public void NullOrWhiteSpace(String _string, String paramName, String message = "") {
            if(!Invert) {
                Null(_string, paramName, message);
            }

            NullOrWhiteSpace<ArgumentException>(_string, message, paramName);
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the <paramref name="_string"/> is null or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        public void NullOrEmpty<TException>(String _string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrEmpty(_string), args);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_string"/> is null or white space or empty.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_string">The <see cref="String"/> to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        public void NullOrWhiteSpace<TException>(String _string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrWhiteSpace(_string), args);

        #endregion

        #region boolean

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        public void True(Boolean condition, String paramName, String message = "") => True<ArgumentException>(condition, message, paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        public void False(Boolean condition, String paramName, String message = "") => False<ArgumentException>(condition, message, paramName);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        public void True<TException>(Boolean condition, params Object[] args) where TException : Exception => InternalThrow<TException>(condition, args);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        public void False<TException>(Boolean condition, params Object[] args) where TException : Exception => InternalThrow<TException>(!condition, args);

        #endregion

        #region private methods

        private void InternalThrow<TException>(Boolean condition, params Object[] args) where TException : Exception {
            condition = Invert ? !condition : condition;

            if(condition) {
                throw ExceptionFactory.Instance.Create<TException>(args);
            }
        }

        #endregion

    }
}
