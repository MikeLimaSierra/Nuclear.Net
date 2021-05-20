using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Exceptions;

namespace Nuclear.Assemblies.Resolvers {
    internal class DefaultResolver : AssemblyResolver<IDefaultResolverData>, IDefaultResolver {

        #region properties

        internal static IDefaultResolver Instance { get; } = new DefaultResolver();

        #endregion

        #region ctors

        internal DefaultResolver() {
            Throw.IfNot.Object.IsNull<AccessViolationException>(Instance, "Constructor must not be called twice.");
        }

        #endregion

        #region public methods

        public override Boolean TryResolve(ResolveEventArgs e, out IEnumerable<IDefaultResolverData> data) {
            data = Enumerable.Empty<IDefaultResolverData>();

            if(AssemblyHelper.TryGetAssemblyName(e, out AssemblyName assemblyName)) {
                if(e.RequestingAssembly == null) {
                    data = ResolveInternal(assemblyName).Select(_ => new DefaultResolverData(_));
                } else {
                    data = ResolveInternal(assemblyName, new FileInfo(e.RequestingAssembly.Location).Directory, SearchOption.AllDirectories).Select(_ => new DefaultResolverData(_));
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
                data = ResolveInternal(assemblyName).Select(_ => new DefaultResolverData(_));
            }

            return data != null && data.Count() > 0;
        }

        #endregion

    }
}
