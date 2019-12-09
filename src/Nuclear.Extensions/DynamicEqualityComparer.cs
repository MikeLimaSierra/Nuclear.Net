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
    /// Helper class to instantiate and create custom <see cref="IEqualityComparer"/> and <see cref="IEqualityComparer{T}"/>
    /// at runtime by passing behaviours via delegates or existing implementations.
    /// </summary>
    public static class DynamicEqualityComparer {

        #region fields

        private static readonly Dictionary<Type, Object> _cache = new Dictionary<Type, Object>();

        #endregion

        #region static methods

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer"/> using the given
        /// <see cref="EqualityComparison{Object}"/> and  <see cref="GetHashCode{Object}"/>.
        /// </summary>
        /// <param name="equals">The <see cref="EqualityComparison{Object}"/> to use for calls of <c>IEqualityComparer.Equals(Object, Object)</c>.</param>
        /// <param name="getHashCode">The <see cref="GetHashCode{Object}"/> to use for calls of <c>IEqualityComparer.GetHashCode(Object)</c>.</param>
        /// <returns>A new instance of <see cref="IEqualityComparer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="equals"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="getHashCode"/> is null.</exception>
        public static IEqualityComparer FromDelegate(EqualityComparison<Object> equals, GetHashCode<Object> getHashCode) {
            Throw.If.Null(equals, nameof(equals));
            Throw.If.Null(getHashCode, nameof(getHashCode));

            return new InternalEqualityComparer(equals, getHashCode);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer{T}"/> using the given
        /// <see cref="EqualityComparison{T}"/> and  <see cref="GetHashCode{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="equals">The <see cref="EqualityComparison{T}"/> to use for calls of <c>IEqualityComparer&lt;T&gt;.Equals(T, T)</c>.</param>
        /// <param name="getHashCode">The <see cref="GetHashCode{T}"/> to use for calls of <c>IEqualityComparer&lt;T&gt;.GetHashCode(T)</c>.</param>
        /// <returns>A new instance of <see cref="IEqualityComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="equals"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="getHashCode"/> is null.</exception>
        public static IEqualityComparer<T> FromDelegate<T>(EqualityComparison<T> equals, GetHashCode<T> getHashCode) {
            Throw.If.Null(equals, nameof(equals));
            Throw.If.Null(getHashCode, nameof(getHashCode));

            return new InternalEqualityComparer<T>(equals, getHashCode);
        }

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer{T}"/> using the given <see cref="IEqualityComparer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="comparer">The <see cref="IEqualityComparer"/> used for comparison.</param>
        /// <returns>A new instance of <see cref="IEqualityComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        public static IEqualityComparer<T> FromComparer<T>(IEqualityComparer comparer) {
            Throw.If.Null(comparer, nameof(comparer));

            return new InternalEqualityComparer<T>((x, y) => comparer.Equals(x, y), (obj) => comparer.GetHashCode(obj));
        }

        /// <summary>
        /// Returns a new instance of <see cref="IEqualityComparer{T}"/> using the given implementation of <see cref="IEquatable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <returns>A new instance of <see cref="IEqualityComparer{T}"/>.</returns>
        public static IEqualityComparer<T> FromIEquatable<T>()
            where T : IEquatable<T> {

            Type type = typeof(T);
            Object syncRoot = (_cache as ICollection).SyncRoot;
            IEqualityComparer<T> comparer = null;

            lock(syncRoot) {
                if(_cache.ContainsKey(type)) {
                    comparer = _cache[type] as IEqualityComparer<T>;
                }
            }

            if(comparer == null) {
                EqualityComparison<T> equals = (x, y) => {
                    if(x == null && y == null) {
                        return true;
                    }

                    if(x != null && y != null) {
                        return x.Equals(y);
                    }

                    return false;
                };

                comparer = new InternalEqualityComparer<T>(equals, (obj) => obj.GetHashCode());

                lock(syncRoot) {
                    if(!_cache.ContainsKey(type)) {
                        _cache.Add(type, comparer);
                    }
                }
            }

            return comparer;
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
            Throw.If.Null(equals, nameof(equals));
            Throw.If.Null(getHashCode, nameof(getHashCode));

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
            Throw.If.Null(equals, nameof(equals));
            Throw.If.Null(getHashCode, nameof(getHashCode));

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
