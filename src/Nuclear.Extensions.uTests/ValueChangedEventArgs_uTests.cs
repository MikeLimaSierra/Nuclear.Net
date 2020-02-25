using System;
using System.Runtime.CompilerServices;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class ValueChangedEventArgs_uTests {

        [TestMethod]
        void ConstructorNullable() {

            String _old = "old";
            String _new = "new";

            DDTConstructor<String>(null, null, false);
            DDTConstructor(null, _new, true);
            DDTConstructor(_old, null, true);
            DDTConstructor(_old, _new, true);
            DDTConstructor(_old, _old, false);

        }

        [TestMethod]
        void ConstructorNonNullable() {

            Int32 _old = 5;
            Int32 _new = 6;

            DDTConstructor(_old, _new, true);
            DDTConstructor(_old, _old, false);

        }

        void DDTConstructor<TValue>(TValue oldValue, TValue newValue, Boolean hasChanged,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            ValueChangedEventArgs<TValue> e = null;

            Test.Note(String.Format("Test ctor with: '{0}', '{1}'", oldValue, newValue), _file, _method);
            Test.IfNot.Action.ThrowsException(() => e = new ValueChangedEventArgs<TValue>(oldValue, newValue), out Exception ex, _file, _method);
            Test.IfNot.Object.IsNull(e, _file, _method);
            Test.If.Value.IsEqual(e.Old, oldValue, _file, _method);
            Test.If.Value.IsEqual(e.New, newValue, _file, _method);
            Test.If.Value.IsEqual(e.HasChanged, hasChanged, _file, _method);

        }

    }
}
