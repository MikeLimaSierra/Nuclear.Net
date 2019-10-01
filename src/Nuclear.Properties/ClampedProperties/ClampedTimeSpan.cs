using System;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implementation of <see cref="ClampedPropertyT{TValue}"/> using <see cref="TimeSpan"/> for value.
    /// </summary>
    public class ClampedTimeSpan : ClampedPropertyT<TimeSpan>, IClampedTimeSpan {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedTimeSpan"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        public ClampedTimeSpan(TimeSpan value, TimeSpan minimum, TimeSpan maximum) : base(value, minimum, maximum) { }

        #endregion

    }

}
