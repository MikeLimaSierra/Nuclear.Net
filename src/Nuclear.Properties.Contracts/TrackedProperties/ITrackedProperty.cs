using System;
using System.ComponentModel;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Defines a typed property that raises events if a value changes.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public interface ITrackedProperty<TOwner, TValue> : INotifyPropertyChanged {

        #region events

        /// <summary>
        /// Is raised when the value changes.
        /// </summary>
        event ChangeTrackedEventHandler<TOwner, TValue> ChangeTracked;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        TValue Value { get; set; }

        /// <summary>
        /// Gets or sets if the value has been changed.
        /// </summary>
        Boolean HasValueChanged { get; set; }

        #endregion

    }
}
