using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Runtimes {
    class FrameworkIdentifiersComparer_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<FrameworkIdentifiersComparer, IComparer<FrameworkIdentifiers>>();

        }

        void Compare() {

            Compare((FrameworkIdentifiers) 1337, (FrameworkIdentifiers) 1337, 0);
            Compare((FrameworkIdentifiers) 1337, (FrameworkIdentifiers) 1338, 0);
            Compare((FrameworkIdentifiers) 1339, (FrameworkIdentifiers) 1338, 0);

            Compare(FrameworkIdentifiers.Unsupported, (FrameworkIdentifiers) 1337, 1);
            Compare((FrameworkIdentifiers) 1337, FrameworkIdentifiers.Unsupported, -1);
            Compare(FrameworkIdentifiers.NETStandard, (FrameworkIdentifiers) 1337, 1);
            Compare((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETStandard, -1);
            Compare(FrameworkIdentifiers.NETFramework, (FrameworkIdentifiers) 1337, 1);
            Compare((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETFramework, -1);
            Compare(FrameworkIdentifiers.NETCoreApp, (FrameworkIdentifiers) 1337, 1);
            Compare((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETCoreApp, -1);

            Compare(FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.Unsupported, 1);
            Compare(FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.Unsupported, 1);
            Compare(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.Unsupported, 1);

            Compare(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETFramework, -1);
            Compare(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETCoreApp, -1);
            Compare(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETStandard, -1);

            Compare(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.Unsupported, 0);
            Compare(FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.NETFramework, 0);
            Compare(FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.NETCoreApp, 0);
            Compare(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETStandard, 0);

            Compare(FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.NETStandard, 1);
            Compare(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETFramework, -1);
            Compare(FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.NETStandard, 1);
            Compare(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETCoreApp, -1);

        }

        [TestMethod]
        [TestParameters((FrameworkIdentifiers) 1337, (FrameworkIdentifiers) 1337, 0)]
        [TestParameters((FrameworkIdentifiers) 1337, (FrameworkIdentifiers) 1338, 0)]
        [TestParameters((FrameworkIdentifiers) 1339, (FrameworkIdentifiers) 1338, 0)]
        [TestParameters(FrameworkIdentifiers.Unsupported, (FrameworkIdentifiers) 1337, 1)]
        [TestParameters((FrameworkIdentifiers) 1337, FrameworkIdentifiers.Unsupported, -1)]
        [TestParameters(FrameworkIdentifiers.NETStandard, (FrameworkIdentifiers) 1337, 1)]
        [TestParameters((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETStandard, -1)]
        [TestParameters(FrameworkIdentifiers.NETFramework, (FrameworkIdentifiers) 1337, 1)]
        [TestParameters((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETFramework, -1)]
        [TestParameters(FrameworkIdentifiers.NETCoreApp, (FrameworkIdentifiers) 1337, 1)]
        [TestParameters((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETCoreApp, -1)]
        [TestParameters(FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.Unsupported, 1)]
        [TestParameters(FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.Unsupported, 1)]
        [TestParameters(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.Unsupported, 1)]
        [TestParameters(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETFramework, -1)]
        [TestParameters(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETCoreApp, -1)]
        [TestParameters(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETStandard, -1)]
        [TestParameters(FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.Unsupported, 0)]
        [TestParameters(FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.NETFramework, 0)]
        [TestParameters(FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.NETCoreApp, 0)]
        [TestParameters(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETStandard, 0)]
        [TestParameters(FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.NETStandard, 1)]
        [TestParameters(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETFramework, -1)]
        [TestParameters(FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.NETStandard, 1)]
        [TestParameters(FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETCoreApp, -1)]
        void Compare(FrameworkIdentifiers input1, FrameworkIdentifiers input2, Int32 expected) {

            IComparer<FrameworkIdentifiers> comparer = new FrameworkIdentifiersComparer();
            Int32 result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Compare(input1, input2), out Exception ex);

            Test.If.Value.IsEqual(result, expected);

        }

    }
}
