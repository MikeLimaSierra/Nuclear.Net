using System;

namespace Nuclear.Assemblies.Resolvers {

    internal abstract class AssemblyResolver : IAssemblyResolver {

        #region properties

        public MatchingStrategies MatchingStrategy { get; }

        #endregion

        #region protected methods

        protected internal static Boolean VersionsMatch(MatchingStrategies strategy, Version requested, Version found)
            => strategy switch {
                MatchingStrategies.Strict => requested.Equals(found),
                MatchingStrategies.SemVer => requested.Major == found.Major && requested.Minor <= found.Minor,
                _ => false,
            };

        #endregion

    }

}
