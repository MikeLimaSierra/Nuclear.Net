using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Boolean"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedUInt64<TOwner> : TrackedProperty<TOwner, UInt64>, ITrackedUInt64<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedUInt64{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedUInt64(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedUInt64{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedUInt64(TOwner owner, UInt64 _default) : base(owner, _default) { }

        #endregion

    }
}
