﻿using System;
using Nuclear.Exceptions;

namespace Nuclear.Arguments {

    /// <summary>
    /// Implementation of an argument that can have a payload.
    /// </summary>
    public class Argument {

        #region properties

        /// <summary>
        /// Gets the switch name of the <see cref="Argument"/>.
        /// </summary>
        public String SwitchName { get; } = null;

        /// <summary>
        /// Gets the value of the <see cref="Argument"/>.
        /// </summary>
        public String Value { get; internal set; } = null;

        /// <summary>
        /// Gets if the <see cref="Argument"/> is a switch. An <see cref="Argument"/> without a switch name is not a switch.
        /// </summary>
        public Boolean IsSwitch => !String.IsNullOrWhiteSpace(SwitchName);

        /// <summary>
        /// Gets if the <see cref="Argument"/> has an attached value.
        /// </summary>
        public Boolean HasValue => !String.IsNullOrWhiteSpace(Value);

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of a value type <see cref="Argument"/>.
        /// </summary>
        internal Argument() : this(null) { }

        /// <summary>
        /// Creates a new instance of a short switch type <see cref="Argument"/> with a switch letter.
        /// </summary>
        /// <param name="_switch">The switch letter of the <see cref="Argument"/>.</param>
        /// <exception cref="ArgumentException">Throws if <paramref name="_switch"/> is not a letter.</exception>
        internal Argument(Char _switch) {
            Throw.If.Value.IsFalse(Char.IsLetter(_switch), nameof(_switch), "Single switches can only be letters.");

            SwitchName = _switch.ToString();
        }

        /// <summary>
        /// Creates a new instance of a long switch type <see cref="Argument"/> with a switch name.
        /// </summary>
        /// <param name="_switch">The switch name of the <see cref="Argument"/>.</param>
        internal Argument(String _switch) {
            SwitchName = _switch;
        }

        #endregion

        #region methods

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override String ToString() => String.Format("{0}{1}{2}{3}",
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
                IsSwitch ? (SwitchName.Length > 1 ? "--" : "-") : String.Empty,
                IsSwitch ? SwitchName : String.Empty,
                IsSwitch && HasValue ? " " : String.Empty,
                HasValue ? Value : String.Empty);

        #endregion

    }
}
