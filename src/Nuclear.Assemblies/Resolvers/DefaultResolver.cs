using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Tries to resolve a reference assembly by looking into directories.
    /// Directories can be the location of the calling assembly or of the entry assembly.
    /// </summary>
    public class DefaultResolver : AssemblyResolver {

        #region properties

        /// <summary>
        /// Gets an instance of <see cref="DefaultResolver"/>.
        /// </summary>
        public static IAssemblyResolver Instance { get; } = new DefaultResolver();

        #endregion

        #region ctors

        internal DefaultResolver() {
            Throw.IfNot.Object.IsNull<AccessViolationException>(Instance, "Constructor must not be called twice.");
        }

        #endregion

        #region public methods

        /// <summary>
        /// Resolves a reference assembly by <see cref="ResolveEventArgs"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="e">The given <see cref="ResolveEventArgs"/>.</param>
        /// <param name="file">The resolved file.</param>
        /// <returns>True if a file could be found.</returns>
        public override Boolean TryResolve(ResolveEventArgs e, out FileInfo file) {
            file = null;

            if(AssemblyHelper.TryGetAssemblyName(e, out AssemblyName assemblyName)) {
                if(e.RequestingAssembly == null) {
                    file = ResolveInternal(assemblyName);
                } else {
                    file = ResolveInternal(assemblyName, new FileInfo(e.RequestingAssembly.Location).Directory);
                }
            }

            return file != null;
        }

        /// <summary>
        /// Resolves a reference assembly by the full name.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="fullName">The full name of the assembly.</param>
        /// <param name="file">The resolved file.</param>
        /// <returns>True if a file could be found.</returns>
        public override Boolean TryResolve(String fullName, out FileInfo file) {
            file = null;

            return AssemblyHelper.TryGetAssemblyName(fullName, out AssemblyName assemblyName) && TryResolve(assemblyName, out file);
        }

        /// <summary>
        /// Resolves a reference assembly by an <see cref="AssemblyName"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="assemblyName">The <see cref="AssemblyName"/> of the assembly.</param>
        /// <param name="file">The resolved file.</param>
        /// <returns>True if a file could be found.</returns>
        public override Boolean TryResolve(AssemblyName assemblyName, out FileInfo file) {
            file = null;

            if(assemblyName != null) {
                file = ResolveInternal(assemblyName);
            }

            return file != null;
        }

        #endregion

        #region private methods

        internal FileInfo ResolveInternal(AssemblyName assemblyName)
            => ResolveInternal(assemblyName, new FileInfo(Assembly.GetEntryAssembly().Location).Directory);

        internal FileInfo ResolveInternal(AssemblyName assemblyName, DirectoryInfo directory) {
            if(assemblyName != null && directory != null && directory.Exists) {

                foreach(String extension in AssemblyHelper.AssemblyFileExtensions) {
                    foreach(FileInfo file in directory.GetFiles($"{assemblyName.Name}.{extension}")) {

                        if(AssemblyHelper.TryGetAssemblyName(file, out AssemblyName _assemblyName) && assemblyName.FullName == _assemblyName.FullName
                            && AssemblyHelper.ValidArchitectures.Contains(_assemblyName.ProcessorArchitecture)) {

                            return file;
                        }
                    }
                }
            }

            return null;
        }

        #endregion

    }
}
