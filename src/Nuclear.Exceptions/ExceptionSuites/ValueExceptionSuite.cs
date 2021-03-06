﻿using System;
using System.ComponentModel;
using Nuclear.Exceptions.ExceptionSuites.Base;

namespace Nuclear.Exceptions.ExceptionSuites {

    /// <summary>
    /// Provides conditional probing instructions for values.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ValueExceptionSuite : BaseExceptionSuite {

        #region ctors

        internal ValueExceptionSuite(ExceptionSuiteCollection parent) : base(parent) { }

        #endregion

        #region IsTrue

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Value.IsTrue(myStream.CanRead, "The stream must not be able to read.");
        /// </code>
        /// </example>
        public void IsTrue(Boolean condition, String paramName, String message = "") => IsTrue<ArgumentException>(condition, message, paramName);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to true.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.Value.IsTrue&lt;NotImplementedException&gt;(myStream.CanRead, "The stream must be able to read.");
        /// </code>
        /// </example>
        public void IsTrue<TException>(Boolean condition, params Object[] args) where TException : Exception => InternalThrow<TException>(condition, args);

        #endregion

        #region IsFalse

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// <code>
        /// Throw.If.Value.IsFalse(myStream.CanTimeout, "Why are we having timeouts?");
        /// </code>
        /// </example>
        public void IsFalse(Boolean condition, String paramName, String message = "") => IsFalse<ArgumentException>(condition, message, paramName);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if <paramref name="condition"/> evaluates to false.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to be thrown.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="args">The arguments needed to create the exception.</param>
        /// <example>
        /// <code>
        /// Throw.If.Value.IsFalse&lt;NotImplementedException&gt;(myStream.CanTimeout, "Why can't we have timeouts?");
        /// </code>
        /// </example>
        public void IsFalse<TException>(Boolean condition, params Object[] args) where TException : Exception => InternalThrow<TException>(!condition, args);

        #endregion

    }
}
