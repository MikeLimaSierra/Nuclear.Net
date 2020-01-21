using System;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="IComparableTExtensions"/> provides extension methods to the type <see cref="IComparable{T}"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class IComparableTExtensions {

        #region IsEqual

        /// <summary>
        /// Checks if <paramref name="_this"/> and <paramref name="other"/> are considered equal.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="_this">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="other">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="_this"/> is equal to <paramref name="other"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.Equals(value2);
        /// </code>
        /// </example>
        public static Boolean IsEqual<T>(this IComparable<T> _this, T other) {

            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.CompareTo(other) == 0;
        }

        #endregion

        #region Less

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered less than <paramref name="other"/>.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="_this">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="other">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="_this"/> is less than <paramref name="other"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.LessThan(value2);
        /// </code>
        /// </example>
        public static Boolean IsLessThan<T>(this IComparable<T> _this, T other) {

            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.CompareTo(other) < 0;
        }

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered less than <paramref name="other"/> or equal.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="_this">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="other">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="_this"/> is less than <paramref name="other"/> or equal.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.LessThanOrEquals(value2);
        /// </code>
        /// </example>
        public static Boolean IsLessThanOrEqual<T>(this IComparable<T> _this, T other) {

            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.CompareTo(other) <= 0;
        }

        #endregion

        #region IsGreater

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered greater than <paramref name="other"/>.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="other">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="_this"/> is greater than <paramref name="other"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.GreaterThan(value2);
        /// </code>
        /// </example>
        public static Boolean IsGreaterThan<T>(this IComparable<T> _this, T other) {

            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.CompareTo(other) > 0;
        }

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered greater than <paramref name="other"/> or equal.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The first object of type <typeparamref name="T"/>.</param>
        /// <param name="other">The second object of type <typeparamref name="T"/>.</param>
        /// <returns>True if <paramref name="_this"/> is greater than <paramref name="other"/> or equal.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.GreaterThanOrEquals(value2);
        /// </code>
        /// </example>
        public static Boolean IsGreaterThanOrEqual<T>(this IComparable<T> _this, T other) {

            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.CompareTo(other) >= 0;
        }

        #endregion

        #region IsClamped

        /// <summary>
        /// Checks if a value is clamped in a given inclusive range.
        /// </summary>
        /// <typeparam name="T">The type used for the range.</typeparam>
        /// <param name="_this">The <see cref="IComparable{T}"/> that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <returns>True if <paramref name="_this"/> is clamped, false if not.</returns>
        /// <example>
        /// <code>
        /// if(someIndex.IsClamped(0, someList.Count - 1)) {
        ///     doSomething(someIndex, someList);
        /// }
        /// </code>
        /// </example>
        public static Boolean IsClamped<T>(this IComparable<T> _this, T min, T max) {

            Throw.If.Object.IsNull(_this, nameof(_this));

            Boolean result = true;

            result &= min == null || _this.IsGreaterThanOrEqual(min);
            result &= max == null || _this.IsLessThanOrEqual(max);

            return result;
        }


        /// <summary>
        /// Checks if a value is clamped in a given exclusive range.
        /// </summary>
        /// <typeparam name="T">The type used for the range.</typeparam>
        /// <param name="_this">The <see cref="IComparable{T}"/> that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <returns>True if <paramref name="_this"/> is clamped, false if not.</returns>
        /// <example>
        /// <code>
        /// if(someIndex.IsClampedExclusive(-1, someList.Count)) {
        ///     doSomething(someIndex, someList);
        /// }
        /// </code>
        /// </example>
        public static Boolean IsClampedExclusive<T>(this IComparable<T> _this, T min, T max) {

            Throw.If.Object.IsNull(_this, nameof(_this));

            Boolean result = true;

            result &= min == null || _this.IsGreaterThan(min);
            result &= max == null || _this.IsLessThan(max);

            return result;
        }

        #endregion

        #region Clamp

        /// <summary>
        /// Clamps <paramref name="_this"/> to a given inclusive range.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="_this">The value that is clamped to the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <returns>The clamped version of <paramref name="_this"/>.</returns>
        /// <example>
        /// <code>
        /// doSomething(someIndex.Clamp(0, someList.Count - 1), someList);
        /// </code>
        /// </example>
        public static T Clamp<T>(this T _this, T min, T max)
            where T : IComparable<T> {

            Throw.If.Object.IsNull(_this, nameof(_this));

            if(min != null && max != null && min.IsGreaterThan(max)) {
                return _this.Clamp(max, min);
            }

            T result = _this;

            result = min != null && result.IsLessThan(min) ? min : result;
            result = max != null && result.IsGreaterThan(max) ? max : result;

            return result;
        }

        #endregion

    }
}
