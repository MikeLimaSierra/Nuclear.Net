namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Defines an assembly resolver.
    /// </summary>
    public interface IAssemblyResolver {

        #region properties

        /// <summary>
        /// Gets the matching strategy for resolving packages.
        /// </summary>
        MatchingStrategies MatchingStrategy { get; }

        #endregion

    }
}
