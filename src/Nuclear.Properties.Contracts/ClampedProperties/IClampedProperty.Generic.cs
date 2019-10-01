using System;

namespace Nuclear.Properties.ClampedProperties {

    #region IComparable<T>

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="String"/> for value.
    /// </summary>
    public interface IClampedString : IClampedPropertyT<String> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Char"/> for value.
    /// </summary>
    public interface IClampedChar : IClampedPropertyT<Char> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Byte"/> for value.
    /// </summary>
    public interface IClampedByte : IClampedPropertyT<Byte> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="SByte"/> for value.
    /// </summary>
    public interface IClampedSByte : IClampedPropertyT<SByte> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Int16"/> for value.
    /// </summary>
    public interface IClampedInt16 : IClampedPropertyT<Int16> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Int32"/> for value.
    /// </summary>
    public interface IClampedInt32 : IClampedPropertyT<Int32> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Int64"/> for value.
    /// </summary>
    public interface IClampedInt64 : IClampedPropertyT<Int64> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="UInt16"/> for value.
    /// </summary>
    public interface IClampedUInt16 : IClampedPropertyT<UInt16> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="UInt32"/> for value.
    /// </summary>
    public interface IClampedUInt32 : IClampedPropertyT<UInt32> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="UInt64"/> for value.
    /// </summary>
    public interface IClampedUInt64 : IClampedPropertyT<UInt64> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Single"/> for value.
    /// </summary>
    public interface IClampedSingle : IClampedPropertyT<Single> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Double"/> for value.
    /// </summary>
    public interface IClampedDouble : IClampedPropertyT<Double> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Decimal"/> for value.
    /// </summary>
    public interface IClampedDecimal : IClampedPropertyT<Decimal> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="TimeSpan"/> for value.
    /// </summary>
    public interface IClampedTimeSpan : IClampedPropertyT<TimeSpan> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="DateTime"/> for value.
    /// </summary>
    public interface IClampedDateTime : IClampedPropertyT<DateTime> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Version"/> for value.
    /// </summary>
    public interface IClampedVersion : IClampedPropertyT<Version> { }

    #endregion

    #region IComparable

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1> : IClampedProperty<Tuple<T1>> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1, T2}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1, T2> : IClampedProperty<Tuple<T1, T2>> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1, T2, T3}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1, T2, T3> : IClampedProperty<Tuple<T1, T2, T3>> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1, T2, T3, T4> : IClampedProperty<Tuple<T1, T2, T3, T4>> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1, T2, T3, T4, T5> : IClampedProperty<Tuple<T1, T2, T3, T4, T5>> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5, T6}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    /// <typeparam name="T6">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1, T2, T3, T4, T5, T6> : IClampedProperty<Tuple<T1, T2, T3, T4, T5, T6>> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    /// <typeparam name="T6">Tuple type parameter.</typeparam>
    /// <typeparam name="T7">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1, T2, T3, T4, T5, T6, T7> : IClampedProperty<Tuple<T1, T2, T3, T4, T5, T6, T7>> { }

    /// <summary>
    /// Implementation of <see cref="IClampedPropertyT{TValue}"/> using <see cref="Tuple{T1, T2, T3, T4, T5, T6, T7, TRest}"/> for value.
    /// </summary>
    /// <typeparam name="T1">Tuple type parameter.</typeparam>
    /// <typeparam name="T2">Tuple type parameter.</typeparam>
    /// <typeparam name="T3">Tuple type parameter.</typeparam>
    /// <typeparam name="T4">Tuple type parameter.</typeparam>
    /// <typeparam name="T5">Tuple type parameter.</typeparam>
    /// <typeparam name="T6">Tuple type parameter.</typeparam>
    /// <typeparam name="T7">Tuple type parameter.</typeparam>
    /// <typeparam name="TRest">Tuple type parameter.</typeparam>
    public interface IClampedTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IClampedProperty<Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>> { }

    #endregion

}
