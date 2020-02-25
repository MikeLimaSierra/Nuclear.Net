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

        #region TryParse

        [TestMethod]
        void TryParse() {

            DDTTryParseApi(".NetFramework,Version=v4.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseApi(".NetFramework,Version=v4.5", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5))));
            DDTTryParseApi(".NetFramework,Version=v4.5.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1))));
            DDTTryParseApi(".NetFramework,Version=v4.5.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2))));
            DDTTryParseApi(".NetFramework,Version=v4.6", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6))));
            DDTTryParseApi(".NetFramework,Version=v4.6.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1))));
            DDTTryParseApi(".NetFramework,Version=v4.6.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2))));
            DDTTryParseApi(".NetFramework,Version=v4.7", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7))));
            DDTTryParseApi(".NetFramework,Version=v4.7.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1))));
            DDTTryParseApi(".NetFramework,Version=v4.7.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2))));
            DDTTryParseApi(".NetFramework,Version=v4.8", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8))));

            DDTTryParseApi(".NETCoreApp,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))));
            DDTTryParseApi(".NETCoreApp,Version=v1.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))));
            DDTTryParseApi(".NETCoreApp,Version=v2.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0))));
            DDTTryParseApi(".NETCoreApp,Version=v2.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1))));
            DDTTryParseApi(".NETCoreApp,Version=v2.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2))));
            DDTTryParseApi(".NETCoreApp,Version=v3.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0))));
            DDTTryParseApi(".NETCoreApp,Version=v3.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1))));

            DDTTryParseApi(".NETStandard,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(".NETStandard,Version=v1.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))));
            DDTTryParseApi(".NETStandard,Version=v1.2", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))));
            DDTTryParseApi(".NETStandard,Version=v1.3", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))));
            DDTTryParseApi(".NETStandard,Version=v1.4", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))));
            DDTTryParseApi(".NETStandard,Version=v1.5", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))));
            DDTTryParseApi(".NETStandard,Version=v1.6", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))));
            DDTTryParseApi(".NETStandard,Version=v2.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))));
            DDTTryParseApi(".NETStandard,Version=v2.1", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))));

            DDTTryParseApi("NetFramework,Version=v4.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0))));
            DDTTryParseApi("NETCoreApp,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))));
            DDTTryParseApi("NETStandard,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(" .NETStandard,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(".NETStandard ,Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(".NETStandard, Version=v1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(".NETStandard,Version =v1.0", (false, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(".NETStandard,Version= v1.0", (false, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(".NETStandard,Version=v 1.0", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryParseApi(".NETStandard,Version=v1.0 ", (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));

        }

        void DDTTryParseApi(String input, (Boolean result, RuntimeInfo info) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            RuntimeInfo info = null;

            Test.Note($"RuntimesHelper.TryParse({input.Format()}, out {expected.info.Format()}) = {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryParse(input, out info), out Exception ex, _file, _method);

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

    }
}
