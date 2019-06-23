using System;
using Nuclear.Properties.TrackedProperty.Base;

namespace Nuclear.Properties.TrackedProperty {

    /// <summary>
    /// Implementation of <see cref="TrackedProperty{TOwner, TValue}"/> using <see cref="Decimal"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public class TrackedDecimal<TOwner> : TrackedProperty<TOwner, Decimal>, ITrackedDecimal<TOwner> {

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedDecimal{TOwner}"/>.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public TrackedDecimal(TOwner owner) : this(owner, 0m) { }

        /// <summary>
        /// Creates a new instance of <see cref="TrackedDecimal{TOwner}"/> with a default value.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedDecimal(TOwner owner, Decimal _default) : base(owner, _default) { }

        #endregion

    }
}