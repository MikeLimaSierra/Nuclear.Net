using System;

using Nuclear.Assemblies.Runtimes;

namespace Nuclear.Assemblies.Resolvers.Data {

    /// <summary>
    /// Defines the nuget package information that was found by an <see cref="INugetResolver"/>.
    /// </summary>
    public interface INugetResolverData : IAssemblyResolverData {

        #region properties

        /// <summary>
        /// Gets the package name.
        /// </summary>
        String PackageName { get; }

        /// <summary>
        /// Gets the package version.
        /// </summary>
        Version PackageVersion { get; }

        /// <summary>
        /// Gets the package version label.
        /// </summary>
        String PackageVersionLabel { get; }

        /// <summary>
        /// Gets the targeted framework.
        /// </summary>
        RuntimeInfo PackageTargetFramework { get; }

        #endregion

    }

}
