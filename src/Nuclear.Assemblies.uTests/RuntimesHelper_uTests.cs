using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies {
    class RuntimesHelper_uTests {

        #region NetStandardVersions

        [TestMethod]
        void NetStandardVersions() {

            IDictionary<RuntimeInfo, Version> versions1 = null;
            IDictionary<RuntimeInfo, Version> versions2 = null;

            Test.IfNot.Action.ThrowsException(() => versions1 = RuntimesHelper.NetStandardVersions, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => versions2 = RuntimesHelper.NetStandardVersions, out ex);

            Test.IfNot.Object.IsNull(versions1);
            Test.IfNot.Object.IsNull(versions2);
            Test.If.Reference.IsEqual(versions1, versions2);
            Test.If.Value.IsEqual(versions1.Count, 29);

            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new Version(1, 1));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new Version(1, 2));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new Version(1, 2));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new Version(1, 3));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new Version(2, 0));

            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new Version(1, 6));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new Version(1, 6));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new Version(2, 0));
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new Version(2, 1));

            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), null);
            DDTNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), null);

        }

        void DDTNetStandardVersions(RuntimeInfo input, Version expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Version version = null;

            Test.Note($"RuntimesHelper.NetStandardVersions[{input.Format()}] == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => version = RuntimesHelper.NetStandardVersions[input], out Exception ex, _file, _method);
            Test.If.Value.IsEqual(version, expected, _file, _method);

        }

        #endregion

        #region TryParseTFM

        [TestMethod]
        void TryParseTFM() {

            DDTTryParseTFM("net40", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseTFM("net45", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))));
            DDTTryParseTFM("net451", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1))));
            DDTTryParseTFM("net452", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2))));
            DDTTryParseTFM("net46", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))));
            DDTTryParseTFM("net461", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1))));
            DDTTryParseTFM("net462", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2))));
            DDTTryParseTFM("net47", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7))));
            DDTTryParseTFM("net471", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1))));
            DDTTryParseTFM("net472", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2))));
            DDTTryParseTFM("net48", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))));

            DDTTryParseTFM("netcoreapp1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))));
            DDTTryParseTFM("netcoreapp1.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))));
            DDTTryParseTFM("netcoreapp2.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))));
            DDTTryParseTFM("netcoreapp2.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1))));
            DDTTryParseTFM("netcoreapp2.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2))));
            DDTTryParseTFM("netcoreapp3.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))));
            DDTTryParseTFM("netcoreapp3.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1))));

            DDTTryParseTFM("netstandard1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseTFM("netstandard1.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))));
            DDTTryParseTFM("netstandard1.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))));
            DDTTryParseTFM("netstandard1.3", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))));
            DDTTryParseTFM("netstandard1.4", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))));
            DDTTryParseTFM("netstandard1.5", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))));
            DDTTryParseTFM("netstandard1.6", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))));
            DDTTryParseTFM("netstandard2.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))));
            DDTTryParseTFM("netstandard2.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))));

            DDTTryParseTFM(null, (false, null));
            DDTTryParseTFM("", (false, null));
            DDTTryParseTFM(" ", (false, null));
            DDTTryParseTFM("bad_tfm", (false, null));
            DDTTryParseTFM("NET40", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseTFM("NeT40", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseTFM(" net40", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseTFM("net40 ", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseTFM(" net40 ", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));

        }

        void DDTTryParseTFM(String input, (Boolean result, RuntimeInfo info) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            RuntimeInfo info = null;

            Test.Note($"RuntimesHelper.TryParseTFM({input.Format()}, out {expected.info.Format()}) = {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryParseTFM(input, out info), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);

            if(expected.result) {
                Test.If.Value.IsEqual(info, expected.info, _file, _method);
            }

        }

        #endregion

        #region SplitTFM

        [TestMethod]
        void SplitTFM() {

            DDTSplitTFM(null, (false, FrameworkIdentifiers.Unsupported, null));
            DDTSplitTFM("", (false, FrameworkIdentifiers.Unsupported, null));
            DDTSplitTFM(" ", (false, FrameworkIdentifiers.Unsupported, null));
            DDTSplitTFM("bad_tfm", (false, FrameworkIdentifiers.Unsupported, null));
            DDTSplitTFM("NET40", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            DDTSplitTFM("NeT40", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            DDTSplitTFM(" net40", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            DDTSplitTFM("net40 ", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            DDTSplitTFM(" net40 ", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));

            DDTSplitTFM("net40", (true, FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            DDTSplitTFM("net45", (true, FrameworkIdentifiers.NETFramework, new Version(4, 5)));
            DDTSplitTFM("net451", (true, FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)));
            DDTSplitTFM("net452", (true, FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)));
            DDTSplitTFM("net46", (true, FrameworkIdentifiers.NETFramework, new Version(4, 6)));
            DDTSplitTFM("net461", (true, FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)));
            DDTSplitTFM("net462", (true, FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)));
            DDTSplitTFM("net47", (true, FrameworkIdentifiers.NETFramework, new Version(4, 7)));
            DDTSplitTFM("net471", (true, FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)));
            DDTSplitTFM("net472", (true, FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)));
            DDTSplitTFM("net48", (true, FrameworkIdentifiers.NETFramework, new Version(4, 8)));

            DDTSplitTFM("netcoreapp1.0", (true, FrameworkIdentifiers.NETCoreApp, new Version(1, 0)));
            DDTSplitTFM("netcoreapp1.1", (true, FrameworkIdentifiers.NETCoreApp, new Version(1, 1)));
            DDTSplitTFM("netcoreapp2.0", (true, FrameworkIdentifiers.NETCoreApp, new Version(2, 0)));
            DDTSplitTFM("netcoreapp2.1", (true, FrameworkIdentifiers.NETCoreApp, new Version(2, 1)));
            DDTSplitTFM("netcoreapp2.2", (true, FrameworkIdentifiers.NETCoreApp, new Version(2, 2)));
            DDTSplitTFM("netcoreapp3.0", (true, FrameworkIdentifiers.NETCoreApp, new Version(3, 0)));
            DDTSplitTFM("netcoreapp3.1", (true, FrameworkIdentifiers.NETCoreApp, new Version(3, 1)));

            DDTSplitTFM("netstandard1.0", (true, FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTSplitTFM("netstandard1.1", (true, FrameworkIdentifiers.NETStandard, new Version(1, 1)));
            DDTSplitTFM("netstandard1.2", (true, FrameworkIdentifiers.NETStandard, new Version(1, 2)));
            DDTSplitTFM("netstandard1.3", (true, FrameworkIdentifiers.NETStandard, new Version(1, 3)));
            DDTSplitTFM("netstandard1.4", (true, FrameworkIdentifiers.NETStandard, new Version(1, 4)));
            DDTSplitTFM("netstandard1.5", (true, FrameworkIdentifiers.NETStandard, new Version(1, 5)));
            DDTSplitTFM("netstandard1.6", (true, FrameworkIdentifiers.NETStandard, new Version(1, 6)));
            DDTSplitTFM("netstandard2.0", (true, FrameworkIdentifiers.NETStandard, new Version(2, 0)));
            DDTSplitTFM("netstandard2.1", (true, FrameworkIdentifiers.NETStandard, new Version(2, 1)));

        }

        void DDTSplitTFM(String input, (Boolean result, FrameworkIdentifiers identifier, Version version) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;
            FrameworkIdentifiers identifier = default;
            Version version = default;

            Test.Note($"RuntimesHelper.SplitTFM({input.Format()}, out {expected.identifier.Format()}, out {expected.version.Format()}) = {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.SplitTFM(input, out identifier, out version), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(identifier, expected.identifier, _file, _method);
            Test.If.Value.IsEqual(version, expected.version, _file, _method);

        }

        #endregion

        #region TryParseFullName

        [TestMethod]
        void TryParseFullName() {

            DDTTryParseFullName(".NetFramework,Version=v4.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseFullName(".NetFramework,Version=v4.5", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))));
            DDTTryParseFullName(".NetFramework,Version=v4.5.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1))));
            DDTTryParseFullName(".NetFramework,Version=v4.5.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2))));
            DDTTryParseFullName(".NetFramework,Version=v4.6", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))));
            DDTTryParseFullName(".NetFramework,Version=v4.6.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1))));
            DDTTryParseFullName(".NetFramework,Version=v4.6.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2))));
            DDTTryParseFullName(".NetFramework,Version=v4.7", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7))));
            DDTTryParseFullName(".NetFramework,Version=v4.7.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1))));
            DDTTryParseFullName(".NetFramework,Version=v4.7.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2))));
            DDTTryParseFullName(".NetFramework,Version=v4.8", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))));

            DDTTryParseFullName(".NETCoreApp,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))));
            DDTTryParseFullName(".NETCoreApp,Version=v1.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))));
            DDTTryParseFullName(".NETCoreApp,Version=v2.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))));
            DDTTryParseFullName(".NETCoreApp,Version=v2.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1))));
            DDTTryParseFullName(".NETCoreApp,Version=v2.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2))));
            DDTTryParseFullName(".NETCoreApp,Version=v3.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))));
            DDTTryParseFullName(".NETCoreApp,Version=v3.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1))));

            DDTTryParseFullName(".NETStandard,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(".NETStandard,Version=v1.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))));
            DDTTryParseFullName(".NETStandard,Version=v1.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))));
            DDTTryParseFullName(".NETStandard,Version=v1.3", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))));
            DDTTryParseFullName(".NETStandard,Version=v1.4", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))));
            DDTTryParseFullName(".NETStandard,Version=v1.5", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))));
            DDTTryParseFullName(".NETStandard,Version=v1.6", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))));
            DDTTryParseFullName(".NETStandard,Version=v2.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))));
            DDTTryParseFullName(".NETStandard,Version=v2.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))));

            DDTTryParseFullName("NetFramework,Version=v4.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseFullName("NETCoreApp,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))));
            DDTTryParseFullName("NETStandard,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(" .NETStandard,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(".NETStandard ,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(".NETStandard, Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(".NETStandard,Version =v1.0", (false, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(".NETStandard,Version= v1.0", (false, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(".NETStandard,Version=v 1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseFullName(".NETStandard,Version=v1.0 ", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));

        }

        void DDTTryParseFullName(String input, (Boolean result, RuntimeInfo info) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            RuntimeInfo info = null;

            Test.Note($"RuntimesHelper.TryParseFullName({input.Format()}, out {expected.info.Format()}) = {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryParseFullName(input, out info), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);

            if(expected.result) {
                Test.If.Value.IsEqual(info, expected.info, _file, _method);
            }

        }

        #endregion

        #region ParseParts

        [TestMethod]
        void ParseParts() {

            DDTParseParts(".NetFramework,Version=v4.0", (FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            DDTParseParts(".NetFramework,Version=v4.5.1", (FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)));
            DDTParseParts(".NetFramework,Version=v4.5.2", (FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)));
            DDTParseParts(".NetFramework,Version=v4.6", (FrameworkIdentifiers.NETFramework, new Version(4, 6)));
            DDTParseParts(".NetFramework,Version=v4.6.1", (FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)));
            DDTParseParts(".NetFramework,Version=v4.6.2", (FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)));
            DDTParseParts(".NetFramework,Version=v4.7", (FrameworkIdentifiers.NETFramework, new Version(4, 7)));
            DDTParseParts(".NetFramework,Version=v4.7.1", (FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)));
            DDTParseParts(".NetFramework,Version=v4.7.2", (FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)));
            DDTParseParts(".NetFramework,Version=v4.8", (FrameworkIdentifiers.NETFramework, new Version(4, 8)));

            DDTParseParts(".NETCoreApp,Version=v1.0", (FrameworkIdentifiers.NETCoreApp, new Version(1, 0)));
            DDTParseParts(".NETCoreApp,Version=v1.1", (FrameworkIdentifiers.NETCoreApp, new Version(1, 1)));
            DDTParseParts(".NETCoreApp,Version=v2.0", (FrameworkIdentifiers.NETCoreApp, new Version(2, 0)));
            DDTParseParts(".NETCoreApp,Version=v2.1", (FrameworkIdentifiers.NETCoreApp, new Version(2, 1)));
            DDTParseParts(".NETCoreApp,Version=v2.2", (FrameworkIdentifiers.NETCoreApp, new Version(2, 2)));
            DDTParseParts(".NETCoreApp,Version=v3.0", (FrameworkIdentifiers.NETCoreApp, new Version(3, 0)));
            DDTParseParts(".NETCoreApp,Version=v3.1", (FrameworkIdentifiers.NETCoreApp, new Version(3, 1)));

            DDTParseParts(".NETStandard,Version=v1.0", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTParseParts(".NETStandard,Version=v1.1", (FrameworkIdentifiers.NETStandard, new Version(1, 1)));
            DDTParseParts(".NETStandard,Version=v1.2", (FrameworkIdentifiers.NETStandard, new Version(1, 2)));
            DDTParseParts(".NETStandard,Version=v1.3", (FrameworkIdentifiers.NETStandard, new Version(1, 3)));
            DDTParseParts(".NETStandard,Version=v1.4", (FrameworkIdentifiers.NETStandard, new Version(1, 4)));
            DDTParseParts(".NETStandard,Version=v1.5", (FrameworkIdentifiers.NETStandard, new Version(1, 5)));
            DDTParseParts(".NETStandard,Version=v1.6", (FrameworkIdentifiers.NETStandard, new Version(1, 6)));
            DDTParseParts(".NETStandard,Version=v2.0", (FrameworkIdentifiers.NETStandard, new Version(2, 0)));
            DDTParseParts(".NETStandard,Version=v2.1", (FrameworkIdentifiers.NETStandard, new Version(2, 1)));

            DDTParseParts("NetFramework,Version=v4.0", (FrameworkIdentifiers.NETFramework, new Version(4, 0)));
            DDTParseParts("NETCoreApp,Version=v1.0", (FrameworkIdentifiers.NETCoreApp, new Version(1, 0)));
            DDTParseParts("NETStandard,Version=v1.0", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTParseParts("NotAFramework,Version=v1.0", (FrameworkIdentifiers.Unsupported, new Version(1, 0)));
            DDTParseParts(".NETStandard,Version=v1.0", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTParseParts(" .NETStandard,Version=v1.0", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTParseParts(".NETStandard ,Version=v1.0", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTParseParts(".NETStandard, Version=v1.0", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTParseParts(".NETStandard,Version =v1.0", (FrameworkIdentifiers.NETStandard, null));
            DDTParseParts(".NETStandard,Version= v1.0", (FrameworkIdentifiers.NETStandard, null));
            DDTParseParts(".NETStandard,Version=v 1.0", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));
            DDTParseParts(".NETStandard,Version=v1.0 ", (FrameworkIdentifiers.NETStandard, new Version(1, 0)));

        }

        void DDTParseParts(String input, (FrameworkIdentifiers framework, Version version) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            FrameworkIdentifiers framework = (FrameworkIdentifiers) (-1);
            Version version = null;

            Test.Note($"RuntimesHelper.ParseParts({input.Format()}, out {expected.framework.Format()}, out {expected.version.Format()})", _file, _method);

            Test.IfNot.Action.ThrowsException(() => RuntimesHelper.ParseParts(input, out framework, out version), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(framework, expected.framework, _file, _method);
            Test.If.Value.IsEqual(version, expected.version, _file, _method);

        }

        #endregion

        #region TryGetStandardVersion

        [TestMethod]
        void TryGetStandardVersion() {

            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), (true, new Version(1, 1)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), (true, new Version(1, 2)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), (true, new Version(1, 2)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), (true, new Version(1, 3)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), (true, new Version(2, 0)));

            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (true, new Version(1, 6)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), (true, new Version(1, 6)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), (true, new Version(2, 0)));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), (true, new Version(2, 1)));

            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), (false, null));
            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), (false, null));

            DDTTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), (false, null));

        }

        void DDTTryGetStandardVersion(RuntimeInfo input, (Boolean result, Version version) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            Version version = null;

            Test.Note($"RuntimesHelper.TryGetStandardVersion({input.Format()}, out {expected.version.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetStandardVersion(input, out version), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(version, expected.version, _file, _method);

        }

        #endregion

        #region TryGetMatchingRuntimes

        [TestMethod]
        void TryGetMatchingRuntimes() {

            DDTTryGetMatchingRuntimes(null, (false, Enumerable.Empty<RuntimeInfo>()));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), (false, Enumerable.Empty<RuntimeInfo>()));

            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));

            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));

            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));

        }

        void DDTTryGetMatchingRuntimes(RuntimeInfo input, (Boolean result, IEnumerable<RuntimeInfo> runtimes) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            IEnumerable<RuntimeInfo> runtimes = null;

            Test.Note($"RuntimesHelper.TryGetMatchingRuntimes({input.Format()}, out {expected.runtimes.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetMatchingRuntimes(input, out runtimes), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes, _file, _method);

        }

        #endregion

        #region TryGetLowestMatchingRuntimes

        [TestMethod]
        void TryGetLowestMatchingRuntimes() {

            DDTTryGetLowestMatchingRuntimes(null, (false, Enumerable.Empty<RuntimeInfo>()));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), (false, Enumerable.Empty<RuntimeInfo>()));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
            }));

            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));

            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2) ),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));

            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
            }));
            DDTTryGetLowestMatchingRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));

        }

        void DDTTryGetLowestMatchingRuntimes(RuntimeInfo input, (Boolean result, IEnumerable<RuntimeInfo> runtimes) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            IEnumerable<RuntimeInfo> runtimes = null;

            Test.Note($"RuntimesHelper.TryGetLowestMatchingRuntimes({input.Format()}, out {expected.runtimes.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetLowestMatchingRuntimes(input, out runtimes), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes, _file, _method);

        }

        #endregion

        #region TryGetLoadableRuntimes

        [TestMethod]
        void TryGetLoadableRuntimes() {

            DDTTryGetLoadableRuntimes(null, (false, Enumerable.Empty<RuntimeInfo>()));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), (false, Enumerable.Empty<RuntimeInfo>()));

            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
            }));

            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));

            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
            }));
            DDTTryGetLoadableRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
            }));

        }

        void DDTTryGetLoadableRuntimes(RuntimeInfo input, (Boolean result, IEnumerable<RuntimeInfo> runtimes) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            IEnumerable<RuntimeInfo> runtimes = null;

            Test.Note($"RuntimesHelper.TryGetLoadableRuntimes({input.Format()}, out {expected.runtimes.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetLoadableRuntimes(input, out runtimes), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes, _file, _method);

        }

        #endregion

        #region TryGetLoadableRuntimesSorted

        [TestMethod]
        void TryGetLoadableRuntimesSorted() {

            DDTTryGetLoadableRuntimesSorted((null, true), (false, new List<RuntimeInfo>()));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), true), (false, new List<RuntimeInfo>()));

            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));

            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
            }));

            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), true), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
            }));

            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), false), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), false), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            DDTTryGetLoadableRuntimesSorted((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), false), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
            }));

        }

        void DDTTryGetLoadableRuntimesSorted((RuntimeInfo runtime, Boolean sortDesc) input, (Boolean result, List<RuntimeInfo> runtimes) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            List<RuntimeInfo> runtimes = null;

            Test.Note($"RuntimesHelper.TryGetLoadableRuntimes({input.runtime.Format()}, {input.sortDesc.Format()}, out {expected.runtimes.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetLoadableRuntimes(input.runtime, input.sortDesc, out runtimes), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.MatchesExactly(runtimes, expected.runtimes, _file, _method);

        }

        #endregion

    }
}
