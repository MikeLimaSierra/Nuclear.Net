namespace Nuclear.Assemblies.Resolvers {

    /// <summary>
    /// Defines a range of version matching strategies to resolve assemblies.
    /// </summary>
    public enum MatchingStrategies {

        /// <summary>
        /// Invalid value.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Versions must match exactly.
        /// </summary>
        Strict = 1,

        /// <summary>
        /// Version matching is done according to semver.
        /// </summary>
        SemVer = 2,
    }
}
