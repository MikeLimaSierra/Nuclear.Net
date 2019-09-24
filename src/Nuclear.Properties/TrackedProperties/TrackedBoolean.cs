using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Boolean"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedBoolean<TOwner> : TrackedProperty<TOwner, Boolean>, ITrackedBoolean<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedBoolean{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedBoolean(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedBoolean{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedBoolean(TOwner owner, Boolean _default) : base(owner, _default) { }

        #endregion

    }
}
