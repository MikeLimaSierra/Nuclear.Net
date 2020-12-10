using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Assemblies.Runtimes {
    class RuntimeInfoFeatureComparer_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<RuntimeInfoFeatureComparer, IComparer<RuntimeInfo>>();

        }

        [TestMethod]
        [TestData(nameof(CompareData))]
        void Compare(RuntimeInfo input1, RuntimeInfo input2, Int32 expected) {

            IComparer<RuntimeInfo> comparer = new RuntimeInfoFeatureComparer();
            Int32 result = default;

            Test.IfNot.Action.ThrowsException(() => result = comparer.Compare(input1, input2), out Exception ex);

            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> CompareData() {
            return new List<Object[]>() {

                #region

                new Object[] { null, null, 0 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), null, 1 },
                new Object[] { null, new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), null, 1 },
                new Object[] { null, new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 0 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 0 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), 0 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), 0 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), 1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), -1 },

                #endregion

                #region NETFramework

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                #endregion

                #region NETCoreApp

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), -1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), -1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), 1 },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), 1 },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 1)), new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), 1 },

                #endregion

            };
        }

    }
}
