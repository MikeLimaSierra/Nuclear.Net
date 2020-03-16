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

        [TestMethod]
        void Compare() {

            DDTCompare(((FrameworkIdentifiers) 1337, (FrameworkIdentifiers) 1337), 0);
            DDTCompare(((FrameworkIdentifiers) 1337, (FrameworkIdentifiers) 1338), 0);
            DDTCompare(((FrameworkIdentifiers) 1339, (FrameworkIdentifiers) 1338), 0);

            DDTCompare((FrameworkIdentifiers.Unsupported, (FrameworkIdentifiers) 1337), 1);
            DDTCompare(((FrameworkIdentifiers) 1337, FrameworkIdentifiers.Unsupported), -1);
            DDTCompare((FrameworkIdentifiers.NETStandard, (FrameworkIdentifiers) 1337), 1);
            DDTCompare(((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETStandard), -1);
            DDTCompare((FrameworkIdentifiers.NETFramework, (FrameworkIdentifiers) 1337), 1);
            DDTCompare(((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETFramework), -1);
            DDTCompare((FrameworkIdentifiers.NETCoreApp, (FrameworkIdentifiers) 1337), 1);
            DDTCompare(((FrameworkIdentifiers) 1337, FrameworkIdentifiers.NETCoreApp), -1);

            DDTCompare((FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.Unsupported), 1);
            DDTCompare((FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.Unsupported), 1);
            DDTCompare((FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.Unsupported), 1);

            DDTCompare((FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETFramework), -1);
            DDTCompare((FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETCoreApp), -1);
            DDTCompare((FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.NETStandard), -1);

            DDTCompare((FrameworkIdentifiers.Unsupported, FrameworkIdentifiers.Unsupported), 0);
            DDTCompare((FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.NETFramework), 0);
            DDTCompare((FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.NETCoreApp), 0);
            DDTCompare((FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETStandard), 0);

            DDTCompare((FrameworkIdentifiers.NETFramework, FrameworkIdentifiers.NETStandard), 1);
            DDTCompare((FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETFramework), -1);
            DDTCompare((FrameworkIdentifiers.NETCoreApp, FrameworkIdentifiers.NETStandard), 1);
            DDTCompare((FrameworkIdentifiers.NETStandard, FrameworkIdentifiers.NETCoreApp), -1);

        }

        void DDTCompare((FrameworkIdentifiers x, FrameworkIdentifiers y) input, Int32 expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IComparer<FrameworkIdentifiers> comparer = new FrameworkIdentifiersComparer();
            Int32 result = default;

            Test.Note($"FrameworkIdentifiersComparer.Compare({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = comparer.Compare(input.x, input.y), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

    }
}
