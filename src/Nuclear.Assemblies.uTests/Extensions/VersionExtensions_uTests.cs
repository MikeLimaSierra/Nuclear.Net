using System;
using System.Collections.Generic;

using Nuclear.Assemblies.Resolvers;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Extensions {
    class VersionExtensions_uTests {

        #region VersionsMatch

        [TestMethod]
        [TestData(nameof(VersionsMatch_Data))]
        void VersionsMatch(VersionMatchingStrategies strategy, Version requested, Version found, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = requested.Matches(found, strategy), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> VersionsMatch_Data() {
            return new List<Object[]>() {
                new Object[] { (VersionMatchingStrategies) 42, new Version(1, 2, 2), new Version(2, 2, 2), false },
                new Object[] { (VersionMatchingStrategies) 42, new Version(2, 1, 2), new Version(2, 2, 2), false },
                new Object[] { (VersionMatchingStrategies) 42, new Version(2, 2, 1), new Version(2, 2, 2), false },
                new Object[] { (VersionMatchingStrategies) 42, new Version(2, 2, 2), new Version(2, 2, 2), false },
                new Object[] { (VersionMatchingStrategies) 42, new Version(2, 2, 2), new Version(1, 2, 2), false },
                new Object[] { (VersionMatchingStrategies) 42, new Version(2, 2, 2), new Version(2, 1, 2), false },
                new Object[] { (VersionMatchingStrategies) 42, new Version(2, 2, 2), new Version(2, 2, 1), false },

                new Object[] { VersionMatchingStrategies.Strict, new Version(1, 2, 2), new Version(2, 2, 2), false },
                new Object[] { VersionMatchingStrategies.Strict, new Version(2, 1, 2), new Version(2, 2, 2), false },
                new Object[] { VersionMatchingStrategies.Strict, new Version(2, 2, 1), new Version(2, 2, 2), false },
                new Object[] { VersionMatchingStrategies.Strict, new Version(2, 2, 2), new Version(2, 2, 2), true },
                new Object[] { VersionMatchingStrategies.Strict, new Version(2, 2, 2), new Version(1, 2, 2), false },
                new Object[] { VersionMatchingStrategies.Strict, new Version(2, 2, 2), new Version(2, 1, 2), false },
                new Object[] { VersionMatchingStrategies.Strict, new Version(2, 2, 2), new Version(2, 2, 1), false },

                new Object[] { VersionMatchingStrategies.SemVer, new Version(1, 2, 2), new Version(2, 2, 2), false },
                new Object[] { VersionMatchingStrategies.SemVer, new Version(2, 1, 2), new Version(2, 2, 2), true },
                new Object[] { VersionMatchingStrategies.SemVer, new Version(2, 2, 1), new Version(2, 2, 2), true },
                new Object[] { VersionMatchingStrategies.SemVer, new Version(2, 2, 2), new Version(2, 2, 2), true },
                new Object[] { VersionMatchingStrategies.SemVer, new Version(2, 2, 2), new Version(1, 2, 2), false },
                new Object[] { VersionMatchingStrategies.SemVer, new Version(2, 2, 2), new Version(2, 1, 2), false },
                new Object[] { VersionMatchingStrategies.SemVer, new Version(2, 2, 2), new Version(2, 2, 1), true },
            };
        }

        #endregion

    }
}
