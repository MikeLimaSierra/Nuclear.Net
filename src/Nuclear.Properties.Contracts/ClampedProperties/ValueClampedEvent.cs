using System;
using Nuclear.Extensions;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// An eventhandler delegate to handle <see cref="ValueClampedEventArgs{TValue}"/> event payload.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    public delegate void ValueClampedEventHandler<TValue>(Object sender, ValueClampedEventArgs<TValue> e);

    /// <summary>
    /// An EventArgs type that includes both old and new values of a change and if the value was clamped to range because it was out of bounds.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class ValueClampedEventArgs<TValue> : ValueChangedEventArgs<TValue> {

        #region properties

        /// <summary>
        /// Gets the value that was tried to set.
        /// </summary>
        public TValue Set { get; private set; }

        /// <summary>
        /// Gets if the value was clamped after setting because it was out of bounds.
        /// </summary>
        public Boolean HasBeenClamped => Set != null && New != null && !Set.Equals(New);

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ValueClampedEventArgs{TValue}"/>
        /// </summary>
        /// <param name="setValue">The value that was tried to set.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public ValueClampedEventArgs(TValue setValue, TValue oldValue, TValue newValue)
            : base(oldValue, newValue) {

            Set = setValue;
        }

        #endregion

    }
}
