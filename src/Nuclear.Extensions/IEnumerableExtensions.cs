using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="IEnumerableTExtensions"/> provides extension methods to the type <see cref="IEnumerable{T}"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class IEnumerableExtensions {

        /// <summary>
        /// Invokes an <paramref name="action"/> on every item in <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The <see cref="IEnumerable"/> that is used.</param>
        /// <param name="action">The <see cref="Action{T}"/> to invoke.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
        /// <example>
        /// <code>
        /// myEnumeration.ForEach(element => doSomething(element));
        /// </code>
        /// </example>
        public static void Foreach(this IEnumerable _this, Action<Object> action) {
            Throw.If.Object.IsNull(_this, nameof(_this));
            Throw.If.Object.IsNull(action, nameof(action));

            _this.Cast<Object>().Foreach(action);
        }

        /// <summary>
        /// Returns the number of elements in <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The <see cref="IEnumerable"/> that is used.</param>
        /// <returns>The number of elements in <paramref name="_this"/>.</returns>
        /// <example>
        /// <code>
        /// Int32 n = myEnumeration.Count();
        /// </code>
        /// </example>
        public static Int32 Count(this IEnumerable _this) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.Cast<Object>().Count<Object>();
        }

        /// <summary>
        /// Returns the number of elements in <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The <see cref="IEnumerable"/> that is used.</param>
        /// <returns>The number of elements in <paramref name="_this"/>.</returns>
        /// <example>
        /// <code>
        /// Int64 n = myEnumeration.LongCount();
        /// </code>
        /// </example>
        public static Int64 LongCount(this IEnumerable _this) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            return _this.Cast<Object>().LongCount<Object>();
        }

    }
}
