using System;
using System.ComponentModel;
using Nuclear.Extensions;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// An eventhandler delegate to handle <see cref="ChangeTrackedEventArgs{TOwner, TValue}"/> event payload.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="sender">The sender of the event (owner).</param>
    /// <param name="e">The event arguments.</param>
    public delegate void ChangeTrackedEventHandler<TOwner, TValue>(Object sender, ChangeTrackedEventArgs<TOwner, TValue> e);

    /// <summary>
    /// An EventArgs type similar to <see cref="PropertyChangedEventArgs"/> that includes the old value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class ChangeTrackedEventArgs<TOwner, TValue> : ValueChangedEventArgs<TValue> {

        #region properties

        /// <summary>
        /// Gets the actual owner.
        /// </summary>
        public TOwner Owner { get; private set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ChangeTrackedEventArgs{TOwner, TValue}"/>
        /// </summary>
        /// <param name="owner">The actual owner.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <example>
        /// <code>
        /// var e = new ChangeTrackedEventArgs&lt;MyClass, Int32&gt;(owner, oldValue, newValue);
        /// </code>
        /// </example>
        public ChangeTrackedEventArgs(TOwner owner, TValue oldValue, TValue newValue)
            : base(oldValue, newValue) {

            Owner = owner;
        }

        #endregion

    }
}
