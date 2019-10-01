using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="DateTime"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedDateTime<TOwner> : TrackedProperty<TOwner, DateTime>, ITrackedDateTime<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedDateTime{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedDateTime(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedDateTime{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedDateTime(TOwner owner, DateTime _default) : base(owner, _default) { }

        #endregion

    }
}