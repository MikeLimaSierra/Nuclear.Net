﻿using System;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="IComparableExtensions"/> provides extension methods to the type <see cref="IComparable"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class IComparableExtensions {

        #region IsEqual

        /// <summary>
        /// Checks if <paramref name="_this"/> and <paramref name="other"/> are considered equal.
        /// </summary>
        /// <param name="_this">The first object of type <see cref="IComparable"/>.</param>
        /// <param name="other">The second <see cref="Object"/>.</param>
        /// <returns>True if <paramref name="_this"/> is equal to <paramref name="other"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.Equals(value2);
        /// </code>
        /// </example>
        public static Boolean IsEqual(this IComparable _this, Object other) {

            Throw.If.Null(_this, "_this");

            return _this.CompareTo(other) == 0;
        }

        #endregion

        #region Less

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered less than <paramref name="other"/>.
        /// </summary>
        /// <param name="_this">The first object of type <see cref="IComparable"/>.</param>
        /// <param name="other">The second <see cref="Object"/>.</param>
        /// <returns>True if <paramref name="_this"/> is less than <paramref name="other"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.LessThan(value2);
        /// </code>
        /// </example>
        public static Boolean LessThan(this IComparable _this, Object other) {

            Throw.If.Null(_this, "_this");

            return _this.CompareTo(other) < 0;
        }

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered less than <paramref name="other"/> or equal.
        /// </summary>
        /// <param name="_this">The first object of type <see cref="IComparable"/>.</param>
        /// <param name="other">The second <see cref="Object"/>.</param>
        /// <returns>True if <paramref name="_this"/> is less than <paramref name="other"/> or equal.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.LessThanOrEquals(value2);
        /// </code>
        /// </example>
        public static Boolean LessThanOrEquals(this IComparable _this, Object other) {

            Throw.If.Null(_this, "_this");

            return _this.CompareTo(other) <= 0;
        }

        #endregion

        #region Greater

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered greater than <paramref name="other"/>.
        /// </summary>
        /// <param name="_this">The first object of type <see cref="IComparable"/>.</param>
        /// <param name="other">The second <see cref="Object"/>.</param>
        /// <returns>True if <paramref name="_this"/> is greater than <paramref name="other"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.GreaterThan(value2);
        /// </code>
        /// </example>
        public static Boolean GreaterThan(this IComparable _this, Object other) {

            Throw.If.Null(_this, "_this");

            return _this.CompareTo(other) > 0;
        }

        /// <summary>
        /// Checks if <paramref name="_this"/> is considered greater than <paramref name="other"/> or equal.
        /// </summary>
        /// <param name="_this">The first object of type <see cref="IComparable"/>.</param>
        /// <param name="other">The second <see cref="Object"/>.</param>
        /// <returns>True if <paramref name="_this"/> is greater than <paramref name="other"/> or equal.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <example>
        /// <code>
        /// Boolean result = value1.GreaterThanOrEquals(value2);
        /// </code>
        /// </example>
        public static Boolean GreaterThanOrEquals(this IComparable _this, Object other) {

            Throw.If.Null(_this, "_this");

            return _this.CompareTo(other) >= 0;
        }

        #endregion

        #region IsClamped

        /// <summary>
        /// Checks if a value is clamped in a given inclusive range.
        /// </summary>
        /// <param name="_this">The <see cref="IComparable"/> that is checked against the range.</param>
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
        public static Boolean IsClamped(this IComparable _this, Object min, Object max) {

            Throw.If.Null(_this, "_this");

            Boolean result = true;

            result &= min == null || _this.GreaterThanOrEquals(min);
            result &= max == null || _this.LessThanOrEquals(max);

            return result;
        }

        /// <summary>
        /// Checks if a value is clamped in a given exclusive range.
        /// </summary>
        /// <param name="_this">The <see cref="IComparable"/> that is checked against the range.</param>
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
        public static Boolean IsClampedExclusive(this IComparable _this, Object min, Object max) {

            Throw.If.Null(_this, "_this");

            Boolean result = true;

            result &= min == null || _this.GreaterThan(min);
            result &= max == null || _this.LessThan(max);

            return result;
        }

        #endregion

        #region Clamp

        /// <summary>
        /// Clamps <paramref name="_this"/> to a given inclusive range.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
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
            where T : IComparable {

            if(min != null && max != null && min.GreaterThan(max)) {
                return _this.Clamp(max, min);
            }

            T result = _this;

            result = min != null && result.LessThan(min) ? min : result;
            result = max != null && result.GreaterThan(max) ? max : result;

            return result;
        }

        #endregion

    }
}