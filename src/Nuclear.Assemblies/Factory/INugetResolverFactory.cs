using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factory {

    /// <summary>
    /// Defines a factory to create instances of nuget assembly resolvers and their data objects.
    /// </summary>
    public interface INugetResolverFactory : ICreator<INugetResolver>, ICreator<INugetResolverData, FileInfo> { }

}
