using System;
using System.IO;

using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Nuget {
    class NugetPackageCache_uTests {

        #region ctor

        [TestMethod]
        void Ctor() {

            Test.If.Action.ThrowsException(() => new NugetPackageCache(null), out ArgumentNullException anex);
            Test.If.Action.ThrowsException(() => new NugetPackageCache(new DirectoryInfo(@"C:\path\not\found")), out ArgumentException aex);

        }

        #endregion

    }
}
