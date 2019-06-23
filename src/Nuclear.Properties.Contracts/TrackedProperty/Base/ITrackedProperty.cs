using System;
using System.ComponentModel;

namespace Nuclear.Properties.TrackedProperty.Base {
    public interface ITrackedProperty<TOwner, TValue> : INotifyPropertyChanged {

        #region events

        /// <summary>
        /// Is raised if Value changes.
        /// </summary>
        event TrackedPropertyChangedEventHandler<TOwner, TValue> PropertyChangeTracked;

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
