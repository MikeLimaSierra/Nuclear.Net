using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies {
    class AssemblyHelper_iTests {

        #region TryLoadFrom

        [TestMethod]
        public void TryLoadFromFails() {

            DDTTryLoadFrom(null, false);
            DDTTryLoadFrom(new FileInfo(@"C:/nonexistent.file"), false);

        }

        void DDTTryLoadFrom(FileInfo input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            Boolean result = false;
            Assembly assembly = null;

            Test.Note($"AssemblyHelper.TryLoadFrom({input.Format()}, out null) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = AssemblyHelper.TryLoadFrom(input, out assembly), out Exception ex, _file, _method);
            Test.If.Value.IsEqual(result, expected, _file, _method);
            Test.If.Object.IsNull(assembly, _file, _method);

        }

        #endregion

    }

}
