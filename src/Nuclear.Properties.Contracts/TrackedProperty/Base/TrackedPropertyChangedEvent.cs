using System;

namespace Nuclear.Properties.TrackedProperty.Base {

    public delegate void TrackedPropertyChangedEventHandler<TOwner, TValue>(Object sender, TrackedPropertyChangedEventArgs<TOwner, TValue> e);

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
