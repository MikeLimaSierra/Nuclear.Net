using System;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Boolean"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedBoolean<TOwner> : ITrackedProperty<TOwner, Boolean> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="String"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedString<TOwner> : ITrackedProperty<TOwner, String> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Char"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedChar<TOwner> : ITrackedProperty<TOwner, Char> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Byte"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedByte<TOwner> : ITrackedProperty<TOwner, Byte> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="SByte"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedSByte<TOwner> : ITrackedProperty<TOwner, SByte> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Int16"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedInt16<TOwner> : ITrackedProperty<TOwner, Int16> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Int32"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedInt32<TOwner> : ITrackedProperty<TOwner, Int32> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Int64"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedInt64<TOwner> : ITrackedProperty<TOwner, Int64> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="UInt16"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedUInt16<TOwner> : ITrackedProperty<TOwner, UInt16> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="UInt32"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedUInt32<TOwner> : ITrackedProperty<TOwner, UInt32> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="UInt64"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedUInt64<TOwner> : ITrackedProperty<TOwner, UInt64> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Single"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedSingle<TOwner> : ITrackedProperty<TOwner, Single> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Double"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedDouble<TOwner> : ITrackedProperty<TOwner, Double> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Decimal"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedDecimal<TOwner> : ITrackedProperty<TOwner, Decimal> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Guid"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedGuid<TOwner> : ITrackedProperty<TOwner, Guid> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="TimeSpan"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedTimeSpan<TOwner> : ITrackedProperty<TOwner, TimeSpan> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="DateTime"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedDateTime<TOwner> : ITrackedProperty<TOwner, DateTime> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="DateTimeOffset"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedDateTimeOffset<TOwner> : ITrackedProperty<TOwner, DateTimeOffset> { }

    /// <summary>
    /// Implementation of <see cref="ITrackedProperty{TOwner, TValue}"/> using <see cref="Version"/> for value.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    public interface ITrackedVersion<TOwner> : ITrackedProperty<TOwner, Version> { }

}
