using System;

namespace Nuclear.Exceptions {

    /// <summary>
    /// Implements a range of methods that throw exceptions on certain conditions.
    /// </summary>
    public class ConditionalThrow {

        #region Properties

        private Boolean Invert { get; set; } = false;

        #endregion

        #region ctors

        internal ConditionalThrow(Boolean invert = false) {
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
        /// <example>
        /// <code>
        /// Throw.If.Null(fileName, "fileName", "The file name must not be null!");
        /// </code>
        /// </example>
        public void Null(Object _object, String paramName, String message = "") => Null<ArgumentNullException>(_object, paramName, message);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="_object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.Null&lt;ArgumentException&gt;(fileName, "The file name must not be null!", "fileName");
        /// </code>
        /// </example>
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
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass&gt;(obj, "The object must not derive from MyClass.");
        /// </code>
        /// </example>
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
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass, NotImplementedException&gt;(obj, "There is no implemented support for objects of type MyClass.");
        /// </code>
        /// </example>
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
        /// <example>
        /// <code>
        /// Throw.If.NullOrEmpty(fileName, "fileName", "The file name must be set.");
        /// </code>
        /// </example>
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
        /// <example>
        /// <code>
        /// Throw.If.NullOrEmpty&lt;NotImplementedException&gt;(fileName, "Implementation does not support file names without content.");
        /// </code>
        /// </example>
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
        /// <example>
        /// <code>
        /// Throw.If.NullOrWhiteSpace(fileName, "fileName", "The file name must be set.");
        /// </code>
        /// </example>
        public void NullOrEmpty<TException>(String _string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrEmpty(_string), args);

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
        public void NullOrWhiteSpace<TException>(String _string, params Object[] args) where TException : Exception => InternalThrow<TException>(String.IsNullOrWhiteSpace(_string), args);

        #endregion

        #region boolean

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.True(myStream.CanRead, "The stream must not be able to read.");
        /// </code>
        /// </example>
        public void True(Boolean condition, String paramName, String message = "") => True<ArgumentException>(condition, message, paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.True&lt;NotImplementedException&gt;(myStream.CanTimeout, "Why are we having timeouts?");
        /// </code>
        /// </example>
        public void False(Boolean condition, String paramName, String message = "") => False<ArgumentException>(condition, message, paramName);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.False(myStream.CanRead, "The stream must be able to read.");
        /// </code>
        /// </example>
        public void True<TException>(Boolean condition, params Object[] args) where TException : Exception => InternalThrow<TException>(condition, args);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.False&lt;NotImplementedException&gt;(myStream.CanTimeout, "Why can't we have timeouts?");
        /// </code>
        /// </example>
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
