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
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// </summary>
        /// <param name="object">The object to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Null(fileName, "fileName", "The file name must not be null!");
        /// </code>
        /// </example>
        public void IsNull(Object @object, String paramName, String message = "") => IsNull<ArgumentNullException>(@object, paramName, message);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="object"/> is null.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.Null&lt;ArgumentException&gt;(fileName, "The file name must not be null!", "fileName");
        /// </code>
        /// </example>
        public void IsNull<TException>(Object @object, params Object[] args) where TException : Exception => InternalThrow<TException>(@object == null, args);

        #endregion

        #region IsOfType

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="object"/> to be checked against.</typeparam>
        /// <param name="object">The object to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass&gt;(obj, "The object must not derive from MyClass.");
        /// </code>
        /// </example>
        public void IsOfType<TType>(Object @object, String paramName, String message = "") => IsOfType(@object, typeof(TType), paramName, message);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="type"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="object"/> is of type <paramref name="type"/>.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass&gt;(obj, "The object must not derive from MyClass.");
        /// </code>
        /// </example>
        public void IsOfType(Object @object, Type type, String paramName, String message = "") => IsOfType<ArgumentException>(@object, type, message, paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <typeparam name="TType">The type of <paramref name="object"/> to be checked against.</typeparam>
        /// <param name="object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass, NotImplementedException&gt;(obj, "There is no implemented support for objects of type MyClass.");
        /// </code>
        /// </example>
        public void IsOfType<TException, TType>(Object @object, params Object[] args) where TException : Exception => IsOfType<TException>(@object, typeof(TType), args);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="type"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="object"/> is of type <paramref name="type"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass, NotImplementedException&gt;(obj, "There is no implemented support for objects of type MyClass.");
        /// </code>
        /// </example>
        public void IsOfType<TException>(Object @object, Type type, params Object[] args) where TException : Exception {
            Throw.If.Object.IsNull<ArgumentNullException>(@object, nameof(@object));
            Throw.If.Object.IsNull<ArgumentNullException>(type, nameof(type));

            InternalThrow<TException>(type.IsAssignableFrom(@object.GetType()), args);
        }

        #endregion

        #region IsOfExactType

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TType">The type of <paramref name="object"/> to be checked against.</typeparam>
        /// <param name="object">The object to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass&gt;(obj, "The object must not derive from MyClass.");
        /// </code>
        /// </example>
        public void IsOfExactType<TType>(Object @object, String paramName, String message = "") => IsOfExactType(@object, typeof(TType), paramName, message);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <typeparam name="TType">The type of <paramref name="object"/> to be checked against.</typeparam>
        /// <param name="object">The object to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass, NotImplementedException&gt;(obj, "There is no implemented support for objects of type MyClass.");
        /// </code>
        /// </example>
        public void IsOfExactType<TException, TType>(Object @object, params Object[] args) where TException : Exception => IsOfExactType<TException>(@object, typeof(TType), args);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an <see cref="ArgumentException"/> if <paramref name="object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass&gt;(obj, "The object must not derive from MyClass.");
        /// </code>
        /// </example>
        public void IsOfExactType(Object @object, Type type, String paramName, String message = "") => IsOfExactType<ArgumentException>(@object, type, message, paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="object"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="object"/> is of type <typeparamref name="TType"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="object">The object to be checked.</param>
        /// <param name="type">The type to be checked for.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.OfType&lt;MyClass, NotImplementedException&gt;(obj, "There is no implemented support for objects of type MyClass.");
        /// </code>
        /// </example>
        public void IsOfExactType<TException>(Object @object, Type type, params Object[] args) where TException : Exception {
            Throw.If.Object.IsNull<ArgumentNullException>(@object, nameof(@object));
            Throw.If.Object.IsNull<ArgumentNullException>(type, nameof(type));

            InternalThrow<TException>(@object.GetType().Equals(type), args);
        }

        #endregion

    }
}
