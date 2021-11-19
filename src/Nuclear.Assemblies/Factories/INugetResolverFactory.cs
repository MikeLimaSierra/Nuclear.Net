using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.ResolverData;
using Nuclear.Assemblies.Resolvers;
using Nuclear.Creation;

namespace Nuclear.Assemblies.Factories {

    /// <summary>
    /// Defines a factory to create instances of nuget assembly resolvers and their data objects.
    /// </summary>
    public interface INugetResolverFactory :
        ICreator<INugetResolver, MatchingStrategies>,
        ICreator<INugetResolver, MatchingStrategies, IEnumerable<DirectoryInfo>>,
        ICreator<INugetResolverData, FileInfo> { }

}
