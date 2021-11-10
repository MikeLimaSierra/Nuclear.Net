using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Resolvers.Data;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// A resolver that searches for a NuGet package.
    /// </summary>
    public interface INugetResolver : IAssemblyResolver<INugetResolverData> {

        #region properties

        /// <summary>
        /// Gets the used Nuget package cache directories.
        /// </summary>
        IEnumerable<DirectoryInfo> NugetCaches { get; }

        #endregion

    }

}
