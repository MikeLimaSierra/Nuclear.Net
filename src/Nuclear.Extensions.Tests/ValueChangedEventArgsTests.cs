using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Extensions {
    class ValueChangedEventArgsTests {

        [TestMethod]
        void TestConstructorNullable() {

            String _old = "old";
            String _new = "new";

            DDTestConstructor<String>(null, null, false);
            DDTestConstructor(null, _new, true);
            DDTestConstructor(_old, null, true);
            DDTestConstructor(_old, _new, true);
            DDTestConstructor(_old, _old, false);

        }

        [TestMethod]
        void TestConstructorNonNullable() {

            Int32 _old = 5;
            Int32 _new = 6;

            DDTestConstructor(_old, _new, true);
            DDTestConstructor(_old, _old, false);

        }

        void DDTestConstructor<TValue>(TValue oldValue, TValue newValue, Boolean hasChanged,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ValueChangedEventArgs<TValue> e = null;

            Test.Note(String.Format("Test ctor with: '{0}', '{1}'", oldValue, newValue), _file, _method);
            Test.IfNot.ThrowsException(() => e = new ValueChangedEventArgs<TValue>(oldValue, newValue), out Exception ex, _file, _method);
            Test.IfNot.Null(e, _file, _method);
            Test.If.ValuesEqual(e.Old, oldValue, _file, _method);
            Test.If.ValuesEqual(e.New, newValue, _file, _method);
            Test.If.ValuesEqual(e.HasChanged, hasChanged, _file, _method);

        }

    }
}
