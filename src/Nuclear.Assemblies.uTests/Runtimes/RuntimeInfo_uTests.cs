using System;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Runtimes {
    class RuntimeInfo_uTests {

        #region ctors

        [TestMethod]
        void Constructor() {

            RuntimeInfo info = null;

            Test.If.Action.ThrowsException(() => info = new RuntimeInfo((FrameworkIdentifiers) 42, null), out ArgumentException argEx);
            Test.If.Action.ThrowsException(() => info = new RuntimeInfo(FrameworkIdentifiers.Unsupported, null), out ArgumentNullException argNullEx);

            DDTConstructor((FrameworkIdentifiers.Unsupported, new Version(1, 2, 3)), (FrameworkIdentifiers.Unsupported, new Version(1, 2, 3)));
            DDTConstructor((FrameworkIdentifiers.NETStandard, new Version(2, 3, 4)), (FrameworkIdentifiers.NETStandard, new Version(2, 3, 4)));

        }

        void DDTConstructor((FrameworkIdentifiers framework, Version version) input, (FrameworkIdentifiers framework, Version version) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            RuntimeInfo info = null;

            Test.Note($"new RuntimeInfo({input.framework.Format()}, {input.version.Format()})", _file, _method);

            Test.IfNot.Action.ThrowsException(() => info = new RuntimeInfo(input.framework, input.version), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(info.Framework, expected.framework, _file, _method);
            Test.If.Value.IsEqual(info.Version, expected.version, _file, _method);

        }

        #endregion

        #region Equals

        [TestMethod]
        void Equals() {

            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (Object) null), false);
            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), "wrong type"), false);

            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (Object) new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))), true);
            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (Object) new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))), false);
            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (Object) new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))), false);
            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (Object) new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), false);

            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))), true);
            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))), false);
            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))), false);
            DDTEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), false);

        }

        void DDTEquals((RuntimeInfo left, Object right) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.left.Format()}.Equals({input.right.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = input.left.Equals(input.right), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        void DDTEquals((RuntimeInfo left, RuntimeInfo right) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.left.Format()}.Equals({input.right.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = input.left.Equals(input.right), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

        #region ToString

        [TestMethod]
        new void ToString() {

            DDTToString(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), "NETFramework 1.0");
            DDTToString(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), "NETCoreApp 2.1");
            DDTToString(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(3, 2)), "NETStandard 3.2");
            DDTToString(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(4, 3)), "Unsupported 4.3");

        }

        void DDTToString(RuntimeInfo input, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String result = null;

            Test.Note($"RuntimeInfo({input.Framework.Format()}, {input.Version.Format()}).ToString() == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = input.ToString(), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

    }
}
