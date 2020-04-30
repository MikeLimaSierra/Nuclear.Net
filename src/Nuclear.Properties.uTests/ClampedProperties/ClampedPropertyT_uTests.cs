﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedPropertyT_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.Implements<ClampedPropertyT<Int32>, IClampedPropertyT<Int32>>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        #region ctors

        [TestMethod]
        void ConstructorThrows() {

            IClampedPropertyT<Version> prop = null;

            Test.If.Action.ThrowsException(() => prop = new ClampedPropertyT<Version>(null, new Version(1, 1), new Version(1, 3)), out ArgumentNullException argEx);
            Test.IfNot.Object.IsNull(argEx);
            Test.If.Value.IsEqual(argEx.ParamName, "value");
            Test.If.Object.IsNull(prop);

        }

        [TestMethod]
        [TestData(nameof(ConstructorData))]
        void Constructor<TValue>(TValue input1, TValue input2, TValue input3, (TValue value, TValue min, TValue max) expected)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = null;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedPropertyT<TValue>(input1, input2, input3), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Minimum, expected.min);
            Test.If.Value.IsEqual(prop.Maximum, expected.max);
            Test.If.Value.IsEqual(prop.Value, expected.value);
        }

        IEnumerable<Object[]> ConstructorData() {
            return new List<Object[]>() {
                new Object[] { typeof(Version), new Version(1, 2), null, null, (new Version(1, 2), (Version) null, (Version) null) },
                new Object[] { typeof(Version), new Version(1, 2), null, new Version(1, 3), (new Version(1, 2), (Version) null, new Version(1, 3)) },
                new Object[] { typeof(Version), new Version(1, 2), new Version(1, 1), null, (new Version(1, 2), new Version(1, 1), (Version) null) },
                new Object[] { typeof(Version), new Version(1, 2), new Version(1, 1), new Version(1, 3), (new Version(1, 2), new Version(1, 1), new Version(1, 3)) },
                new Object[] { typeof(Version), new Version(1, 2), new Version(1, 3), new Version(1, 1), (new Version(1, 2), new Version(1, 1), new Version(1, 3)) },
                new Object[] { typeof(Version), new Version(1, 0), new Version(1, 1), new Version(1, 3), (new Version(1, 1), new Version(1, 1), new Version(1, 3)) },
            };
        }

        #endregion

        #region properties

        [TestMethod]
        void ValuePropertyNonNullable() {

            DDTestValueProperty((0, -2, 2), 0, (0, -2, 2));
            DDTestValueProperty((0, -2, 2), 1, (1, -2, 2));
            DDTestValueProperty((0, -2, 2), -2, (-2, -2, 2));
            DDTestValueProperty((0, -2, 2), 2, (2, -2, 2));
            DDTestValueProperty((0, -2, 2), -3, (-2, -2, 2));
            DDTestValueProperty((0, -2, 2), 3, (2, -2, 2));

        }

        [TestMethod]
        void ValuePropertyNullable() {

            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(2, 0), (new Version(2, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(1, 0), (new Version(1, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(3, 0), (new Version(3, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(0, 1), (new Version(1, 0), new Version(1, 0), new Version(3, 0)));
            DDTestValueProperty((new Version(2, 0), new Version(1, 0), new Version(3, 0)), new Version(3, 1), (new Version(3, 0), new Version(1, 0), new Version(3, 0)));

        }

        void DDTestValueProperty<TValue>((TValue value, TValue min, TValue max) input, TValue newValue, (TValue value, TValue min, TValue max) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = new ClampedPropertyT<TValue>(input.value, input.min, input.max);

            Test.Note($"Value = '{newValue}'", _file, _method);
            Test.IfNot.Action.ThrowsException(() => prop.Value = newValue, out Exception ex, _file, _method);
            Test.If.Value.IsEqual(prop.Minimum, expected.min, _file, _method);
            Test.If.Value.IsEqual(prop.Maximum, expected.max, _file, _method);
            Test.If.Value.IsEqual(prop.Value, expected.value, _file, _method);

        }

        [TestMethod]
        void MinimumPropertyNonNullable() {

            DDTestMinimumProperty((0, -2, 2), -2, (0, -2, 2));
            DDTestMinimumProperty((0, -2, 2), 0, (0, 0, 2));
            DDTestMinimumProperty((0, -2, 2), 1, (1, 1, 2));
            DDTestMinimumProperty((0, -2, 2), -3, (0, -3, 2));
            DDTestMinimumProperty((0, -2, 2), 3, (2, 2, 2));

        }

        [TestMethod]
        void MinimumPropertyNullable() {

            DDTestMinimumProperty((new Version(2, 0), null, null), new Version(1, 0), (new Version(2, 0), new Version(1, 0), null));
            DDTestMinimumProperty((new Version(2, 0), null, null), new Version(2, 0), (new Version(2, 0), new Version(2, 0), null));
            DDTestMinimumProperty((new Version(2, 0), null, null), new Version(2, 5), (new Version(2, 5), new Version(2, 5), null));
            DDTestMinimumProperty((new Version(2, 0), null, null), null, (new Version(2, 0), null, null));

        }

        void DDTestMinimumProperty<TValue>((TValue value, TValue min, TValue max) input, TValue newMin, (TValue value, TValue min, TValue max) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = new ClampedPropertyT<TValue>(input.value, input.min, input.max);

            Test.Note($"Minimum = '{newMin}'", _file, _method);
            Test.IfNot.Action.ThrowsException(() => prop.Minimum = newMin, out Exception ex, _file, _method);
            Test.If.Value.IsEqual(prop.Minimum, expected.min, _file, _method);
            Test.If.Value.IsEqual(prop.Maximum, expected.max, _file, _method);
            Test.If.Value.IsEqual(prop.Value, expected.value, _file, _method);

        }

        [TestMethod]
        void MaximumPropertyNonNullable() {

            DDTestMaximumProperty((0, -2, 2), 2, (0, -2, 2));
            DDTestMaximumProperty((0, -2, 2), 0, (0, -2, 0));
            DDTestMaximumProperty((0, -2, 2), -1, (-1, -2, -1));
            DDTestMaximumProperty((0, -2, 2), 3, (0, -2, 3));
            DDTestMaximumProperty((0, -2, 2), -3, (-2, -2, -2));

        }

        [TestMethod]
        void MaximumPropertyNullable() {

            DDTestMaximumProperty((new Version(2, 0), null, null), new Version(3, 0), (new Version(2, 0), null, new Version(3, 0)));
            DDTestMaximumProperty((new Version(2, 0), null, null), new Version(2, 0), (new Version(2, 0), null, new Version(2, 0)));
            DDTestMaximumProperty((new Version(2, 0), null, null), new Version(1, 5), (new Version(1, 5), null, new Version(1, 5)));
            DDTestMaximumProperty((new Version(2, 0), null, null), null, (new Version(2, 0), null, null));

        }

        void DDTestMaximumProperty<TValue>((TValue value, TValue min, TValue max) input, TValue newMax, (TValue value, TValue min, TValue max) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = new ClampedPropertyT<TValue>(input.value, input.min, input.max);

            Test.Note($"Maximum = '{newMax}'", _file, _method);
            Test.IfNot.Action.ThrowsException(() => prop.Maximum = newMax, out Exception ex, _file, _method);
            Test.If.Value.IsEqual(prop.Minimum, expected.min, _file, _method);
            Test.If.Value.IsEqual(prop.Maximum, expected.max, _file, _method);
            Test.If.Value.IsEqual(prop.Value, expected.value, _file, _method);

        }

        #endregion

        #region events

        [TestMethod]
        void ValuePropertyChangedEvent() {

            IClampedPropertyT<Int32> prop = new ClampedPropertyT<Int32>(0, -1, 1);

            Test.IfNot.Action.RaisesPropertyChangedEvent(() => prop.Value = 0, prop, out EventData<PropertyChangedEventArgs> eventData);
            DDTestRaisePropertyChangedEvent(prop, () => prop.Value = 1, "Value");

        }

        [TestMethod]
        void MinimumPropertyChangedEvent() {

            IClampedPropertyT<Int32> prop = new ClampedPropertyT<Int32>(0, -1, 1);

            Test.IfNot.Action.RaisesPropertyChangedEvent(() => prop.Minimum = -1, prop, out EventData<PropertyChangedEventArgs> eventData);
            DDTestRaisePropertyChangedEvent(prop, () => prop.Minimum = 0, "Minimum");
            DDTestRaisePropertyChangedEvent(prop, () => prop.Minimum = 1, "Value");

        }

        [TestMethod]
        void MaximumPropertyChangedEvent() {

            IClampedPropertyT<Int32> prop = new ClampedPropertyT<Int32>(0, -1, 1);

            Test.IfNot.Action.RaisesPropertyChangedEvent(() => prop.Maximum = 1, prop, out EventData<PropertyChangedEventArgs> eventData);
            DDTestRaisePropertyChangedEvent(prop, () => prop.Maximum = 0, "Maximum");
            DDTestRaisePropertyChangedEvent(prop, () => prop.Maximum = -1, "Value");

        }

        void DDTestRaisePropertyChangedEvent<TValue>(IClampedPropertyT<TValue> prop, Action action, String propertyName,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null)
            where TValue : IComparable<TValue> {

            Test.Note($"Change property: '{propertyName}'", _file, _method);
            Test.If.Action.RaisesPropertyChangedEvent(action, prop, out EventData<PropertyChangedEventArgs> eventData, _file, _method);
            Test.IfNot.Object.IsNull(eventData.Sender, _file, _method);
            Test.If.Reference.IsEqual(eventData.Sender, prop, _file, _method);
            Test.IfNot.Object.IsNull(eventData.EventArgs, _file, _method);
            Test.If.Value.IsEqual(eventData.EventArgs.PropertyName, propertyName, _file, _method);

        }

        [TestMethod]
        void ValueClampedEvent() {

            IClampedPropertyT<Int32> prop = new ClampedPropertyT<Int32>(0, -1, 5);

            Test.Note("Value = Value");
            Test.IfNot.Action.RaisesEvent(() => prop.Value = 0, prop, "ValueClamped", out EventData<ValueClampedEventArgs<Int32>> eventData);

            Test.Note("Value = in range");
            Test.If.Action.RaisesEvent(() => prop.Value = 1, prop, "ValueClamped", out eventData);
            Test.IfNot.Object.IsNull(eventData.Sender);
            Test.If.Reference.IsEqual(eventData.Sender, prop);
            Test.IfNot.Object.IsNull(eventData.EventArgs);
            Test.If.Value.IsEqual(eventData.EventArgs.Set, 1);
            Test.If.Value.IsEqual(eventData.EventArgs.Old, 0);
            Test.If.Value.IsEqual(eventData.EventArgs.New, 1);
            Test.If.Value.IsFalse(eventData.EventArgs.HasBeenClamped);
            Test.If.Value.IsTrue(eventData.EventArgs.HasChanged);

            Test.Note("Value = out of range");

            Test.If.Action.RaisesEvent(() => prop.Value = 6, prop, "ValueClamped", out eventData);
            Test.IfNot.Object.IsNull(eventData.Sender);
            Test.If.Reference.IsEqual(eventData.Sender, prop);
            Test.IfNot.Object.IsNull(eventData.EventArgs);
            Test.If.Value.IsEqual(eventData.EventArgs.Set, 6);
            Test.If.Value.IsEqual(eventData.EventArgs.Old, 1);
            Test.If.Value.IsEqual(eventData.EventArgs.New, 5);
            Test.If.Value.IsTrue(eventData.EventArgs.HasBeenClamped);
            Test.If.Value.IsTrue(eventData.EventArgs.HasChanged);

        }

        #endregion

    }
}
