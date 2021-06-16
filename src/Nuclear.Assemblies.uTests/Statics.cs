using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Extensions;

namespace Nuclear.Assemblies {
    internal static class Statics {

        internal static IEqualityComparer<FileInfo> FileInfoComparer { get; } = DynamicEqualityComparer.FromDelegate<FileInfo>(
            (x, y) => (x == null && y == null) || (x != null && y != null && x.FullName.Equals(y.FullName)),
            obj => obj.GetHashCode());

        internal static Assembly TestAsm { get; } = typeof(DefaultResolver_uTests).Assembly;

        internal static FileInfo TestPath { get; } = new FileInfo(TestAsm.Location);

        internal static DirectoryInfo FakeNugetCache { get; }

        static Statics() {
            DirectoryInfo repodir = TestPath.Directory.Parent.Parent.Parent.Parent.Parent;

            FakeNugetCache = new DirectoryInfo(Path.Combine(repodir.FullName, "fake-nuget", "packages"));
        }

    }
}
