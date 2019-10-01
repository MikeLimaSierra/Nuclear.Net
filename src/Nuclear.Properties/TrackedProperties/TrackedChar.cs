using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Char"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedChar<TOwner> : TrackedProperty<TOwner, Char>, ITrackedChar<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedChar{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedChar(TOwner owner) : base(owner) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedChar{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedChar(TOwner owner, Char _default) : base(owner, _default) { }

        #endregion

    }
}
