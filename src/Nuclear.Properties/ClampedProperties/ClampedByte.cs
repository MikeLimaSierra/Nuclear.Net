using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Byte"/> for value.
    /// </summary>
    public class ClampedByte : ClampedPropertyT<Byte>, IClampedByte {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedByte"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedByte(Byte value, Byte minimum, Byte maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
