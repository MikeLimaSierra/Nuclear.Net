using System;
using System.IO;

namespace Nuclear.Assemblies.Resolvers.Data {

    internal class DefaultResolverData : AssemblyResolverData, IDefaultResolverData {

        #region ctors

        internal DefaultResolverData(FileInfo file) : base(file) { }

        #endregion

        #region methods

        protected override Boolean Init() => true;

        #endregion

    }

}
