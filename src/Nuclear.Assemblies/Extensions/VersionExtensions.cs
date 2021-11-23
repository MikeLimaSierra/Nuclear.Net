using System;

using Nuclear.Assemblies.Resolvers;

namespace Nuclear.Assemblies.Extensions {
    internal static class VersionExtensions {

        internal static Boolean Matches(this Version requested, Version found, VersionMatchingStrategies strategy)
            => strategy switch {
                VersionMatchingStrategies.Strict => requested.Equals(found),
                VersionMatchingStrategies.SemVer => requested.Major == found.Major && requested.Minor <= found.Minor,
                _ => false,
            };

    }
}
