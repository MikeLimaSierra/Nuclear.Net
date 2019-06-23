using System;
using Nuclear.Properties.TrackedProperty.Base;

namespace Nuclear.Properties.TrackedProperty {

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Boolean"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedBoolean<TOwner> : ITrackedProperty<TOwner, Boolean> { }
}
