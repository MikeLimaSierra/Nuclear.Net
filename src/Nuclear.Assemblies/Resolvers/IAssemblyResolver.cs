﻿using System;
using System.Reflection;

using Nuclear.Assemblies.Resolvers.Data;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Defines an assembly resolver.
    /// </summary>
    /// <typeparam name="TData">The type of the reslver data, must inherit from <see cref="IAssemblyResolverData"/>.</typeparam>
    public interface IAssemblyResolver<TData> where TData : IAssemblyResolverData {

        #region methods

        /// <summary>
        /// Resolves a reference assembly by <see cref="ResolveEventArgs"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="e">The given <see cref="ResolveEventArgs"/>.</param>
        /// <param name="data">The resolved data.</param>
        /// <returns>True if a file could be found.</returns>
        Boolean TryResolve(ResolveEventArgs e, out TData data);

        /// <summary>
        /// Resolves a reference assembly by the full name.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="fullName">The full name of the assembly.</param>
        /// <param name="data">The resolved data.</param>
        /// <returns>True if a file could be found.</returns>
        Boolean TryResolve(String fullName, out TData data);

        /// <summary>
        /// Resolves a reference assembly by an <see cref="AssemblyName"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="assemblyName">The <see cref="AssemblyName"/> of the assembly.</param>
        /// <param name="data">The resolved data.</param>
        /// <returns>True if a file could be found.</returns>
        Boolean TryResolve(AssemblyName assemblyName, out TData data);

        #endregion

    }
}
