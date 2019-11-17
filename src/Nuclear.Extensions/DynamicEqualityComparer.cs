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
    public class DynamicEqualityComparer : IEqualityComparer {

        #region fields

        private readonly EqualityComparison<Object> _equals = null;

        private readonly GetHashCode<Object> _getHashCode = null;

        #endregion

        #region ctor

        internal DynamicEqualityComparer(EqualityComparison<Object> equals, GetHashCode<Object> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            _equals = equals;
            _getHashCode = getHashCode;
        }

        #endregion

        #region methods

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first <see cref="Object"/> to compare.</param>
        /// <param name="y">The second <see cref="Object"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public new Boolean Equals(Object x, Object y) => _equals(x, y);

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public Int32 GetHashCode(Object obj) => _getHashCode(obj);

        /// <summary>
        /// Returns a new instance of <see cref="DynamicEqualityComparer"/> using the given <see cref="EqualityComparison{T}"/> and  <see cref="GetHashCode{T}"/>.
        /// </summary>
        /// <param name="equals">The delegate to use for calls of <c>IEqualityComparer&lt;T&gt;.Equals(T, T)</c>.</param>
        /// <param name="getHashCode">The delegate to use for calls of <c>IEqualityComparer&lt;T&gt;.GetHashCode(T)</c>.</param>
        /// <returns>A new instance of <see cref="DynamicEqualityComparer"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="equals"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="getHashCode"/> is null.</exception>
        public static IEqualityComparer From(EqualityComparison<Object> equals, GetHashCode<Object> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            return new DynamicEqualityComparer(equals, getHashCode);
        }

        #endregion

    }

    /// <summary>
    /// Represents an <see cref="IEqualityComparer{T}"/> implementation that can be configured at runtime by passing behaviour via delegates.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    public class DynamicEqualityComparer<T> : IEqualityComparer<T> {

        #region fields

        private readonly EqualityComparison<T> _equals = null;

        private readonly GetHashCode<T> _getHashCode = null;

        #endregion

        #region ctor

        internal DynamicEqualityComparer(EqualityComparison<T> equals, GetHashCode<T> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            _equals = equals;
            _getHashCode = getHashCode;
        }

        #endregion

        #region methods

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <typeparamref name="T"/> to compare.</param>
        /// <param name="y">The second object of type <typeparamref name="T"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public Boolean Equals(T x, T y) => _equals(x, y);

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The object of type <typeparamref name="T"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        public Int32 GetHashCode(T obj) => _getHashCode(obj);

        /// <summary>
        /// Returns a new instance of <see cref="DynamicEqualityComparer{T}"/> using the given <see cref="IEqualityComparer"/>.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer"/> used for comparison.</param>
        /// <returns>A new instance of <see cref="DynamicEqualityComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        public static IEqualityComparer<T> From(IEqualityComparer comparer) {
            Throw.If.Null(comparer, "comparer");

            return new DynamicEqualityComparer<T>((x, y) => comparer.Equals(x, y), (obj) => comparer.GetHashCode(obj));
        }

        /// <summary>
        /// Returns a new instance of <see cref="DynamicEqualityComparer{T}"/> using the given <see cref="EqualityComparison{T}"/> and  <see cref="GetHashCode{T}"/>.
        /// </summary>
        /// <param name="equals">The delegate to use for calls of <c>IEqualityComparer&lt;T&gt;.Equals(T, T)</c>.</param>
        /// <param name="getHashCode">The delegate to use for calls of <c>IEqualityComparer&lt;T&gt;.GetHashCode(T)</c>.</param>
        /// <returns>A new instance of <see cref="DynamicEqualityComparer{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="equals"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="getHashCode"/> is null.</exception>
        public static IEqualityComparer<T> From(EqualityComparison<T> equals, GetHashCode<T> getHashCode) {
            Throw.If.Null(equals, "equals");
            Throw.If.Null(getHashCode, "getHashCode");

            return new DynamicEqualityComparer<T>(equals, getHashCode);
        }

        #endregion

    }

}
