using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Extensions;

namespace Nuclear.Arguments {

    /// <summary>
    /// Implements the transformation of an <see cref="Array"/> of <see cref="String"/> into a <see cref="List{Argument}"/>.
    /// </summary>
    public class ArgumentCollector {

        #region properties

        /// <summary>
        /// Gets the <see cref="Char"/> that is used to identify switches. Default is '-'.
        /// </summary>
        public Char SwitchIndicator { get; }

        /// <summary>
        /// Gets the <see cref="Char"/> that is used to seperate values. Default is ';'.
        /// </summary>
        public Char ValueSeparator { get; }

        /// <summary>
        /// Gets the collected list of arguments.
        /// </summary>
        public List<Argument> Arguments { get; } = new List<Argument>();

        #endregion

        #region ctors

        /// <summary>
        /// Creates a new instance of <see cref="ArgumentCollector"/> using '-' as switch indicator and ';' as value separator.
        /// </summary>
        public ArgumentCollector() : this('-', ';') { }

        /// <summary>
        /// Creates a new instance of <see cref="ArgumentCollector"/> using custom settings.
        /// </summary>
        /// <param name="switchIndicator">The char to be used to identify switches.</param>
        /// <param name="valueSeparator">The char to be used to separate values.</param>
        public ArgumentCollector(Char switchIndicator, Char valueSeparator) {
            SwitchIndicator = switchIndicator;
            ValueSeparator = valueSeparator;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Transforms a given <see cref="Array"/> of <see cref="String"/> into a <see cref="List{Argument}"/>.
        /// </summary>
        /// <param name="args">The <see cref="Array"/> of <see cref="String"/> to transform.</param>
        public void Collect(String[] args) {
            foreach(String arg in args) {
                if(!String.IsNullOrWhiteSpace(arg)) {
                    CollectInternal(arg.Trim());
                }
            }
        }

        /// <summary>
        /// Tries to get a specific <see cref="Argument"/> by its switch name.
        /// </summary>
        /// <param name="_switch">The switch name.</param>
        /// <param name="arg">The argument instance.</param>
        /// <returns>True if the argument was found, false if not.</returns>
        public Boolean TryGetSwitch(String _switch, out Argument arg) {
            arg = Arguments.Find(argument => argument.SwitchName == _switch);

            return arg != null;
        }

        /// <summary>
        /// Gets the separated values of a given <see cref="Argument"/>.
        ///     If an argument does not contain values, the returned <see cref="List{String}"/> will be empty.
        ///     If an argument contains only one value, the returned <see cref="List{String}"/> will contain one item.
        /// </summary>
        /// <param name="arg">The <see cref="Argument"/> to get values from.</param>
        /// <returns>A <see cref="List{String}"/> of values from the supplied <see cref="Argument"/>.</returns>
        public List<String> GetSeparatedValues(Argument arg) {
            List<String> values = new List<String>();

            if(arg.HasValue) {
                values.AddRange(arg.Value.Split(new Char[] { ValueSeparator }, StringSplitOptions.RemoveEmptyEntries));
            }

            return values;
        }

        #endregion

        #region private methods

        private void CollectInternal(String arg) {
            if(arg.StartsWith(SwitchIndicator)) {
                if(arg.TrimStartOnce(SwitchIndicator).StartsWith(SwitchIndicator)) {
                    // is long switch
                    Arguments.Add(new Argument(arg.TrimStart(SwitchIndicator)));
                } else {
                    // is short switch
                    foreach(Char _switch in arg.TrimStart(SwitchIndicator).ToCharArray()) {
                        if(Arguments.Where(argument => argument.IsSwitch && argument.SwitchName == _switch.ToString()).Count() == 0) {
                            Arguments.Add(new Argument(_switch));
                        }
                    }
                }
            } else {
                // is value

                Argument lastArg;

                if(Arguments.Count == 0 || Arguments[Arguments.Count - 1].HasValue) {
                    Arguments.Add(new Argument());
                }

                lastArg = Arguments[Arguments.Count - 1];
                lastArg.Value = arg;

            }
        }

        #endregion

    }
}
