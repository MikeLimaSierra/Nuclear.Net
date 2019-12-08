using System;
using System.Collections;
using System.Collections.Generic;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// Compares two objects and returns a value indicating whether one is less than,
    ///     equal to, or greater than the other.
    /// </summary>
    /// <param name="x">The first <see cref="Object"/> to compare.</param>
    /// <param name="y">The second <see cref="Object"/> to compare.</param>
    /// <returns>A signed integer that indicates the relative values of x and y, as shown in the following table.
    ///     Value Meaning Less than zero x is less than y.
    ///     Zero x equals y.
    ///     Greater than zero x is greater than y.</returns>
    public delegate Int32 Comparison(Object x, Object y);

    /// <summary>
    /// Represents an <see cref="IComparer"/> implementation that can be configured at runtime by passing behaviour via delegates.
    /// </summary>
    public class DynamicComparer {

        #region static methods

        /// <summary>
        /// Returns a new instance of <see cref="IComparer"/> using the given <see cref="Comparison"/>.
        /// </summary>
        /// <param name="compare">The <see cref="Comparison"/> to use for calls of <c>IComparer&lt;T&gt;.Compare(T, T)</c>.</param>
        /// <returns>A new instance of <see cref="IComparer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="compare"/> is null.</exception>
        public static IComparer From(Comparison compare) {
            Throw.If.Null(compare, "compare");

            return new InternalComparer(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer{T}"/> using the given <see cref="Comparison{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="compare">The <see cref="Comparison{T}"/> to use for calls of <c>IComparer&lt;T&gt;.Compare(T, T)</c>.</param>
        /// <returns>A new instance of <see cref="IComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="compare"/> is null.</exception>
        public static IComparer<T> From<T>(Comparison<T> compare) {
            Throw.If.Null(compare, "compare");

            return new InternalComparer<T>(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer{T}"/> using the given <see cref="IComparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <returns>A new instance of <see cref="IComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        public static IComparer<T> From<T>(IComparer comparer) {
            Throw.If.Null(comparer, "comparer");

            return new InternalComparer<T>((x, y) => comparer.Compare(x, y));
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer{T}"/> using the given implementation of <see cref="IComparable"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <returns>A new instance of <see cref="IComparer{T}"/>.</returns>
        public static IComparer From<T>()
            where T : IComparable {

            Comparison compare = (x, y) => {
                if(x != null && x is T tX) {
                    return y == null ? 1 : tX.CompareTo(y);
                }

                return (y != null && y is T tY) ? -tY.CompareTo(x) : 0;
            };

            return new InternalComparer(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer{T}"/> using the given implementation of <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <returns>A new instance of <see cref="IComparer{T}"/>.</returns>
        public static IComparer<T> FromT<T>()
            where T : IComparable<T> {

            Comparison<T> compare = (x, y) => {
                if(x == null) {
                    return y == null ? 0 : -y.CompareTo(x);
                }

                return y == null ? 1 : x.CompareTo(y);
            };

            return new InternalComparer<T>(compare);
        }

        #endregion

    }

    internal class InternalComparer : IComparer {

        #region fields

        private readonly Comparison _compare = null;

        #endregion

        #region ctors

        internal InternalComparer(Comparison compare) {
            Throw.If.Null(compare, "compare");

            _compare = compare;
        }

        #endregion

        #region methods

        public Int32 Compare(Object x, Object y) => _compare(x, y);

        #endregion

    }

    internal class InternalComparer<T> : IComparer<T> {

        #region fields

        private readonly Comparison<T> _compare = null;

        #endregion

        #region ctors

        internal InternalComparer(Comparison<T> compare) {
            Throw.If.Null(compare, "compare");

            _compare = compare;
        }

        #endregion

        #region methods

        public Int32 Compare(T x, T y) => _compare(x, y);

        #endregion

    }

}
