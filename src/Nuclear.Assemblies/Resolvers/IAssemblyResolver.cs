namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Defines an assembly resolver.
    /// </summary>
    public interface IAssemblyResolver {

        #region properties

        /// <summary>
        /// Gets the matching strategy for assembly versions.
        /// </summary>
        MatchingStrategies AssemblyMatchingStrategy { get; }

        #endregion

    }
}
