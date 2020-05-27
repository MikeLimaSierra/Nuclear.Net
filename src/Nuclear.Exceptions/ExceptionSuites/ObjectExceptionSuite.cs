using System;
using System.ComponentModel;
using Nuclear.Exceptions.ExceptionSuites.Base;

namespace Nuclear.Exceptions.ExceptionSuites {

    /// <summary>
    /// Provides conditional probing instructions for objects.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ObjectExceptionSuite : BaseExceptionSuite {

        #region ctors

        internal ObjectExceptionSuite(ExceptionSuiteCollection parent) : base(parent) { }

        #endregion

        #region IsNull

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
        public void IsNull(Object _object, String paramName, String message = "") => IsNull<ArgumentNullException>(_object, paramName, message);

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
        public void IsNull<TException>(Object _object, params Object[] args) where TException : Exception => InternalThrow<TException>(_object == null, args);

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
        public void IsOfType<TType>(Object _object, String paramName, String message = "") {
            Throw.If.Object.IsNull(_object, paramName, message);
            IsOfType<ArgumentException, TType>(_object, message, paramName);
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
        public void IsOfType<TException, TType>(Object _object, params Object[] args) where TException : Exception {
            Throw.If.Object.IsNull<ArgumentNullException>(_object);
            InternalThrow<TException>(_object is TType, args);
        }

        #endregion

    }
}
