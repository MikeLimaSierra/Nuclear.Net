using System;
using System.ComponentModel;
using Nuclear.Exceptions.ExceptionSuites.Base;

namespace Nuclear.Exceptions.ExceptionSuites {

    /// <summary>
    /// Supplies conditional throw instructions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ExceptionSuiteCollection : ExceptionSuite {

        #region fields

        internal Boolean Invert { get; private set; }

        #endregion

        #region properties

        /// <summary>
        /// Test suite with instructions for probing objects in general.
        /// </summary>
        public ObjectExceptionSuite Object { get; private set; }

        /// <summary>
        /// Test suite with instructions for probing strings.
        /// </summary>
        public StringExceptionSuite String { get; private set; }

        /// <summary>
        /// Test suite with instructions for probing values.
        /// </summary>
        public ValueExceptionSuite Value { get; private set; }

        #endregion

        #region ctors

        internal ExceptionSuiteCollection(Boolean invert = false) {
            Invert = invert;

            Object = new ObjectExceptionSuite(this);
            String = new StringExceptionSuite(this);
            Value = new ValueExceptionSuite(this);
        }

        #endregion

        #region methods

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> based on <paramref name="condition"/> and invertion.
        /// </summary>
        /// <typeparam name="TException">The type of <see cref="Exception"/> to throw.</typeparam>
        /// <param name="condition">Condition is combined with invertion.</param>
        /// <param name="args">The arguments that are passed to the constructor of <typeparamref name="TException"/>.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InternalThrow<TException>(Boolean condition, params Object[] args) where TException : Exception {
            condition = Invert ? !condition : condition;

            if(condition) {
                throw ExceptionFactory.Instance.Create<TException>(args);
            }
        }

        #endregion

    }

}
