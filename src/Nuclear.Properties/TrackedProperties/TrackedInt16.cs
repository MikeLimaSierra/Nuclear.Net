using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Int16"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedInt16<TOwner> : TrackedProperty<TOwner, Int16>, ITrackedInt16<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedInt16{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedInt16(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedInt16{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedInt16(TOwner owner, Int16 _default) : base(owner, _default) { }

        #endregion

    }
}
