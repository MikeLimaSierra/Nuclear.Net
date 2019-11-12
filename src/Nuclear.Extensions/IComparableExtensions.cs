using Nuclear.Exceptions;
using System;
using System.Collections;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="IComparableExtensions"/> provides extension methods to the type <see cref="IComparable"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class IComparableExtensions {

        #region IsClamped

        /// <summary>
        /// Checks if a value is clamped in a given inclusive range.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The value that is checked against the range.</param>
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
        public static Boolean IsClamped<T>(this T _this, T min, T max)
            where T : IComparable {

            Throw.If.Null(_this, "_this");

            if(min != null && max != null && min.CompareTo(max) > 0) {
                return _this.IsClamped(max, min);
            }

            Boolean result = true;

            result &= min == null || _this.CompareTo(min) >= 0;
            result &= max == null || _this.CompareTo(max) <= 0;

            return result;
        }

        /// <summary>
        /// Checks if a value is clamped in a given inclusive range.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <returns>True if <paramref name="_this"/> is clamped, false if not.</returns>
        /// <example>
        /// <code>
        /// if(someIndex.IsClamped(0, someList.Count - 1, new MyComparer())) {
        ///     doSomething(someIndex, someList);
        /// }
        /// </code>
        /// </example>
        public static Boolean IsClamped<T>(this T _this, T min, T max, IComparer comparer)
            where T : IComparable {

            Throw.If.Null(_this, "_this");
            Throw.If.Null(comparer, "comparer");

            if(min != null && max != null && min.CompareTo(max) > 0) {
                return _this.IsClamped(max, min);
            }

            Boolean result = true;

            result &= min == null || comparer.Compare(_this, min) >= 0;
            result &= max == null || comparer.Compare(_this, max) <= 0;

            return result;
        }

        /// <summary>
        /// Checks if a value is clamped in a given exclusive range.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The value that is checked against the range.</param>
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
        public static Boolean IsClampedExclusive<T>(this T _this, T min, T max)
            where T : IComparable {

            Throw.If.Null(_this, "_this");

            if(min != null && max != null && min.CompareTo(max) > 0) {
                return _this.IsClamped(max, min);
            }

            Boolean result = true;

            result &= min == null || _this.CompareTo(min) > 0;
            result &= max == null || _this.CompareTo(max) < 0;

            return result;
        }

        /// <summary>
        /// Checks if a value is clamped in a given exclusive range.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The value that is checked against the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <returns>True if <paramref name="_this"/> is clamped, false if not.</returns>
        /// <example>
        /// <code>
        /// if(someIndex.IsClampedExclusive(-1, someList.Count, new MyComparer())) {
        ///     doSomething(someIndex, someList);
        /// }
        /// </code>
        /// </example>
        public static Boolean IsClampedExclusive<T>(this T _this, T min, T max, IComparer comparer)
            where T : IComparable {

            Throw.If.Null(_this, "_this");
            Throw.If.Null(comparer, "comparer");

            if(min != null && max != null && min.CompareTo(max) > 0) {
                return _this.IsClamped(max, min);
            }

            Boolean result = true;

            result &= min == null || comparer.Compare(_this, min) > 0;
            result &= max == null || comparer.Compare(_this, max) < 0;

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

            Throw.If.Null(_this, "_this");

            if(min != null && max != null && min.CompareTo(max) > 0) {
                return _this.Clamp(max, min);
            }

            T result = _this;

            result = min != null && result.CompareTo(min) < 0 ? min : result;
            result = max != null && result.CompareTo(max) > 0 ? max : result;

            return result;
        }

        /// <summary>
        /// Clamps <paramref name="_this"/> to a given inclusive range.
        /// </summary>
        /// <typeparam name="T">Type must implement <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The value that is clamped to the range.</param>
        /// <param name="min">The lower border of the range. Is considered lower than <paramref name="_this"/> if null.</param>
        /// <param name="max">The upper border of the range. Is considered higher than <paramref name="_this"/> if null.</param>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <returns>The clamped version of <paramref name="_this"/>.</returns>
        /// <example>
        /// <code>
        /// doSomething(someIndex.Clamp(0, someList.Count - 1), someList, new MyComparer());
        /// </code>
        /// </example>
        public static T Clamp<T>(this T _this, T min, T max, IComparer comparer)
            where T : IComparable {

            Throw.If.Null(_this, "_this");
            Throw.If.Null(comparer, "comparer");

            if(min != null && max != null && min.CompareTo(max) > 0) {
                return _this.Clamp(max, min);
            }

            T result = _this;

            result = min != null && comparer.Compare(result, min) < 0 ? min : result;
            result = max != null && comparer.Compare(result, max) > 0 ? max : result;

            return result;
        }

        #endregion

    }
}
