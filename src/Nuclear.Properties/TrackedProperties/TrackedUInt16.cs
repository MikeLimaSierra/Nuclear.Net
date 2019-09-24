using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="UInt16"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedUInt16<TOwner> : TrackedProperty<TOwner, UInt16>, ITrackedUInt16<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedUInt16{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedUInt16(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedUInt16{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedUInt16(TOwner owner, UInt16 _default) : base(owner, _default) { }

        #endregion

    }
}
