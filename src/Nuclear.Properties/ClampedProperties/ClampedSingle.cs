using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="Single"/> for value.
    /// </summary>
    public class ClampedSingle : ClampedPropertyT<Single>, IClampedSingle {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedSingle"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedSingle(Single value, Single minimum, Single maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
