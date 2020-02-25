using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

using Nuclear.Extensions;
using Nuclear.TestSite;

using static System.Environment;

namespace Nuclear.Assemblies.Resolvers.Nuget {
    class NugetPackageCache_iTests {

        #region GetCaches

        [TestMethod]
        void GetCaches() {

            IEnumerable<NugetPackageCache> caches = null;

            String userPath = Path.Combine(GetFolderPath(SpecialFolder.UserProfile), ".nuget", "packages");

            Test.IfNot.Action.ThrowsException(() => caches = NugetPackageCache.GetCaches(), out Exception ex);

            Test.If.Value.IsEqual(caches.Count(), 1);
            Test.If.Value.IsEqual(caches.First().Location.FullName, userPath);

        }

        #endregion

        #region HasPackage

        [TestMethod]
        void HasPackage() {

            NugetPackageCache cache = NugetPackageCache.GetCaches().First();

            Test.If.Action.ThrowsException(() => cache.HasPackage(null), out ArgumentNullException anex);
            Test.If.Action.ThrowsException(() => cache.HasPackage(""), out ArgumentException aex);
            Test.If.Action.ThrowsException(() => cache.HasPackage(" "), out aex);

            DDTHasPackage("microsoft.csharp", true);
            DDTHasPackage("netstandard.library", true);
            DDTHasPackage("non.existent.library", false);

        }

        void DDTHasPackage(String input, Boolean expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            NugetPackageCache cache = NugetPackageCache.GetCaches().First();

            Boolean result = false;

            Test.Note($"NugetPackageCache.HasPackage({input.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = cache.HasPackage(input), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected, _file, _method);
        }

        #endregion

    }
}
