using System;
using System.Collections.Generic;
using System.Linq;
using Nuclear.Exceptions;
using Nuclear.Extensions;

namespace Nuclear.Assemblies.Runtimes {
    internal class RuntimeInfo {

        #region properties

        public FrameworkIdentifiers Framework { get; }

        public Version Version { get; }

        #endregion

        #region ctors

        internal RuntimeInfo(FrameworkIdentifiers framework, Version version) {
            Throw.If.Value.IsFalse(Enum.IsDefined(typeof(FrameworkIdentifiers), framework), nameof(framework));
            Throw.If.Object.IsNull(version, nameof(version));

            Framework = framework;
            Version = version;
        }

        #endregion

        #region public methods

        public static Boolean TryParse(String fullName, out RuntimeInfo runtimeInfo) {
            runtimeInfo = null;

            ParseParts(fullName, out FrameworkIdentifiers framework, out Version version);

            try {
                runtimeInfo = new RuntimeInfo(framework, version);

            } catch { /* Don't worry about exceptions here */ }

            return runtimeInfo != null && runtimeInfo.Framework != FrameworkIdentifiers.Unsupported;
        }

        #endregion

        #region static methods

        internal static void ParseParts(String fullName, out FrameworkIdentifiers framework, out Version version) {
            framework = FrameworkIdentifiers.Unsupported;
            version = null;

            List<String> parts = fullName.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if(TryGetPart(ref parts, part => part.Trim().StartsWith("Version=v"), out String versionPart)) {
                String tmp = versionPart.Trim().TrimStartOnce("Version=v");

                try {
                    version = new Version(tmp);

                } catch { /* Don't worry about exceptions here */ }
            }

            if(TryGetPart(ref parts, part => {
                try {
                    Enum.Parse(typeof(FrameworkIdentifiers), part.Trim().TrimStartOnce('.'), true);
                    return true;

                } catch {
                    return false;
                }
            }, out String frameworkPart)) {
                framework = (FrameworkIdentifiers) Enum.Parse(typeof(FrameworkIdentifiers), frameworkPart.Trim().TrimStartOnce('.'), true);

            }
        }

        internal static Boolean TryGetPart(ref List<String> parts, Predicate<String> match, out String part) {
            part = null;

            if(parts.Exists(match)) {
                part = parts.Find(match).Trim();
                parts.Remove(part);
            }

            return part != null;
        }

        #endregion

    }
}
