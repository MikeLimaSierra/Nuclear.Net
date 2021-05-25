using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Data;

namespace Nuclear.Assemblies.Factories {

    internal class DefaultResolverFactory : IDefaultResolverFactory {

        #region methods

        public void Create(out IDefaultResolver obj) => obj = new DefaultResolver();

        public void Create(out IDefaultResolverData obj, FileInfo file) => obj = new DefaultResolverData(file);

        #endregion

    }

}
