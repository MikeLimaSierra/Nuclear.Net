using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolver_iTests {

        private static readonly FileInfo _nonExistentAssembly = new FileInfo(@"C:\NonExistent.dll");

        #region TryResolve

        [TestMethod]
        [TestData(nameof(TryResolveArgsData))]
        void TryResolveArgs(ResolveEventArgs input, Boolean result, IEnumerable<FileInfo> files) {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance);
            Boolean _result = false;
            IEnumerable<IDefaultResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveArgsData() {
            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs(null, null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs("", null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs("some name", null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs(Statics.TestAsm.FullName, null), false, Enumerable.Empty<FileInfo>() },
                new Object[] { new ResolveEventArgs(typeof(StringExtensions).Assembly.FullName, null), true, new FileInfo[] {
                    new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
                } },
                new Object[] { new ResolveEventArgs(typeof(DefaultResolver).Assembly.FullName, Statics.TestAsm), true, new FileInfo[] {
                    new FileInfo(typeof(DefaultResolver).Assembly.Location)
                } },
            };
        }

        [TestMethod]
        [TestData(nameof(TryResolveStringData))]
        void TryResolveString(String input, Boolean result, IEnumerable<FileInfo> files) {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance);
            Boolean _result = false;
            IEnumerable<IDefaultResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveStringData() {
            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<FileInfo>() },
                new Object[] { "", false, Enumerable.Empty<FileInfo>() },
                new Object[] { "some name", false, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.FullName, false, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(StringExtensions).Assembly.FullName, true, new FileInfo[] {
                    new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
                } },
            };
        }

        [TestMethod]
        [TestData(nameof(TryResolveNameData))]
        void TryResolveName(AssemblyName input, Boolean result, IEnumerable<FileInfo> files) {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance);
            Boolean _result = false;
            IEnumerable<IDefaultResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveNameData() {
            return new List<Object[]>() {
                new Object[] { null, false, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), false, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(StringExtensions).Assembly.GetName(), true, new FileInfo[] {
                    new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
                } },
            };
        }

        #endregion

        #region ResolveInternal

        [TestMethod]
        [TestData(nameof(ResolveInternalData))]
        void ResolveInternal(AssemblyName input1, SearchOption input2, IEnumerable<FileInfo> expected) {

            IEnumerable<FileInfo> files = null;

            Test.IfNot.Action.ThrowsException(() => files = DefaultResolver.ResolveInternal(input1, input2), out Exception ex);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> ResolveInternalData() {
            return new List<Object[]>() {
                new Object[] { null, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), SearchOption.AllDirectories, Enumerable.Empty<FileInfo>() },
                new Object[] { typeof(StringExtensions).Assembly.GetName(), SearchOption.AllDirectories, new FileInfo[] {
                    new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
                } },
            };
        }

        [TestMethod]
        [TestData(nameof(ResolveInternalDirData))]
        void ResolveInternalDir(AssemblyName input1, DirectoryInfo input2, SearchOption input3, IEnumerable<FileInfo> expected) {

            IEnumerable<FileInfo> files = null;

            Test.IfNot.Action.ThrowsException(() => files = DefaultResolver.ResolveInternal(input1, input2, input3), out Exception ex);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> ResolveInternalDirData() {
            return new List<Object[]>() {
                new Object[] { null, null, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), null, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), Statics.EntryPath.Directory, (SearchOption) 1000, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), Statics.EntryPath.Directory, SearchOption.AllDirectories, Enumerable.Empty<FileInfo>() },
                new Object[] { Statics.TestAsm.GetName(), Statics.TestPath.Directory, SearchOption.AllDirectories, new FileInfo[] { Statics.TestPath } },
            };
        }

        #endregion

    }
}
