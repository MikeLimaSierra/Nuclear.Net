using System.IO;

using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.Resolvers;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factories {

    /// <summary>
    /// Defines a factory to create instances of default assembly resolvers and their data objects.
    /// </summary>
    public interface IDefaultResolverFactory :
        ICreator<IDefaultResolver, MatchingStrategies, SearchOption>,
        ICreator<IDefaultResolverData, FileInfo> { }

}
