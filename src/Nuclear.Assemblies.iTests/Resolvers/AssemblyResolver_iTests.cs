using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class AssemblyResolver_iTests {

        #region ResolveInternal

        [TestMethod]
        [TestData(nameof(ResolveInternalData))]
        void ResolveInternal(AssemblyName input1, SearchOption input2, IEnumerable<FileInfo> expected) {

            IEnumerable<FileInfo> files = null;

            Test.IfNot.Action.ThrowsException(() => files = AssemblyResolver.ResolveInternal(input1, input2), out Exception ex);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> ResolveInternalData() {
            return new List<Object[]>() {
                new Object[] { null, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(AssemblyResolver_iTests).Assembly.GetName(), (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(AssemblyResolver_iTests).Assembly.GetName(), (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(AssemblyResolver_iTests).Assembly.GetName(), SearchOption.AllDirectories, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(StringExtensions).Assembly.GetName(), SearchOption.AllDirectories, new FileInfo[] {
                    new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
                } },
            };
        }

        [TestMethod]
        [TestData(nameof(ResolveInternalDirData))]
        void ResolveInternalDir(AssemblyName input1, DirectoryInfo input2, SearchOption input3, IEnumerable<FileInfo> expected) {

            IEnumerable<FileInfo> files = null;

            Test.IfNot.Action.ThrowsException(() => files = AssemblyResolver.ResolveInternal(input1, input2, input3), out Exception ex);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> ResolveInternalDirData() {
            return new List<Object[]>() {
                new Object[] { null, null, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(AssemblyResolver_iTests).Assembly.GetName(), null, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(AssemblyResolver_iTests).Assembly.GetName(), Statics.EntryPath.Directory, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(AssemblyResolver_iTests).Assembly.GetName(), Statics.EntryPath.Directory, SearchOption.AllDirectories, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(StringExtensions).Assembly.GetName(), Statics.EntryPath.Directory, SearchOption.AllDirectories, new FileInfo[] {
                    new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
                } },
            };
        }

        #endregion

    }
}
