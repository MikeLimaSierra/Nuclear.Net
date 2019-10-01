using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class TrackedPropertyTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.TypeImplements<TrackedProperty<Object, TestEnum>, ITrackedProperty<Object, TestEnum>>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        #region ctors

        [TestMethod]
        void TestConstructors() {

            DDTestDefaultConstructor(null, (TestEnum.Default, false));
            DDTestDefaultConstructor(new Object(), (TestEnum.Default, false));

            DDTestFullConstructor((null, TestEnum.Default), (TestEnum.Default, false));
            DDTestFullConstructor((new Object(), TestEnum.Value1), (TestEnum.Value1, false));

        }

        void DDTestDefaultConstructor<TValue>(Object input, (TValue value, Boolean hasChanged) expected,
               [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = null;

            Test.Note($"Test ctor with: '{input}'", _file, _method);
            Test.IfNot.ThrowsException(() => prop = new TrackedProperty<Object, TValue>(input), out Exception ex, _file, _method);
            Test.IfNot.Null(prop, _file, _method);
            Test.If.ValuesEqual(prop.Value, expected.value, _file, _method);
            Test.If.ValuesEqual(prop.HasValueChanged, expected.hasChanged, _file, _method);

        }

        void DDTestFullConstructor<TValue>((Object owner, TValue value) input, (TValue value, Boolean hasChanged) expected,
               [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = null;

            Test.Note($"Test ctor with: '{input.owner}', '{input.value}'", _file, _method);
            Test.IfNot.ThrowsException(() => prop = new TrackedProperty<Object, TValue>(input.owner, input.value), out Exception ex, _file, _method);
            Test.IfNot.Null(prop, _file, _method);
            Test.If.ValuesEqual(prop.Value, expected.value, _file, _method);
            Test.If.ValuesEqual(prop.HasValueChanged, expected.hasChanged, _file, _method);

        }

        #endregion

        #region properties

        [TestMethod]
        void TestValueProperty() {

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
            Test.IfNot.ThrowsException(() => prop.Value = newValue, out Exception ex, _file, _method);
            Test.If.ValuesEqual(prop.Value, expected.value, _file, _method);
            Test.If.ValuesEqual(prop.HasValueChanged, expected.hasChanged, _file, _method);

        }

        #endregion

        #region events

        [TestMethod]
        void TestPropertyChangedEvent() {

            ITrackedProperty<Object, TestEnum?> prop = new TrackedProperty<Object, TestEnum?>(null, null);

            Test.IfNot.RaisesPropertyChangedEvent(prop, () => prop.Value = null, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(prop.Value, null);
            Test.If.Null(sender);
            Test.If.Null(e);

            DDTestPropertyChangedEvent<TestEnum?>((null, null), TestEnum.Default, "Value");
            DDTestPropertyChangedEvent<TestEnum?>((null, TestEnum.Default), null, "Value");

        }

        void DDTestPropertyChangedEvent<TValue>((Object owner, TValue value) input, TValue newValue, String propertyName,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input.owner, input.value);

            Test.Note($"Value = '{newValue}'", _file, _method);
            Test.If.RaisesPropertyChangedEvent(prop, () => prop.Value = newValue, out Object sender, out PropertyChangedEventArgs e, _file, _method);
            Test.IfNot.Null(sender, _file, _method);
            Test.If.ReferencesEqual(sender, prop, _file, _method);
            Test.IfNot.Null(e, _file, _method);
            Test.If.ValuesEqual(e.PropertyName, propertyName, _file, _method);

        }

        [TestMethod]
        void TestChangeTrackedEvent() {

            Object owner = new Object();
            ITrackedProperty<Object, TestEnum?> prop = new TrackedProperty<Object, TestEnum?>(owner, null);

            Test.IfNot.RaisesEvent(prop, "ChangeTracked", () => prop.Value = null, out Object sender, out ChangeTrackedEventArgs<Object, TestEnum?> e);

            DDTestChangeTrackedEvent<TestEnum?>((owner, null), TestEnum.Default, (owner, null, TestEnum.Default, true));
            DDTestChangeTrackedEvent<TestEnum?>((owner, TestEnum.Default), null, (owner, TestEnum.Default, null, true));

        }

        void DDTestChangeTrackedEvent<TValue>((Object owner, TValue value) input, TValue newValue, (Object owner, TValue old, TValue _new, Boolean hasChanged) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ITrackedProperty<Object, TValue> prop = new TrackedProperty<Object, TValue>(input.owner, input.value);

            Test.Note($"Value = '{newValue}'", _file, _method);
            Test.If.RaisesEvent(prop, "ChangeTracked", () => prop.Value = newValue, out Object sender, out ChangeTrackedEventArgs<Object, TValue> e, _file, _method);
            Test.IfNot.Null(sender, _file, _method);
            Test.If.ValuesEqual(sender, prop, _file, _method);
            Test.IfNot.Null(e, _file, _method);
            Test.If.ValuesEqual(e.Owner, expected.owner, _file, _method);
            Test.If.ValuesEqual(e.Old, expected.old, _file, _method);
            Test.If.ValuesEqual(e.New, expected._new, _file, _method);
            Test.If.ValuesEqual(e.HasChanged, expected.hasChanged, _file, _method);

        }

        #endregion

        private enum TestEnum : Int32 {
            Default = 0,
            Value1 = 1
        }

    }
}
