using System;
using System.Collections.Generic;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="ComparerTExtensions"/> provides extension methods to the type <see cref="Comparer{T}"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class ComparerTExtensions {

        #region IsEqual

        /// <summary>
        /// Checks if two objects <paramref name="x"/> and <paramref name="y"/> are considered equal.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="x">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="x"/> is equal to <paramref name="y"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = new MyComparer().IsEqual(value1, value2);
        /// </code>
        /// </example>
        public static Boolean IsEqual<T>(this Comparer<T> _this, T x, T y) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.Compare(x, y) == 0;
        }

        #endregion

        #region IsLess

        /// <summary>
        /// Checks if <paramref name="x"/> is considered less than <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="x">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="x"/> is less than <paramref name="y"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = new MyComparer().LessThan(value1, value2);
        /// </code>
        /// </example>
        public static Boolean IsLessThan<T>(this Comparer<T> _this, T x, T y) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.Compare(x, y) < 0;
        }

        /// <summary>
        /// Checks if <paramref name="x"/> is considered less than <paramref name="y"/> or equal.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="x">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="x"/> is less than <paramref name="y"/> or equal.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = new MyComparer().LessThanOrEquals(value1, value2);
        /// </code>
        /// </example>
        public static Boolean IsLessThanOrEqual<T>(this Comparer<T> _this, T x, T y) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.Compare(x, y) <= 0;
        }

        #endregion

        #region IsGreater

        /// <summary>
        /// Checks if <paramref name="x"/> is considered greater than <paramref name="y"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="x">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="x"/> is greater than <paramref name="y"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = new MyComparer().GreaterThan(value1, value2);
        /// </code>
        /// </example>
        public static Boolean IsGreaterThan<T>(this Comparer<T> _this, T x, T y) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.Compare(x, y) > 0;
        }

        /// <summary>
        /// Checks if <paramref name="x"/> is considered greater than <paramref name="y"/> or equal.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="x">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="x"/> is greater than <paramref name="y"/> or equal.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = new MyComparer().GreaterThanOrEquals(value1, value2);
        /// </code>
        /// </example>
        public static Boolean IsGreaterThanOrEqual<T>(this Comparer<T> _this, T x, T y) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.Compare(x, y) >= 0;
        }

        #endregion

        #region IsClamped

        /// <summary>
        /// Checks if a <paramref name="value"/> is clamped in an inclusive range between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="value"></param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <returns>True if <paramref name="value"/> is clamped, false if not.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = new MyComparer().IsClamped(value, min, max);
        /// </code>
        /// </example>
        public static Boolean IsClamped<T>(this Comparer<T> _this, T value, T min, T max) {
            Throw.If.Object.IsNull(_this, nameof(_this));
            Throw.If.Object.IsNull(value, nameof(value));

            if(min != null && max != null && _this.IsGreaterThan(min, max)) {
                return _this.IsClamped(value, max, min);
            }

            Boolean result = true;

            result &= min == null || _this.IsGreaterThanOrEqual(value, min);
            result &= max == null || _this.IsLessThanOrEqual(value, max);

            return result;
        }

        /// <summary>
        /// Checks if a <paramref name="value"/> is clamped in an exclusive range between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="value"></param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <returns>True if <paramref name="value"/> is clamped, false if not.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = new MyComparer().IsClampedExclusive(value, min, max);
        /// </code>
        /// </example>
        public static Boolean IsClampedExclusive<T>(this Comparer<T> _this, T value, T min, T max) {
            Throw.If.Object.IsNull(_this, nameof(_this));
            Throw.If.Object.IsNull(value, nameof(value));

            if(min != null && max != null && _this.IsGreaterThan(min, max)) {
                return _this.IsClampedExclusive(value, max, min);
            }

            Boolean result = true;

            result &= min == null || _this.IsGreaterThan(value, min);
            result &= max == null || _this.IsLessThan(value, max);

            return result;
        }

        #endregion

        #region Clamp

        /// <summary>
        /// Clamps <paramref name="value"/> to a given inclusive range between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="value"></param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <returns>The clamped version of <paramref name="value"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// var result = new MyComparer().Clamp(value, min, max);
        /// </code>
        /// </example>
        public static T Clamp<T>(this Comparer<T> _this, T value, T min, T max) {
            Throw.If.Object.IsNull(_this, nameof(_this));
            Throw.If.Object.IsNull(value, nameof(value));

            if(min != null && max != null && _this.IsGreaterThan(min, max)) {
                return _this.Clamp(value, max, min);
            }

            T result = value;

            if(min != null) { result = _this.Max(value, min); }

            if(max != null) { result = _this.Min(result, max); }

            return result;
        }

        #endregion

        #region Min

        /// <summary>
        /// Gets the lower value of two objects.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="x">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>The lower value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// var result = new MyComparer().Min(value1, value2);
        /// </code>
        /// </example>
        public static T Min<T>(this Comparer<T> _this, T x, T y) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.IsLessThan(x, y) ? x : y;
        }

        #endregion

        #region Max

        /// <summary>
        /// Gets the higher value of two objects.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="_this">The <see cref="Comparer{T}"/> used for comparisons.</param>
        /// <param name="x">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>The higher value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// var result = new MyComparer().Max(value1, value2);
        /// </code>
        /// </example>
        public static T Max<T>(this Comparer<T> _this, T x, T y) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.IsGreaterThan(x, y) ? x : y;
        }

        #endregion

    }
}
