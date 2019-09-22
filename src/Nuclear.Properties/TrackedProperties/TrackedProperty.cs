using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nuclear.Properties.TrackedProperties {

    /// <summary>
    /// Implements a typed property that raises events if a value changes.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner required to retrieve the actual sender.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class TrackedProperty<TOwner, TValue> : ITrackedProperty<TOwner, TValue> {

        #region events

        /// <summary>
        /// Is raised if Value changes.
        /// </summary>
        public event TrackedPropertyChangedEventHandler<TOwner, TValue> PropertyChangeTracked;

        /// <summary>
        /// Is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region fields

        private readonly TOwner _owner;

        private TValue _value;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public TValue Value {
            get => _value;
            set {
                TValue old = _value;
                _value = value;
                RaisePropertyChanged(old, _value);
            }
        }

        /// <summary>
        /// Gets or sets if the value has been changed.
        /// </summary>
        public Boolean HasValueChanged { get; set; }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="TrackedProperty{TOwner, TValue}"/>.
        /// </summary>
        /// <param name="owner">The actual owner.</param>
        /// <param name="_default">The default value.</param>
        public TrackedProperty(TOwner owner, TValue _default) {
            _owner = owner;
            _value = _default;
        }

        #endregion

        #region methods

        private void RaisePropertyChanged(TValue old, TValue _new, [CallerMemberName] String propertyName = null) {
            TrackedPropertyChangedEventArgs<TOwner, TValue> e = new TrackedPropertyChangedEventArgs<TOwner, TValue>(_owner, old, _new);

            if(e.HasChanged) {
                HasValueChanged |= e.HasChanged;
                PropertyChangeTracked?.Invoke(this, e);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
