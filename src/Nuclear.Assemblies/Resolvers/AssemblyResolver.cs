using System;

namespace Nuclear.Assemblies.Resolvers {

    internal abstract class AssemblyResolver : IAssemblyResolver {

        #region properties

        public MatchingStrategies MatchingStrategy { get; }

        #endregion

        #region protected methods

        protected internal static Boolean VersionsMatch(MatchingStrategies strategy, Version requested, Version found) {
            switch(strategy) {
                case MatchingStrategies.Strict: return requested.Equals(found);

                default: return false;
            }
        }

        #endregion

    }

}
