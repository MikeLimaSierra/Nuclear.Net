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
    /// Helper class to instantiate and create custom <see cref="IComparer"/> and <see cref="IComparer{T}"/>
    /// at runtime by passing behaviours via delegates or existing implementations.
    /// </summary>
    public static class DynamicComparer {

        #region static methods

        /// <summary>
        /// Returns a new instance of <see cref="IComparer"/> using the given <see cref="Comparison"/>.
        /// </summary>
        /// <param name="compare">The <see cref="Comparison"/> to use for calls of <c>IComparer&lt;T&gt;.Compare(T, T)</c>.</param>
        /// <returns>A new instance of <see cref="IComparer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="compare"/> is null.</exception>
        public static IComparer FromDelegate(Comparison compare) {
            Throw.If.Null(compare, nameof(compare));

            return new InternalComparer(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer{T}"/> using the given <see cref="Comparison{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="compare">The <see cref="Comparison{T}"/> to use for calls of <c>IComparer&lt;T&gt;.Compare(T, T)</c>.</param>
        /// <returns>A new instance of <see cref="IComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="compare"/> is null.</exception>
        public static IComparer<T> FromDelegate<T>(Comparison<T> compare) {
            Throw.If.Null(compare, nameof(compare));

            return new InternalComparer<T>(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer{T}"/> using the given <see cref="IComparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <returns>A new instance of <see cref="IComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        public static IComparer<T> FromComparer<T>(IComparer comparer) {
            Throw.If.Null(comparer, nameof(comparer));

            return new InternalComparer<T>((x, y) => comparer.Compare(x, y));
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer"/> using the given implementation of <see cref="IComparable"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <returns>A new instance of <see cref="IComparer"/>.</returns>
        public static IComparer FromIComparable<T>()
            where T : IComparable {

            Comparison compare = (x, y) => {
                T _x = (T) x;
                T _y = (T) y;

                if(_x == null && _y == null) {
                    return 0;
                }

                if(_x != null && _y != null) {
                    return _x.CompareTo(_y);
                }

                return _x != null ? 1 : -1;
            };

            return new InternalComparer(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IComparer{T}"/> using the given implementation of <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <returns>A new instance of <see cref="IComparer{T}"/>.</returns>
        public static IComparer<T> FromIComparableT<T>()
            where T : IComparable<T> {

            Comparison<T> compare = (x, y) => {
                if(x == null && y == null) {
                    return 0;
                }

                if(x != null && y != null) {
                    return x.CompareTo(y);
                }

                return x != null ? 1 : -1;
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
            Throw.If.Null(compare, nameof(compare));

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
            Throw.If.Null(compare, nameof(compare));

            _compare = compare;
        }

        #endregion

        #region methods

        public Int32 Compare(T x, T y) => _compare(x, y);

        #endregion

    }

}
