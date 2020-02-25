using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuclear.Exceptions;

namespace Nuclear.Assemblies.Resolvers {
    internal class DefaultResolver : AssemblyResolver, IDefaultResolver {

        #region properties

        internal static IDefaultResolver Instance { get; } = new DefaultResolver();

        #endregion

        #region ctors

        internal DefaultResolver() {
            Throw.IfNot.Object.IsNull<AccessViolationException>(Instance, "Constructor must not be called twice.");
        }

        #endregion

        #region public methods

        public override Boolean TryResolve(ResolveEventArgs e, out IEnumerable<FileInfo> files) {
            files = Enumerable.Empty<FileInfo>();

            if(AssemblyHelper.TryGetAssemblyName(e, out AssemblyName assemblyName)) {
                if(e.RequestingAssembly == null) {
                    files = ResolveInternal(assemblyName);
                } else {
                    files = ResolveInternal(assemblyName, new FileInfo(e.RequestingAssembly.Location).Directory, SearchOption.AllDirectories);
                }
            }

            return files != null && files.Count() > 0;
        }

        public override Boolean TryResolve(String fullName, out IEnumerable<FileInfo> files) {
            files = Enumerable.Empty<FileInfo>();

            return AssemblyHelper.TryGetAssemblyName(fullName, out AssemblyName assemblyName) && TryResolve(assemblyName, out files);
        }

        public override Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<FileInfo> files) {
            files = Enumerable.Empty<FileInfo>();

            if(assemblyName != null) {
                files = ResolveInternal(assemblyName);
            }

            return files != null && files.Count() > 0;
        }

        #endregion

    }
}
