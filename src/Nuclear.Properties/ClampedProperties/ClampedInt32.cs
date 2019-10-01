using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Int32"/> for value.
    /// </summary>
    public class ClampedInt32 : ClampedPropertyT<Int32>, IClampedInt32 {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedInt32"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedInt32(Int32 value, Int32 minimum, Int32 maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
