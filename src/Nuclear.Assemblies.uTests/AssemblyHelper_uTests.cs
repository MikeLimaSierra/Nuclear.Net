using System;
using System.Collections.Generic;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.TestSite;

namespace Nuclear.Assemblies {
    class AssemblyHelper_uTests {

        #region AssemblyFileExtensions

        [TestMethod]
        void AssemblyFileExtensions() {

            Test.If.Enumerable.Matches(AssemblyHelper.AssemblyFileExtensions, new String[] { "dll", "exe" });

        }

        #endregion

        #region runtime info

        [TestMethod]
        [TestData(nameof(TryGetRuntimeData))]
        void TryGetRuntime(Assembly input, Boolean result, RuntimeInfo runtime) {

            Boolean _result = default;
            RuntimeInfo _runtime = default;

            Test.IfNot.Action.ThrowsException(() => _result = AssemblyHelper.TryGetRuntime(input, out _runtime), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Value.IsEqual(_runtime, runtime);

        }

        IEnumerable<Object[]> TryGetRuntimeData() {
            return new List<Object[]>() {
                new Object[] { null, false, null },
                new Object[] { typeof(TestMethodAttribute).Assembly, true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)) },
                new Object[] { typeof(Test).Assembly, true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)) },
            };
        }

        #endregion

    }

}
