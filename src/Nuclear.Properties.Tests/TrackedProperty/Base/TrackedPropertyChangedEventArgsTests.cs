using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperty.Base {
    class TrackedPropertyChangedEventArgsTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.TypeIsSubClass<TrackedPropertyChangedEventArgs<Object, String>, EventArgs>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void TestConstructors() {

            TrackedPropertyChangedEventArgs<Object, String> e = null;
            Object owner = new Object();
            String old = "old";
            String _new = "new";

            Test.IfNot.ThrowsException(() => e = new TrackedPropertyChangedEventArgs<Object, String>(null, null, null), out Exception ex);
            Test.If.Null(e.Owner);
            Test.If.Null(e.Old);
            Test.If.Null(e.New);
            Test.If.False(e.HasChanged);

            Test.IfNot.ThrowsException(() => e = new TrackedPropertyChangedEventArgs<Object, String>(owner, null, _new), out ex);
            Test.If.ValuesEqual(e.Owner, owner);
            Test.If.Null(e.Old);
            Test.If.ValuesEqual(e.New, _new);
            Test.If.True(e.HasChanged);

            Test.IfNot.ThrowsException(() => e = new TrackedPropertyChangedEventArgs<Object, String>(owner, old, null), out ex);
            Test.If.ValuesEqual(e.Owner, owner);
            Test.If.ValuesEqual(e.Old, old);
            Test.If.Null(e.New);
            Test.If.True(e.HasChanged);

            Test.IfNot.ThrowsException(() => e = new TrackedPropertyChangedEventArgs<Object, String>(owner, old, _new), out ex);
            Test.If.ValuesEqual(e.Owner, owner);
            Test.If.ValuesEqual(e.Old, old);
            Test.If.ValuesEqual(e.New, _new);
            Test.If.True(e.HasChanged);

            Test.IfNot.ThrowsException(() => e = new TrackedPropertyChangedEventArgs<Object, String>(owner, _new, _new), out ex);
            Test.If.ValuesEqual(e.Owner, owner);
            Test.If.ValuesEqual(e.Old, _new);
            Test.If.ValuesEqual(e.New, _new);
            Test.If.False(e.HasChanged);

        }

    }
}
