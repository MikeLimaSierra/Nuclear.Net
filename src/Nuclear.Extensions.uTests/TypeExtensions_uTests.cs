using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Extensions {
    class TypeExtensions_uTests {

        [TestMethod]
        void ResolveFriendlyName_Throws() {

            Test.If.Action.ThrowsException(() => ((Type) null).ResolveFriendlyName(), out ArgumentNullException ex);

        }

        [TestMethod]
        [TestParameters(typeof(Int64), "System.Int64")]
        [TestParameters(typeof(Tuple<Int16, Int32, Int64, String>), "System.Tuple<System.Int16, System.Int32, System.Int64, System.String>")]
        [TestParameters(typeof((Int16, Int32, Int64, String)), "System.ValueTuple<System.Int16, System.Int32, System.Int64, System.String>")]
        [TestParameters(typeof(List<Int64>), "System.Collections.Generic.List<System.Int64>")]
        [TestParameters(typeof(List<Int64>[]), "System.Collections.Generic.List<System.Int64>[]")]
        [TestParameters(typeof(Dictionary<Int64, String[]>), "System.Collections.Generic.Dictionary<System.Int64, System.String[]>")]
        [TestParameters(typeof(Dictionary<(Int32, Int64), String[]>), "System.Collections.Generic.Dictionary<System.ValueTuple<System.Int32, System.Int64>, System.String[]>")]
        [TestParameters(typeof(Dictionary<(Int32, List<Int64>), String[]>), "System.Collections.Generic.Dictionary<System.ValueTuple<System.Int32, System.Collections.Generic.List<System.Int64>>, System.String[]>")]
        void ResolveFriendlyName<T>(String expected) {

            String name = null;

            Test.IfNot.Action.ThrowsException(() => name = typeof(T).ResolveFriendlyName(), out Exception ex);
            Test.If.Value.IsEqual(name, expected);

        }

    }
}
