using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="GenericExtensions"/> provides extension methods to any unrestricted generic type.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class GenericExtensions {

        #region Format

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

            if(_this is String @string) { return String.Format(CultureInfo.InvariantCulture, "'{0}'", @string); }

            if(_this is IEnumerable enumerable) {
                Boolean first = true;
                StringBuilder sb = new StringBuilder("[");

                foreach(Object element in enumerable) {
                    sb.AppendFormat(CultureInfo.InvariantCulture, first ? "{0}" : ", {0}", element.Format());
                    first = false;
                }

                return sb.Append("]").ToString();
            }

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

        #endregion

        #region Equals

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
        public static Boolean Equals<T>(this T left, T right) {

            if(left == null) {
                return right != null ? right.Equals<T>(left) : true;
            }

            if(right == null) {
                return false;
            }

            if(left is IEquatable<T> eLeft) {
                try {
                    return eLeft.Equals(right);
                } catch { /* advance to next */ }
            }

            if(left is IComparable<T> cTLeft) {
                try {
                    return cTLeft.IsEqual(right);
                } catch { /* advance to next */ }
            }

            if(left is IComparable cLeft) {
                try {
                    return cLeft.IsEqual(right);
                } catch { /* advance to next */ }
            }

            return EqualityComparer<T>.Default.Equals(left, right);
        }

        #endregion

    }
}
