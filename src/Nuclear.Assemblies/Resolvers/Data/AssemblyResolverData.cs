using System;
using System.IO;
using System.Reflection;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers.Data {

    /// <summary>
    /// Implements the assembly information that was found by an <see cref="IAssemblyResolver{TData}"/>.
    /// </summary>
    internal abstract class AssemblyResolverData : IAssemblyResolverData {

        #region properties

        /// <summary>
        /// Gets the resolved assembly.
        /// </summary>
        public FileInfo File { get; }

        /// <summary>
        /// Gets the <see cref="AssemblyName"/> of the assembly.
        /// </summary>
        public AssemblyName Name { get; private set; }

        /// <summary>
        /// Gets if the given <see cref="FileInfo"/> is valid.
        /// </summary>
        public Boolean IsValid { get; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="AssemblyResolverData"/>.
        /// </summary>
        /// <param name="file">The assembly file that was resolved.</param>
        internal AssemblyResolverData(FileInfo file) {
            Throw.If.Object.IsNull(file, nameof(file), $"Parameter {nameof(file).Format()} must not be null.");
            Throw.If.Value.IsFalse(AssemblyHelper.TryGetAssemblyName(file, out AssemblyName name), nameof(file), $"Could not resolve the AssemblyName of file {file.Format()}.");

            File = file;
            Name = name;

            IsValid = Init();
        }

        #endregion

        #region methods

        /// <summary>
        /// Initializes the data object by analyzing the <see cref="File"/> object.
        /// </summary>
        /// <returns>True if the instance could be initialized.</returns>
        protected abstract Boolean Init();

        #endregion

    }
}
