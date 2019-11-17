﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="IEnumerableTExtensions"/> provides extension methods to the type <see cref="IEnumerable{T}"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class IEnumerableTExtensions {

        #region ForEach

        /// <summary>
        /// Invokes an <paramref name="action"/> on every item in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of items in <paramref name="_this"/>.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <param name="action">The <see cref="Action{T}"/> to invoke.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="action"/> is null.</exception>
        /// <example>
        /// <code>
        /// myEnumeration.ForEach(element => doSomething(element));
        /// </code>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> _this, Action<T> action) {
            Throw.If.Null(_this, "_this");
            Throw.If.Null(action, "action");

            foreach(T element in _this) {
                action(element);
            }
        }

        #endregion

        #region Min

        /// <summary>
        /// Gets the minimum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of items in <paramref name="_this"/> implements <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <returns>The minimum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Min();
        /// </code>
        /// </example>
        public static T Min<T>(this IEnumerable<T> _this) where T : IComparable {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");

            T min = default;
            Action<T> action = (element) => {
                if(min == null) {
                    min = element;
                }

                if(element != null && min != null && element.CompareTo(min) < 0) {
                    min = element;
                }
            };

            _this.ForEach(action);

            return min;
        }

        /// <summary>
        /// Gets the minimum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of items in <paramref name="_this"/> implements <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <returns>The minimum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.MinT();
        /// </code>
        /// </example>
        public static T MinT<T>(this IEnumerable<T> _this) where T : IComparable<T> {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");

            T min = default;
            Action<T> action = (element) => {
                if(min == null) {
                    min = element;
                }

                if(element != null && min != null && element.CompareTo(min) < 0) {
                    min = element;
                }
            };

            _this.ForEach(action);

            return min;
        }

        /// <summary>
        /// Gets the minimum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <param name="comparer">The <see cref="Comparer{T}"/> used for comparison.</param>
        /// <returns>The minimum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Min(new MyComparer());
        /// </code>
        /// </example>
        public static T Min<T>(this IEnumerable<T> _this, Comparer<T> comparer) {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");
            Throw.If.Null(comparer, "comparer");

            return _this.Min(comparer as IComparer<T>);
        }

        /// <summary>
        /// Gets the minimum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <returns>The minimum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Min(new MyComparer());
        /// </code>
        /// </example>
        public static T Min<T>(this IEnumerable<T> _this, IComparer comparer) {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");
            Throw.If.Null(comparer, "comparer");

            return _this.Min(DynamicComparer<T>.From(comparer));
        }

        /// <summary>
        /// Gets the minimum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <param name="comparer">The <see cref="IComparer{T}"/> used for comparison.</param>
        /// <returns>The minimum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Min(new MyComparer());
        /// </code>
        /// </example>
        public static T Min<T>(this IEnumerable<T> _this, IComparer<T> comparer) {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");
            Throw.If.Null(comparer, "comparer");

            T min = default;
            Action<T> action = (element) => {
                if(min == null) {
                    min = element;
                }

                if(element != null && min != null && comparer.Compare(element, min) < 0) {
                    min = element;
                }
            };

            _this.ForEach(action);

            return min;
        }

        #endregion

        #region Max

        /// <summary>
        /// Gets the maximum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of items in <paramref name="_this"/> implements <see cref="IComparable"/>.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <returns>The maximum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Max();
        /// </code>
        /// </example>
        public static T Max<T>(this IEnumerable<T> _this) where T : IComparable {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");

            T max = default;
            Action<T> action = (element) => {
                if(max == null) {
                    max = element;
                }

                if(element != null && max != null && element.CompareTo(max) > 0) {
                    max = element;
                }
            };

            _this.ForEach(action);

            return max;
        }

        /// <summary>
        /// Gets the maximum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of items in <paramref name="_this"/> implements <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <returns>The maximum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.MaxT();
        /// </code>
        /// </example>
        public static T MaxT<T>(this IEnumerable<T> _this) where T : IComparable<T> {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");

            T max = default;
            Action<T> action = (element) => {
                if(max == null) {
                    max = element;
                }

                if(element != null && max != null && element.CompareTo(max) > 0) {
                    max = element;
                }
            };

            _this.ForEach(action);

            return max;
        }

        /// <summary>
        /// Gets the maximum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <param name="comparer">The <see cref="Comparer{T}"/> used for comparison.</param>
        /// <returns>The maximum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Max(new MyComparer());
        /// </code>
        /// </example>
        public static T Max<T>(this IEnumerable<T> _this, Comparer<T> comparer) {
            Throw.If.Null(_this, "_this");
            Throw.If.Null(comparer, "comparer");

            return _this.Max(comparer as IComparer<T>);
        }

        /// <summary>
        /// Gets the maximum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <param name="comparer">The <see cref="IComparer"/> used for comparison.</param>
        /// <returns>The maximum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Max(new MyComparer());
        /// </code>
        /// </example>
        public static T Max<T>(this IEnumerable<T> _this, IComparer comparer) {
            Throw.If.Null(_this, "_this");
            Throw.If.Null(comparer, "comparer");

            return _this.Max(DynamicComparer<T>.From(comparer));
        }

        /// <summary>
        /// Gets the maximum value in <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="_this">The <see cref="IEnumerable{T}"/> that is used.</param>
        /// <param name="comparer">The <see cref="IComparer{T}"/> used for comparison.</param>
        /// <returns>The maximum value in <paramref name="_this"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> is empty.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="_this"/> contains null values only.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null.</exception>
        /// <example>
        /// <code>
        /// var min = myEnumeration.Max(new MyComparer());
        /// </code>
        /// </example>
        public static T Max<T>(this IEnumerable<T> _this, IComparer<T> comparer) {
            Throw.If.Null(_this, "_this");
            Throw.If.False(_this.Count() > 0, "_this", "The enumeration is empty.");
            Throw.If.False(_this.Any((element) => element != null), "_this", "The enumeration only contains null values.");
            Throw.If.Null(comparer, "comparer");

            T max = default;
            Action<T> action = (element) => {
                if(max == null) {
                    max = element;
                }

                if(element != null && max != null && comparer.Compare(element, max) > 0) {
                    max = element;
                }
            };

            _this.ForEach(action);

            return max;
        }

        #endregion

    }
}
