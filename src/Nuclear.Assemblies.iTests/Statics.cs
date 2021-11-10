using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Extensions;

namespace Nuclear.Assemblies {
    internal static class Statics {

        internal static IEqualityComparer<FileInfo> FileInfoComparer { get; } = DynamicEqualityComparer.FromDelegate<FileInfo>(
            (x, y) => (x == null && y == null) || (x != null && y != null && x.FullName.Equals(y.FullName)),
            obj => obj.FullName.GetHashCode());

        internal static Assembly EntryAsm { get; }

        internal static FileInfo EntryPath { get; }

        internal static Assembly TestAsm { get; }

        internal static FileInfo TestPath { get; }

        internal static DirectoryInfo FakeNugetCache { get; }

        internal static String SimpleFakePackageName => "Simple.Nuget.Package";

        internal static List<String> SimpleFakePackageVersions => new List<String>() {
            "1.1.0",
            "1.1.0-beta",
            "1.1.0-beta+meta"
        };

        internal static List<String> SimpleFakePackageTfms => new List<String>() {
            "net48",
            "netcoreapp3.0",
            "netstandard2.1",
            "net5.0"
        };

        internal static String ComplexFakePackageName => "Awesome.Nuget.Package";

        internal static List<String> ComplexFakePackageVersions => new List<String>() {
                "1.1.0",
                "1.1.0-beta",
                "1.1.0-beta+meta",
                "1.1.1",
                "1.2.0",
                "1.3.0",
                "2.1.0",
                "2.1.1",
                "2.2.0",
                "2.3.0",
                "3.1.0",
                "3.1.1",
                "3.2.0",
                "3.3.0"
        };

        internal static List<String> ComplexFakePackageTfms => new List<String>() {
                "net45",
                "net46",
                "net48",
                "netcoreapp1.0",
                "netcoreapp2.0",
                "netcoreapp3.0",
                "netcoreapp3.1",
                "net5.0",
                "netstandard1.0",
                "netstandard2.0",
                "netstandard2.1"
        };

        static Statics() {
            EntryAsm = Assembly.GetEntryAssembly();
            EntryPath = new FileInfo(EntryAsm.Location);
            TestAsm = typeof(Statics).Assembly;
            TestPath = new FileInfo(TestAsm.Location);
            FakeNugetCache = new DirectoryInfo(Path.Combine(new FileInfo(TestAsm.Location).Directory.Parent.Parent.Parent.Parent.Parent.FullName, "fake-nuget", "packages"));
        }

    }
}
