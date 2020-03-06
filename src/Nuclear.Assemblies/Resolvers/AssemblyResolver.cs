using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Abstract base implementation of <see cref="IAssemblyResolver"/> including some basic resolving functionality.
    /// </summary>
    public abstract class AssemblyResolver : IAssemblyResolver {

        #region static properties

        /// <summary>
        /// Gets an instance of the default resolver.
        /// </summary>
        public static IDefaultResolver Default => DefaultResolver.Instance;

        /// <summary>
        /// Gets an instance of the NuGet resolver.
        /// </summary>
        //public static INugetResolver Nuget => NugetResolver.Instance;

        #endregion

        #region public methods

        /// <summary>
        /// Resolves a reference assembly by <see cref="ResolveEventArgs"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="e">The given <see cref="ResolveEventArgs"/>.</param>
        /// <param name="files">The resolved files.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(ResolveEventArgs e, out IEnumerable<FileInfo> files);

        /// <summary>
        /// Resolves a reference assembly by the full name.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="fullName">The full name of the assembly.</param>
        /// <param name="files">The resolved files.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(String fullName, out IEnumerable<FileInfo> files);

        /// <summary>
        /// Resolves a reference assembly by an <see cref="AssemblyName"/>.
        /// A return value indicates if the resolving operation was successful.
        /// </summary>
        /// <param name="assemblyName">The <see cref="AssemblyName"/> of the assembly.</param>
        /// <param name="files">The resolved files.</param>
        /// <returns>True if a file could be found.</returns>
        public abstract Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<FileInfo> files);

        #endregion

        #region protected methods

        /// <summary>
        /// Resolves an assembly by searching recursively in the entry assembly directory.
        /// Files are considered valid if the <see cref="AssemblyName"/> and <see cref="ProcessorArchitecture"/> match the request.
        /// </summary>
        /// <param name="assemblyName">The assembly name to resolve.</param>
        /// <returns>A list of files matching the pattern.</returns>
        protected internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName)
            => ResolveInternal(assemblyName, SearchOption.AllDirectories);

        /// <summary>
        /// Resolves an assembly by searching recursively in <paramref name="searchDir"/>.
        /// Files are considered valid if the <see cref="AssemblyName"/> and <see cref="ProcessorArchitecture"/> match the request.
        /// </summary>
        /// <param name="assemblyName">The assembly name to resolve.</param>
        /// <param name="searchDir">The search directory. If null or non existent, the entry assembly directory will be used.</param>
        /// <returns>A list of files matching the pattern.</returns>
        protected internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName, DirectoryInfo searchDir)
            => ResolveInternal(assemblyName, searchDir, SearchOption.AllDirectories);

        /// <summary>
        /// Resolves an assembly by searching in the entry assembly directory.
        /// Files are considered valid if the <see cref="AssemblyName"/> and <see cref="ProcessorArchitecture"/> match the request.
        /// </summary>
        /// <param name="assemblyName">The assembly name to resolve.</param>
        /// <param name="searchOption">The value wether to search sub directories or not.</param>
        /// <returns>A list of files matching the pattern.</returns>
        protected internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName, SearchOption searchOption)
            => ResolveInternal(assemblyName, new FileInfo(Assembly.GetEntryAssembly().Location).Directory, searchOption);

        /// <summary>
        /// Resolves an assembly by searching in <paramref name="searchDir"/>.
        /// Files are considered valid if the <see cref="AssemblyName"/> and <see cref="ProcessorArchitecture"/> match the request.
        /// </summary>
        /// <param name="assemblyName">The assembly name to resolve.</param>
        /// <param name="searchDir">The search directory. If null or non existent, the entry assembly directory will be used.</param>
        /// <param name="searchOption">The value wether to search sub directories or not.</param>
        /// <returns>A list of files matching the pattern.</returns>
        protected internal static IEnumerable<FileInfo> ResolveInternal(AssemblyName assemblyName, DirectoryInfo searchDir, SearchOption searchOption) {
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
