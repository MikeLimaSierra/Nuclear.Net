using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="TimeSpan"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedTimeSpan<TOwner> : TrackedProperty<TOwner, TimeSpan>, ITrackedTimeSpan<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedTimeSpan{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedTimeSpan(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedTimeSpan{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedTimeSpan(TOwner owner, TimeSpan _default) : base(owner, _default) { }

        #endregion

    }
}