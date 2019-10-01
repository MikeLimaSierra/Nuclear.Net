using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="SByte"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedSByte<TOwner> : TrackedProperty<TOwner, SByte>, ITrackedSByte<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedSByte{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedSByte(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedSByte{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedSByte(TOwner owner, SByte _default) : base(owner, _default) { }

        #endregion

    }
}
