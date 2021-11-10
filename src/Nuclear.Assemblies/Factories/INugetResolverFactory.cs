using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factories {

    /// <summary>
    /// Defines a factory to create instances of nuget assembly resolvers and their data objects.
    /// </summary>
    public interface INugetResolverFactory : ICreator<INugetResolver>, ICreator<INugetResolver, IEnumerable<DirectoryInfo>>, ICreator<INugetResolverData, FileInfo> { }

}
