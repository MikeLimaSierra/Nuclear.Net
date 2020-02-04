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

        internal static Assembly TestAsm { get; } = typeof(DefaultResolver_iTests).Assembly;

        internal static FileInfo TestPath { get; } = new FileInfo(TestAsm.Location);
    }
}
