using System;
using System.ComponentModel;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperty.Base {
    class TrackedPropertyTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.TypeImplements<TrackedProperty<Object, TestEnum>, ITrackedProperty<Object, TestEnum>>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void TestConstructors() {

            ITrackedProperty<Object, TestEnum> prop = null;
            Object owner = new Object();

            Test.IfNot.ThrowsException(() => prop = new TrackedProperty<Object, TestEnum>(null, TestEnum.Default), out Exception ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, TestEnum.Default);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop = new TrackedProperty<Object, TestEnum>(owner, TestEnum.Default), out ex);
            Test.IfNot.Null(prop);
            Test.If.ValuesEqual(prop.Value, TestEnum.Default);
            Test.If.False(prop.HasValueChanged);

        }

        [TestMethod]
        void TestValueProperty() {

            ITrackedProperty<Object, TestEnum> prop = new TrackedProperty<Object, TestEnum>(null, TestEnum.Default);

            Test.IfNot.ThrowsException(() => prop.Value = TestEnum.Value1, out Exception ex);
            Test.If.ValuesEqual(prop.Value, TestEnum.Value1);
            Test.If.True(prop.HasValueChanged);

            prop.HasValueChanged = false;

            Test.IfNot.ThrowsException(() => prop.Value = TestEnum.Value1, out ex);
            Test.If.ValuesEqual(prop.Value, TestEnum.Value1);
            Test.If.False(prop.HasValueChanged);

        }

        [TestMethod]
        void TestNullableValueProperty() {

            ITrackedProperty<Object, TestEnum?> prop = new TrackedProperty<Object, TestEnum?>(null, null);

            Test.IfNot.ThrowsException(() => prop.Value = null, out Exception ex);
            Test.If.ValuesEqual(prop.Value, null);
            Test.If.False(prop.HasValueChanged);

            Test.IfNot.ThrowsException(() => prop.Value = TestEnum.Default, out ex);
            Test.If.ValuesEqual(prop.Value, TestEnum.Default);
            Test.If.True(prop.HasValueChanged);

            prop.HasValueChanged = false;

            Test.IfNot.ThrowsException(() => prop.Value = null, out ex);
            Test.If.ValuesEqual(prop.Value, null);
            Test.If.True(prop.HasValueChanged);

        }

        [TestMethod]
        void TestPropertyChangedEvent() {

            ITrackedProperty<Object, TestEnum?> prop = new TrackedProperty<Object, TestEnum?>(null, null);

            Test.IfNot.RaisesPropertyChangedEvent(prop, () => prop.Value = null, out Object sender, out PropertyChangedEventArgs e);
            Test.If.ValuesEqual(prop.Value, null);
            Test.If.Null(sender);
            Test.If.Null(e);

            Test.If.RaisesPropertyChangedEvent(prop, () => prop.Value = TestEnum.Default, out sender, out e);
            Test.If.ValuesEqual(prop.Value, TestEnum.Default);
            Test.IfNot.Null(sender);
            Test.If.ValuesEqual(sender, prop);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.PropertyName, "Value");

            Test.If.RaisesPropertyChangedEvent(prop, () => prop.Value = null, out sender, out e);
            Test.If.ValuesEqual(prop.Value, null);
            Test.IfNot.Null(sender);
            Test.If.ValuesEqual(sender, prop);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.PropertyName, "Value");

        }

        [TestMethod]
        void TestPropertyChangeTrackedEvent() {

            Object owner = new Object();
            ITrackedProperty<Object, TestEnum?> prop = new TrackedProperty<Object, TestEnum?>(owner, null);

            Test.IfNot.RaisesEvent(prop, "PropertyChangeTracked", () => prop.Value = null, out Object sender, out TrackedPropertyChangedEventArgs<Object, TestEnum?> e);
            Test.If.ValuesEqual(prop.Value, null);
            Test.If.Null(sender);
            Test.If.Null(e);

            Test.If.RaisesEvent(prop, "PropertyChangeTracked", () => prop.Value = TestEnum.Default, out sender, out e);
            Test.If.ValuesEqual(prop.Value, TestEnum.Default);
            Test.IfNot.Null(sender);
            Test.If.ValuesEqual(sender, prop);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.Owner, owner);
            Test.If.Null(e.Old);
            Test.If.ValuesEqual(e.New, TestEnum.Default);
            Test.If.True(e.HasChanged);

            Test.If.RaisesEvent(prop, "PropertyChangeTracked", () => prop.Value = null, out sender, out e);
            Test.If.ValuesEqual(prop.Value, null);
            Test.IfNot.Null(sender);
            Test.If.ValuesEqual(sender, prop);
            Test.IfNot.Null(e);
            Test.If.ValuesEqual(e.Owner, owner);
            Test.If.ValuesEqual(e.Old, TestEnum.Default);
            Test.If.Null(e.New);
            Test.If.True(e.HasChanged);

        }

        private enum TestEnum : Int32 {
            Default = 0,
            Value1 = 1
        }

    }
}
