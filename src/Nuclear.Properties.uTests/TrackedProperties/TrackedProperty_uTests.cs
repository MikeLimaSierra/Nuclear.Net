using System;
using System.Collections.Generic;
using System.ComponentModel;

using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedProperty_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.Implements<TrackedProperty<Object, Int32>, ITrackedProperty<Object, Int32>>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        #region ctors

        [TestMethod]
        [TestData(nameof(DefaultConstructorData))]
        void DefaultConstructor(Object input, Int32 value, Boolean hasChanged) {

            ITrackedProperty<Object, Int32> prop = null;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedProperty<Object, Int32>(input), out Exception ex);

            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.HasValueChanged, hasChanged);

        }

        IEnumerable<Object[]> DefaultConstructorData() {
            return new List<Object[]>() {
                new Object[] { null, 0, false },
                new Object[] { new Object(), 0, false },
            };
        }

        [TestMethod]
        [TestData(nameof(FullConstructorData))]
        void FullConstructor(Object input1, Int32 input2, Int32 value, Boolean hasChanged) {

            ITrackedProperty<Object, Int32> prop = null;

            Test.IfNot.Action.ThrowsException(() => prop = new TrackedProperty<Object, Int32>(input1, input2), out Exception ex);

            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.HasValueChanged, hasChanged);

        }

        IEnumerable<Object[]> FullConstructorData() {
            return new List<Object[]>() {
                new Object[] { null, 0, 0, false },
                new Object[] { new Object(), 1, 1, false },
            };
        }

        #endregion

        #region properties

        [TestMethod]
        [TestData(nameof(ValuePropertyData))]
        void ValueProperty<TValue>(Object input1, TValue input2, TValue newValue, TValue value, Boolean hasChanged) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input1, input2);

            Test.IfNot.Action.ThrowsException(() => prop.Value = newValue, out Exception ex);
            Test.If.Value.IsEqual(prop.Value, value);
            Test.If.Value.IsEqual(prop.HasValueChanged, hasChanged);

        }

        IEnumerable<Object[]> ValuePropertyData() {
            return new List<Object[]>() {
                new Object[] { typeof(Int32), null, 0, 1, 1, true },
                new Object[] { typeof(Int32), null, 1, 1, 1, false },

                new Object[] { typeof(Int32?), null, null, null, null, false },
                new Object[] { typeof(Int32?), null, null, 0, 0, true },
                new Object[] { typeof(Int32?), null, 0, null, null, true },
            };
        }

        #endregion

        #region events

        [TestMethod]
        [TestData(nameof(PropertyChangedEventData))]
        void PropertyChangedEvent<TValue>(Object input1, TValue input2, Boolean raises, TValue newValue, String propertyName) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input1, input2);

            if(raises) {
                Test.If.Action.RaisesPropertyChangedEvent(() => prop.Value = newValue, prop, out EventData<PropertyChangedEventArgs> eventData);

                Test.If.Reference.IsEqual(eventData.Sender, prop);
                Test.IfNot.Object.IsNull(eventData.EventArgs);
                Test.If.Value.IsEqual(eventData.EventArgs.PropertyName, propertyName);

            } else {
                Test.IfNot.Action.RaisesPropertyChangedEvent(() => prop.Value = newValue, prop, out EventData<PropertyChangedEventArgs> eventData);
            }

        }

        IEnumerable<Object[]> PropertyChangedEventData() {
            return new List<Object[]>() {
                new Object[] { typeof(Int32?), null, null, false, null, null },
                new Object[] { typeof(Int32?), null, null, true, 0, "Value" },
                new Object[] { typeof(Int32?), null, 0, true, null, "Value" },
                new Object[] { typeof(Int32?), new Object(), null, false, null, null },
                new Object[] { typeof(Int32?), new Object(), null, true, 0, "Value" },
                new Object[] { typeof(Int32?), new Object(), 0, true, null, "Value" },
            };
        }

        [TestMethod]
        [TestData(nameof(ChangeTrackedEventData))]
        void ChangeTrackedEvent<TValue>(Object input1, TValue input2, Boolean raises, TValue newValue, Object owner, TValue old, TValue _new, Boolean hasChanged) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input1, input2);

            if(raises) {
                Test.If.Action.RaisesEvent(() => prop.Value = newValue, prop, "ChangeTracked", out EventData<ChangeTrackedEventArgs<Object, TValue>> eventData);

                Test.If.Value.IsEqual(eventData.Sender, prop);
                Test.If.Value.IsEqual(eventData.EventArgs.Owner, owner);
                Test.If.Value.IsEqual(eventData.EventArgs.Old, old);
                Test.If.Value.IsEqual(eventData.EventArgs.New, _new);
                Test.If.Value.IsEqual(eventData.EventArgs.HasChanged, hasChanged);

            } else {
                Test.IfNot.Action.RaisesEvent(() => prop.Value = newValue, prop, "ChangeTracked", out EventData<ChangeTrackedEventArgs<Object, TValue>> eventData);
            }

        }

        IEnumerable<Object[]> ChangeTrackedEventData() {
            Object owner = new Object();

            return new List<Object[]>() {
                new Object[] { typeof(Int32?), owner, null, false, null, owner, null, null, false },
                new Object[] { typeof(Int32?), owner, null, true, 0, owner, null, 0, true },
                new Object[] { typeof(Int32?), owner, 0, true, null, owner, 0, null, true },
            };
        }

        #endregion

    }
}
