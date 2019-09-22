using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Single"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedSingle<TOwner> : TrackedProperty<TOwner, Single>, ITrackedSingle<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedSingle{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedSingle(TOwner owner) : this(owner, 0f) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedSingle{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedSingle(TOwner owner, Single _default) : base(owner, _default) { }

        #endregion

    }
}
