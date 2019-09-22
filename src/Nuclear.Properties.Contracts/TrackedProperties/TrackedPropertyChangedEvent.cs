using System;
using System.ComponentModel;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// An eventhandler delegate to handle <see cref="TrackedPropertyChangedEventArgs{TOwner, TValue}"/> event payload.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="sender">The sender of the event (owner).</param>
    /// <param name="e">The event arguments.</param>
    public delegate void TrackedPropertyChangedEventHandler<TOwner, TValue>(Object sender, TrackedPropertyChangedEventArgs<TOwner, TValue> e);

    /// <summary>
    /// An EventArgs type similar to <see cref="PropertyChangedEventArgs"/> that includes the old value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class TrackedPropertyChangedEventArgs<TOwner, TValue> : EventArgs {

        #region properties

        /// <summary>
        /// Gets the actual owner.
        /// </summary>
        public TOwner Owner { get; private set; }

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
        public Boolean HasChanged => Old == null ? New != null : !Old.Equals(New);

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedPropertyChangedEventArgs{TOwner, TValue}"/>
        /// </summary>
        /// <param name="owner">The actual owner.</param>
        /// <param name="old">The old value.</param>
        /// <param name="_new">The new value.</param>
        public TrackedPropertyChangedEventArgs(TOwner owner, TValue old, TValue _new) {
            Owner = owner;
            Old = old;
            New = _new;
        }

        #endregion

    }
}
