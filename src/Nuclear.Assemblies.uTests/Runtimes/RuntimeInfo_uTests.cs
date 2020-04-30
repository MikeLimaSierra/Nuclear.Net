using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Assemblies.Runtimes {
    class RuntimeInfo_uTests {

        #region ctors

        [TestMethod]
        void ConstructorThrows() {

            RuntimeInfo info = null;

            Test.If.Action.ThrowsException(() => info = new RuntimeInfo((FrameworkIdentifiers) 42, null), out ArgumentException argEx);
            Test.If.Action.ThrowsException(() => info = new RuntimeInfo(FrameworkIdentifiers.Unsupported, null), out ArgumentNullException argNullEx);

        }

        [TestMethod]
        [TestData(nameof(ConstructorData))]
        void Constructor(FrameworkIdentifiers input1, Version input2, FrameworkIdentifiers framework, Version version) {

            RuntimeInfo info = null;

            Test.IfNot.Action.ThrowsException(() => info = new RuntimeInfo(input1, input2), out Exception ex);

            Test.If.Value.IsEqual(info.Framework, framework);
            Test.If.Value.IsEqual(info.Version, version);

        }

        IEnumerable<Object[]> ConstructorData() {
            return new List<Object[]>() {
                new Object[] { FrameworkIdentifiers.Unsupported, new Version(1, 2, 3), FrameworkIdentifiers.Unsupported, new Version(1, 2, 3) },
                new Object[] { FrameworkIdentifiers.NETStandard, new Version(2, 3, 4), FrameworkIdentifiers.NETStandard, new Version(2, 3, 4) },
            };
        }

        #endregion

        #region Equals

        [TestMethod]
        [TestData(nameof(EqualsObjectData))]
        void EqualsObject(RuntimeInfo left, Object right, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = left.Equals(right), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> EqualsObjectData() {
            return new List<Object[]>() {
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), null, false },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), "wrong type", false },

                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), false },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), false },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), false },
            };
        }

        [TestMethod]
        [TestData(nameof(EqualsData))]
        void Equals(RuntimeInfo left, RuntimeInfo right, Boolean expected) {

            Boolean result = false;

            Test.IfNot.Action.ThrowsException(() => result = left.Equals(right), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> EqualsData() {
            return new List<Object[]>() {
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), true },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), false },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), false },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), false },
            };
        }

        #endregion

        #region ToString

        [TestMethod]
        [TestData(nameof(ToStringData))]
        void ToString(RuntimeInfo input, String expected) {

            String result = null;

            Test.IfNot.Action.ThrowsException(() => result = input.ToString(), out Exception ex);
            Test.If.Value.IsEqual(result, expected);

        }

        IEnumerable<Object[]> ToStringData() {
            return new List<Object[]>() {
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 0)), "NETFramework 1.0" },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), "NETCoreApp 2.1" },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(3, 2)), "NETStandard 3.2" },
                new Object[] { new RuntimeInfo(FrameworkIdentifiers.Unsupported, new Version(4, 3)), "Unsupported 4.3" },
            };
        }

        #endregion

    }
}
