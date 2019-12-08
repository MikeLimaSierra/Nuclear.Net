using System;
using System.Collections;
using System.Collections.Generic;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// A delegate used to determine wether the specified objects are equal.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    /// <param name="x">The first object of type <typeparamref name="T"/> to compare.</param>
    /// <param name="y">The second object of type <typeparamref name="T"/> to compare.</param>
    /// <returns>true if the specified objects are equal; otherwise, false.</returns>
    public delegate Boolean EqualityComparison<T>(T x, T y);

    /// <summary>
    /// A delegate used to return a hashcode for the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    /// <param name="obj">The object of type <typeparamref name="T"/> for which a hash code is to be returned.</param>
    /// <returns>A hash code for the specified object.</returns>
    public delegate Int32 GetHashCode<T>(T obj);

    /// <summary>
    /// Represents an <see cref="IEqualityComparer"/> implementation that can be configured at runtime by passing behaviour via delegates.
    /// </summary>
    public class DynamicEqualityComparer {

        #region static methods

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer"/> using the given <see cref="EqualityComparison{Object}"/> and  <see cref="GetHashCode{Object}"/>.
        /// </summary>
        /// <param name="equals">The <see cref="EqualityComparison{Object}"/> to use for calls of <c>IEqualityComparer.Equals(Object, Object)</c>.</param>
        /// <param name="getHashCode">The <see cref="GetHashCode{Object}"/> to use for calls of <c>IEqualityComparer.GetHashCode(Object)</c>.</param>
        /// <returns>A new instance of <see cref="IEqualityComparer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="equals"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="getHashCode"/> is null.</exception>
        public static IEqualityComparer From(EqualityComparison<Object> equals, GetHashCode<Object> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            return new InternalEqualityComparer(equals, getHashCode);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer{T}"/> using the given <see cref="EqualityComparison{T}"/> and  <see cref="GetHashCode{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="equals">The <see cref="EqualityComparison{T}"/> to use for calls of <c>IEqualityComparer&lt;T&gt;.Equals(T, T)</c>.</param>
        /// <param name="getHashCode">The <see cref="GetHashCode{T}"/> to use for calls of <c>IEqualityComparer&lt;T&gt;.GetHashCode(T)</c>.</param>
        /// <returns>A new instance of <see cref="IEqualityComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="equals"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="getHashCode"/> is null.</exception>
        public static IEqualityComparer<T> From<T>(EqualityComparison<T> equals, GetHashCode<T> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            return new InternalEqualityComparer<T>(equals, getHashCode);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer{T}"/> using the given <see cref="IEqualityComparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="comparer">The <see cref="IEqualityComparer"/> used for comparison.</param>
        /// <returns>A new instance of <see cref="IEqualityComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        public static IEqualityComparer<T> From<T>(IEqualityComparer comparer) {
            Throw.If.Null(comparer, "comparer");

            return new InternalEqualityComparer<T>((x, y) => comparer.Equals(x, y), (obj) => comparer.GetHashCode(obj));
        }

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer{T}"/> using the given implementation of <see cref="IEquatable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <returns>A new instance of <see cref="IEqualityComparer{T}"/>.</returns>
        public static IEqualityComparer<T> From<T>()
            where T : IEquatable<T> {

            EqualityComparison<T> equals = (x, y) => {
                if(x == null) {
                    return y == null ? true : y.Equals(x);
                }

                return y == null ? false : x.Equals(y);
            };

            GetHashCode<T> getHashCode = (obj) => obj.GetHashCode();

            return new InternalEqualityComparer<T>(equals, getHashCode);
        }

        #endregion

    }

    internal class InternalEqualityComparer : IEqualityComparer {

        #region fields

        private readonly EqualityComparison<Object> _equals = null;

        private readonly GetHashCode<Object> _getHashCode = null;

        #endregion

        #region ctor

        internal InternalEqualityComparer(EqualityComparison<Object> equals, GetHashCode<Object> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            _equals = equals;
            _getHashCode = getHashCode;
        }

        #endregion

        #region methods

        public new Boolean Equals(Object x, Object y) => _equals(x, y);

        public Int32 GetHashCode(Object obj) => _getHashCode(obj);

        #endregion

    }

    internal class InternalEqualityComparer<T> : IEqualityComparer<T> {

        #region fields

        private readonly EqualityComparison<T> _equals = null;

        private readonly GetHashCode<T> _getHashCode = null;

        #endregion

        #region ctor

        internal InternalEqualityComparer(EqualityComparison<T> equals, GetHashCode<T> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            _equals = equals;
            _getHashCode = getHashCode;
        }

        #endregion

        #region methods

        public Boolean Equals(T x, T y) => _equals(x, y);

        public Int32 GetHashCode(T obj) => _getHashCode(obj);

        #endregion

    }

}
