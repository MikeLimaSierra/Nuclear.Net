using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nuclear.Assemblies {
    public static class AssemblyHelper {

        #region properties

        public static String[] AssemblyFileExtensions { get; } = new String[] { "dll", "exe" };

        public static ProcessorArchitecture[] ValidArchitectures { get; } = new ProcessorArchitecture[] { ProcessorArchitecture.MSIL, Environment.Is64BitProcess ? ProcessorArchitecture.Amd64 : ProcessorArchitecture.X86 };

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

    }
}
