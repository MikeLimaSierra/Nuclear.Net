using System;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;

namespace Nuclear.Assemblies.Resolvers.Data {

    internal class NugetResolverData : AssemblyResolverData, INugetResolverData {

        #region properties

        public String PackageName { get; private set; }

        public Version PackageVersion { get; private set; }

        public String PackageVersionLabel { get; private set; }

        public ProcessorArchitecture PackageArchitecture { get; private set; } = ProcessorArchitecture.None;

        public RuntimeInfo PackageTargetFramework { get; private set; }

        #endregion

        #region ctors

        internal NugetResolverData(FileInfo file) : base(file) { }

        #endregion

        #region methods

        protected override Boolean Init() => TryGetTargetFramework(out DirectoryInfo runtimeDir)
            && TryGetArchitecture(runtimeDir, out DirectoryInfo libDir)
            && TryGetVersion(libDir, out DirectoryInfo versionDir)
            && TryGetName(versionDir);

        private Boolean TryGetTargetFramework(out DirectoryInfo runtimeDir) {
            runtimeDir = File.Directory;

            if(RuntimesHelper.TryParseTFM(File.Directory.Name, out RuntimeInfo runtime)) {
                PackageTargetFramework = runtime;
            }

            return PackageTargetFramework != null && runtimeDir != null;
        }

        private Boolean TryGetArchitecture(DirectoryInfo runtimeDir, out DirectoryInfo libDir) {
            libDir = runtimeDir.Parent;

            if(libDir != null) {
                switch(libDir.Name) {
                    case "x86":
                        PackageArchitecture = ProcessorArchitecture.X86;
                        libDir = libDir.Parent;
                        break;

                    case "x64":
                        PackageArchitecture = ProcessorArchitecture.Amd64;
                        libDir = libDir.Parent;
                        break;

                    case "lib":
                        PackageArchitecture = ProcessorArchitecture.MSIL;
                        break;

                    default: break;
                }
            }

            return PackageArchitecture != ProcessorArchitecture.None && libDir != null && libDir.Name == "lib";
        }

        private Boolean TryGetVersion(DirectoryInfo libDir, out DirectoryInfo versionDir) {
            versionDir = libDir.Parent;

            if(versionDir != null) {
                String v = versionDir.Name;

                Int32 dashIndex = v.IndexOf('-');

                PackageVersionLabel = dashIndex >= 0 ? v.Substring(dashIndex + 1) : null;
                PackageVersion = Version.TryParse(dashIndex >= 0 ? v.Substring(0, dashIndex) : v, out Version version) ? version : new Version(0, 0, 0);
            }

            return PackageVersion != null && versionDir != null;
        }

        private Boolean TryGetName(DirectoryInfo versionDir) {
            PackageName = versionDir?.Parent?.Name;

            return PackageName == Name.Name;
        }

        #endregion

    }

}
