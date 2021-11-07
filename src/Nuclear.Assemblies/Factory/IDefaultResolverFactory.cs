using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factory {

    /// <summary>
    /// Defines a factory to create instances of default assembly resolvers and their data objects.
    /// </summary>
    public interface IDefaultResolverFactory : ICreator<IDefaultResolver>, ICreator<IDefaultResolverData, FileInfo> { }

}
