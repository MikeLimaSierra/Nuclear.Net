﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.TestSite;

namespace Nuclear.Assemblies {
    class AssemblyHelper_iTests {

        #region TryLoadFrom

        [TestMethod]
        [TestData(nameof(TryLoadFromData))]
        void TryLoadFrom(FileInfo input, Boolean expected) {

            Boolean result = false;
            Assembly assembly = null;

            Test.IfNot.Action.ThrowsException(() => result = AssemblyHelper.TryLoadFrom(input, out assembly), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Object.IsNull(assembly);

        }

        IEnumerable<Object[]> TryLoadFromData() {
            return new List<Object[]>() {
                new Object[] { null, false },
                new Object[] { new FileInfo(@"C:/nonexistent.file"), false },
            };
        }

        #endregion

    }

}
