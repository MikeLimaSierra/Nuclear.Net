using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedProperty_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.Implements<TrackedProperty<Object, TestEnum>, ITrackedProperty<Object, TestEnum>>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        #region ctors

        [TestMethod]
        void Constructors() {

            DDTestDefaultConstructor(null, (TestEnum.Default, false));
            DDTestDefaultConstructor(new Object(), (TestEnum.Default, false));

            DDTestFullConstructor((null, TestEnum.Default), (TestEnum.Default, false));
            DDTestFullConstructor((new Object(), TestEnum.Value1), (TestEnum.Value1, false));

        }

        void DDTestDefaultConstructor<TValue>(Object input, (TValue value, Boolean hasChanged) expected,
               [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = null;

            Test.Note($"Test ctor with: '{input}'", _file, _method);
            Test.IfNot.Action.ThrowsException(() => prop = new TrackedProperty<Object, TValue>(input), out Exception ex, _file, _method);
            Test.IfNot.Object.IsNull(prop, _file, _method);
            Test.If.Value.IsEqual(prop.Value, expected.value, _file, _method);
            Test.If.Value.IsEqual(prop.HasValueChanged, expected.hasChanged, _file, _method);

        }

        void DDTestFullConstructor<TValue>((Object owner, TValue value) input, (TValue value, Boolean hasChanged) expected,
               [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = null;

            Test.Note($"Test ctor with: '{input.owner}', '{input.value}'", _file, _method);
            Test.IfNot.Action.ThrowsException(() => prop = new TrackedProperty<Object, TValue>(input.owner, input.value), out Exception ex, _file, _method);
            Test.IfNot.Object.IsNull(prop, _file, _method);
            Test.If.Value.IsEqual(prop.Value, expected.value, _file, _method);
            Test.If.Value.IsEqual(prop.HasValueChanged, expected.hasChanged, _file, _method);

        }

        #endregion

        #region properties

        [TestMethod]
        void ValueProperty() {

            DDTestValueProperty((null, TestEnum.Default), TestEnum.Value1, (TestEnum.Value1, true));
            DDTestValueProperty((null, TestEnum.Value1), TestEnum.Value1, (TestEnum.Value1, false));

            DDTestValueProperty<TestEnum?>((null, null), null, (null, false));
            DDTestValueProperty<TestEnum?>((null, null), TestEnum.Default, (TestEnum.Default, true));
            DDTestValueProperty<TestEnum?>((null, TestEnum.Default), null, (null, true));

        }

        void DDTestValueProperty<TValue>((Object owner, TValue value) input, TValue newValue, (TValue value, Boolean hasChanged) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input.owner, input.value);

            Test.Note($"Value = '{newValue}'", _file, _method);
            Test.IfNot.Action.ThrowsException(() => prop.Value = newValue, out Exception ex, _file, _method);
            Test.If.Value.IsEqual(prop.Value, expected.value, _file, _method);
            Test.If.Value.IsEqual(prop.HasValueChanged, expected.hasChanged, _file, _method);

        }

        #endregion

        #region events

        [TestMethod]
        void PropertyChangedEvent() {

            ITrackedProperty<Object, TestEnum?> prop = new TrackedProperty<Object, TestEnum?>(null, null);

            Test.IfNot.Action.RaisesPropertyChangedEvent(() => prop.Value = null, prop, out EventData<PropertyChangedEventArgs> eventData);
            Test.If.Value.IsEqual(prop.Value, null);

            DDTestPropertyChangedEvent<TestEnum?>((null, null), TestEnum.Default, "Value");
            DDTestPropertyChangedEvent<TestEnum?>((null, TestEnum.Default), null, "Value");

        }

        void DDTestPropertyChangedEvent<TValue>((Object owner, TValue value) input, TValue newValue, String propertyName,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input.owner, input.value);

            Test.Note($"Value = '{newValue}'", _file, _method);
            Test.If.Action.RaisesPropertyChangedEvent(() => prop.Value = newValue, prop, out EventData<PropertyChangedEventArgs> eventData, _file, _method);
            Test.IfNot.Object.IsNull(eventData.Sender, _file, _method);
            Test.If.Reference.IsEqual(eventData.Sender, prop, _file, _method);
            Test.IfNot.Object.IsNull(eventData.EventArgs, _file, _method);
            Test.If.Value.IsEqual(eventData.EventArgs.PropertyName, propertyName, _file, _method);

        }

        [TestMethod]
        void ChangeTrackedEvent() {

            Object owner = new Object();
            ITrackedProperty<Object, TestEnum?> prop = new TrackedProperty<Object, TestEnum?>(owner, null);

            Test.IfNot.Action.RaisesEvent(() => prop.Value = null, prop, "ChangeTracked", out EventData<ChangeTrackedEventArgs<Object, TestEnum?>> eventData);

            DDTestChangeTrackedEvent<TestEnum?>((owner, null), TestEnum.Default, (owner, null, TestEnum.Default, true));
            DDTestChangeTrackedEvent<TestEnum?>((owner, TestEnum.Default), null, (owner, TestEnum.Default, null, true));

        }

        void DDTestChangeTrackedEvent<TValue>((Object owner, TValue value) input, TValue newValue, (Object owner, TValue old, TValue _new, Boolean hasChanged) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input.owner, input.value);

            Test.Note($"Value = '{newValue}'", _file, _method);
            Test.If.Action.RaisesEvent(() => prop.Value = newValue, prop, "ChangeTracked", out EventData<ChangeTrackedEventArgs<Object, TValue>> eventData, _file, _method);
            Test.IfNot.Object.IsNull(eventData.Sender, _file, _method);
            Test.If.Value.IsEqual(eventData.Sender, prop, _file, _method);
            Test.IfNot.Object.IsNull(eventData.EventArgs, _file, _method);
            Test.If.Value.IsEqual(eventData.EventArgs.Owner, expected.owner, _file, _method);
            Test.If.Value.IsEqual(eventData.EventArgs.Old, expected.old, _file, _method);
            Test.If.Value.IsEqual(eventData.EventArgs.New, expected._new, _file, _method);
            Test.If.Value.IsEqual(eventData.EventArgs.HasChanged, expected.hasChanged, _file, _method);

        }

        #endregion

        private enum TestEnum : Int32 {
            Default = 0,
            Value1 = 1
        }

    }
}
