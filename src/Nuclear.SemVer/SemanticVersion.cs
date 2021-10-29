using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.SemVer {

    /// <summary>
    /// Implements a semantic version structure that behaves according to https://semver.org/ .
    /// </summary>
    public class SemanticVersion : IEquatable<SemanticVersion>, IComparable<SemanticVersion> {

        #region static fields

        /// <summary>
        /// ^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$
        /// </summary>
        private static readonly String _pattern = $"(?<major>0|[1-9]\\d*)\\.(?<minor>0|[1-9]\\d*)\\.(?<patch>0|[1-9]\\d*)" +
            $"(?:-(?<pre>(0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*)(\\.(0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?" +
            $"(?:\\+(?<meta>[0-9a-zA-Z-]+(?:\\.[0-9a-zA-Z-]+)*))?";
        private static readonly String pattern_ = $"(?<major>0|[1-9]\\d*)\\.(?<minor>0|[1-9]\\d*)\\.(?<patch>0|[1-9]\\d*)(-{_preReleasePattern})?(\\+{_metaDataPattern})?";

        private static readonly String _preReleasePattern = "(0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*)(\\.(0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*))*";

        private static readonly String _metaDataPattern = "[0-9a-zA-Z-]+(\\.[0-9a-zA-Z-]+)*";

        #endregion

        #region properties

        /// <summary>
        /// Gets the major part of the version.
        /// </summary>
        public UInt32 Major { get; }

        /// <summary>
        /// Gets the minor part of the version.
        /// </summary>
        public UInt32 Minor { get; }

        /// <summary>
        /// Gets the patch part of the version.
        /// </summary>
        public UInt32 Patch { get; }

        /// <summary>
        /// Gets if the version is a pre-release.
        /// </summary>
        public Boolean IsPreRelease => !String.IsNullOrWhiteSpace(PreRelease);

        /// <summary>
        /// Gets the pre-release part of the version.
        /// </summary>
        public String PreRelease { get; }

        /// <summary>
        /// Gets if the version has meta data.
        /// </summary>
        public Boolean HasMetaData => !String.IsNullOrWhiteSpace(MetaData);

        /// <summary>
        /// Gets the meta data of the version.
        /// </summary>
        public String MetaData { get; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="SemanticVersion"/>.
        /// </summary>
        /// <param name="major">The major part of the version.</param>
        /// <param name="minor">The minor part of the version.</param>
        /// <param name="patch">The patch part of the version.</param>
        public SemanticVersion(UInt32 major, UInt32 minor, UInt32 patch) {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        /// <summary>
        /// Creates a new instance of <see cref="SemanticVersion"/>.
        /// </summary>
        /// <param name="major">The major part of the version.</param>
        /// <param name="minor">The minor part of the version.</param>
        /// <param name="patch">The patch part of the version.</param>
        /// <param name="preRelease">The pre-release component of the version, defaults to null.</param>
        /// <param name="metaData">The versions meta data, defaults to null.</param>
        public SemanticVersion(UInt32 major, UInt32 minor, UInt32 patch, String preRelease = null, String metaData = null) : this(major, minor, patch) {
            PreRelease = ValidatePreRelease(preRelease) || preRelease == null ? preRelease : throw new ArgumentException($"Pre-release has an incorrect format: {preRelease.Format()}", nameof(preRelease));
            MetaData = ValidateMetaData(metaData) || metaData == null ? metaData : throw new ArgumentException($"Meta data has an incorrect format: {metaData.Format()}", nameof(metaData));
        }

        #endregion

        #region static methods

        /// <summary>
        /// Parses a given version string into a <see cref="SemanticVersion"/> instance.
        /// </summary>
        /// <param name="input">The version string.</param>
        /// <returns>The semantic version instance.</returns>
        internal static SemanticVersion Parse(String input) {
            Throw.If.Object.IsNull(input, nameof(input));

            Regex regex = new Regex($"^{_pattern}$");

            if(Try.Do(() => regex.IsMatch(input), out Boolean result, out Exception _) && result) {
                Match match = regex.Match(input);

                return new SemanticVersion(
                    UInt32.Parse(match.Groups["major"].Value),
                    UInt32.Parse(match.Groups["minor"].Value),
                    UInt32.Parse(match.Groups["patch"].Value),
                    match.Groups["pre"].Value);

            } else {
                throw new FormatException($"Parameter {nameof(input).Format()} has an incorrect format: {input.Format()}");
            }
        }

        /// <summary>
        /// Validates a pre-release input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>True if the input is valid.</returns>
        protected internal static Boolean ValidatePreRelease(String input) => Validate(input, _preReleasePattern);

        /// <summary>
        /// Validates a meta data input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>True if the input is valid.</returns>
        protected internal static Boolean ValidateMetaData(String input) => Validate(input, _metaDataPattern);

        private static Boolean Validate(String input, String pattern) => !String.IsNullOrWhiteSpace(input) && new Regex($"^{pattern}$").IsMatch(input);

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        #region override methods

        public override String ToString() {
            StringBuilder sb = new StringBuilder($"{Major}.{Minor}.{Patch}");

            if(IsPreRelease) { sb.AppendFormat("-{0}", PreRelease); }
            if(HasMetaData) { sb.AppendFormat("+{0}", MetaData); }

            return sb.ToString();
        }

        public override Int32 GetHashCode() {
            Int32 hashCode = 829241888;
            hashCode = hashCode * -1521134295 + Major.GetHashCode();
            hashCode = hashCode * -1521134295 + Minor.GetHashCode();
            hashCode = hashCode * -1521134295 + Patch.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<String>.Default.GetHashCode(PreRelease);
            return hashCode;
        }

        public override Boolean Equals(Object obj) => obj != null && obj is SemanticVersion other && Equals(other);

        #endregion

        #region IEquatable

        public Boolean Equals(SemanticVersion other) {
            if(other == null) { return false; }

            if(Major != other.Major) { return false; }
            if(Minor != other.Minor) { return false; }
            if(Patch != other.Patch) { return false; }
            if(IsPreRelease != other.IsPreRelease) { return false; }

            return PreRelease.IsEqual(other.PreRelease);
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(SemanticVersion other) {
            if(other == null) { return 1; }

            if(!Equals(other)) {
                Int32 result = Major.CompareTo(other.Major);
                if(result != 0) { return result; }

                result = Minor.CompareTo(other.Minor);
                if(result != 0) { return result; }

                result = Patch.CompareTo(other.Patch);
                if(result != 0) { return result; }

                if(IsPreRelease && other.IsPreRelease) {
                    return PreRelease.CompareTo(other.PreRelease);
                }

                return IsPreRelease ? -1 : 1;
            }

            return 0;
        }

        #endregion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    }
}
