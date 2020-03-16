using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Runtimes {
    class RuntimeInfoFeatureComparer_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<RuntimeInfoFeatureComparer, IComparer<RuntimeInfo>>();

        }

        [TestMethod]
        void Compare() {

            DDTCompare((null, null), 0);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), null), 1);
            DDTCompare((null, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), null), 1);
            DDTCompare((null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 0);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 0);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), 0);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))), 0);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0))), 1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0))), -1);

        }

        [TestMethod]
        void CompareFramework() {

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

        }

        [TestMethod]
        void CompareCoreApp() {

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), -1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), -1);

            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))), 1);
            DDTCompare((new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1))), 1);

        }

        void DDTCompare((RuntimeInfo x, RuntimeInfo y) input, Int32 expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IComparer<RuntimeInfo> comparer = new RuntimeInfoFeatureComparer();
            Int32 result = default;

            Test.Note($"RuntimeInfoFeatureComparer.Compare({input.x.Format()}, {input.y.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = comparer.Compare(input.x, input.y), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected, _file, _method);

        }

    }
}
