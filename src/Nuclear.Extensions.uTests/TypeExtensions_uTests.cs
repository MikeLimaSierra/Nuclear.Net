using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class TypeExtensions_uTests {

        [TestMethod]
        void ResolveFriendlyName() {

            String name = null;

            Test.If.Action.ThrowsException(() => name = ((Type) null).ResolveFriendlyName(), out NullReferenceException nREx);

            TTDResolveFriendlyName<Int64>("System.Int64");
            TTDResolveFriendlyName<Tuple<Int16, Int32, Int64, String>>("System.Tuple<System.Int16, System.Int32, System.Int64, System.String>");
            TTDResolveFriendlyName<(Int16, Int32, Int64, String)>("System.ValueTuple<System.Int16, System.Int32, System.Int64, System.String>");
            TTDResolveFriendlyName<List<Int64>>("System.Collections.Generic.List<System.Int64>");
            TTDResolveFriendlyName<List<Int64>[]>("System.Collections.Generic.List<System.Int64>[]");
            TTDResolveFriendlyName<Dictionary<Int64, String[]>>("System.Collections.Generic.Dictionary<System.Int64, System.String[]>");
            TTDResolveFriendlyName<Dictionary<(Int32, Int64), String[]>>("System.Collections.Generic.Dictionary<System.ValueTuple<System.Int32, System.Int64>, System.String[]>");

        }

        void TTDResolveFriendlyName<T>(String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String name = null;

            Test.Note($"typeof({typeof(T).Format()}).ResolveFriendlyName() = {expected.Format()})", _file, _method);

            Test.IfNot.Action.ThrowsException(() => name = typeof(T).ResolveFriendlyName(), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(name, expected, _file, _method);

        }

    }
}
