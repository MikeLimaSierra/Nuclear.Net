using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.SemVer {
    class SemVer_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ISemVer, IComparable<ISemVer>>();
            Test.If.Type.Implements<ISemVer, IEquatable<ISemVer>>();
            Test.If.Type.Implements<SemVer, ISemVer>();

        }

        #region ctor

        [TestMethod]
        [TestParameters(typeof(ArgumentNullException), null, "input")]
        [TestParameters(typeof(ArgumentException), "", "input")]
        [TestParameters(typeof(ArgumentException), " ", "input")]
        void CtorThrowsArgEx<TEx>(String input, String expected)
            where TEx : ArgumentException {

            Test.If.Action.ThrowsException(() => new SemVer(input), out TEx _);

        }

        [TestMethod]
        [TestParameters("1", "input")]
        [TestParameters("1.2", "input")]
        [TestParameters("01.2.3", "input")]
        [TestParameters("1.02.3", "input")]
        [TestParameters("1.2.03", "input")]

        [TestParameters("1.2.3.alpha", "input")]
        [TestParameters("1.2.3_alpha", "input")]
        [TestParameters("1.2.3+alpha", "input")]
        [TestParameters("1.2.3-", "input")]
        [TestParameters("1.2.3-abc/def", "input")]
        [TestParameters("1.2.3-abc_def", "input")]
        [TestParameters("1.2.3-0123", "input")]

        [TestParameters("1.2.3.beta", "input")]
        [TestParameters("1.2.3_beta", "input")]
        [TestParameters("1.2.3-beta", "input")]
        [TestParameters("1.2.3+", "input")]
        [TestParameters("1.2.3+abc/def", "input")]
        [TestParameters("1.2.3+abc_def", "input")]
        void CtorThrowsFormatEx(String input, String expected) {

            Test.If.Action.ThrowsException(() => new SemVer(input), out FormatException _);

        }

        [TestMethod]
        [TestData(nameof(CtorData))]
        void Ctor(String input, (Int32 major, Int32 minor, Int32 patch, String pre, Boolean isPre, String meta, Boolean hasMeta) expected) {

            ISemVer version = default;

            Test.IfNot.Action.ThrowsException(() => version = new SemVer(input), out Exception _);

            Test.If.Value.IsEqual(version.Major, expected.major);
            Test.If.Value.IsEqual(version.Minor, expected.minor);
            Test.If.Value.IsEqual(version.Patch, expected.patch);
            Test.If.Value.IsEqual(version.PreRelease, expected.pre);
            Test.If.Value.IsEqual(version.IsPreRelease, expected.isPre);
            Test.If.Value.IsEqual(version.MetaData, expected.meta);
            Test.If.Value.IsEqual(version.HasMetaData, expected.hasMeta);

        }

        IEnumerable<Object[]> CtorData() {
            return new List<Object[]> {
                new Object[] { "1.2.3", (1, 2, 3, (String) null, false, (String) null, false) },
                new Object[] { "1.2.3-alpha", (1, 2, 3, "alpha", true, (String) null, false) },
                new Object[] { "1.2.3-alpha-alpha", (1, 2, 3, "alpha-alpha", true, (String) null, false) },
                new Object[] { "1.2.3-alpha.1", (1, 2, 3, "alpha.1", true, (String) null, false) },
                new Object[] { "1.2.3-4.5.6", (1, 2, 3, "4.5.6", true, (String) null, false) },
                new Object[] { "1.2.3-a.2.c.45", (1, 2, 3, "a.2.c.45", true, (String) null, false) },
                new Object[] { "1.2.3+1-a", (1, 2, 3, (String) null, false, "1-a", true) },
                new Object[] { "1.2.3+1", (1, 2, 3, (String) null, false, "1", true) },
                new Object[] { "1.2.3+001", (1, 2, 3, (String) null, false, "001", true) },
                new Object[] { "1.2.3+e.s.456", (1, 2, 3, (String) null, false, "e.s.456", true) },
                new Object[] { "1.2.3-alpha+1", (1, 2, 3, "alpha", true, "1", true) },
                new Object[] { "1.2.3-alpha+1-a", (1, 2, 3, "alpha", true, "1-a", true) },
                new Object[] { "1.2.3-alpha+001", (1, 2, 3, "alpha", true, "001", true) },
                new Object[] { "1.2.3-alpha+e.s.456", (1, 2, 3, "alpha", true, "e.s.456", true) }
            };
        }

        #endregion

    }
}
