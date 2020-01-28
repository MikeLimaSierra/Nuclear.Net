﻿using System;
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

            TTDConstructor((FrameworkIdentifiers.Unsupported, new Version(1, 2, 3)), (FrameworkIdentifiers.Unsupported, new Version(1, 2, 3)));
            TTDConstructor((FrameworkIdentifiers.NETStandard, new Version(2, 3, 4)), (FrameworkIdentifiers.NETStandard, new Version(2, 3, 4)));

        }

        void TTDConstructor((FrameworkIdentifiers framework, Version version) input, (FrameworkIdentifiers framework, Version version) expected,
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

            TTDEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))), true);
            TTDEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))), false);
            TTDEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))), false);
            TTDEquals((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), false);

        }

        void TTDEquals((RuntimeInfo left, RuntimeInfo right) input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;

            Test.Note($"{input.left.Format()}.Equals({input.right.Format()}) == {expected.Format()}");

            Test.IfNot.Action.ThrowsException(() => result = input.left.Equals(input.right), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        #endregion

        #region TryParse

        [TestMethod]
        void TryParse() {

            TTDTryParseApi(".NetFramework,Version=v4.0", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            TTDTryParseApi(".NetFramework,Version=v4.5", (true, FrameworkIdentifiers.NETFramework, new Version(4, 5)));
            TTDTryParseApi(".NetFramework,Version=v4.5.1", (true, FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)));
            TTDTryParseApi(".NetFramework,Version=v4.5.2", (true, FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)));
            TTDTryParseApi(".NetFramework,Version=v4.6", (true, FrameworkIdentifiers.NETFramework, new Version(4, 6)));
            TTDTryParseApi(".NetFramework,Version=v4.6.1", (true, FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)));
            TTDTryParseApi(".NetFramework,Version=v4.6.2", (true, FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)));
            TTDTryParseApi(".NetFramework,Version=v4.7", (true, FrameworkIdentifiers.NETFramework, new Version(4, 7)));
            TTDTryParseApi(".NetFramework,Version=v4.7.1", (true, FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)));
            TTDTryParseApi(".NetFramework,Version=v4.7.2", (true, FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)));
            TTDTryParseApi(".NetFramework,Version=v4.8", (true, FrameworkIdentifiers.NETFramework, new Version(4, 8)));

            TTDTryParseApi(".NETCoreApp,Version=v1.0", (true, FrameworkIdentifiers.NETCoreApp, new Version(1, 0)));
            TTDTryParseApi(".NETCoreApp,Version=v1.1", (true, FrameworkIdentifiers.NETCoreApp, new Version(1, 1)));
            TTDTryParseApi(".NETCoreApp,Version=v2.0", (true, FrameworkIdentifiers.NETCoreApp, new Version(2, 0)));
            TTDTryParseApi(".NETCoreApp,Version=v2.1", (true, FrameworkIdentifiers.NETCoreApp, new Version(2, 1)));
            TTDTryParseApi(".NETCoreApp,Version=v2.2", (true, FrameworkIdentifiers.NETCoreApp, new Version(2, 2)));
            TTDTryParseApi(".NETCoreApp,Version=v3.0", (true, FrameworkIdentifiers.NETCoreApp, new Version(3, 0)));
            TTDTryParseApi(".NETCoreApp,Version=v3.1", (true, FrameworkIdentifiers.NETCoreApp, new Version(3, 1)));

            TTDTryParseApi(".NETStandard,Version=v1.0", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(".NETStandard,Version=v1.1", (true, FrameworkIdentifiers.NETStandard, new Version(1, 1)));
            TTDTryParseApi(".NETStandard,Version=v1.2", (true, FrameworkIdentifiers.NETStandard, new Version(1, 2)));
            TTDTryParseApi(".NETStandard,Version=v1.3", (true, FrameworkIdentifiers.NETStandard, new Version(1, 3)));
            TTDTryParseApi(".NETStandard,Version=v1.4", (true, FrameworkIdentifiers.NETStandard, new Version(1, 4)));
            TTDTryParseApi(".NETStandard,Version=v1.5", (true, FrameworkIdentifiers.NETStandard, new Version(1, 5)));
            TTDTryParseApi(".NETStandard,Version=v1.6", (true, FrameworkIdentifiers.NETStandard, new Version(1, 6)));
            TTDTryParseApi(".NETStandard,Version=v2.0", (true, FrameworkIdentifiers.NETStandard, new Version(2, 0)));
            TTDTryParseApi(".NETStandard,Version=v2.1", (true, FrameworkIdentifiers.NETStandard, new Version(2, 1)));

            TTDTryParseApi("NetFramework,Version=v4.0", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            TTDTryParseApi("NETCoreApp,Version=v1.0", (true, FrameworkIdentifiers.NETCoreApp, new Version(1, 0)));
            TTDTryParseApi("NETStandard,Version=v1.0", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(" .NETStandard,Version=v1.0", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(".NETStandard ,Version=v1.0", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(".NETStandard, Version=v1.0", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(".NETStandard,Version =v1.0", (false, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(".NETStandard,Version= v1.0", (false, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(".NETStandard,Version=v 1.0", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            TTDTryParseApi(".NETStandard,Version=v1.0 ", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));

        }

        void TTDTryParseApi(String input, (Boolean result, FrameworkIdentifiers framework, Version version) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            RuntimeInfo info = null;

            Test.Note($"RuntimeInfo.TryParse({input.Format()} => {expected.result.Format()}, {expected.framework.Format()}, {expected.version.Format()})", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimeInfo.TryParse(input, out info), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);

            if(expected.result) {
                Test.If.Value.IsEqual(info.Framework, expected.framework, _file, _method);
                Test.If.Value.IsEqual(info.Version, expected.version, _file, _method);
            }

        }

        #endregion

        #region ToString

        [TestMethod]
        new void ToString() {

            TTDToString(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), "NETFramework 1.0");
            TTDToString(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), "NETCoreApp 2.1");
            TTDToString(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(3, 2)), "NETStandard 3.2");
            TTDToString(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(4, 3)), "Unsupported 4.3");

        }

        void TTDToString(RuntimeInfo input, String expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            String result = null;

            Test.Note($"RuntimeInfo({input.Framework.Format()}, {input.Version.Format()}).ToString() == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = input.ToString(), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

        #endregion

    }
}
