using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedPropertyTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.TypeImplements<ClampedProperty<Int32>, IClampedProperty<Int32>>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        #region ctors

        [TestMethod]
        void TestConstructorNonNullable() {

            DDTestConstructor((1, 3, -3), (1, -3, 3));
            DDTestConstructor((1, -2, 2), (1, -2, 2));
            DDTestConstructor((1, 2, 4), (2, 2, 4));

        }

        [TestMethod]
        void TestConstructorNullable() {

            IClampedProperty<Version> prop = null;

            Test.Note("Test ctor with 'null', [1.1; 1.3]");
            Test.If.ThrowsException(() => prop = new ClampedProperty<Version>(null, new Version(1, 1), new Version(1, 3)), out ArgumentNullException argEx);
            Test.IfNot.Null(argEx);
            Test.If.ValuesEqual(argEx.ParamName, "value");
            Test.If.Null(prop);

            DDTestConstructor((new Version(1, 2), null, null), (new Version(1, 2), null, null));
            DDTestConstructor((new Version(1, 2), null, new Version(1, 3)), (new Version(1, 2), null, new Version(1, 3)));
            DDTestConstructor((new Version(1, 2), new Version(1, 1), null), (new Version(1, 2), new Version(1, 1), null));
            DDTestConstructor((new Version(1, 2), new Version(1, 1), new Version(1, 3)), (new Version(1, 2), new Version(1, 1), new Version(1, 3)));
            DDTestConstructor((new Version(1, 2), new Version(1, 3), new Version(1, 1)), (new Version(1, 2), new Version(1, 1), new Version(1, 3)));
            DDTestConstructor((new Version(1, 0), new Version(1, 1), new Version(1, 3)), (new Version(1, 1), new Version(1, 1), new Version(1, 3)));

        }

        void DDTestConstructor<TValue>((TValue value, TValue min, TValue max) input, (TValue value, TValue min, TValue max) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable {

            IClampedProperty<TValue> prop = null;

            Test.Note($"Test ctor with '{input.value}', [{input.min}; {input.max}]", _file, _method);
            Test.IfNot.ThrowsException(() => prop = new ClampedProperty<TValue>(input.value, input.min, input.max), out Exception ex, _file, _method);
            Test.IfNot.Null(prop, _file, _method);
            Test.If.ValuesEqual(prop.Minimum, expected.min, _file, _method);
            Test.If.ValuesEqual(prop.Maximum, expected.max, _file, _method);
            Test.If.ValuesEqual(prop.Value, expected.value, _file, _method);
        }

        #endregion

        #region properties

        [TestMethod]
        void TestValuePropertyNonNullable() {

            DDTestValueProperty((0, -2, 2), 0, (0, -2, 2));
            DDTestValueProperty((0, -2, 2), 1, (1, -2, 2));
            DDTestValueProperty((0, -2, 2), -2, (-2, -2, 2));
            DDTestValueProperty((0, -2, 2), 2, (2, -2, 2));
            DDTestValueProperty((0, -2, 2), -3, (-2, -2, 2));
            DDTestValueProperty((0, -2, 2), 3, (2, -2, 2));

        }

        [TestMethod]
        void TestValuePropertyNullable() {

            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(2, 0), (new Version(2, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(1, 0), (new Version(1, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(3, 0), (new Version(3, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(0, 1), (new Version(1, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(3, 1), (new Version(3, 0), new Version(1, 0), new Version(3, 0)));

        }

        void DDTestValueProperty<TValue>((TValue value, TValue min, TValue max) input, TValue newValue, (TValue value, TValue min, TValue max) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable {

            IClampedProperty<TValue> prop = new ClampedProperty<TValue>(input.value, input.min, input.max);

            Test.Note($"Value = '{newValue}'", _file, _method);
            Test.IfNot.ThrowsException(() => prop.Value = newValue, out Exception ex, _file, _method);
            Test.If.ValuesEqual(prop.Minimum, expected.min, _file, _method);
            Test.If.ValuesEqual(prop.Maximum, expected.max, _file, _method);
            Test.If.ValuesEqual(prop.Value, expected.value, _file, _method);

        }

        [TestMethod]
        void TestMinimumPropertyNonNullable() {

            DDTestMinimumProperty((0, -2, 2), -2, (0, -2, 2));
            DDTestMinimumProperty((0, -2, 2), 0, (0, 0, 2));
            DDTestMinimumProperty((0, -2, 2), 1, (1, 1, 2));
            DDTestMinimumProperty((0, -2, 2), -3, (0, -3, 2));
            DDTestMinimumProperty((0, -2, 2), 3, (2, 2, 2));

        }

        [TestMethod]
        void TestMinimumPropertyNullable() {

            DDTestMinimumProperty((new Version(2, 0), null, null), new Version(1, 0), (new Version(2, 0), new Version(1, 0), null));
            DDTestMinimumProperty((new Version(2, 0), null, null), new Version(2, 0), (new Version(2, 0), new Version(2, 0), null));
            DDTestMinimumProperty((new Version(2, 0), null, null), new Version(2, 5), (new Version(2, 5), new Version(2, 5), null));
            DDTestMinimumProperty((new Version(2, 0), null, null), null, (new Version(2, 0), null, null));

        }

        void DDTestMinimumProperty<TValue>((TValue value, TValue min, TValue max) input, TValue newMin, (TValue value, TValue min, TValue max) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable {

            IClampedProperty<TValue> prop = new ClampedProperty<TValue>(input.value, input.min, input.max);

            Test.Note($"Minimum = '{newMin}'", _file, _method);
            Test.IfNot.ThrowsException(() => prop.Minimum = newMin, out Exception ex, _file, _method);
            Test.If.ValuesEqual(prop.Minimum, expected.min, _file, _method);
            Test.If.ValuesEqual(prop.Maximum, expected.max, _file, _method);
            Test.If.ValuesEqual(prop.Value, expected.value, _file, _method);

        }

        [TestMethod]
        void TestMaximumPropertyNonNullable() {

            DDTestMaximumProperty((0, -2, 2), 2, (0, -2, 2));
            DDTestMaximumProperty((0, -2, 2), 0, (0, -2, 0));
            DDTestMaximumProperty((0, -2, 2), -1, (-1, -2, -1));
            DDTestMaximumProperty((0, -2, 2), 3, (0, -2, 3));
            DDTestMaximumProperty((0, -2, 2), -3, (-2, -2, -2));

        }

        [TestMethod]
        void TestMaximumPropertyNullable() {

            DDTestMaximumProperty((new Version(2, 0), null, null), new Version(3, 0), (new Version(2, 0), null, new Version(3, 0)));
            DDTestMaximumProperty((new Version(2, 0), null, null), new Version(2, 0), (new Version(2, 0), null, new Version(2, 0)));
            DDTestMaximumProperty((new Version(2, 0), null, null), new Version(1, 5), (new Version(1, 5), null, new Version(1, 5)));
            DDTestMaximumProperty((new Version(2, 0), null, null), null, (new Version(2, 0), null, null));

        }

        void DDTestMaximumProperty<TValue>((TValue value, TValue min, TValue max) input, TValue newMax, (TValue value, TValue min, TValue max) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable {

            IClampedProperty<TValue> prop = new ClampedProperty<TValue>(input.value, input.min, input.max);

            Test.Note($"Maximum = '{newMax}'", _file, _method);
            Test.IfNot.ThrowsException(() => prop.Maximum = newMax, out Exception ex, _file, _method);
            Test.If.ValuesEqual(prop.Minimum, expected.min, _file, _method);
            Test.If.ValuesEqual(prop.Maximum, expected.max, _file, _method);
            Test.If.ValuesEqual(prop.Value, expected.value, _file, _method);

        }

        #endregion

        #region events

        [TestMethod]
        void TestValuePropertyChangedEvent() {

            IClampedProperty<Int32> prop = new ClampedProperty<Int32>(0, -1, 1);

            Test.IfNot.RaisesPropertyChangedEvent(prop, () => prop.Value = 0, out Object sender, out PropertyChangedEventArgs e);
            DDTestRaisePropertyChangedEvent(prop, () => prop.Value = 1, "Value");

        }

        [TestMethod]
        void TestMinimumPropertyChangedEvent() {

            IClampedProperty<Int32> prop = new ClampedProperty<Int32>(0, -1, 1);

            Test.IfNot.RaisesPropertyChangedEvent(prop, () => prop.Minimum = -1, out Object sender, out PropertyChangedEventArgs e);
            DDTestRaisePropertyChangedEvent(prop, () => prop.Minimum = 0, "Minimum");
            DDTestRaisePropertyChangedEvent(prop, () => prop.Minimum = 1, "Value");

        }

        [TestMethod]
        void TestMaximumPropertyChangedEvent() {

            IClampedProperty<Int32> prop = new ClampedProperty<Int32>(0, -1, 1);

            Test.IfNot.RaisesPropertyChangedEvent(prop, () => prop.Maximum = 1, out Object sender, out PropertyChangedEventArgs e);
            DDTestRaisePropertyChangedEvent(prop, () => prop.Maximum = 0, "Maximum");
            DDTestRaisePropertyChangedEvent(prop, () => prop.Maximum = -1, "Value");

        }

        void DDTestRaisePropertyChangedEvent<TValue>(IClampedProperty<TValue> prop, Action action, String propertyName,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable {

            Test.Note($"Change property: '{propertyName}'", _file, _method);
            Test.If.RaisesPropertyChangedEvent(prop, action, out Object sender, out PropertyChangedEventArgs e, _file, _method);
            Test.IfNot.Null(sender, _file, _method);
            Test.If.ReferencesEqual(sender, prop, _file, _method);
            Test.IfNot.Null(e, _file, _method);
            Test.If.ValuesEqual(e.PropertyName, propertyName, _file, _method);

        }

        [TestMethod]
        void TestValueClampedEvent() {

            IClampedProperty<Int32> prop = new ClampedProperty<Int32>(0, -1, 5);

            Test.Note("Value = Value");
            Test.IfNot.RaisesEvent(prop, "ValueClamped", () => prop.Value = 0, out Object sender, out PropertyChangedEventArgs e);

            Test.Note("Value = in range");
            Test.IfNot.RaisesEvent(prop, "ValueClamped", () => prop.Value = 1, out sender, out e);

            Test.Note("Value = out of range");

            Test.If.RaisesEvent(prop, "ValueClamped", () => prop.Value = 6, out sender, out ValueClampedEventArgs<Int32> ve);
            Test.IfNot.Null(sender);
            Test.If.ReferencesEqual(sender, prop);
            Test.IfNot.Null(ve);
            Test.If.ValuesEqual(ve.Set, 6);
            Test.If.ValuesEqual(ve.Old, 0);
            Test.If.ValuesEqual(ve.New, 5);

        }

        #endregion

    }
}
