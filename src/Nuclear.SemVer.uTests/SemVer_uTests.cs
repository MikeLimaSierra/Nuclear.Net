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

        #region Parse

        [TestMethod]
        void Parse_ThrowsArgNullException() {

            Test.If.Action.ThrowsException(() => SemanticVersion.Parse(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "input");

        }

        [TestMethod]
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
        [TestParameters("1.2.3-")]
        [TestParameters("1.2.3- ")]
        [TestParameters("1.2.3-01")]
        [TestParameters("1.2.3-1.02")]
        [TestParameters("1.2.3-abc/def")]
        [TestParameters("1.2.3-abc_def")]
        [TestParameters("1.2.3+")]
        [TestParameters("1.2.3+ ")]
        [TestParameters("1.2.3+abc/def")]
        [TestParameters("1.2.3+abc_def")]
        void Parse_ThrowsFormatException(String input) {

            Test.If.Action.ThrowsException(() => SemanticVersion.Parse(input), out FormatException ex);

            Test.If.Value.IsEqual(ex.Message, $"Parameter 'input' has an incorrect format: {input.Format()}");

        }

        [TestMethod]
        [TestData(nameof(Parse_Data))]
        void Parse(String input, (Int32 major, Int32 minor, Int32 patch, String pre, String meta) expected) {

            SemanticVersion result = default;

            Test.IfNot.Action.ThrowsException(() => result = SemanticVersion.Parse(input), out Exception _);

            Test.IfNot.Object.IsNull(result);
            Test.If.Value.IsEqual(result.Major, expected.major);
            Test.If.Value.IsEqual(result.Minor, expected.minor);
            Test.If.Value.IsEqual(result.Patch, expected.patch);
            Test.If.Value.IsEqual(result.PreRelease, expected.pre);
            Test.If.Value.IsEqual(result.MetaData, expected.meta);

        }

        IEnumerable<Object[]> Parse_Data() {
            return new List<Object[]> {
                new Object[] { "1.2.3", (1, 2, 3, (String) null, (String) null) },
                new Object[] { "1.2.3-0", (1, 2, 3, "0", (String) null) },
                new Object[] { "1.2.3-1.2", (1, 2, 3, "1.2", (String) null) },
                new Object[] { "1.2.3-1.2.3", (1, 2, 3, "1.2.3", (String) null) },
                new Object[] { "1.2.3-a.2.c.45", (1, 2, 3, "a.2.c.45", (String) null) },
                new Object[] { "1.2.3-alpha", (1, 2, 3, "alpha", (String) null) },
                new Object[] { "1.2.3-alpha-alpha", (1, 2, 3, "alpha-alpha", (String) null) },
                new Object[] { "1.2.3-alpha.1", (1, 2, 3, "alpha.1", (String) null) },
                new Object[] { "1.2.3+0", (1, 2, 3, (String) null, "0") },
                new Object[] { "1.2.3+01", (1, 2, 3, (String) null, "01") },
                new Object[] { "1.2.3+1.02", (1, 2, 3, (String) null, "1.02") },
                new Object[] { "1.2.3+1.2", (1, 2, 3, (String) null, "1.2") },
                new Object[] { "1.2.3+1.2.3", (1, 2, 3, (String) null, "1.2.3") },
                new Object[] { "1.2.3+a.2.c.45", (1, 2, 3, (String) null, "a.2.c.45") },
                new Object[] { "1.2.3+alpha", (1, 2, 3, (String) null, "alpha") },
                new Object[] { "1.2.3+alpha-alpha", (1, 2, 3, (String) null, "alpha-alpha") },
                new Object[] { "1.2.3+alpha.1", (1, 2, 3, (String) null, "alpha.1") },
                new Object[] { "1.2.3-alpha+beta", (1, 2, 3, "alpha", "beta") },
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
        [TestParameters(0u, 0u, 0u, null, false)]
        [TestParameters(0u, 0u, 0u, "alpha", true)]
        [TestParameters(1u, 2u, 3u, "alpha-alpha", true)]
        [TestParameters(3u, 2u, 1u, "4.5.6", true)]
        void Ctor_WithPreRelease(UInt32 major, UInt32 minor, UInt32 patch, String preRelease, Boolean expectedIsPreRelease) {

            SemanticVersion sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new SemanticVersion(major, minor, patch, preRelease: preRelease), out Exception _);

            Test.If.Value.IsEqual(sut.Major, major);
            Test.If.Value.IsEqual(sut.Minor, minor);
            Test.If.Value.IsEqual(sut.Patch, patch);
            Test.If.Value.IsEqual(sut.PreRelease, preRelease);
            Test.If.Value.IsEqual(sut.IsPreRelease, expectedIsPreRelease);
            Test.If.Object.IsNull(sut.MetaData);
            Test.If.Value.IsFalse(sut.HasMetaData);

        }

        [TestMethod]
        [TestParameters(0u, 0u, 0u, "")]
        [TestParameters(0u, 0u, 0u, " ")]
        [TestParameters(0u, 0u, 0u, "01")]
        [TestParameters(0u, 0u, 0u, "1.02")]
        [TestParameters(0u, 0u, 0u, "abc/def")]
        [TestParameters(0u, 0u, 0u, "abc_def")]
        void Ctor_WithPreRelease_Throws(UInt32 major, UInt32 minor, UInt32 patch, String preRelease) {

            SemanticVersion sut = default;

            Test.If.Action.ThrowsException(() => sut = new SemanticVersion(major, minor, patch, preRelease: preRelease), out ArgumentException ex);

            Test.If.Value.IsEqual(ex.ParamName, "preRelease");
            Test.If.String.Contains(ex.Message, $"Pre-release has an incorrect format: {preRelease.Format()}");

        }

        [TestMethod]
        [TestParameters(0u, 0u, 0u, null, false)]
        [TestParameters(0u, 0u, 0u, "alpha", true)]
        [TestParameters(1u, 2u, 3u, "alpha-alpha", true)]
        [TestParameters(3u, 2u, 1u, "4.5.6", true)]
        [TestParameters(0u, 0u, 0u, "01", true)]
        [TestParameters(0u, 0u, 0u, "1.02", true)]
        void Ctor_WithMetaData(UInt32 major, UInt32 minor, UInt32 patch, String metaData, Boolean expectedHasMetaData) {

            SemanticVersion sut = default;

            Test.IfNot.Action.ThrowsException(() => sut = new SemanticVersion(major, minor, patch, metaData: metaData), out Exception _);

            Test.If.Value.IsEqual(sut.Major, major);
            Test.If.Value.IsEqual(sut.Minor, minor);
            Test.If.Value.IsEqual(sut.Patch, patch);
            Test.If.Object.IsNull(sut.PreRelease);
            Test.If.Value.IsFalse(sut.IsPreRelease);
            Test.If.Value.IsEqual(sut.MetaData, metaData);
            Test.If.Value.IsEqual(sut.HasMetaData, expectedHasMetaData);

        }

        [TestMethod]
        [TestParameters(0u, 0u, 0u, "")]
        [TestParameters(0u, 0u, 0u, " ")]
        [TestParameters(0u, 0u, 0u, "abc/def")]
        [TestParameters(0u, 0u, 0u, "abc_def")]
        void Ctor_WithMetaData_Throws(UInt32 major, UInt32 minor, UInt32 patch, String metaData) {

            SemanticVersion sut = default;

            Test.If.Action.ThrowsException(() => sut = new SemanticVersion(major, minor, patch, metaData: metaData), out ArgumentException ex);

            Test.If.Value.IsEqual(ex.ParamName, "metaData");
            Test.If.String.Contains(ex.Message, $"Meta data has an incorrect format: {metaData.Format()}");

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

        #region ToString

        [TestMethod]
        [TestParameters(0u, 0u, 0u, null, null, "0.0.0")]
        [TestParameters(1u, 2u, 3u, null, null, "1.2.3")]
        [TestParameters(1u, 2u, 3u, "alpha", null, "1.2.3-alpha")]
        [TestParameters(1u, 2u, 3u, null, "meta", "1.2.3+meta")]
        [TestParameters(1u, 2u, 3u, "alpha", "meta", "1.2.3-alpha+meta")]
        void ToString(UInt32 major, UInt32 minor, UInt32 patch, String preRelease, String metaData, String expected) {

            String result = default;
            SemanticVersion sut = new SemanticVersion(major, minor, patch, preRelease, metaData);

            Test.IfNot.Action.ThrowsException(() => result = sut.ToString(), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        #endregion

        #region GetHashCode

        [TestMethod]
        [TestData(nameof(GetHashCodeData))]
        void GetHashCode(SemanticVersion lhs, SemanticVersion rhs, Boolean expected) {

            Int32 hash1 = default;
            Int32 hash2 = default;

            Test.IfNot.Action.ThrowsException(() => hash1 = lhs.GetHashCode(), out Exception _);
            Test.IfNot.Action.ThrowsException(() => hash2 = rhs.GetHashCode(), out Exception _);

            Test.If.Value.IsEqual(hash1 == hash2, expected);

        }

        IEnumerable<Object[]> GetHashCodeData() {
            return new List<Object[]>() {
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 0), true },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(1, 0, 0), false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 1, 0), false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 1), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0), false },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, "alpha"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha"), true },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "beta"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.beta"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.1"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha.1"), new SemanticVersion(1, 0, 0, "alpha.2"), false },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, null, "meta"), true },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0), true },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0, null, "meta.1"), true },
            };
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestData(nameof(Equals_Data))]
        void Equals(SemanticVersion lhs, Object rhs, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = lhs.Equals(rhs), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> Equals_Data() {
            return new List<Object[]>() {
                new Object[] { new SemanticVersion(0, 0, 0), null, false },
                new Object[] { new SemanticVersion(0, 0, 0), "Hello World!", false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 0), true },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(1, 0, 0), false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 1, 0), false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 1), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0), false },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, "alpha"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha"), true },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "beta"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.beta"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.1"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha.1"), new SemanticVersion(1, 0, 0, "alpha.2"), false },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, null, "meta"), true },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0), true },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0, null, "meta.1"), true },
            };
        }

        #endregion

        #region EqualsT

        [TestMethod]
        [TestData(nameof(EqualsT_Data))]
        void EqualsT(SemanticVersion lhs, SemanticVersion rhs, Boolean expected) {

            Boolean result = default;

            Test.IfNot.Action.ThrowsException(() => result = lhs.Equals(rhs), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> EqualsT_Data() {
            return new List<Object[]>() {
                new Object[] { new SemanticVersion(0, 0, 0), null, false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 0), true },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(1, 0, 0), false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 1, 0), false },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 1), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0), false },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, "alpha"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha"), true },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "beta"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.beta"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.1"), false },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha.1"), new SemanticVersion(1, 0, 0, "alpha.2"), false },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, null, "meta"), true },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0), true },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0, null, "meta.1"), true },
            };
        }

        #endregion

        #region CompareTo

        [TestMethod]
        [TestData(nameof(CompareTo_Data))]
        void CompareTo(SemanticVersion lhs, SemanticVersion rhs, Int32 expected) {

            Int32 result = default;

            Test.IfNot.Action.ThrowsException(() => result = lhs.CompareTo(rhs), out Exception _);

            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> CompareTo_Data() {
            return new List<Object[]>() {
                new Object[] { new SemanticVersion(0, 0, 0), null, 1 },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 0), 0 },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(1, 0, 0), -1 },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 1, 0), -1 },
                new Object[] { new SemanticVersion(0, 0, 0), new SemanticVersion(0, 0, 1), -1 },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(0, 0, 0), 1 },
                new Object[] { new SemanticVersion(0, 1, 0), new SemanticVersion(0, 0, 0), 1 },
                new Object[] { new SemanticVersion(0, 0, 1), new SemanticVersion(0, 0, 0), 1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0), -1 },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, "alpha"), 1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha"), 0 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "beta"), -1 },
                new Object[] { new SemanticVersion(1, 0, 0, "beta"), new SemanticVersion(1, 0, 0, "alpha"), 1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.beta"), -1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha.beta"), new SemanticVersion(1, 0, 0, "alpha"), 1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha"), new SemanticVersion(1, 0, 0, "alpha.1"), -1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha.1"), new SemanticVersion(1, 0, 0, "alpha"), 1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha.1"), new SemanticVersion(1, 0, 0, "alpha.2"), -1 },
                new Object[] { new SemanticVersion(1, 0, 0, "alpha.2"), new SemanticVersion(1, 0, 0, "alpha.1"), 1 },
                new Object[] { new SemanticVersion(1, 0, 0), new SemanticVersion(1, 0, 0, null, "meta"), 0 },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0), 0 },
                new Object[] { new SemanticVersion(1, 0, 0, null, "meta"), new SemanticVersion(1, 0, 0, null, "meta.1"), 0 },
            };
        }

        #endregion

    }

}
