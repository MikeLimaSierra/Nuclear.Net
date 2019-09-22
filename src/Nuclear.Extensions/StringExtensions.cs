using System;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="StringExtensions"/> provides extension methods to the type <see cref="String"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class StringExtensions {

        #region StartsWith

        /// <summary>
        /// Determines whether the beginning of <paramref name="_this"/> matches <paramref name="value"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">The <see cref="Char"/> to compare.</param>
        /// <returns>True if <paramref name="_this"/> begins with <paramref name="value"/>, otherwise false.</returns>
        public static Boolean StartsWith(this String _this, Char value) => _this.StartsWith(value.ToString());

        /// <summary>
        /// Determines whether the beginning of <paramref name="_this"/> matches <paramref name="value"/> when compared using <paramref name="comparisonType"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">The <see cref="Char"/> to compare.</param>
        /// <param name="comparisonType">A definition of how strings are compared.</param>
        /// <returns>True if <paramref name="_this"/> begins with <paramref name="value"/>, otherwise false.</returns>
        public static Boolean StartsWith(this String _this, Char value, StringComparison comparisonType) => _this.StartsWith(value.ToString(), comparisonType);

        #endregion

        #region EndsWith

        /// <summary>
        /// Determines whether the end of <paramref name="_this"/> matches <paramref name="value"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">The <see cref="Char"/> to compare.</param>
        /// <returns>True if <paramref name="_this"/> ends with <paramref name="value"/>, otherwise false.</returns>
        public static Boolean EndsWith(this String _this, Char value) => _this.EndsWith(value.ToString());

        /// <summary>
        /// Determines whether the beginning of <paramref name="_this"/> matches <paramref name="value"/> when compared using <paramref name="comparisonType"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">The <see cref="Char"/> to compare.</param>
        /// <param name="comparisonType">A definition of how strings are compared.</param>
        /// <returns>True if <paramref name="_this"/> ends with <paramref name="value"/>, otherwise false.</returns>
        public static Boolean EndsWith(this String _this, Char value, StringComparison comparisonType) => _this.EndsWith(value.ToString(), comparisonType);

        #endregion

        #region Trim

        /// <summary>
        /// Removes one leading and one trailing <see cref="String"/> occurrence from <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">A <see cref="String"/> to remove or null.</param>
        /// <returns>The <see cref="String"/> that remains after one occurrence of <paramref name="value"/> is removed from the start and the end of <paramref name="_this"/>.
        ///		If <paramref name="value"/> is null or an empty string, the method returns the current instance unchanged.</returns>
        public static String TrimOnce(this String _this, String value) => _this.TrimStartOnce(value).TrimEndOnce(value);

        /// <summary>
        /// Removes one leading and one trailing <see cref="Char"/> occurrence from <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">A <see cref="Char"/> to remove.</param>
        /// <returns>The <see cref="String"/> that remains after one occurrence of <paramref name="value"/> is removed from the start and end of <paramref name="_this"/>.</returns>
        public static String TrimOnce(this String _this, Char value) => _this.TrimOnce(value.ToString());

        /// <summary>
        /// Removes one leading <see cref="String"/> occurrence from <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">A <see cref="String"/> to remove or null.</param>
        /// <returns>The <see cref="String"/> that remains after one occurrence of <paramref name="value"/> is removed from the start of <paramref name="_this"/>.
        ///		If <paramref name="value"/> is null or an empty string, the method returns the current instance unchanged.</returns>
        public static String TrimStartOnce(this String _this, String value) {
            if(String.IsNullOrEmpty(value)) {
                return _this;
            }
            if(_this.StartsWith(value)) {
                return _this.Substring(value.Length);
            }
            return _this;
        }

        /// <summary>
        /// Removes one leading <see cref="Char"/> occurrence from <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">A <see cref="Char"/> to remove.</param>
        /// <returns>The <see cref="String"/> that remains after one occurrence of <paramref name="value"/> is removed from the start of <paramref name="_this"/>.</returns>
        public static String TrimStartOnce(this String _this, Char value) => _this.TrimStartOnce(value.ToString());

        /// <summary>
        /// Removes one trailing <see cref="String"/> occurrence from <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">A <see cref="String"/> to remove or null.</param>
        /// <returns>The <see cref="String"/> that remains after one occurrence of <paramref name="value"/> is removed from the end of <paramref name="_this"/>.
        ///		If <paramref name="value"/> is null or an empty string, the method returns the current instance unchanged.</returns>
        public static String TrimEndOnce(this String _this, String value) {
            if(String.IsNullOrEmpty(value)) {
                return _this;
            }
            if(_this.EndsWith(value)) {
                return _this.Substring(0, _this.Length - value.Length);
            }
            return _this;
        }

        /// <summary>
        /// Removes one trailing <see cref="Char"/> occurrence from <paramref name="_this"/>.
        /// </summary>
        /// <param name="_this">The current <see cref="String"/> instance.</param>
        /// <param name="value">A <see cref="Char"/> to remove.</param>
        /// <returns>The <see cref="String"/> that remains after one occurrence of <paramref name="value"/> is removed from the end of <paramref name="_this"/>.</returns>
        public static String TrimEndOnce(this String _this, Char value) => _this.TrimEndOnce(value.ToString());

        #endregion

    }
}
