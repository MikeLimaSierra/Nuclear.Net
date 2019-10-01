using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="UInt16"/> for value.
    /// </summary>
    public class ClampedUInt16 : ClampedPropertyT<UInt16>, IClampedUInt16 {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedUInt16"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedUInt16(UInt16 value, UInt16 minimum, UInt16 maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
