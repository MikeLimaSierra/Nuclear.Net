using System;

using Nuclear.Assemblies.Resolvers;

namespace Nuclear.Assemblies.Extensions {
    internal static class VersionExtensions {

        internal static Boolean Matches(this Version requested, Version found, VersionMatchingStrategies strategy) {
            if(requested == null || found == null) {
                return false;
            }

            return strategy switch {
                VersionMatchingStrategies.Strict => requested.Major == found.Major && requested.Minor == found.Minor && requested.Build == found.Build,
                VersionMatchingStrategies.SemVer => requested.Major == found.Major && requested.Minor <= found.Minor,
                _ => false,
            };
        }
    }
}
