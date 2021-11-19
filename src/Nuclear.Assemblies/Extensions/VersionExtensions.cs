using System;

using Nuclear.Assemblies.Resolvers;

namespace Nuclear.Assemblies.Extensions {
    internal static class VersionExtensions {

        internal static Boolean Matches(this Version requested, Version found, MatchingStrategies strategy)
            => strategy switch {
                MatchingStrategies.Strict => requested.Equals(found),
                MatchingStrategies.SemVer => requested.Major == found.Major && requested.Minor <= found.Minor,
                _ => false,
            };

    }
}
