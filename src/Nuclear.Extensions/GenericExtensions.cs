using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Nuclear.Extensions {

    /// <summary>
    /// Provides extension methods for any type.
    /// </summary>
    public static class GenericExtensions {

        /// <summary>
        /// Gets a <see cref="String"/> representing <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="_this"/>.</typeparam>
        /// <param name="_this">The object in question.</param>
        /// <returns>The formatted <see cref="String"/>.</returns>
        /// <example>
        /// <code>
        /// Console.WriteLine(someObject.Format());
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static String Format<T>(this T _this) {
            if(_this == null) { return "'null'"; }

            if(_this is Type type) { return String.Format(CultureInfo.InvariantCulture, "'{0}'", type.FullName); }

            return String.Format(CultureInfo.InvariantCulture, "'{0}'", _this);
        }

        /// <summary>
        /// Gets a <see cref="String"/> representing the type of <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="_this"/>.</typeparam>
        /// <param name="_this">The object in question.</param>
        /// <returns>The formatted <see cref="String"/>.</returns>
        /// <example>
        /// <code>
        /// Console.WriteLine(someObject.FormatType());
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static String FormatType<T>(this T _this) => _this != null ? _this.GetType().Format() : _this.Format();

        /// <summary>
        /// Determines equality of <paramref name="left"/> and <paramref name="right"/> using the implementations of
        ///     <see cref="IEquatable{T}"/>, <see cref="IComparable{T}"/>, <see cref="IComparable"/> and the default <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns>True if both objects are equal or null.</returns>
        /// <example>
        /// <code>
        /// if(someObject.IsEqual(someOtherObject)) {
        ///     // ...
        /// }
        /// </code>
        /// </example>
        public static Boolean IsEqual<T>(this T left, T right) {

            if(left == null) {
                if(right == null) {
                    return true;
                } else {
                    return right.IsEqual(left);
                }
            }

            if(left is IEquatable<T> eLeft) {
                try {
                    return eLeft.Equals(right);
                } catch { /* advance to next */ }
            }

            if(left is IComparable<T> cTLeft) {
                try {
                    return cTLeft.CompareTo(right) == 0;
                } catch { /* advance to next */ }
            }

            if(left is IComparable cLeft) {
                try {
                    return cLeft.CompareTo(right) == 0;
                } catch { /* advance to next */ }
            }

            return IsEqual(left, right, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Determines equality of <paramref name="left"/> and <paramref name="right"/> using an <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <param name="comparer">The comparer used to establish equality. Fallback is the default <see cref="IEqualityComparer{T}"/>.</param>
        /// <returns>True if both objects are equal or null.</returns>
        /// <example>
        /// <code>
        /// if(someObject.IsEqual(someOtherObject, new SomeClassEqualityComparer())) {
        ///     // ...
        /// }
        /// </code>
        /// </example>
        public static Boolean IsEqual<T>(this T left, T right, IEqualityComparer<T> comparer) {
            if(comparer == null) {
                comparer = EqualityComparer<T>.Default;
            }

            try {
                return comparer.Equals(left, right);

            } catch { }

            return false;
        }

    }
}
