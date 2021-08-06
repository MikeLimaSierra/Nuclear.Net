using System;
using System.Text.RegularExpressions;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.SemVer {
    public class SemanticVersion : IEquatable<SemanticVersion>, IComparable<SemanticVersion> {

        #region static fields

        private static readonly String _pattern = "(0|[1-9]\\d*)";

        private static readonly Regex _regex = new Regex(_pattern);

        #endregion

        #region properties

        /// <summary>
        /// Gets the major part of the version.
        /// </summary>
        public Int32 Major { get; }

        /// <summary>
        /// Gets the minor part of the version.
        /// </summary>
        public Int32 Minor { get; }

        /// <summary>
        /// Gets the patch part of the version.
        /// </summary>
        public Int32 Patch { get; }

        /// <summary>
        /// Gets if the version is a pre-release.
        /// </summary>
        public Boolean IsPreRelease { get; }

        /// <summary>
        /// Gets the pre-release part of the version.
        /// </summary>
        public String PreRelease { get; }

        /// <summary>
        /// Gets if the version has meta data.
        /// </summary>
        public Boolean HasMetaData { get; }

        /// <summary>
        /// Gets the meta data of the version.
        /// </summary>
        public String MetaData { get; }

        #endregion

        #region ctors

        #endregion

        #region static methods

        /// <summary>
        /// Tries to parse a given version string into a semantic versioning instance.
        /// </summary>
        /// <param name="input">The version string.</param>
        /// <param name="version">The parsed semantic version.</param>
        /// <returns>True if the string can be parsed.</returns>
        public static SemanticVersion Parse(String input) {
            Throw.If.Object.IsNull(input, nameof(input));
            Throw.If.String.IsNullOrWhiteSpace(input, nameof(input));

            SemanticVersion version = default;

            if(!Try.Do(() => _regex.IsMatch(input), out Exception _)) {
                throw new FormatException($"Parameter {nameof(input).Format()} has an incorrect format: {input.Format()}");
            }

            return version;
        }

        /// <summary>
        /// Tries to parse a given version string into a semantic versioning instance.
        /// </summary>
        /// <param name="input">The version string.</param>
        /// <param name="version">The parsed semantic version.</param>
        /// <returns>True if the string can be parsed.</returns>
        public static Boolean TryParse(String input, out SemanticVersion version) {
            version = default;
            SemanticVersion _version = default;

            Try.Do(() => _version = Parse(input), out Exception _);
            version = _version;

            return version != null;
        }

        #endregion

        #region methods

        public override String ToString() => base.ToString();

        public override Int32 GetHashCode() => base.GetHashCode();

        public override Boolean Equals(Object obj) => base.Equals(obj);

        #endregion

        #region IEquatable

        public Boolean Equals(SemanticVersion other) => throw new NotImplementedException();

        #endregion

        #region IComparable

        public Int32 CompareTo(SemanticVersion other) => throw new NotImplementedException();

        #endregion

    }
}
