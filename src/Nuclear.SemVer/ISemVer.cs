using System;

namespace Nuclear.SemVer {

    /// <summary>
    /// Defines a semantic version object.
    /// </summary>
    public interface ISemVer : IEquatable<ISemVer>, IComparable<ISemVer> {

        #region properties

        /// <summary>
        /// Gets the major part of the version.
        /// </summary>
        Int32 Major { get; }

        /// <summary>
        /// Gets the minor part of the version.
        /// </summary>
        Int32 Minor { get; }

        /// <summary>
        /// Gets the patch part of the version.
        /// </summary>
        Int32 Patch { get; }

        /// <summary>
        /// Gets if the version is a pre-release.
        /// </summary>
        Boolean IsPreRelease { get; }

        /// <summary>
        /// Gets the pre-release part of the version.
        /// </summary>
        String PreRelease { get; }

        /// <summary>
        /// Gets if the version has meta data.
        /// </summary>
        Boolean HasMetaData { get; }

        /// <summary>
        /// Gets the meta data of the version.
        /// </summary>
        String MetaData { get; }

        #endregion

    }
}
