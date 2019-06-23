using System;

namespace Nuclear.Exceptions {
    internal class ExceptionFactory : IExceptionFactory {

        #region properties

        /// <summary>
        /// Gets the single instance of <see cref="ExceptionFactory"/>.
        /// </summary>
        public static IExceptionFactory Instance { get; } = new ExceptionFactory();

        #endregion

        #region ctors

        private ExceptionFactory() {
            Throw.IfNot.Null(Instance, "Instance", "Constructor must not be called twice.");
        }

        #endregion

        #region methods

        /// <summary>
        /// Creates a new instance of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The type of exception to be created.</typeparam>
        /// <param name="args">The arguments required to create the exception.</param>
        /// <returns>The exception of type <typeparamref name="TException"/>.</returns>
        public TException Create<TException>(params Object[] args) where TException : Exception => Activator.CreateInstance(typeof(TException), args) as TException;

        #endregion

    }
}
