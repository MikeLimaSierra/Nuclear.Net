using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="UInt32"/> for value.
    /// </summary>
    public class ClampedUInt32 : ClampedPropertyT<UInt32>, IClampedUInt32 {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedUInt32"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedUInt32(UInt32 value, UInt32 minimum, UInt32 maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
