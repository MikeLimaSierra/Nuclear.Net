using System;
using System.ComponentModel;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Defines a typed property that clamps a value within a given inclusive range.
    /// </summary>
    /// <typeparam name="TValue">The type of the value, must implement <see cref="IComparable{T}"/>.</typeparam>
    public interface IClampedPropertyT<TValue> : INotifyPropertyChanged
        where TValue : IComparable<TValue> {

        #region events

        /// <summary>
        /// Is raised when the value changes.
        /// </summary>
        event ValueClampedEventHandler<TValue> ValueClamped;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        TValue Value { get; set; }

        /// <summary>
        /// Gets or sets the lower border of the range.
        /// Is considered unrestricted if null.
        /// </summary>
        TValue Minimum { get; set; }

        /// <summary>
        /// Gets or sets the upper border of the range.
        /// Is considered unrestricted if null.
        /// </summary>
        TValue Maximum { get; set; }

        #endregion

    }
}
