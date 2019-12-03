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
    public class DynamicComparer : IComparer {

        #region fields

        private readonly Comparison _compare = null;

        #endregion

        #region ctors

        internal DynamicComparer(Comparison compare) {
            Throw.If.Null(compare, "compare");

            _compare = compare;
        }

        #endregion

        #region methods

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
        public Int32 Compare(Object x, Object y) => _compare(x, y);

        /// <summary>
        /// Returns a new instance of <see cref="DynamicComparer"/> using the given <see cref="Compare"/>.
        /// </summary>
        /// <param name="compare">The <see cref="Comparison"/> to use for calls of <c>IComparer&lt;T&gt;.Compare(T, T)</c>.</param>
        /// <returns>A new instance of <see cref="DynamicComparer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="compare"/> is null.</exception>
        public static IComparer From(Comparison compare) {
            Throw.If.Null(compare, "compare");

            return new DynamicComparer(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="DynamicComparer{T}"/> using the given implementation of <see cref="IComparable"/>.
        /// </summary>
        /// <typeparam name="TType">The type of the <see cref="IComparable"/></typeparam>
        /// <returns>A new instance of <see cref="DynamicComparer{T}"/>.</returns>
        public static IComparer<TType> From<TType>()
            where TType : IComparable {

            Comparison<TType> compare = (x, y) => {
                if(x == null) {
                    return y == null ? 0 : -y.CompareTo(x);
                }

                return y == null ? 1 : x.CompareTo(y);
            };

            return new DynamicComparer<TType>(compare);
        }

        /// <summary>
        /// Returns a new instance of <see cref="DynamicComparer{T}"/> using the given implementation of <see cref="IComparable{T}"/>.
        /// </summary>
        /// <typeparam name="TType">The type of the <see cref="IComparable{T}"/></typeparam>
        /// <returns>A new instance of <see cref="DynamicComparer{T}"/>.</returns>
        public static IComparer<TType> FromT<TType>()
            where TType : IComparable<TType> {

            Comparison<TType> compare = (x, y) => {
                if(x == null) {
                    return y == null ? 0 : -y.CompareTo(x);
                }

                return y == null ? 1 : x.CompareTo(y);
            };

            return new DynamicComparer<TType>(compare);
        }

        #endregion

    }

    /// <summary>
    /// Represents an <see cref="IComparer{T}"/> implementation that can be configured at runtime by passing behaviour via delegates.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    public class DynamicComparer<T> : IComparer<T> {

        #region fields

        private readonly Comparison<T> _compare = null;

        #endregion

        #region ctors

        internal DynamicComparer(Comparison<T> compare) {
            Throw.If.Null(compare, "compare");

            _compare = compare;
        }

        #endregion

        #region methods

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than,
        ///     equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object of type <typeparamref name="T"/> to compare.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/> to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x and y, as shown in the following table.
        ///     Value Meaning Less than zero x is less than y.
        ///     Zero x equals y.
        ///     Greater than zero x is greater than y.</returns>
        public Int32 Compare(T x, T y) => _compare(x, y);

        /// <summary>
        /// Returns a new instance of <see cref="DynamicComparer{T}"/> using the given <see cref="IComparer"/>.
        /// </summary>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <returns>A new instance of <see cref="DynamicComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        public static IComparer<T> From(IComparer comparer) {
            Throw.If.Null(comparer, "comparer");

            return new DynamicComparer<T>((x, y) => comparer.Compare(x, y));
        }

        /// <summary>
        /// Returns a new instance of <see cref="DynamicComparer{T}"/> using the given <see cref="Comparison{T}"/>.
        /// </summary>
        /// <param name="compare">The <see cref="Comparison{T}"/> to use for calls of <c>IComparer&lt;T&gt;.Compare(T, T)</c>.</param>
        /// <returns>A new instance of <see cref="DynamicComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="compare"/> is null.</exception>
        public static IComparer<T> From(Comparison<T> compare) {
            Throw.If.Null(compare, "compare");

            return new DynamicComparer<T>(compare);
        }

        #endregion

    }

}
