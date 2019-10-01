using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="UInt64"/> for value.
    /// </summary>
    public class ClampedUInt64 : ClampedPropertyT<UInt64>, IClampedUInt64 {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedUInt64"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedUInt64(UInt64 value, UInt64 minimum, UInt64 maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
