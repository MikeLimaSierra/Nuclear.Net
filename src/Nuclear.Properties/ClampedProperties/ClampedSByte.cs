using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="SByte"/> for value.
    /// </summary>
    public class ClampedSByte : ClampedPropertyT<SByte>, IClampedSByte {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedSByte"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedSByte(SByte value, SByte minimum, SByte maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
