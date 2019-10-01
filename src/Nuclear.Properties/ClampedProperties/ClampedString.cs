using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="String"/> for value.
    /// </summary>
    public class ClampedString : ClampedPropertyT<String>, IClampedString {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedString"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedString(String value, String minimum, String maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
