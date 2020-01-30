using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuclear.Exceptions;

namespace Nuclear.Extensions {
public static    class TypeExtensions {

        public static String ResolveFriendlyName(this Type _this) {
            Throw.If.Object.IsNull(_this, nameof(_this));

            String name = $"{_this.Namespace}.{_this.Name}";

            if(name.Contains("`")) { name = name.Remove(name.IndexOf('`')); }

            if(_this.GenericTypeArguments.Length > 0) {
                name += $"<{String.Join(", ", _this.GenericTypeArguments.Select(type => type.ResolveFriendlyName()))}>";
            }

            return name;
        }

    }
}
