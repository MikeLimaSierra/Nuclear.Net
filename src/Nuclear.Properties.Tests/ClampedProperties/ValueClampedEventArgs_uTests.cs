using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ValueClampedEventArgs_uTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.Type.IsSubClass<ValueClampedEventArgs<String>, EventArgs>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void TestConstructorNullable() {

            Int32? _set = 6;
            Int32? _outOfBoundsSet = 7;
            Int32? _old = 5;
            Int32? _new = 6;

            DDTestConstructor<Int32?>(null, null, null, false, false);
            DDTestConstructor(null, _old, _new, true, false);
            DDTestConstructor(_set, null, _new, true, false);
            DDTestConstructor(_set, _old, null, true, false);
            DDTestConstructor(_set, _old, _new, true, false);
            DDTestConstructor(_outOfBoundsSet, _old, _new, true, true);
            DDTestConstructor(_set, _new, _new, false, false);

        }

        [TestMethod]
        void TestConstructorNonNullable() {

            Int32 _set = 6;
            Int32 _outOfBoundsSet = 7;
            Int32 _old = 5;
            Int32 _new = 6;

            DDTestConstructor(_set, _old, _new, true, false);
            DDTestConstructor(_outOfBoundsSet, _old, _new, true, true);
            DDTestConstructor(_set, _new, _new, false, false);

        }

        void DDTestConstructor<TValue>(TValue setValue, TValue oldValue, TValue newValue, Boolean hasChanged, Boolean hasBeenClamped,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ValueClampedEventArgs<TValue> e = null;

            Test.Note(String.Format("Test ctor with: '{0}', '{1}', '{2}'", setValue, oldValue, newValue), _file, _method);
            Test.IfNot.Action.ThrowsException(() => e = new ValueClampedEventArgs<TValue>(setValue, oldValue, newValue), out Exception ex, _file, _method);
            Test.IfNot.Object.IsNull(e, _file, _method);
            Test.If.Value.Equals(e.Set, setValue, _file, _method);
            Test.If.Value.Equals(e.Old, oldValue, _file, _method);
            Test.If.Value.Equals(e.New, newValue, _file, _method);
            Test.If.Value.Equals(e.HasChanged, hasChanged, _file, _method);
            Test.If.Value.Equals(e.HasBeenClamped, hasBeenClamped, _file, _method);

        }

    }
}
