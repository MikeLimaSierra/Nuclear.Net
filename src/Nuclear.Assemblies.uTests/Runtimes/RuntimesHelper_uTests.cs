using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Runtimes {
    class RuntimesHelper_uTests {

        #region properties

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

            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new Version(1, 1));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new Version(1, 2));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new Version(1, 2));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new Version(1, 3));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new Version(2, 0));

            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new Version(1, 6));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new Version(1, 6));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new Version(2, 0));
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new Version(2, 1));

            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), null);
            TTDNetStandardVersions(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), null);

        }

        void TTDNetStandardVersions(RuntimeInfo input, Version expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Version version = null;

            Test.Note($"RuntimesHelper.NetStandardVersions[{input.Format()}] == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => version = RuntimesHelper.NetStandardVersions[input], out Exception ex, _file, _method);
            Test.If.Value.IsEqual(version, expected, _file, _method);

        }

        #endregion

        #region TryGetStandardVersion

        [TestMethod]
        void TryGetStandardVersion() {

            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), (true, new Version(1, 1)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), (true, new Version(1, 2)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), (true, new Version(1, 2)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), (true, new Version(1, 3)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), (true, new Version(2, 0)));

            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (true, new Version(1, 6)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), (true, new Version(1, 6)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), (true, new Version(2, 0)));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), (true, new Version(2, 1)));

            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), (false, null));
            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), (false, null));

            TTDTryGetStandardVersion(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), (false, null));

        }

        void TTDTryGetStandardVersion(RuntimeInfo input, (Boolean result, Version version) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            Version version = null;

            Test.Note($"RuntimesHelper.TryGetStandardVersion({input.Format()}, out {expected.version.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetStandardVersion(input, out version), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(version, expected.version, _file, _method);

        }

        #endregion

        #region TryGetSupportedRuntimes

        [TestMethod]
        void TryGetSupportedRuntimes() {

            TTDTryGetSupportedRuntimes(null, (false, Enumerable.Empty<RuntimeInfo>()));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), (false, Enumerable.Empty<RuntimeInfo>()));

            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));

            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
            }));

            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), (true, new List<RuntimeInfo>() {
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
            TTDTryGetSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), (true, new List<RuntimeInfo>() {
                new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
            }));

        }

        void TTDTryGetSupportedRuntimes(RuntimeInfo input, (Boolean result, IEnumerable<RuntimeInfo> runtimes) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            IEnumerable<RuntimeInfo> runtimes = null;

            Test.Note($"RuntimesHelper.TryGetSupportedRuntimes({input.Format()}, out {expected.runtimes.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetSupportedRuntimes(input, out runtimes), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes, _file, _method);

        }

        #endregion

        #region TryGetMinimumSupportedRuntimes

        [TestMethod]
        void TryGetMinimumSupportedRuntimes() {

            TTDTryGetMinimumSupportedRuntimes(null, (false, new Dictionary<FrameworkIdentifiers, Version>()));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), (false, new Dictionary<FrameworkIdentifiers, Version>()));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), (false, new Dictionary<FrameworkIdentifiers, Version>()));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 2)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(1, 1) } }));

            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETCoreApp, new Version(1, 1) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETCoreApp, new Version(2, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETCoreApp, new Version(2, 1) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETCoreApp, new Version(2, 2) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETCoreApp, new Version(3, 0) } }));

            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(1, 1) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(2, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(3, 5) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 5) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 5, 1) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 5, 2) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6, 1) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6, 2) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 7) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 7, 1) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 7, 2) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 8) } }));

            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 5) }, { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 5) }, { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 5, 1) }, { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6) }, { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6, 1) }, { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6, 1) }, { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6, 1) }, { FrameworkIdentifiers.NETCoreApp, new Version(1, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETFramework, new Version(4, 6, 1) }, { FrameworkIdentifiers.NETCoreApp, new Version(2, 0) } }));
            TTDTryGetMinimumSupportedRuntimes(new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                (true, new Dictionary<FrameworkIdentifiers, Version>() { { FrameworkIdentifiers.NETCoreApp, new Version(3, 0) } }));

        }

        void TTDTryGetMinimumSupportedRuntimes(RuntimeInfo input, (Boolean result, IDictionary<FrameworkIdentifiers, Version> runtimes) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            IDictionary<FrameworkIdentifiers, Version> runtimes = null;

            Test.Note($"RuntimesHelper.TryGetMinimumSupportedRuntimes({input.Format()}, out {expected.runtimes.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetMinimumSupportedRuntimes(input, out runtimes), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes, _file, _method);

        }

        #endregion

    }
}
