using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Nuclear.Extensions;
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
        [TestParameters(typeof(String), "c", null, null, "c", null, null)]
        [TestParameters(typeof(String), "c", null, "d", "c", null, "d")]
        [TestParameters(typeof(String), "c", "b", null, "c", "b", null)]
        [TestParameters(typeof(String), "c", "b", "d", "c", "b", "d")]
        [TestParameters(typeof(String), "c", "d", "b", "c", "b", "d")]
        [TestParameters(typeof(String), "a", "b", "d", "b", "b", "d")]
        void Constructor<TValue>(TValue input1, TValue input2, TValue input3, TValue value, TValue min, TValue max)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = null;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedPropertyT<TValue>(input1, input2, input3), out Exception ex);

            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);
            Test.If.Value.IsEqual(prop.Value, value);
        }

        #endregion

        #region properties

        [TestMethod]
        [TestParameters(typeof(Int32), 0, -2, 2, 0, 0, -2, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, 1, 1, -2, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, -2, -2, -2, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, 2, 2, -2, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, -3, -2, -2, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, 3, 2, -2, 2)]
        [TestParameters(typeof(String), "d", "b", "f", "d", "d", "b", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "e", "e", "b", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "b", "b", "b", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "f", "f", "b", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "a", "b", "b", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "g", "f", "b", "f")]
        void ValueProperty<TValue>(TValue input1, TValue input2, TValue input3, TValue newValue, TValue value, TValue min, TValue max)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = new ClampedPropertyT<TValue>(input1, input2, input3);

            Test.IfNot.Action.ThrowsException(() => prop.Value = newValue, out Exception ex);

            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);
            Test.If.Value.IsEqual(prop.Value, value);

        }

        [TestMethod]
        [TestParameters(typeof(Int32), 0, -2, 2, -2, 0, -2, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, 0, 0, 0, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, 1, 1, 1, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, -3, 0, -3, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, 3, 2, 2, 2)]
        [TestParameters(typeof(String), "d", "b", "f", "b", "d", "b", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "d", "d", "d", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "e", "e", "e", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "a", "d", "a", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "g", "f", "f", "f")]
        [TestParameters(typeof(String), "c", null, null, "a", "c", "a", null)]
        [TestParameters(typeof(String), "c", null, null, "c", "c", "c", null)]
        [TestParameters(typeof(String), "c", null, null, "d", "d", "d", null)]
        [TestParameters(typeof(String), "c", null, null, null, "c", null, null)]
        void MinimumProperty<TValue>(TValue input1, TValue input2, TValue input3, TValue newMin, TValue value, TValue min, TValue max)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = new ClampedPropertyT<TValue>(input1, input2, input3);

            Test.IfNot.Action.ThrowsException(() => prop.Minimum = newMin, out Exception ex);

            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);
            Test.If.Value.IsEqual(prop.Value, value);

        }

        [TestMethod]
        [TestParameters(typeof(Int32), 0, -2, 2, 2, 0, -2, 2)]
        [TestParameters(typeof(Int32), 0, -2, 2, 0, 0, -2, 0)]
        [TestParameters(typeof(Int32), 0, -2, 2, -1, -1, -2, -1)]
        [TestParameters(typeof(Int32), 0, -2, 2, 3, 0, -2, 3)]
        [TestParameters(typeof(Int32), 0, -2, 2, -3, -2, -2, -2)]
        [TestParameters(typeof(String), "d", "b", "f", "f", "d", "b", "f")]
        [TestParameters(typeof(String), "d", "b", "f", "d", "d", "b", "d")]
        [TestParameters(typeof(String), "d", "b", "f", "c", "c", "b", "c")]
        [TestParameters(typeof(String), "d", "b", "f", "g", "d", "b", "g")]
        [TestParameters(typeof(String), "d", "b", "f", "a", "b", "b", "b")]
        [TestParameters(typeof(String), "c", null, null, "e", "c", null, "e")]
        [TestParameters(typeof(String), "c", null, null, "c", "c", null, "c")]
        [TestParameters(typeof(String), "c", null, null, "b", "b", null, "b")]
        [TestParameters(typeof(String), "c", null, null, null, "c", null, null)]
        void MaximumProperty<TValue>(TValue input1, TValue input2, TValue input3, TValue newMax, TValue value, TValue min, TValue max)
            where TValue : IComparable<TValue> {

            IClampedPropertyT<TValue> prop = new ClampedPropertyT<TValue>(input1, input2, input3);

            Test.IfNot.Action.ThrowsException(() => prop.Maximum = newMax, out Exception ex);

            Test.If.Value.IsEqual(prop.Minimum, min);
            Test.If.Value.IsEqual(prop.Maximum, max);
            Test.If.Value.IsEqual(prop.Value, value);

        }

        #endregion

        #region events

        [TestMethod]
        [TestData(nameof(RaisePropertyChangedEventData))]
        void RaisePropertyChangedEvent<TValue>(IClampedPropertyT<TValue> prop, TValue v, TValue min, TValue max, Action action, IEnumerable<EventData<PropertyChangedEventArgs>> expected)
            where TValue : IComparable<TValue> {

            prop.Minimum = min;
            prop.Maximum = max;
            prop.Value = v;

            if(expected.Count() > 0) {
                Test.If.Action.RaisesPropertyChangedEvent(action, prop, out EventDataCollection<PropertyChangedEventArgs> eventDatas);

                Test.If.Enumerable.Matches(eventDatas, expected, DynamicEqualityComparer.FromDelegate<EventData<PropertyChangedEventArgs>>(
                    (x, y) => ReferenceEquals(x.Sender, y.Sender) && x.EventArgs.PropertyName == y.EventArgs.PropertyName,
                    (obj) => obj.GetHashCode()));

            } else {
                Test.IfNot.Action.RaisesPropertyChangedEvent(action, prop, out EventDataCollection<PropertyChangedEventArgs> _);
            }

        }

        IEnumerable<Object[]> RaisePropertyChangedEventData() {
            IClampedPropertyT<Int32> intProp = new ClampedPropertyT<Int32>(0, -1, 1);
            IClampedPropertyT<String> stringProp = new ClampedPropertyT<String>("b", "a", "c");

            return new List<Object[]>() {
                new Object[] { typeof(Int32), intProp, 0, -1, 1, new Action(() => intProp.Value = 1) , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(intProp, new PropertyChangedEventArgs("Value")) } },
                new Object[] { typeof(Int32), intProp, 0, -1, 1, new Action(() => intProp.Minimum = -1) , Enumerable.Empty<EventData<PropertyChangedEventArgs>>() },
                new Object[] { typeof(Int32), intProp, 0, -1, 1, new Action(() => intProp.Minimum = 0) , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(intProp, new PropertyChangedEventArgs("Minimum")) } },
                new Object[] { typeof(Int32), intProp, 0, -1, 1, new Action(() => intProp.Minimum = 1) , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(intProp, new PropertyChangedEventArgs("Minimum")), new EventData<PropertyChangedEventArgs>(intProp, new PropertyChangedEventArgs("Value")) } },
                new Object[] { typeof(Int32), intProp, 0, -1, 1, new Action(() => intProp.Maximum = 1) , Enumerable.Empty<EventData<PropertyChangedEventArgs>>() },
                new Object[] { typeof(Int32), intProp, 0, -1, 1, new Action(() => intProp.Maximum = 0) , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(intProp, new PropertyChangedEventArgs("Maximum")) } },
                new Object[] { typeof(Int32), intProp, 0, -1, 1, new Action(() => intProp.Maximum = -1) , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(intProp, new PropertyChangedEventArgs("Maximum")), new EventData<PropertyChangedEventArgs>(intProp, new PropertyChangedEventArgs("Value")) } },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Value = "c") , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Value")) } },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Minimum = "a") , Enumerable.Empty<EventData<PropertyChangedEventArgs>>() },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Minimum = "b") , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Minimum")) } },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Minimum = "c") , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Minimum")), new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Value")) } },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Maximum = "c") , Enumerable.Empty<EventData<PropertyChangedEventArgs>>() },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Maximum = "b") , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Maximum")) } },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Maximum = "a") , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Maximum")), new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Value")) } },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Minimum = null) , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Minimum")) } },
                new Object[] { typeof(String), stringProp, "b", "a", "c", new Action(() => stringProp.Maximum = null) , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Maximum")) } },
                new Object[] { typeof(String), stringProp, null, null, null, new Action(() => stringProp.Minimum = "a") , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Minimum")) } },
                new Object[] { typeof(String), stringProp, null, null, null, new Action(() => stringProp.Maximum = "a") , new List<EventData<PropertyChangedEventArgs>>() { new EventData<PropertyChangedEventArgs>(stringProp, new PropertyChangedEventArgs("Maximum")) } },
            };
        }

        [TestMethod]
        void ValueClampedEvent() {

            IClampedPropertyT<Int32> prop = new ClampedPropertyT<Int32>(0, -1, 5);

            Test.IfNot.Action.RaisesEvent(() => prop.Value = 0, prop, "ValueClamped", out EventData<ValueClampedEventArgs<Int32>> eventData);

            Test.If.Action.RaisesEvent(() => prop.Value = 1, prop, "ValueClamped", out eventData);

            Test.IfNot.Object.IsNull(eventData.Sender);
            Test.If.Reference.IsEqual(eventData.Sender, prop);
            Test.IfNot.Object.IsNull(eventData.EventArgs);
            Test.If.Value.IsEqual(eventData.EventArgs.Set, 1);
            Test.If.Value.IsEqual(eventData.EventArgs.Old, 0);
            Test.If.Value.IsEqual(eventData.EventArgs.New, 1);
            Test.If.Value.IsFalse(eventData.EventArgs.HasBeenClamped);
            Test.If.Value.IsTrue(eventData.EventArgs.HasChanged);

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
