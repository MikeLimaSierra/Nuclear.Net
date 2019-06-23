using System;

namespace Nuclear.Arguments {
    public interface IArgument {

        #region properties

        /// <summary>
        /// Gets the switch name of the <see cref="IArgument"/>.
        /// </summary>
        String SwitchName { get; }

        /// <summary>
        /// Gets or sets the value of the <see cref="IArgument"/>.
        /// </summary>
        String Value { get; set; }

        /// <summary>
        /// Gets if the <see cref="IArgument"/> is a switch. An <see cref="IArgument"/> without a switch name is not a switch.
        /// </summary>
        Boolean IsSwitch { get; }

        /// <summary>
        /// Gets if the <see cref="IArgument"/> has an attached value.
        /// </summary>
        Boolean HasValue { get; }

        #endregion

    }
}
