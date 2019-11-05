using System;

namespace Nuclear.Extensions {

    /// <summary>
    /// An eventhandler delegate to handle <see cref="ValueChangedEventArgs{TValue}"/> event payload.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    public delegate void ValueChangedEventHandler<TValue>(Object sender, ValueChangedEventArgs<TValue> e);

    /// <summary>
    /// An EventArgs type that includes both old and new values of a change.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class ValueChangedEventArgs<TValue> : EventArgs {

        #region properties

        /// <summary>
        /// Gets the old value.
        /// </summary>
        public TValue Old { get; private set; }

        /// <summary>
        /// Gets the new value.
        /// </summary>
        public TValue New { get; private set; }

        /// <summary>
        /// Gets if the value has changed.
        /// </summary>
        public Boolean HasChanged => Old == null ? New != null : (New == null || !Old.Equals(New));

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ValueChangedEventArgs{TValue}"/>
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <example>
        /// <code>
        /// var e = new ValueChangedEventArgs&lt;Int32&gt;(oldValue, newValue);
        /// </code>
        /// </example>
        public ValueChangedEventArgs(TValue oldValue, TValue newValue) {
            Old = oldValue;
            New = newValue;
        }

        #endregion

    }
}
