using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Properties.TrackedProperties {
    class ChangeTrackedEventArgs_uTests {

        [TestMethod]
        void Implementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.IsSubClass<ChangeTrackedEventArgs<Object, String>, EventArgs>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void ConstructorNullable() {

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
        void ConstructorNonNullable() {

            Int32 _old = 5;
            Int32 _new = 6;

            DDTestConstructor<Object, Int32>(null, _old, _new, true);
            DDTestConstructor<Object, Int32>(null, _old, _old, false);

        }

        void DDTestConstructor<TOwner, TValue>(TOwner owner, TValue oldValue, TValue newValue, Boolean hasChanged,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ChangeTrackedEventArgs<TOwner, TValue> e = null;

            Test.Note(String.Format("Test ctor with: '{0}', '{1}', '{2}'", owner, oldValue, newValue), _file, _method);
            Test.IfNot.Action.ThrowsException(() => e = new ChangeTrackedEventArgs<TOwner, TValue>(owner, oldValue, newValue), out Exception ex, _file, _method);
            Test.IfNot.Object.IsNull(e, _file, _method);
            Test.If.Value.Equals(e.Owner, owner, _file, _method);
            Test.If.Value.Equals(e.Old, oldValue, _file, _method);
            Test.If.Value.Equals(e.New, newValue, _file, _method);
            Test.If.Value.Equals(e.HasChanged, hasChanged, _file, _method);

        }

    }
}
