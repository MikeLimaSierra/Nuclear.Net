using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Int32"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedInt32<TOwner> : TrackedProperty<TOwner, Int32>, ITrackedInt32<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedInt32{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedInt32(TOwner owner) : this(owner, 0) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedInt32{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedInt32(TOwner owner, Int32 _default) : base(owner, _default) { }

        #endregion

    }
}
