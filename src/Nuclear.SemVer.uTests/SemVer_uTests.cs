using System;
using System.Collections.Generic;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.SemVer {
    class SemVer_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<SemanticVersion, IComparable<SemanticVersion>>();
            Test.If.Type.Implements<SemanticVersion, IEquatable<SemanticVersion>>();

        }

        #region TryParse

        [TestMethod("asdf")]
        [TestParameters(null)]
        [TestParameters("")]
        [TestParameters(" ")]
        [TestParameters(".")]
        [TestParameters("1")]
        [TestParameters("1.2")]
        [TestParameters("1.2.")]
        [TestParameters("01.2.3")]
        [TestParameters("1.02.3")]
        [TestParameters("1.2.03")]
        [TestParameters("1.2.3.")]
        [TestParameters("1.2.3.4")]
        [TestParameters("1.2.3.alpha")]
        [TestParameters("1.2.3_alpha")]
        [TestParameters("1.2.3+alpha")]
        [TestParameters("1.2.3-")]
        [TestParameters("1.2.3-abc/def")]
        [TestParameters("1.2.3-abc_def")]
        [TestParameters("1.2.3-0123")]
        [TestParameters("1.2.3-123.0456")]
        [TestParameters("1.2.3.beta")]
        [TestParameters("1.2.3_beta")]
        [TestParameters("1.2.3+")]
        [TestParameters("1.2.3+abc/def")]
        [TestParameters("1.2.3+abc_def")]
        void TryParseFails(String input) {

            SemanticVersion version = default;
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = SemanticVersion.TryParse(input, out version), out FormatException ex);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(version);
            Test.If.Value.IsEqual(ex.Message, $"Version string {input.Format()} has a bad format.");

        }

        [TestMethod("asdf")]
        [TestData(nameof(CtorData))]
        void TryParse(String input, (Int32 major, Int32 minor, Int32 patch, String pre, Boolean isPre, String meta, Boolean hasMeta) expected) {

            SemanticVersion version = default;
            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = SemanticVersion.TryParse(input, out version), out Exception _);

            Test.If.Value.IsTrue(result);
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

        #region ctors

        [TestMethod]
        [TestParameters(0u, 0u, 0u)]
        [TestParameters(1u, 2u, 3u)]
        [TestParameters(3u, 2u, 1u)]
        void Ctor(UInt32 major, UInt32 minor, UInt32 patch) {

            SemanticVersion sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new SemanticVersion(major, minor, patch), out Exception _);

            Test.If.Value.IsEqual(sut.Major, major);
            Test.If.Value.IsEqual(sut.Minor, minor);
            Test.If.Value.IsEqual(sut.Patch, patch);
            Test.If.Object.IsNull(sut.PreRelease);
            Test.If.Value.IsFalse(sut.IsPreRelease);
            Test.If.Object.IsNull(sut.MetaData);
            Test.If.Value.IsFalse(sut.HasMetaData);

        }

        [TestMethod]
        [TestParameters(0u, 0u, 0u, "alpha")]
        [TestParameters(1u, 2u, 3u, "alpha-alpha")]
        [TestParameters(3u, 2u, 1u, "4.5.6")]
        void Ctor_WithPreRelease(UInt32 major, UInt32 minor, UInt32 patch, String preRelease) {

            SemanticVersion sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new SemanticVersion(major, minor, patch, preRelease: preRelease), out Exception _);

            Test.If.Value.IsEqual(sut.Major, major);
            Test.If.Value.IsEqual(sut.Minor, minor);
            Test.If.Value.IsEqual(sut.Patch, patch);
            Test.If.Value.IsEqual(sut.PreRelease, preRelease);
            Test.If.Value.IsTrue(sut.IsPreRelease);
            Test.If.Object.IsNull(sut.MetaData);
            Test.If.Value.IsFalse(sut.HasMetaData);

        }

        #endregion

        #region ValidatePreRelease

        [TestMethod]
        [TestParameters(null, false)]
        [TestParameters("", false)]
        [TestParameters(" ", false)]
        [TestParameters("0", true)]
        [TestParameters("01", false)]
        [TestParameters("1.02", false)]
        [TestParameters("1.2", true)]
        [TestParameters("1.2.3", true)]
        [TestParameters("a.2.c.45", true)]
        [TestParameters("alpha", true)]
        [TestParameters("alpha-alpha", true)]
        [TestParameters("alpha.1", true)]
        [TestParameters("abc/def", false)]
        [TestParameters("abc_def", false)]
        void ValidatePreRelease(String input, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = SemanticVersion.ValidatePreRelease(input), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        #endregion

        #region ValidateMetaData

        [TestMethod]
        [TestParameters(null, false)]
        [TestParameters("", false)]
        [TestParameters(" ", false)]
        [TestParameters("0", true)]
        [TestParameters("01", true)]
        [TestParameters("1.02", true)]
        [TestParameters("1.2", true)]
        [TestParameters("1.2.3", true)]
        [TestParameters("a.2.c.45", true)]
        [TestParameters("alpha", true)]
        [TestParameters("alpha-alpha", true)]
        [TestParameters("alpha.1", true)]
        [TestParameters("abc/def", false)]
        [TestParameters("abc_def", false)]
        void ValidateMetaData(String input, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = SemanticVersion.ValidateMetaData(input), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        #endregion

    }
}
