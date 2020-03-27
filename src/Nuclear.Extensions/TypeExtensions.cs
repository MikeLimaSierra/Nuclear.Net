using System;
using System.Linq;

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
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="_this"/> is null.</exception>
        public static String ResolveFriendlyName(this Type _this) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            String name = _this.FullName ?? "";

            if(_this.IsArray && name.EndsWith("[]")) {
                String typeName = name.Substring(0, name.Length - 2);
                Type type = Type.GetType(typeName);

                if(type == null) {
                    name = $"{typeName}[]";

                } else {
                    name = $"{type.ResolveFriendlyName()}[]";
                }

            } else if(name.Contains("`")) {
                name = name.Remove(name.IndexOf('`'));
            }

            if(_this.GenericTypeArguments != null && _this.GenericTypeArguments.Length > 0) {
                name += $"<{String.Join(", ", _this.GenericTypeArguments.Select(type => type != null ? type.ResolveFriendlyName() : "UnkownType"))}>";
            }

            return name;
        }

    }
}
