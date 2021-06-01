using System;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Runtimes;
using Nuclear.Exceptions;

namespace Nuclear.Assemblies.Resolvers.Data {

    internal class NugetResolverData : AssemblyResolverData, INugetResolverData {

        #region properties

        public String PackageName { get; private set; }

        public Version PackageVersion { get; private set; }

        public String PackageVersionLabel { get; private set; }

        public ProcessorArchitecture PackageArchitecture { get; private set; }

        public RuntimeInfo PackageTargetFramework { get; private set; }

        #endregion

        #region ctors

        internal NugetResolverData(FileInfo file) : base(file) { }

        #endregion

        #region methods

        protected override void Init() {
            base.Init();

            // packages/name/version/lib/[arch/]runtime/assembly.dll

            GetTargetFramework(out DirectoryInfo runtimeDir);
            GetArchitecture(runtimeDir, out DirectoryInfo libDir);
            GetVersion(libDir, out DirectoryInfo versionDir);
            GetName(versionDir, out DirectoryInfo nameDir);
        }

        private void GetTargetFramework(out DirectoryInfo runtimeDir) {
            Throw.If.Value.IsFalse(RuntimesHelper.TryParseTFM(File.Directory.Name, out RuntimeInfo runtime), nameof(File), "Could not resolve the targeted framework.");

            runtimeDir = File.Directory;

            PackageTargetFramework = runtime;
        }

        private void GetArchitecture(DirectoryInfo runtimeDir, out DirectoryInfo libDir) {
            libDir = runtimeDir.Parent;

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

            if(libDir.Name != "lib") {
                throw new ArgumentException("Could not resolve lib directory.", nameof(File));
            }
        }

        private void GetVersion(DirectoryInfo libDir, out DirectoryInfo versionDir) {
            versionDir = libDir.Parent;
            String v = versionDir.Name;

            Int32 dashIndex = v.IndexOf('-');

            PackageVersionLabel = dashIndex >= 0 ? v.Substring(dashIndex + 1) : null;
            PackageVersion = Version.TryParse(dashIndex >= 0 ? v.Substring(0, dashIndex) : v, out Version version)
                ? version : throw new ArgumentException("Could not resolve version.", nameof(File));
        }

        private void GetName(DirectoryInfo versionDir, out DirectoryInfo nameDir) {
            nameDir = versionDir.Parent;

            PackageName = nameDir.Name;
        }

        #endregion

    }

}
