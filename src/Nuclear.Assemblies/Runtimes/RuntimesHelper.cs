using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Runtimes {
    internal static class RuntimesHelper {

        #region properties

        internal static IDictionary<RuntimeInfo, Version> NetStandardVersions { get; }
            = new Dictionary<RuntimeInfo, Version>() {

                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(1, 1)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(2, 0)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(3, 5)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 0)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5)), new Version(1, 1) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 1)), new Version(1, 2) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 5, 2)), new Version(1, 2) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6)), new Version(1, 3) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 1)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 6, 2)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 1)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 7, 2)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETFramework, new Version(4, 8)), new Version(2, 0) },

                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 0)), new Version(1, 6) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(1, 1)), new Version(1, 6) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 0)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 1)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(2, 2)), new Version(2, 0) },
                { new RuntimeInfo(FrameworkIdentifiers.NETCoreApp, new Version(3, 0)), new Version(2, 1) },

                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 0)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 1)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 2)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 3)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 4)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 5)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(1, 6)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 0)), null },
                { new RuntimeInfo(FrameworkIdentifiers.NETStandard, new Version(2, 1)), null },

            };

        #endregion

        #region methods

        /// <summary>
        /// Tries to get the implemented <see cref="Version"/> of .NETStandard that is implemented in <paramref name="runtime"/>.
        /// </summary>
        /// <param name="runtime">The runtime to check.</param>
        /// <param name="netStandardVersion">The <see cref="Version"/> of .NETStandard or null if not implemented.</param>
        /// <returns>True if <paramref name="runtime"/> implements a <see cref="Version"/> of .NETStandard, False if not.</returns>
        internal static Boolean TryGetStandardVersion(RuntimeInfo runtime, out Version netStandardVersion) {
            netStandardVersion = null;

            if(runtime != null && NetStandardVersions.TryGetValue(runtime, out Version version)) {
                netStandardVersion = version;
            }

            return netStandardVersion != null;
        }

        /// <summary>
        /// Tries to get all matching runtimes that can load an assembly targeting <paramref name="runtime"/>.
        /// </summary>
        /// <param name="runtime">The runtime to check.</param>
        /// <param name="runtimes">A collection of matching runtimes.</param>
        /// <returns>True if any matching runtimes were found.</returns>
        internal static Boolean TryGetMatchingRuntimes(RuntimeInfo runtime, out IEnumerable<RuntimeInfo> runtimes) {
            List<RuntimeInfo> _runtimes = new List<RuntimeInfo>();

            if(runtime != null) {
                switch(runtime.Framework) {
                    case FrameworkIdentifiers.NETStandard:
                        _runtimes.AddRange(NetStandardVersions.Keys.Where(key => TryGetStandardVersion(key, out Version _version) && _version >= runtime.Version));
                        break;

                    default:
                        _runtimes.AddRange(NetStandardVersions.Keys.Where(key => key.Framework == runtime.Framework && key.Version >= runtime.Version));
                        break;
                }
            }

            runtimes = _runtimes;

            return runtimes.Count() > 0;
        }

        /// <summary>
        /// Tries to get the minimum matching runtime of all supported frameworks that can load an assembly targeting <paramref name="runtime"/>.
        /// </summary>
        /// <param name="runtime">The runtime to check.</param>
        /// <param name="runtimes">A collection of matching runtimes.</param>
        /// <returns>True if any matching runtimes were found.</returns>
        internal static Boolean TryGetMinimumMatchingRuntimes(RuntimeInfo runtime, out IDictionary<FrameworkIdentifiers, Version> runtimes) {
            runtimes = new Dictionary<FrameworkIdentifiers, Version>();

            if(TryGetMatchingRuntimes(runtime, out IEnumerable<RuntimeInfo> supportedRuntimes)) {
                foreach(FrameworkIdentifiers tfm in supportedRuntimes.Select(_runtime => _runtime.Framework).Distinct()) {
                    IEnumerable<Version> versions = supportedRuntimes.Where(__runtime => __runtime.Framework == tfm).Select(__runtime => __runtime.Version);

                    if(versions.Count() > 0) {
                        runtimes.Add(tfm, versions.MinT());
                    }
                }
            }

            return runtimes.Count() > 0;
        }

        /// <summary>
        /// Tries to get all supported runtimes that can be loaded by an assembly targeting <paramref name="runtime"/>.
        /// </summary>
        /// <param name="runtime">The runtime to check.</param>
        /// <param name="runtimes">A collection of matching runtimes.</param>
        /// <returns>True if any matching runtimes were found.</returns>
        internal static Boolean TryGetSupportedRuntimes(RuntimeInfo runtime, out IEnumerable<RuntimeInfo> runtimes) {
            throw new NotImplementedException();
        }

        #endregion

    }
}
