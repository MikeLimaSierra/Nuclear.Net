using System;

namespace Nuclear.Exceptions {
    internal class ExceptionFactory {

        #region properties

        internal static ExceptionFactory Instance { get; } = new ExceptionFactory();

        #endregion

        #region ctors

        private ExceptionFactory() {
            Throw.IfNot.Null(Instance, "Instance", "Constructor must not be called twice.");
        }

        #endregion

        #region methods

        internal TException Create<TException>(params Object[] args) where TException : Exception => Activator.CreateInstance(typeof(TException), args) as TException;

        #endregion

    }
}
