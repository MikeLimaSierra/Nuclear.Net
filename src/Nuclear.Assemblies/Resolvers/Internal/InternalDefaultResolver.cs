using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Extensions;

namespace Nuclear.Assemblies.Resolvers.Internal {
    internal class InternalDefaultResolver : IInternalDefaultResolver {

        #region methods

        public IEnumerable<FileInfo> Resolve(AssemblyName assemblyName, DirectoryInfo searchDir, SearchOption searchOption, MatchingStrategies strategy) {
            List<FileInfo> files = new List<FileInfo>();

            if(assemblyName != null && searchDir != null) {

                foreach(String extension in AssemblyHelper.AssemblyFileExtensions) {
                    foreach(FileInfo file in searchDir.GetFiles($"{assemblyName.Name}.{extension}", searchOption)) {

                        if(AssemblyHelper.TryGetAssemblyName(file, out AssemblyName _asmName)
                            && assemblyName.Name == _asmName.Name
                            && assemblyName.Version.Matches(_asmName.Version, strategy)
                            && AssemblyHelper.ValidateArchitecture(_asmName)) {

                            files.Add(file);
                        }
                    }
                }
            }

            return files;
        }

        #endregion

    }
}
