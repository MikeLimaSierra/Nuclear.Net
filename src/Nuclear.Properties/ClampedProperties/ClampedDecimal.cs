using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Decimal"/> for value.
    /// </summary>
    public class ClampedDecimal : ClampedPropertyT<Decimal>, IClampedDecimal {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedDecimal"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedDecimal(Decimal value, Decimal minimum, Decimal maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
