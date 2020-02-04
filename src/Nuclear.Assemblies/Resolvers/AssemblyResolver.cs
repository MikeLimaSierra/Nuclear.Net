using System;
using System.IO;
using System.Reflection;

namespace Nuclear.Assemblies.Resolvers {
    public abstract class AssemblyResolver : IAssemblyResolver {

        #region public methods

        /// <summary>
        /// Resolves a reference assembly by <see cref="ResolveEventArgs"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="e">The given <see cref="ResolveEventArgs"/>.</param>
        /// <param name="file">The resolved file.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(ResolveEventArgs e, out FileInfo file);

        /// <summary>
        /// Resolves a reference assembly by the full name.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="fullName">The full name of the assembly.</param>
        /// <param name="file">The resolved file.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(String fullName, out FileInfo file);

        /// <summary>
        /// Resolves a reference assembly by an <see cref="AssemblyName"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="assemblyName">The <see cref="AssemblyName"/> of the assembly.</param>
        /// <param name="file">The resolved file.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(AssemblyName assemblyName, out FileInfo file);

        #endregion

    }
}
