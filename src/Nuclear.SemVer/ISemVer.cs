using System;

namespace Nuclear.SemVer {

    /// <summary>
    /// Defines a semantic version object.
    /// </summary>
    public interface ISemVer {

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

        #endregion

    }
}
