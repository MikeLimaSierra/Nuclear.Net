using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Int16"/> for value.
    /// </summary>
    public class ClampedInt16 : ClampedPropertyT<Int16>, IClampedInt16 {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedInt16"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedInt16(Int16 value, Int16 minimum, Int16 maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
