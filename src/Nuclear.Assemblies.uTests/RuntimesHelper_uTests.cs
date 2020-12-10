using System;
using System.Collections.Generic;
using System.Linq;

using Nuclear.Assemblies.Runtimes;
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
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new Version(2, 1) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)), new Version(2, 1) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)), new Version(1, 6) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)), new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)), new Version(2, 1) },

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

                new Object[] { "net5.0", true, new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)) },
                
                // TODO: Add Mono
                //new Object[] { "mono4.6", true, new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)) },
                //new Object[] { "mono5.4", true, new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)) },
                //new Object[] { "mono6.4", true, new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)) },

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

                new Object[] { "net5.0", true, FrameworkIdentifiers.NET, new Version(5, 0) },
                
                // TODO: Add Mono
                //new Object[] { "mono4.6", true, FrameworkIdentifiers.Mono, new Version(4, 6) },
                //new Object[] { "mono5.4", true, FrameworkIdentifiers.Mono, new Version(5, 4) },
                //new Object[] { "mono6.4", true, FrameworkIdentifiers.Mono, new Version(6, 4) },

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

                new Object[] { ".NETCoreApp,Version=v5.0", true, new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)) },

                // TODO: Add Mono
                //new Object[] { "Mono,Version=v4.6", true, new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)) },
                //new Object[] { "Mono,Version=v5.4", true, new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)) },
                //new Object[] { "Mono,Version=v6.4", true, new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)) },

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

                new Object[] { ".NETCoreApp,Version=v5.0", FrameworkIdentifiers.NET, new Version(5, 0) },

                // TODO: Add Mono
                //new Object[] { "Mono,Version=v4.6", FrameworkIdentifiers.Mono, new Version(4, 6) },
                //new Object[] { "Mono,Version=v5.4", FrameworkIdentifiers.Mono, new Version(5, 4) },
                //new Object[] { "Mono,Version=v6.4", FrameworkIdentifiers.Mono, new Version(6, 4) },

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
        [TestData(nameof(TryGetStandardVersionData))]
        void TryGetStandardVersion(RuntimeInfo input, Boolean result, Version version) {

            Boolean _result = false;
            Version _version = null;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.TryGetStandardVersion(input, out _version), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Value.IsEqual(_version, version);

        }

        IEnumerable<Object[]> TryGetStandardVersionData() {
            return new List<Object[]>() {
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), true, new Version(1, 1) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), true, new Version(1, 2) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), true, new Version(1, 2) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), true, new Version(1, 3) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), true, new Version(2, 0) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true, new Version(1, 6) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), true, new Version(1, 6) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), true, new Version(2, 1) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), true, new Version(2, 1) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)), true, new Version(2, 1) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)), true, new Version(1, 6) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)), true, new Version(2, 0) },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)), true, new Version(2, 1) },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), false, null },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), false, null },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), false, null },
            };
        }

        #endregion

        #region TryGetMatchingRuntimes

        [TestMethod]
        [TestData(nameof(TryGetMatchingRuntimesData))]
        void TryGetMatchingRuntimes(RuntimeInfo input, Boolean result, IEnumerable<RuntimeInfo> runtimes) {

            Boolean _result = false;
            IEnumerable<RuntimeInfo> _runtimes = null;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.TryGetMatchingRuntimes(input, out _runtimes), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_runtimes, runtimes);

        }

        IEnumerable<Object[]> TryGetMatchingRuntimesData() {
            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<RuntimeInfo>() },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), false, Enumerable.Empty<RuntimeInfo>() },

                #region Mono
                
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },

                #endregion

                #region NET

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                } },

                #endregion

                #region NETCoreApp

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },

                #endregion

                #region NETFramework

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },

                #endregion

                #region NETStandard

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },

                #endregion

            };
        }

        #endregion

        #region TryGetLowestMatchingRuntimes

        [TestMethod]
        [TestData(nameof(TryGetLowestMatchingRuntimesData))]
        void TryGetLowestMatchingRuntimes(RuntimeInfo input, Boolean result, IEnumerable<RuntimeInfo> runtimes) {

            Boolean _result = false;
            IEnumerable<RuntimeInfo> _runtimes = null;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.TryGetLowestMatchingRuntimes(input, out _runtimes), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_runtimes, runtimes);

        }

        IEnumerable<Object[]> TryGetLowestMatchingRuntimesData() {
            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<RuntimeInfo>() },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), false, Enumerable.Empty<RuntimeInfo>() },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                } },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                } },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2) ),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)),
                } },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
            };
        }

        #endregion

        #region TryGetLoadableRuntimes

        [TestMethod]
        [TestData(nameof(TryGetLoadableRuntimesData))]
        void TryGetLoadableRuntimes(RuntimeInfo input, Boolean result, IEnumerable<RuntimeInfo> runtimes) {

            Boolean _result = false;
            IEnumerable<RuntimeInfo> _runtimes = null;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.TryGetLoadableRuntimes(input, out _runtimes), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_runtimes, runtimes);

        }

        IEnumerable<Object[]> TryGetLoadableRuntimesData() {
            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<RuntimeInfo>() },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), false, Enumerable.Empty<RuntimeInfo>() },

                #region NETCoreApp

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                } },

                #endregion

                #region NET

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                } },

                #endregion

                #region Mono
                
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                } },

                #endregion

                #region NETFramework

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), true, new List<RuntimeInfo>() {
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
                } },

                #endregion

                #region NETStandard

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                } },

                #endregion

            };
        }

        #endregion

        #region TryGetLoadableRuntimesSorted

        [TestData(nameof(TryGetLoadableRuntimesSortedData))]
        void TryGetLoadableRuntimesSorted(RuntimeInfo input1, Boolean input2, Boolean result, List<RuntimeInfo> runtimes) {

            Boolean _result = false;
            List<RuntimeInfo> _runtimes = null;

            Test.IfNot.Action.ThrowsException(() => _result = RuntimesHelper.TryGetLoadableRuntimes(input1, input2, out _runtimes), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.MatchesExactly(_runtimes, runtimes);

        }

        IEnumerable<Object[]> TryGetLoadableRuntimesSortedData() {
            return new List<Object[]>() {
                new Object[] { null, true, false, new List<RuntimeInfo>() },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), true, false, new List<RuntimeInfo>() },

                #region NETCoreApp desc
                
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
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
                } },

                #endregion

                #region Mono desc
                
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },

                #endregion

                #region NET desc

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },

                #endregion

                #region NETFramework desc
                
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), true, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), true, true, new List<RuntimeInfo>() {
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
                } },

                #endregion

                #region NETStandard desc
                
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                } },

                #endregion

                #region asc
                
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)), true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NET, new Version(5, 0)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)), true, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(4, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(5, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.Mono, new Version(6, 4)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), false, true, new List<RuntimeInfo>() {
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
                    new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)),
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), false, true, new List<RuntimeInfo>() {
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
                } },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), false, true, new List<RuntimeInfo>() {
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)),
                    new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)),
                } },

                #endregion

            };
        }

        #endregion

    }
}
