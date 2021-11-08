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

        internal static Assembly EntryAsm { get; } = Assembly.GetEntryAssembly();

        internal static FileInfo EntryPath { get; } = new FileInfo(EntryAsm.Location);

        internal static Assembly TestAsm { get; } = typeof(Statics).Assembly;

        internal static FileInfo TestPath { get; } = new FileInfo(TestAsm.Location);

        internal static DirectoryInfo FakeNugetCache { get; }

        static Statics() {
            EntryAsm = Assembly.GetEntryAssembly();
            EntryPath = new FileInfo(EntryAsm.Location);
            TestAsm = typeof(DefaultResolver_iTests).Assembly;
            TestPath = new FileInfo(TestAsm.Location);
            FakeNugetCache = new DirectoryInfo(Path.Combine(new FileInfo(TestAsm.Location).Directory.Parent.Parent.Parent.Parent.Parent.FullName, "fake-nuget", "packages"));
        }

    }
}
