using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class AssemblyResolver_uTests {

        #region VersionsMatch

        [TestMethod]
        [TestData(nameof(VersionsMatch_Data))]
        void VersionsMatch(MatchingStrategies strategy, Version requested, Version found, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = AssemblyResolver.VersionsMatch(strategy, requested, found), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> VersionsMatch_Data() {
            return new List<Object[]>() {
                new Object[] { MatchingStrategies.Unknown, new Version(1, 2, 2), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.Unknown, new Version(2, 1, 2), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.Unknown, new Version(2, 2, 1), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.Unknown, new Version(2, 2, 2), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.Unknown, new Version(2, 2, 2), new Version(1, 2, 2), false },
                new Object[] { MatchingStrategies.Unknown, new Version(2, 2, 2), new Version(2, 1, 2), false },
                new Object[] { MatchingStrategies.Unknown, new Version(2, 2, 2), new Version(2, 2, 1), false },

                new Object[] { MatchingStrategies.Strict, new Version(1, 2, 2), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.Strict, new Version(2, 1, 2), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.Strict, new Version(2, 2, 1), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.Strict, new Version(2, 2, 2), new Version(2, 2, 2), true },
                new Object[] { MatchingStrategies.Strict, new Version(2, 2, 2), new Version(1, 2, 2), false },
                new Object[] { MatchingStrategies.Strict, new Version(2, 2, 2), new Version(2, 1, 2), false },
                new Object[] { MatchingStrategies.Strict, new Version(2, 2, 2), new Version(2, 2, 1), false },

                new Object[] { MatchingStrategies.SemVer, new Version(1, 2, 2), new Version(2, 2, 2), false },
                new Object[] { MatchingStrategies.SemVer, new Version(2, 1, 2), new Version(2, 2, 2), true },
                new Object[] { MatchingStrategies.SemVer, new Version(2, 2, 1), new Version(2, 2, 2), true },
                new Object[] { MatchingStrategies.SemVer, new Version(2, 2, 2), new Version(2, 2, 2), true },
                new Object[] { MatchingStrategies.SemVer, new Version(2, 2, 2), new Version(1, 2, 2), false },
                new Object[] { MatchingStrategies.SemVer, new Version(2, 2, 2), new Version(2, 1, 2), false },
                new Object[] { MatchingStrategies.SemVer, new Version(2, 2, 2), new Version(2, 2, 1), true },
            };
        }

        #endregion

    }
}
