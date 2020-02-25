using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nuclear.Assemblies {
    public static class AssemblyHelper {

        #region fields

        internal static ProcessorArchitecture[] _validArchitectures =
            new ProcessorArchitecture[] { ProcessorArchitecture.MSIL, Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86 };

        #endregion

        #region properties

        /// <summary>
        /// Gets a list of valid file extensions for .NET assemblies.
        /// </summary>
        public static String[] AssemblyFileExtensions { get; } = new String[] { "dll", "exe" };

        #endregion

        #region loading

        public static Boolean TryLoadFrom(FileInfo file, out Assembly assembly) {
            assembly = null;

            if(file != null && file.Exists) {
                try {
                    assembly = Assembly.LoadFrom(file.FullName);

                } catch { /* Don't worry about exceptions here */ }
            }

            return assembly != null;
        }

        #endregion

        #region assembly name

        public static Boolean TryGetAssemblyName(ResolveEventArgs e, out AssemblyName assemblyName) {
            assemblyName = null;

            try {
                assemblyName = new AssemblyName(e.Name);

            } catch { return false; }

            return assemblyName != null;
        }

        public static Boolean TryGetAssemblyName(String fullName, out AssemblyName assemblyName) {
            assemblyName = null;

            try {
                assemblyName = new AssemblyName(fullName);

            } catch { return false; }

            return assemblyName != null;
        }

        public static Boolean TryGetAssemblyName(FileInfo file, out AssemblyName assemblyName) {
            assemblyName = null;

            try {
                assemblyName = AssemblyName.GetAssemblyName(file.FullName);

            } catch { return false; }

            return assemblyName != null;
        }

        #endregion

        #region validation

        public static Boolean ValidateByName(AssemblyName lhs, AssemblyName rhs) => lhs != null && rhs != null && lhs.FullName == rhs.FullName;

        public static Boolean ValidateArchitecture(AssemblyName asmName) => _validArchitectures.Contains(asmName.ProcessorArchitecture);

        #endregion

    }
}
