using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Properties.ClampedProperties {

    /// <summary>
    /// Implements a typed property that clamps a value within a given inclusive range.
    /// </summary>
    /// <typeparam name="TValue">The type of the value, must implement <see cref="IComparable"/>.</typeparam>
    public class ClampedProperty<TValue> : IClampedProperty<TValue>
        where TValue : IComparable {

        #region events

        /// <summary>
        /// Is raised when the value changes.
        /// </summary>
        public event ValueClampedEventHandler<TValue> ValueClamped;

        /// <summary>
        /// Is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region fields

        private TValue _value;

        private TValue _minimum;

        private TValue _maximum;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public TValue Value {
            get => _value;
            set {
                TValue old = _value;
                _value = value.Clamp(_minimum, _maximum);

                if(!ReferenceEquals(old, Value) && old != null && Value != null && old.CompareTo(Value) != 0) {
                    RaisePropertyChanged();
                }

                if(!ReferenceEquals(old, value) && old != null && value != null && old.CompareTo(value) != 0) {
                    RaiseClampedPropertyChanged(value, old, _value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the lower border of the range.
        /// Is considered unrestricted if null.
        /// </summary>
        public TValue Minimum {
            get => _minimum;
            set {
                TValue old = Minimum;
                _minimum = (value != null && Maximum != null && value.CompareTo(Maximum) > 0) ? Maximum : value;

                if(!ReferenceEquals(old, Minimum) && old != null && Minimum != null && old.CompareTo(Minimum) != 0) {
                    RaisePropertyChanged();
                }

                Value = Value;
            }
        }

        /// <summary>
        /// Gets or sets the upper border of the range.
        /// Is considered unrestricted if null.
        /// </summary>
        public TValue Maximum {
            get => _maximum;
            set {
                TValue old = _maximum;
                _maximum = (value != null && Minimum != null && value.CompareTo(Minimum) < 0) ? Minimum : value;

                if(!ReferenceEquals(old, Maximum) && old != null && Maximum != null && old.CompareTo(Maximum) != 0) {
                    RaisePropertyChanged();
                }

                Value = Value;
            }
        }

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ClampedProperty{TValue}"/>.
        /// </summary>
        /// <param name="value">The initial value.</param>
        /// <param name="minimum">The lower border of the range.</param>
        /// <param name="maximum">The upper border of the range.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
        public ClampedProperty(TValue value, TValue minimum, TValue maximum) {
            Throw.If.Null(value, "value");

            if(minimum != null && maximum != null && minimum.CompareTo(maximum) > 0) {
                _minimum = maximum;
                _maximum = minimum;
            } else {
                _minimum = minimum;
                _maximum = maximum;
            }

            Value = value;
        }

        #endregion

        #region methods

        private void RaiseClampedPropertyChanged(TValue setValue, TValue oldValue, TValue newValue) {
            ValueClampedEventArgs<TValue> e = new ValueClampedEventArgs<TValue>(setValue, oldValue, newValue);

            if(e.HasChanged) {
                ValueClamped?.Invoke(this, e);
            }
        }

        private void RaisePropertyChanged([CallerMemberName] String propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

    }
}
