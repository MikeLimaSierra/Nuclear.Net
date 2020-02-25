using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Resolvers.Nuget {
    internal class NugetPackageCache {

        #region fields

        private static readonly String _nugetDirName = ".nuget";

        private static readonly String _packagesDirName = "packages";

        #endregion

        #region properties

        internal DirectoryInfo Location { get; private set; }

        #endregion

        #region ctors

        internal NugetPackageCache(DirectoryInfo location) {
            Throw.If.Object.IsNull(location, nameof(location));
            Throw.If.Value.IsFalse(location.Exists, nameof(location), $"{location.FullName.Format()} doesn't exist!");

            Location = location;
        }

        #endregion

        #region static methods

        internal static IEnumerable<NugetPackageCache> GetCaches() {
            List<NugetPackageCache> caches = new List<NugetPackageCache>();

            DirectoryInfo userProfileDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            DirectoryInfo usersDir = userProfileDir.Parent;

            DirectoryInfo userNugetDir = new DirectoryInfo(Path.Combine(userProfileDir.FullName, _nugetDirName, _packagesDirName));

            if(userNugetDir.Exists) {
                caches.Add(new NugetPackageCache(userNugetDir));
            }

            foreach(DirectoryInfo userDir in usersDir.EnumerateDirectories()) {
                try {
                    DirectoryInfo packageDir = new DirectoryInfo(Path.Combine(userDir.FullName, _nugetDirName, _packagesDirName));

                    if(packageDir.FullName != userNugetDir.FullName && packageDir.Exists) {
                        caches.Add(new NugetPackageCache(packageDir));
                    }

                } catch { /* Don't care if we can't access drectories */ }

            }

            return caches;
        }

        #endregion

        #region methods

        internal Boolean HasPackage(String name) {
            Throw.If.String.IsNullOrWhiteSpace(name, nameof(name));

            String lowerCaseName = name.ToLower();

            return Location.EnumerateDirectories().Any((dir) => dir.Name.ToLower() == lowerCaseName);
        }

        #endregion

    }
}
