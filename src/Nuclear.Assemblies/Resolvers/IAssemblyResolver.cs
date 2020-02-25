using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Defines an assembly resolver.
    /// </summary>
    public interface IAssemblyResolver {

        #region methods

        /// <summary>
        /// Resolves a reference assembly by <see cref="ResolveEventArgs"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="e">The given <see cref="ResolveEventArgs"/>.</param>
        /// <param name="files">The resolved files.</param>
        /// <returns>True if a file could be found.</returns>
        Boolean TryResolve(ResolveEventArgs e, out IEnumerable<FileInfo> files);

        /// <summary>
        /// Resolves a reference assembly by the full name.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="fullName">The full name of the assembly.</param>
        /// <param name="files">The resolved files.</param>
        /// <returns>True if a file could be found.</returns>
        Boolean TryResolve(String fullName, out IEnumerable<FileInfo> files);

        /// <summary>
        /// Resolves a reference assembly by an <see cref="AssemblyName"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="assemblyName">The <see cref="AssemblyName"/> of the assembly.</param>
        /// <param name="files">The resolved files.</param>
        /// <returns>True if a file could be found.</returns>
        Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<FileInfo> files);

        #endregion

    }
}
