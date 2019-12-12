using System;
using System.ComponentModel;
using Nuclear.Exceptions.ExceptionSuites.Base;

namespace Nuclear.Exceptions.ExceptionSuites {

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
