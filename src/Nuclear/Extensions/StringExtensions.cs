using System;
using System.Globalization;

namespace Nuclear.Extensions {
    public static class StringExtensions {

        #region StartsWith

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified char.
        /// </summary>
        /// <param name="value">The char to compare.</param>
        /// <returns>true if this instance begins with value; otherwise, false.</returns>
        public static Boolean StartsWith(this String _this, Char value) => _this.StartsWith(value.ToString());

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified char when compared using the specified comparison option.
        /// </summary>
        /// <param name="value">The char to compare.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and value are compared.</param>
        /// <returns>true if this instance begins with value; otherwise, false.</returns>
        public static Boolean StartsWith(this String _this, Char value, StringComparison comparisonType) => _this.StartsWith(value.ToString(), comparisonType);

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified char when compared using the specified culture.
        /// </summary>
        /// <param name="value">The char to compare.</param>
        /// <param name="ignoreCase">true to ignore case during the comparison; otherwise, false.</param>
        /// <param name="culture">Cultural information that determines how this string and value are compared. If culture is null, the current culture is used.</param>
        /// <returns>true if this instance begins with value; otherwise, false.</returns>
        public static Boolean StartsWith(this String _this, Char value, Boolean ignoreCase, CultureInfo culture) => _this.StartsWith(value.ToString(), ignoreCase, culture);

        #endregion

        #region EndsWith

        /// <summary>
        /// Determines whether the end of this string instance matches the specified char.
        /// </summary>
        /// <param name="value">The char to compare.</param>
        /// <returns>true if value matches the end of this instance; otherwise, false.</returns>
        public static Boolean EndsWith(this String _this, Char value) => _this.EndsWith(value.ToString());

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified string when compared using the specified comparison option.
        /// </summary>
        /// <param name="value">The char to compare.</param>
        /// <param name="comparisonType">One of the enumeration values that determines how this string and value are compared.</param>
        /// <returns>true if value matches the end of this instance; otherwise, false.</returns>
        public static Boolean EndsWith(this String _this, Char value, StringComparison comparisonType) => _this.EndsWith(value.ToString(), comparisonType);

        /// <summary>
        /// Determines whether the end of this string instance matches the specified char when compared using the specified culture.
        /// </summary>
        /// <param name="value">The char to compare.</param>
        /// <param name="ignoreCase">true to ignore case during the comparison; otherwise, false.</param>
        /// <param name="culture">Cultural information that determines how this string and value are compared. If culture is null, the current culture is used.</param>
        /// <returns>true if value matches the end of this instance; otherwise, false.</returns>
        public static Boolean EndsWith(this String _this, Char value, Boolean ignoreCase, CultureInfo culture) => _this.EndsWith(value.ToString(), ignoreCase, culture);

        #endregion

        #region Trim

        /// <summary>
        /// Removes one leading and one trailing occurrence of a string from the current System.String object.
        /// </summary>
        /// <param name="value">A string to remove or null.</param>
        /// <returns>The string that remains after one occurrence of the parameter value is removed from the start and the end of the current string.
        ///		If value is null or an empty string, the method returns the current instance unchanged.</returns>
        public static String TrimOnce(this String _this, String value) => _this.TrimStartOnce(value).TrimEndOnce(value);

        /// <summary>
        /// Removes one leading and one trailing occurrence of a char from the current System.String object.
        /// </summary>
        /// <param name="value">A char to remove.</param>
        /// <returns>The string that remains after one occurrence of the parameter value is removed from the start and end of the current string.</returns>
        public static String TrimOnce(this String _this, Char value) => _this.TrimOnce(value.ToString());

        /// <summary>
        /// Removes one leading occurrence of a string from the current System.String object.
        /// </summary>
        /// <param name="value">A string to remove or null.</param>
        /// <returns>The string that remains after one occurrence of the parameter value is removed from the start of the current string.
        ///		If value is null or an empty string, the method returns the current instance unchanged.</returns>
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
        /// Removes one leading occurrence of a char from the current System.String object.
        /// </summary>
        /// <param name="value">A char to remove.</param>
        /// <returns>The string that remains after one occurrence of the parameter value is removed from the start of the current string.</returns>
        public static String TrimStartOnce(this String _this, Char value) => _this.TrimStartOnce(value.ToString());

        /// <summary>
        /// Removes one trailing occurrence of a string from the current System.String object.
        /// </summary>
        /// <param name="value">A string to remove or null.</param>
        /// <returns>The string that remains after one occurrence of the parameter value is removed from the end of the current string.
        ///		If value is null or an empty string, the method returns the current instance unchanged.</returns>
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
        /// Removes one trailing occurrence of a char from the current System.String object.
        /// </summary>
        /// <param name="value">A char to remove.</param>
        /// <returns>The string that remains after one occurrence of the parameter value is removed from the end of the current string.</returns>
        public static String TrimEndOnce(this String _this, Char value) => _this.TrimEndOnce(value.ToString());

        #endregion

        #region misc

        /// <summary>
        /// Modifies a given string to be of the given length. Excess will be cut off.
        /// </summary>
        /// <param name="length">The desired length.</param>
        /// <param name="filler">The char to be used for filling the tail.</param>
        /// <returns>A string of the given length.</returns>
        public static String ToLength(this String _this, Int32 length, Char filler = ' ') {
            _this = _this ?? String.Empty;

            while(_this.Length != length) {
                if(_this.Length < length) {
                    _this += filler;
                } else {
                    _this = _this.Substring(0, length);
                }
            }

            return _this;
        }

        #endregion

    }
}
