using System.ComponentModel;
using System.IO;
using System.Reflection;

using Nuclear.Exceptions;

namespace Nuclear.Assemblies.Resolvers.Data {

    /// <summary>
    /// Implements the assembly information that was found by an <see cref="IAssemblyResolver{TData}"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AssemblyResolverData : IAssemblyResolverData {

        #region properties

        /// <summary>
        /// Gets the resolved assembly.
        /// </summary>
        public FileInfo File { get; }

        /// <summary>
        /// Gets the <see cref="AssemblyName"/> of the assembly.
        /// </summary>
        public AssemblyName Name { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="AssemblyResolverData"/>.
        /// </summary>
        /// <param name="file">The assembly file that was resolved.</param>
        protected internal AssemblyResolverData(FileInfo file) {
            Throw.If.Object.IsNull(file, nameof(file));

            File = file;

            Init();
        }

        #endregion

        #region methods

        /// <summary>
        /// Initializes the data object by analyzing the <see cref="File"/> object.
        /// </summary>
        protected virtual void Init() {
            Throw.If.Value.IsFalse(AssemblyHelper.TryGetAssemblyName(File, out AssemblyName name), nameof(File), "Could not resolve the AssemblyName object.");

            Name = name;
        }

        #endregion

    }
}
