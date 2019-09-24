using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Int64"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedInt64<TOwner> : TrackedProperty<TOwner, Int64>, ITrackedInt64<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedInt64{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedInt64(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedInt64{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedInt64(TOwner owner, Int64 _default) : base(owner, _default) { }

        #endregion

    }
}
