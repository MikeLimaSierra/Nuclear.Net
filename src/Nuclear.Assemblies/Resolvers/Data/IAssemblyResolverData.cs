using System.IO;

namespace Nuclear.Assemblies.Resolvers.Data {

    /// <summary>
    /// Defines the assembly information that was found by an <see cref="IAssemblyResolver{TData}"/>.
    /// </summary>
    public interface IAssemblyResolverData {

        #region properties

        /// <summary>
        /// Gets the resolved assembly.
        /// </summary>
        public FileInfo File { get; }

        #endregion

    }

}
