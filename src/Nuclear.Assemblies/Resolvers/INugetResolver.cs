using Nuclear.Assemblies.Resolvers.Data;

namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// A resolver that searches for a NuGet package.
    /// </summary>
    public interface INugetResolver : IAssemblyResolver<INugetResolverData> { }

}
