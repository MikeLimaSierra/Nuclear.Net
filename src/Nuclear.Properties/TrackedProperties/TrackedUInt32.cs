using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="UInt32"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedUInt32<TOwner> : TrackedProperty<TOwner, UInt32>, ITrackedUInt32<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedUInt32{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedUInt32(TOwner owner) : this(owner, 0u) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedUInt32{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedUInt32(TOwner owner, UInt32 _default) : base(owner, _default) { }

        #endregion

    }
}
