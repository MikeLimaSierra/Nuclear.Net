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
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.
        /// Throws an exception of type <see cref="ArgumentException"/> if <paramref name="value"/> is not defined in <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Enum.IsDefined&lt;MyEnum&gt;(enumVal, nameof(enumVal), $"The value of {nameof(enumVal)} must be defined!");
        /// </code>
        /// </example>
        public void IsDefined<TEnum>(Object value, String paramName, String message = "") where TEnum : Enum => IsDefined(typeof(TEnum), value, paramName, message);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="enum"/> is null.
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.
        /// Throws an exception of type <see cref="ArgumentException"/> if <paramref name="value"/> is not defined in <paramref name="enum"/>.
        /// </summary>
        /// <param name="enum">The enum type.</param>
        /// <param name="value">The enum value.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Enum.IsDefined(typeof(MyEnum), enumVal, nameof(enumVal), $"The value of {nameof(enumVal)} must be defined!");
        /// </code>
        /// </example>
        public void IsDefined(Type @enum, Object value, String paramName, String message = "") => IsDefined<ArgumentException>(@enum, value, message, paramName);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="value"/> is not defined in <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="value">The enum value.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.Enum.IsDefined&lt;ArgumentException, MyEnum&gt;(enumVal, $"The value of {nameof(enumVal)} must be defined!", nameof(enumVal));
        /// </code>
        /// </example>
        public void IsDefined<TException, TEnum>(Object value, params Object[] args) where TException : Exception where TEnum : Enum
            => IsDefined<TException>(typeof(TEnum), value, args);

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="enum"/> is null.
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="value"/> is null.
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="value"/> is not defined in <paramref name="enum"/>.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="enum">The enum type.</param>
        /// <param name="value">The enum value.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.Enum.IsDefined&lt;ArgumentException&gt;(typeof(MyEnum), enumVal, $"The value of {nameof(enumVal)} must be defined!", nameof(enumVal));
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
