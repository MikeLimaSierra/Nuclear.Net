using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Assemblies.Runtimes;
using Nuclear.Extensions;
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
        void TryGetRuntime() {

            DDTTryGetRuntime(null, (false, null));
            DDTTryGetRuntime(typeof(TestMethodAttribute).Assembly, (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0))));
            DDTTryGetRuntime(typeof(Test).Assembly, (true, new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0))));

        }

        void DDTTryGetRuntime(Assembly input, (Boolean result, RuntimeInfo runtime) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = default;
            RuntimeInfo runtime = default;

            Test.Note($"AssemblyHelper.TryGetRuntime({input.Format()}, out {expected.runtime.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = AssemblyHelper.TryGetRuntime(input, out runtime), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(runtime, expected.runtime, _file, _method);

        }

        #endregion

    }

}
