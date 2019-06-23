using System;

namespace Nuclear.Exceptions {
    public interface IExceptionFactory {

        #region methods

        /// <summary>
        /// Creates a new instance of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The type of exception to be created.</typeparam>
        /// <param name="args">The arguments required to create the exception.</param>
        /// <returns>The exception of type <typeparamref name="TException"/>.</returns>
        TException Create<TException>(params Object[] args) where TException : Exception;

        #endregion

    }
}
