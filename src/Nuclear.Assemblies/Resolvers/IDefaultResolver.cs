namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// A resolver that searches in a directory.
    /// Directories can be the location of the calling assembly or of the entry assembly.
    /// </summary>
    public interface IDefaultResolver : IAssemblyResolver { }
}
