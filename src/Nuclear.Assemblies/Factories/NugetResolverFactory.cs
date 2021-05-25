using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Data;

namespace Nuclear.Assemblies.Factories {

    internal class NugetResolverFactory : INugetResolverFactory {

        #region methods

        public void Create(out INugetResolver obj) => obj = new NugetResolver();

        public void Create(out INugetResolverData obj, FileInfo file) => obj = new NugetResolverData(file);

        #endregion

    }

}
