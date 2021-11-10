using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.TestSite;

namespace Nuclear.Assemblies {
    class AssemblyHelper_iTests {

        #region TryLoadFile

        [TestMethod]
        [TestData(nameof(TryLoadFile_Data))]
        void TryLoadFile(FileInfo input, Boolean expected) {

            Boolean result = false;
            Assembly assembly = null;

            Test.IfNot.Action.ThrowsException(() => result = AssemblyHelper.TryLoadFile(input, out assembly), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Object.IsNull(assembly);

        }

        IEnumerable<Object[]> TryLoadFile_Data() {
            return new List<Object[]>() {
                new Object[] { null, false },
                new Object[] { new FileInfo(@"C:/nonexistent.file"), false },
            };
        }

        #endregion

        #region TryLoadFrom

        [TestMethod]
        [TestData(nameof(TryLoadFrom_Data))]
        void TryLoadFrom(FileInfo input, Boolean expected) {

            Boolean result = false;
            Assembly assembly = null;

            Test.IfNot.Action.ThrowsException(() => result = AssemblyHelper.TryLoadFrom(input, out assembly), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Object.IsNull(assembly);

        }

        IEnumerable<Object[]> TryLoadFrom_Data() {
            return new List<Object[]>() {
                new Object[] { null, false },
                new Object[] { new FileInfo(@"C:/nonexistent.file"), false },
            };
        }

        #endregion

        #region TryUnsafeLoadFrom

        [TestMethod]
        [TestData(nameof(TryUnsafeLoadFrom_Data))]
        void TryUnsafeLoadFrom(FileInfo input, Boolean expected) {

            Boolean result = false;
            Assembly assembly = null;

            Test.IfNot.Action.ThrowsException(() => result = AssemblyHelper.TryUnsafeLoadFrom(input, out assembly), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Object.IsNull(assembly);

        }

        IEnumerable<Object[]> TryUnsafeLoadFrom_Data() {
            return new List<Object[]>() {
                new Object[] { null, false },
                new Object[] { new FileInfo(@"C:/nonexistent.file"), false },
            };
        }

        #endregion

    }

}
