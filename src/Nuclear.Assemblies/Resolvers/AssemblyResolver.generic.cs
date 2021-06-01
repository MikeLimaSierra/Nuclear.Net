using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Resolvers.Data;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Abstract base implementation of <see cref="IAssemblyResolver{TData}"/> including some basic resolving functionality.
    /// </summary>
    /// <typeparam name="TData">The type of the resolver data, must inherit from <see cref="IAssemblyResolverData"/>.</typeparam>
    internal abstract class AssemblyResolver<TData> : IAssemblyResolver<TData> where TData : IAssemblyResolverData {

        #region public methods

        /// <summary>
        /// Resolves a reference assembly by <see cref="ResolveEventArgs"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="e">The given <see cref="ResolveEventArgs"/>.</param>
        /// <param name="data">The resolved data.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(ResolveEventArgs e, out IEnumerable<TData> data);

        /// <summary>
        /// Resolves a reference assembly by the full name.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="fullName">The full name of the assembly.</param>
        /// <param name="data">The resolved data.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(String fullName, out IEnumerable<TData> data);

        /// <summary>
        /// Resolves a reference assembly by an <see cref="AssemblyName"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="assemblyName">The <see cref="AssemblyName"/> of the assembly.</param>
        /// <param name="data">The resolved data.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<TData> data);

        #endregion

    }
}
