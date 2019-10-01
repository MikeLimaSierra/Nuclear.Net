using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="DateTime"/> for value.
    /// </summary>
    public class ClampedDateTime : ClampedPropertyT<DateTime>, IClampedDateTime {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedDateTime"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedDateTime(DateTime value, DateTime minimum, DateTime maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
