using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Int64"/> for value.
    /// </summary>
    public class ClampedInt64 : ClampedPropertyT<Int64>, IClampedInt64 {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedInt64"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedInt64(Int64 value, Int64 minimum, Int64 maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
