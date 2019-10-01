using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Version"/> for value.
    /// </summary>
    public class ClampedVersion : ClampedPropertyT<Version>, IClampedVersion {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedVersion"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedVersion(Version value, Version minimum, Version maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
