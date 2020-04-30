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
            
        }

        [TestMethod]
        [TestData(nameof(NetStandardVersionsIndexerData))]
        void NetStandardVersionsIndexer(RuntimeInfo input, Version expected) {

            Version version = null;

            Test.IfNot.Action.ThrowsException(() => version = RuntimesHelper.NetStandardVersions[input], out Exception ex);
         
            Test.If.Value.IsEqual(version, expected);

        }

        IEnumerable<Object[]> NetStandardVersionsIndexerData() {
            return new List<Object[]>() {
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new Version(1, 1) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new Version(1, 2) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new Version(1, 2) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new Version(1, 3) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new Version(2, 0) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new Version(1, 6) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new Version(1, 6) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new Version(2, 1) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), null },
            };
        }

        #endregion

        #region TryParseTFM

        [TestMethod]
        [TestData(nameof(TryParseTFMData))]
        void TryParseTFM(String input, Boolean result, RuntimeInfo info) {

            Boolean _result = false;
            RuntimeInfo _info = null;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.TryParseTFM(input, out _info), out Exception ex);

            Test.If.Value.IsEqual(_result, result);

            if(result) {
                Test.If.Value.IsEqual(_info, info);
            }

        }

        IEnumerable<Object[]> TryParseTFMData() {
            return new List<Object[]>() {
                new Object[] { "net40", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
                new Object[] { "net45", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)) },
                new Object[] { "net451", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)) },
                new Object[] { "net452", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)) },
                new Object[] { "net46", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)) },
                new Object[] { "net461", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)) },
                new Object[] { "net462", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)) },
                new Object[] { "net47", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)) },
                new Object[] { "net471", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)) },
                new Object[] { "net472", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)) },
                new Object[] { "net48", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)) },

                new Object[] { "netcoreapp1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)) },
                new Object[] { "netcoreapp1.1", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)) },
                new Object[] { "netcoreapp2.0", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)) },
                new Object[] { "netcoreapp2.1", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)) },
                new Object[] { "netcoreapp2.2", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)) },
                new Object[] { "netcoreapp3.0", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)) },
                new Object[] { "netcoreapp3.1", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)) },

                new Object[] { "netstandard1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { "netstandard1.1", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)) },
                new Object[] { "netstandard1.2", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)) },
                new Object[] { "netstandard1.3", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)) },
                new Object[] { "netstandard1.4", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)) },
                new Object[] { "netstandard1.5", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)) },
                new Object[] { "netstandard1.6", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)) },
                new Object[] { "netstandard2.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)) },
                new Object[] { "netstandard2.1", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)) },

                new Object[] { null, false, null },
                new Object[] { "", false, null },
                new Object[] { " ", false, null },
                new Object[] { "bad_tfm", false, null },
                new Object[] { "NET40", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
                new Object[] { "NeT40", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
                new Object[] { " net40", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
                new Object[] { "net40 ", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
                new Object[] { " net40 ", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
            };
        }

        #endregion

        #region SplitTFM

        [TestMethod]
        [TestData(nameof(SplitTFMData))]
        void SplitTFM(String input, Boolean result, FrameworkIdentifiers identifier, Version version) {

            Boolean _result = default;
            FrameworkIdentifiers _identifier = default;
            Version _version = default;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.SplitTFM(input, out _identifier, out _version), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Value.IsEqual(_identifier, identifier);
            Test.If.Value.IsEqual(_version, version);

        }

        IEnumerable<Object[]> SplitTFMData() {
            return new List<Object[]>() {
                new Object[] { null, false, FrameworkIdentifiers.Unsupported, null },
                new Object[] { "", false, FrameworkIdentifiers.Unsupported, null },
                new Object[] { " ", false, FrameworkIdentifiers.Unsupported, null },
                new Object[] { "bad_tfm", false, FrameworkIdentifiers.Unsupported, null },
                new Object[] { "NET40", true, FrameworkIdentifiers.NETFramework, new Version(4, 0) },
                new Object[] { "NeT40", true, FrameworkIdentifiers.NETFramework, new Version(4, 0) },
                new Object[] { " net40", true, FrameworkIdentifiers.NETFramework, new Version(4, 0) },
                new Object[] { "net40 ", true, FrameworkIdentifiers.NETFramework, new Version(4, 0) },
                new Object[] { " net40 ", true, FrameworkIdentifiers.NETFramework, new Version(4, 0) },

                new Object[] { "net40", true, FrameworkIdentifiers.NETFramework, new Version(4, 0) },
                new Object[] { "net45", true, FrameworkIdentifiers.NETFramework, new Version(4, 5) },
                new Object[] { "net451", true, FrameworkIdentifiers.NETFramework, new Version(4, 5, 1) },
                new Object[] { "net452", true, FrameworkIdentifiers.NETFramework, new Version(4, 5, 2) },
                new Object[] { "net46", true, FrameworkIdentifiers.NETFramework, new Version(4, 6) },
                new Object[] { "net461", true, FrameworkIdentifiers.NETFramework, new Version(4, 6, 1) },
                new Object[] { "net462", true, FrameworkIdentifiers.NETFramework, new Version(4, 6, 2) },
                new Object[] { "net47", true, FrameworkIdentifiers.NETFramework, new Version(4, 7) },
                new Object[] { "net471", true, FrameworkIdentifiers.NETFramework, new Version(4, 7, 1) },
                new Object[] { "net472", true, FrameworkIdentifiers.NETFramework, new Version(4, 7, 2) },
                new Object[] { "net48", true, FrameworkIdentifiers.NETFramework, new Version(4, 8) },

                new Object[] { "netcoreapp1.0", true, FrameworkIdentifiers.NETCoreApp, new Version(1, 0) },
                new Object[] { "netcoreapp1.1", true, FrameworkIdentifiers.NETCoreApp, new Version(1, 1) },
                new Object[] { "netcoreapp2.0", true, FrameworkIdentifiers.NETCoreApp, new Version(2, 0) },
                new Object[] { "netcoreapp2.1", true, FrameworkIdentifiers.NETCoreApp, new Version(2, 1) },
                new Object[] { "netcoreapp2.2", true, FrameworkIdentifiers.NETCoreApp, new Version(2, 2) },
                new Object[] { "netcoreapp3.0", true, FrameworkIdentifiers.NETCoreApp, new Version(3, 0) },
                new Object[] { "netcoreapp3.1", true, FrameworkIdentifiers.NETCoreApp, new Version(3, 1) },

                new Object[] { "netstandard1.0", true, FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { "netstandard1.1", true, FrameworkIdentifiers.NETStandard, new Version(1, 1) },
                new Object[] { "netstandard1.2", true, FrameworkIdentifiers.NETStandard, new Version(1, 2) },
                new Object[] { "netstandard1.3", true, FrameworkIdentifiers.NETStandard, new Version(1, 3) },
                new Object[] { "netstandard1.4", true, FrameworkIdentifiers.NETStandard, new Version(1, 4) },
                new Object[] { "netstandard1.5", true, FrameworkIdentifiers.NETStandard, new Version(1, 5) },
                new Object[] { "netstandard1.6", true, FrameworkIdentifiers.NETStandard, new Version(1, 6) },
                new Object[] { "netstandard2.0", true, FrameworkIdentifiers.NETStandard, new Version(2, 0) },
                new Object[] { "netstandard2.1", true, FrameworkIdentifiers.NETStandard, new Version(2, 1) },
            };
        }

        #endregion

        #region TryParseFullName

        [TestMethod]
        [TestData(nameof(TryParseFullNameData))]
        void TryParseFullName(String input, Boolean result, RuntimeInfo info) {

            Boolean _result = false;
            RuntimeInfo _info = null;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.TryParseFullName(input, out _info), out Exception ex);

            Test.If.Value.IsEqual(_result, result);

            if(result) {
                Test.If.Value.IsEqual(_info, info);
            }

        }

        IEnumerable<Object[]> TryParseFullNameData() {
            return new List<Object[]>() {
                new Object[] { ".NetFramework,Version=v4.0", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
                new Object[] { ".NetFramework,Version=v4.5", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)) },
                new Object[] { ".NetFramework,Version=v4.5.1", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)) },
                new Object[] { ".NetFramework,Version=v4.5.2", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)) },
                new Object[] { ".NetFramework,Version=v4.6", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)) },
                new Object[] { ".NetFramework,Version=v4.6.1", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)) },
                new Object[] { ".NetFramework,Version=v4.6.2", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)) },
                new Object[] { ".NetFramework,Version=v4.7", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)) },
                new Object[] { ".NetFramework,Version=v4.7.1", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)) },
                new Object[] { ".NetFramework,Version=v4.7.2", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)) },
                new Object[] { ".NetFramework,Version=v4.8", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)) },

                new Object[] { ".NETCoreApp,Version=v1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)) },
                new Object[] { ".NETCoreApp,Version=v1.1", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)) },
                new Object[] { ".NETCoreApp,Version=v2.0", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)) },
                new Object[] { ".NETCoreApp,Version=v2.1", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)) },
                new Object[] { ".NETCoreApp,Version=v2.2", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)) },
                new Object[] { ".NETCoreApp,Version=v3.0", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)) },
                new Object[] { ".NETCoreApp,Version=v3.1", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)) },

                new Object[] { ".NETStandard,Version=v1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { ".NETStandard,Version=v1.1", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)) },
                new Object[] { ".NETStandard,Version=v1.2", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)) },
                new Object[] { ".NETStandard,Version=v1.3", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)) },
                new Object[] { ".NETStandard,Version=v1.4", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)) },
                new Object[] { ".NETStandard,Version=v1.5", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)) },
                new Object[] { ".NETStandard,Version=v1.6", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)) },
                new Object[] { ".NETStandard,Version=v2.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)) },
                new Object[] { ".NETStandard,Version=v2.1", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)) },

                new Object[] { "NetFramework,Version=v4.0", true, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)) },
                new Object[] { "NETCoreApp,Version=v1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)) },
                new Object[] { "NETStandard,Version=v1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { " .NETStandard,Version=v1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { ".NETStandard ,Version=v1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { ".NETStandard, Version=v1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { ".NETStandard,Version =v1.0", false, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { ".NETStandard,Version= v1.0", false, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { ".NETStandard,Version=v 1.0", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { ".NETStandard,Version=v1.0 ", true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
            };
        }

        #endregion

        #region ParseParts

        [TestMethod]
        [TestData(nameof(ParsePartsData))]
        void ParseParts(String input, FrameworkIdentifiers framework, Version version) {

            FrameworkIdentifiers _framework = (FrameworkIdentifiers) (-1);
            Version _version = null;

            Test.IfNot.Action.ThrowsException(() => RuntimesHelper.ParseParts(input, out _framework, out _version), out Exception ex);

            Test.If.Value.IsEqual(_framework, framework);
            Test.If.Value.IsEqual(_version, version);

        }

        IEnumerable<Object[]> ParsePartsData() {
            return new List<Object[]>() {
                new Object[] { ".NetFramework,Version=v4.0", FrameworkIdentifiers.NETFramework, new Version(4, 0) },
                new Object[] { ".NetFramework,Version=v4.5.1", FrameworkIdentifiers.NETFramework, new Version(4, 5, 1) },
                new Object[] { ".NetFramework,Version=v4.5.2", FrameworkIdentifiers.NETFramework, new Version(4, 5, 2) },
                new Object[] { ".NetFramework,Version=v4.6", FrameworkIdentifiers.NETFramework, new Version(4, 6) },
                new Object[] { ".NetFramework,Version=v4.6.1", FrameworkIdentifiers.NETFramework, new Version(4, 6, 1) },
                new Object[] { ".NetFramework,Version=v4.6.2", FrameworkIdentifiers.NETFramework, new Version(4, 6, 2) },
                new Object[] { ".NetFramework,Version=v4.7", FrameworkIdentifiers.NETFramework, new Version(4, 7) },
                new Object[] { ".NetFramework,Version=v4.7.1", FrameworkIdentifiers.NETFramework, new Version(4, 7, 1) },
                new Object[] { ".NetFramework,Version=v4.7.2", FrameworkIdentifiers.NETFramework, new Version(4, 7, 2) },
                new Object[] { ".NetFramework,Version=v4.8", FrameworkIdentifiers.NETFramework, new Version(4, 8) },

                new Object[] { ".NETCoreApp,Version=v1.0", FrameworkIdentifiers.NETCoreApp, new Version(1, 0) },
                new Object[] { ".NETCoreApp,Version=v1.1", FrameworkIdentifiers.NETCoreApp, new Version(1, 1) },
                new Object[] { ".NETCoreApp,Version=v2.0", FrameworkIdentifiers.NETCoreApp, new Version(2, 0) },
                new Object[] { ".NETCoreApp,Version=v2.1", FrameworkIdentifiers.NETCoreApp, new Version(2, 1) },
                new Object[] { ".NETCoreApp,Version=v2.2", FrameworkIdentifiers.NETCoreApp, new Version(2, 2) },
                new Object[] { ".NETCoreApp,Version=v3.0", FrameworkIdentifiers.NETCoreApp, new Version(3, 0) },
                new Object[] { ".NETCoreApp,Version=v3.1", FrameworkIdentifiers.NETCoreApp, new Version(3, 1) },

                new Object[] { ".NETStandard,Version=v1.0", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { ".NETStandard,Version=v1.1", FrameworkIdentifiers.NETStandard, new Version(1, 1) },
                new Object[] { ".NETStandard,Version=v1.2", FrameworkIdentifiers.NETStandard, new Version(1, 2) },
                new Object[] { ".NETStandard,Version=v1.3", FrameworkIdentifiers.NETStandard, new Version(1, 3) },
                new Object[] { ".NETStandard,Version=v1.4", FrameworkIdentifiers.NETStandard, new Version(1, 4) },
                new Object[] { ".NETStandard,Version=v1.5", FrameworkIdentifiers.NETStandard, new Version(1, 5) },
                new Object[] { ".NETStandard,Version=v1.6", FrameworkIdentifiers.NETStandard, new Version(1, 6) },
                new Object[] { ".NETStandard,Version=v2.0", FrameworkIdentifiers.NETStandard, new Version(2, 0) },
                new Object[] { ".NETStandard,Version=v2.1", FrameworkIdentifiers.NETStandard, new Version(2, 1) },

                new Object[] { "NetFramework,Version=v4.0", FrameworkIdentifiers.NETFramework, new Version(4, 0) },
                new Object[] { "NETCoreApp,Version=v1.0", FrameworkIdentifiers.NETCoreApp, new Version(1, 0) },
                new Object[] { "NETStandard,Version=v1.0", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { "NotAFramework,Version=v1.0", FrameworkIdentifiers.Unsupported, new Version(1, 0) },
                new Object[] { ".NETStandard,Version=v1.0", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { " .NETStandard,Version=v1.0", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { ".NETStandard ,Version=v1.0", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { ".NETStandard, Version=v1.0", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { ".NETStandard,Version =v1.0", FrameworkIdentifiers.NETStandard, null },
                new Object[] { ".NETStandard,Version= v1.0", FrameworkIdentifiers.NETStandard, null },
                new Object[] { ".NETStandard,Version=v 1.0", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
                new Object[] { ".NETStandard,Version=v1.0 ", FrameworkIdentifiers.NETStandard, new Version(1, 0) },
            };
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

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetStandardVersion(input, out version), out Exception ex);
         
            Test.If.Value.IsEqual(result, expected.result);
            Test.If.Value.IsEqual(version, expected.version);

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

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetMatchingRuntimes(input, out runtimes), out Exception ex);
       
            Test.If.Value.IsEqual(result, expected.result);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes);

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

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetLowestMatchingRuntimes(input, out runtimes), out Exception ex);
       
            Test.If.Value.IsEqual(result, expected.result);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes);

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

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetLoadableRuntimes(input, out runtimes), out Exception ex);
     
            Test.If.Value.IsEqual(result, expected.result);
            Test.If.Enumerable.Matches(runtimes, expected.runtimes);

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

            Test.IfNot.Action.ThrowsException(() => result = RuntimesHelper.TryGetLoadableRuntimes(input.runtime, input.sortDesc, out runtimes), out Exception ex);
   
            Test.If.Value.IsEqual(result, expected.result);
            Test.If.Enumerable.MatchesExactly(runtimes, expected.runtimes);

        }

        #endregion

    }
}
