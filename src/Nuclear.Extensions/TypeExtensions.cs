using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="TypeExtensions"/> provides extension methods to the type <see cref="Type"/>.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class TypeExtensions {

        /// <summary>
        /// Resolves the friendly name to a given <see cref="Type"/>.
        /// </summary>
        /// <param name="_this">The <see cref="Type"/> to resolve.</param>
        /// <returns>The friendly name.</returns>
        public static String ResolveFriendlyName(this Type _this) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            String name = _this.FullName;

            if(_this.IsArray && name.EndsWith("[]")) {
                name = $"{Type.GetType(name.Substring(0, name.Length - 2)).ResolveFriendlyName()}[]";
            } else if(name.Contains("`")) {
                name = name.Remove(name.IndexOf('`'));
            }
            

            if(_this.GenericTypeArguments.Length > 0) {
                name += $"<{String.Join(", ", _this.GenericTypeArguments.Select(type => type.ResolveFriendlyName()))}>";
            }

            return name;
        }

    }
}
