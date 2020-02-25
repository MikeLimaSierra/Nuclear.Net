using System;
using Nuclear.TestSite;

namespace Nuclear.Assemblies {
    class AssemblyHelper_uTests {

        #region AssemblyFileExtensions

        [TestMethod]
        void AssemblyFileExtensions() {

            Test.If.Enumerable.Matches(AssemblyHelper.AssemblyFileExtensions, new String[] { "dll", "exe" });

        }

        #endregion

    }

}
