using System;
using System.Collections.Generic;

namespace Nuclear.Arguments {
    public interface IArgumentCollector {

        #region properties

        /// <summary>
        /// Gets the char that is used to identify switches. Default is '-'
        /// </summary>
        Char SwitchIndicator { get; }

        /// <summary>
        /// Gets the char that is used to seperate values. Default is ';'
        /// </summary>
        Char ValueSeparator { get; }

        /// <summary>
        /// Gets the collected list of arguments.
        /// </summary>
        List<IArgument> Arguments { get; }

        #endregion

        #region  methods

        /// <summary>
        /// Transforms a given <see cref="String[]"/> into a <see cref="List{IArgument}"/>.
        /// </summary>
        /// <param name="args">The <see cref="String[]"/> to transform.</param>
        void Collect(String[] args);

        /// <summary>
        /// Tries to get a specific <see cref="IArgument"/> by its switch name.
        /// </summary>
        /// <param name="_switch">The switch name.</param>
        /// <param name="arg">The argument instance.</param>
        /// <returns>True if the argument was found, false if not.</returns>
        Boolean TryGetSwitch(String _switch, out IArgument arg);


        /// <summary>
        /// Gets the separated values of a given <see cref="IArgument"/>.
        ///     If an argument does not contain values, the returned <see cref="List{String}"/> will be empty.
        ///     If an argument contains only one value, the returned <see cref="List{String}"/> will contain one item.
        /// </summary>
        /// <param name="arg">The <see cref="IArgument"/> to get values from.</param>
        /// <returns>A <see cref="List{String}"/> of values from the supplied <see cref="IArgument"/>.</returns>
        List<String> GetSeparatedValues(IArgument arg);

        #endregion
    }
}
