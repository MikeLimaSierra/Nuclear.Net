using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolver_iTests {

        private static readonly FileInfo _nonExistentAssembly = new FileInfo(@"C:\NonExistent.dll");

        #region TryResolve

        [TestMethod]
        [TestData(nameof(TryResolveArgs_Data))]
        void TryResolveArgs(ResolveEventArgs input, Boolean result, IEnumerable<FileInfo> files) {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance);
            Boolean _result = false;
            IEnumerable<IDefaultResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveArgs_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs(null, null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs("", null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs("some name", null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs(Statics.TestAsm.FullName, null), false, Enumerable.Empty<FileInfo>() };

            foreach(var assembly in Statics.EntryPath.Directory.GetFiles("*.dll")) {
                yield return new Object[] { new ResolveEventArgs(AssemblyName.GetAssemblyName(assembly.FullName).FullName, null), true, new FileInfo[] { assembly } };
            }

            yield return new Object[] { new ResolveEventArgs(Statics.TestAsm.FullName, Statics.TestAsm), true, new FileInfo[] {
                new FileInfo(Statics.TestAsm.Location)
            } };
        }

        [TestMethod]
        [TestData(nameof(TryResolveString_Data))]
        void TryResolveString(String input, Boolean result, IEnumerable<FileInfo> files) {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance);
            Boolean _result = false;
            IEnumerable<IDefaultResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveString_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { "", false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { "some name", false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.FullName, false, Enumerable.Empty<FileInfo>() };

            foreach(var assembly in Statics.EntryPath.Directory.GetFiles("*.dll")) {
                yield return new Object[] { AssemblyName.GetAssemblyName(assembly.FullName).FullName, true, new FileInfo[] { assembly } };
            }
        }

        [TestMethod]
        [TestData(nameof(TryResolveName_Data))]
        void TryResolveName(AssemblyName input, Boolean result, IEnumerable<FileInfo> files) {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance);
            Boolean _result = false;
            IEnumerable<IDefaultResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => _result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(_result, result);
            Test.If.Enumerable.Matches(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveName_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), false, Enumerable.Empty<FileInfo>() };

            foreach(var assembly in Statics.EntryPath.Directory.GetFiles("*.dll")) {
                yield return new Object[] { AssemblyName.GetAssemblyName(assembly.FullName), true, new FileInfo[] { assembly } };
            }
        }

        #endregion

        #region ResolveInternal

        [TestMethod]
        [TestData(nameof(ResolveInternal_Data))]
        void ResolveInternal(AssemblyName input1, SearchOption input2, IEnumerable<FileInfo> expected) {

            IEnumerable<FileInfo> files = null;

            Test.IfNot.Action.ThrowsException(() => files = DefaultResolver.ResolveInternal(input1, input2), out Exception ex);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> ResolveInternal_Data() {
            yield return new Object[] { null, (SearchOption) 1000, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), (SearchOption) 1000, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), (SearchOption) 1000, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), SearchOption.AllDirectories, Enumerable.Empty<FileInfo>() };

            foreach(var assembly in Statics.EntryPath.Directory.GetFiles("*.dll")) {
                yield return new Object[] { AssemblyName.GetAssemblyName(assembly.FullName), SearchOption.AllDirectories, new FileInfo[] { assembly } };
            }
        }

        [TestMethod]
        [TestData(nameof(ResolveInternalDir_Data))]
        void ResolveInternalDir(AssemblyName input1, DirectoryInfo input2, SearchOption input3, IEnumerable<FileInfo> expected) {

            IEnumerable<FileInfo> files = null;

            Test.IfNot.Action.ThrowsException(() => files = DefaultResolver.ResolveInternal(input1, input2, input3), out Exception ex);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> ResolveInternalDir_Data() {
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
