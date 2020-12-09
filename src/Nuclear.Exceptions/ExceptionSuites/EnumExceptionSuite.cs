using System;
using System.ComponentModel;

using Nuclear.Exceptions.ExceptionSuites.Base;

namespace Nuclear.Exceptions.ExceptionSuites {

    /// <summary>
    /// Provides conditional probing instructions for enums.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EnumExceptionSuite : BaseExceptionSuite {

        #region ctors

        internal EnumExceptionSuite(ExceptionSuiteCollection parent) : base(parent) { }

        #endregion

        #region IsDefined

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <param name="enum">The enum type.</param>
        /// <param name="value">The enum value.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Null(fileName, "fileName", "The file name must not be null!");
        /// </code>
        /// </example>
        public void IsDefined<TEnum>(Object value, String paramName, String message = "") where TEnum : Enum => IsDefined(typeof(TEnum), value, paramName, message);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <param name="enum">The enum type.</param>
        /// <param name="value">The enum value.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Null(fileName, "fileName", "The file name must not be null!");
        /// </code>
        /// </example>
        public void IsDefined(Type @enum, Object value, String paramName, String message = "") => IsDefined<ArgumentException>(@enum, value, message, paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <param name="enum">The enum type.</param>
        /// <param name="value">The enum value.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Null(fileName, "fileName", "The file name must not be null!");
        /// </code>
        /// </example>
        public void IsDefined<TException, TEnum>(Object value, params Object[] args) where TException : Exception where TEnum : Enum
            => IsDefined<TException>(typeof(TEnum), value, args);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="_object"/> is null.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="enum">The enum type.</param>
        /// <param name="value">The enum value.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.Null&lt;ArgumentException&gt;(fileName, "The file name must not be null!", "fileName");
        /// </code>
        /// </example>
        public void IsDefined<TException>(Type @enum, Object value, params Object[] args) where TException : Exception {
            Throw.If.Object.IsNull<ArgumentNullException>(@enum, nameof(@enum));
            Throw.If.Object.IsNull<ArgumentNullException>(value, nameof(value));

            InternalThrow<TException>(Enum.IsDefined(@enum, value), args);
        }

        #endregion

    }
}
