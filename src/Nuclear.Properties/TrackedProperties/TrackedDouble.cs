using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Double"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedDouble<TOwner> : TrackedProperty<TOwner, Double>, ITrackedDouble<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedDouble{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedDouble(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedDouble{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedDouble(TOwner owner, Double _default) : base(owner, _default) { }

        #endregion

    }
}
