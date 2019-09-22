using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="String"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedString<TOwner> : TrackedProperty<TOwner, String>, ITrackedString<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedString{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedString(TOwner owner) : this(owner, String.Empty) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedString{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedString(TOwner owner, String _default) : base(owner, _default) { }

        #endregion

    }
}
