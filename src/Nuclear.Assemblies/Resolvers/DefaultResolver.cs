using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Resolvers {

    internal class DefaultResolver : AssemblyResolver<IDefaultResolverData>, IDefaultResolver {

        #region fields

        private static readonly ICreator<IDefaultResolverData, FileInfo> _factory = Factory.Instance.Default();

        #endregion

        #region public methods

        public override Boolean TryResolve(ResolveEventArgs e, out IEnumerable<IDefaultResolverData> data) {
            data = Enumerable.Empty<IDefaultResolverData>();

            if(AssemblyHelper.TryGetAssemblyName(e, out AssemblyName assemblyName)) {
                if(e.RequestingAssembly == null) {
                    data = ResolveInternal(assemblyName).Select(_ => {
                        _factory.Create(out IDefaultResolverData data, _);
                        return data;
                    });
                } else {
                    data = ResolveInternal(assemblyName, new FileInfo(e.RequestingAssembly.Location).Directory, SearchOption.AllDirectories).Select(_ => {
                        _factory.Create(out IDefaultResolverData data, _);
                        return data;
                    });
                }
            }

            return data != null && data.Count() > 0;
        }

        public override Boolean TryResolve(String fullName, out IEnumerable<IDefaultResolverData> data) {
            data = Enumerable.Empty<IDefaultResolverData>();

            return AssemblyHelper.TryGetAssemblyName(fullName, out AssemblyName assemblyName) && TryResolve(assemblyName, out data);
        }

        public override Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<IDefaultResolverData> data) {
            data = Enumerable.Empty<IDefaultResolverData>();

            if(assemblyName != null) {
                data = ResolveInternal(assemblyName).Select(_ => {
                    _factory.Create(out IDefaultResolverData data, _);
                    return data;
                });
            }

            return data != null && data.Count() > 0;
        }

        #endregion

        #region private methods

        internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName)
            => ResolveInternal(assemblyName, SearchOption.AllDirectories);

        internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName, DirectoryInfo searchDir)
            => ResolveInternal(assemblyName, searchDir, SearchOption.AllDirectories);

        internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName, SearchOption searchOption)
           => ResolveInternal(assemblyName, new FileInfo(Assembly.GetEntryAssembly().Location).Directory, searchOption);

        internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName, DirectoryInfo searchDir, SearchOption searchOption) {
            if(searchDir == null || !searchDir.Exists) {
                return ResolveInternal(assemblyName, searchOption);
            }

            if(!Enum.IsDefined(typeof(SearchOption), searchOption)) {
                return ResolveInternal(assemblyName, searchDir);
            }

            List<FileInfo> files = new List<FileInfo>();

            if(assemblyName != null) {

                foreach(String extension in AssemblyHelper.AssemblyFileExtensions) {
                    foreach(FileInfo file in searchDir.GetFiles($"{assemblyName.Name}.{extension}", searchOption)) {

                        if(AssemblyHelper.TryGetAssemblyName(file, out AssemblyName _asmName)
                            && AssemblyHelper.ValidateByName(assemblyName, _asmName)
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
