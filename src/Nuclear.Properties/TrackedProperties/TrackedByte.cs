using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Byte"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedByte<TOwner> : TrackedProperty<TOwner, Byte>, ITrackedByte<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedByte{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedByte(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedByte{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedByte(TOwner owner, Byte _default) : base(owner, _default) { }

        #endregion

    }
}
