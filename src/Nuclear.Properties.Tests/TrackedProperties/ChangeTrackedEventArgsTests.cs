using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Properties.TrackedProperties {
    class ChangeTrackedEventArgsTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.TypeIsSubClass<ChangeTrackedEventArgs<Object, String>, EventArgs>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void TestConstructorNullable() {

            Object owner = new Object();
            String _old = "old";
            String _new = "new";

            DDTestConstructor<Object, String>(null, null, null, false);
            DDTestConstructor(owner, null, _new, true);
            DDTestConstructor(owner, _old, null, true);
            DDTestConstructor(owner, _old, _new, true);
            DDTestConstructor(owner, _old, _old, false);

        }

        [TestMethod]
        void TestConstructorNonNullable() {

            Int32 _old = 5;
            Int32 _new = 6;

            DDTestConstructor<Object, Int32>(null, _old, _new, true);
            DDTestConstructor<Object, Int32>(null, _old, _old, false);

        }

        void DDTestConstructor<TOwner, TValue>(TOwner owner, TValue oldValue, TValue newValue, Boolean hasChanged,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ChangeTrackedEventArgs<TOwner, TValue> e = null;

            Test.Note(String.Format("Test ctor with: '{0}', '{1}', '{2}'", owner, oldValue, newValue), _file, _method);
            Test.IfNot.ThrowsException(() => e = new ChangeTrackedEventArgs<TOwner, TValue>(owner, oldValue, newValue), out Exception ex, _file, _method);
            Test.IfNot.Null(e, _file, _method);
            Test.If.ValuesEqual(e.Owner, owner, _file, _method);
            Test.If.ValuesEqual(e.Old, oldValue, _file, _method);
            Test.If.ValuesEqual(e.New, newValue, _file, _method);
            Test.If.ValuesEqual(e.HasChanged, hasChanged, _file, _method);

        }

    }
}
