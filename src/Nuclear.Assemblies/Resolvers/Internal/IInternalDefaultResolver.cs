using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Nuclear.Assemblies.Resolvers.Internal {
    internal interface IInternalDefaultResolver {

        #region methods

        IEnumerable<FileInfo> Resolve(AssemblyName assemblyName, DirectoryInfo searchDir, SearchOption searchOption, MatchingStrategies strategy);

        #endregion

    }
}
