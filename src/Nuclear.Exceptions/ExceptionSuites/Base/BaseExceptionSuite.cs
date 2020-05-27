using System;
using System.ComponentModel;

namespace Nuclear.Exceptions.ExceptionSuites.Base {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BaseExceptionSuite : ExceptionSuite {

        #region properties

        internal ExceptionSuiteCollection Parent { get; private set; }

        #endregion

        #region ctors

        public BaseExceptionSuite(ExceptionSuiteCollection parent) {
            Parent = parent;
        }

        #endregion

        #region protected methods

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InternalThrow<TException>(Boolean condition, params Object[] args) where TException : Exception => Parent.InternalThrow<TException>(condition, args);

        #endregion

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
