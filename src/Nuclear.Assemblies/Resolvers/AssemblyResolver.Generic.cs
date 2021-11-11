using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Resolvers.Data;

namespace Nuclear.Assemblies.Resolvers {

    internal abstract class AssemblyResolver<TData> : AssemblyResolver, IAssemblyResolver<TData> where TData : IAssemblyResolverData {

        #region public methods

        public abstract Boolean TryResolve(ResolveEventArgs e, out IEnumerable<TData> data);

        public abstract Boolean TryResolve(String fullName, out IEnumerable<TData> data);

        public abstract Boolean TryResolve(AssemblyName assemblyName, out IEnumerable<TData> data);

        #endregion

    }

}
