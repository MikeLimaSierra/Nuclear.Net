using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Double"/> for value.
    /// </summary>
    public class ClampedDouble : ClampedPropertyT<Double>, IClampedDouble {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedDouble"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedDouble(Double value, Double minimum, Double maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
