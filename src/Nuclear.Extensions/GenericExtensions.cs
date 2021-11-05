using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Nuclear.Extensions {

    /// <summary>
    /// The class <see cref="GenericExtensions"/> provides extension methods to any unrestricted generic type.
    /// These methods add either completely new functionality or enhanced functionality based on existing implementations.
    /// </summary>
    public static class GenericExtensions {

        #region Format

        /// <summary>
        /// Gets a <see cref="String"/> representing <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="_this"/>.</typeparam>
        /// <param name="_this">The object in question.</param>
        /// <returns>The formatted <see cref="String"/>.</returns>
        /// <example>
        /// <code>
        /// Console.WriteLine(someObject.Format());
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static String Format<T>(this T _this) {

            if(_this == null) { return "null"; }

            if(_this is String @string) { return $"'{@string}'"; }

            if(_this is Byte b) { return Format($"0x{b:X2}"); }

            if(_this is Type type) { return Format(type.ResolveFriendlyName()); }

            if(_this is DictionaryEntry dictEntry) { return $"[{Format(dictEntry.Key)}] => {Format(dictEntry.Value)}"; }

            Type _type = _this.GetType();

            if(_type.FullName.StartsWith("System.Collections.Generic.KeyValuePair`")) {
                Object key = default;
                Object value = default;

                try {
                    key = _type.GetRuntimeProperty("Key").GetValue(_this);
                    value = _type.GetRuntimeProperty("Value").GetValue(_this);

                } catch { }

                return $"[{Format(key)}] => {Format(value)}";
            }

            if(_type.FullName.StartsWith("System.Tuple`")) {
                List<String> items = new List<String>();

                try {
                    items.Add(Format(_type.GetRuntimeProperty("Item1").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeProperty("Item2").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeProperty("Item3").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeProperty("Item4").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeProperty("Item5").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeProperty("Item6").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeProperty("Item7").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeProperty("Item8").GetValue(_this)));

                } catch { /* They should have included ITuple in netstandard1.0 so it's their bloody fault and they fix it! */ }

                return $"({String.Join(", ", items)})";
            }

            if(_type.FullName.StartsWith("System.ValueTuple`")) {
                List<String> items = new List<String>();

                try {
                    items.Add(Format(_type.GetRuntimeField("Item1").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeField("Item2").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeField("Item3").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeField("Item4").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeField("Item5").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeField("Item6").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeField("Item7").GetValue(_this)));
                    items.Add(Format(_type.GetRuntimeField("Item8").GetValue(_this)));

                } catch { /* They should have included ITuple in netstandard1.0 so it's their bloody fault and they fix it! */ }

                return $"({String.Join(", ", items)})";
            }

            if(_this is IEnumerable enumerable) { return $"[{String.Join(", ", enumerable.Cast<Object>().Select(element => Format(element)))}]"; }

            return Format(String.Format(CultureInfo.InvariantCulture, "{0}", _this));

        }

        /// <summary>
        /// Gets a <see cref="String"/> representing the type of <paramref name="_this"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="_this"/>.</typeparam>
        /// <param name="_this">The object in question.</param>
        /// <returns>The formatted <see cref="String"/>.</returns>
        /// <example>
        /// <code>
        /// Console.WriteLine(someObject.FormatType());
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static String FormatType<T>(this T _this) => _this != null ? _this.GetType().Format() : _this.Format();

        #endregion

        #region IsEqual

        /// <summary>
        /// Determines equality of <paramref name="left"/> and <paramref name="right"/> using the implementations of
        ///     <see cref="IEquatable{T}"/>, <see cref="IComparable{T}"/>, <see cref="IComparable"/> and the default <see cref="IEqualityComparer{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns>True if both objects are equal or null.</returns>
        /// <example>
        /// <code>
        /// if(someObject.IsEqual(someOtherObject)) {
        ///     // ...
        /// }
        /// </code>
        /// </example>
        public static Boolean IsEqual<T>(this T left, T right) {

            if(left == null) {
                return right == null || right.IsEqual<T>(left);
            }

            if(right == null) {
                return false;
            }

            if(left is IEquatable<T> eLeft) {
                try {
                    return eLeft.Equals(right);
                } catch { /* advance to next */ }
            }

            if(left is IComparable<T> cTLeft) {
                try {
                    return cTLeft.IsEqual(right);
                } catch { /* advance to next */ }
            }

            if(left is IComparable cLeft) {
                try {
                    return cLeft.IsEqual(right);
                } catch { /* advance to next */ }
            }

            return EqualityComparer<T>.Default.Equals(left, right);
        }

        #endregion

    }
}
