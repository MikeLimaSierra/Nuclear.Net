using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Char"/> for value.
    /// </summary>
    public class ClampedChar : ClampedPropertyT<Char>, IClampedChar {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedChar"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedChar(Char value, Char minimum, Char maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
