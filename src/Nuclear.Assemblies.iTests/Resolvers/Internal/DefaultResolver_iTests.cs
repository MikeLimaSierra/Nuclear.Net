using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Internal {
    class DefaultResolver_iTests {

        private static readonly FileInfo _nonExistentAssembly = new FileInfo(@"C:\NonExistent.dll");

        #region TryResolve

        [TestMethod]
        [TestData(nameof(TryResolveArgs_Data))]
        void TryResolveArgs(ResolveEventArgs input, Boolean result, IEnumerable<FileInfo> files) {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance, VersionMatchingStrategies.Strict, SearchOption.AllDirectories);
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

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance, VersionMatchingStrategies.Strict, SearchOption.AllDirectories);
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

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance, VersionMatchingStrategies.Strict, SearchOption.AllDirectories);
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

        #region InternalResolver_Wiring

        [TestMethod]
        void TryResolveArgs_Wiring() {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance, VersionMatchingStrategies.SemVer, SearchOption.TopDirectoryOnly);
            var internalResolver = new DummyInternalResolver();
            ((DefaultResolver) instance).InternalResolver = internalResolver;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(new ResolveEventArgs(Statics.TestAsm.FullName, null), out _), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Value.IsEqual(internalResolver.SearchDir, Statics.EntryPath.Directory);
            Test.If.Value.IsEqual(internalResolver.SearchOption, SearchOption.TopDirectoryOnly);

        }

        [TestMethod]
        void TryResolveArgsWithPath_Wiring() {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance, VersionMatchingStrategies.SemVer, SearchOption.TopDirectoryOnly);
            var internalResolver = new DummyInternalResolver();
            ((DefaultResolver) instance).InternalResolver = internalResolver;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(new ResolveEventArgs(Statics.TestAsm.FullName, Statics.TestAsm), out _), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Value.IsEqual(internalResolver.SearchDir, Statics.TestPath.Directory);
            Test.If.Value.IsEqual(internalResolver.SearchOption, SearchOption.TopDirectoryOnly);

        }

        [TestMethod]
        void TryResolveString_Wiring() {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance, VersionMatchingStrategies.SemVer, SearchOption.TopDirectoryOnly);
            var internalResolver = new DummyInternalResolver();
            ((DefaultResolver) instance).InternalResolver = internalResolver;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(Statics.TestAsm.FullName, out _), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Value.IsEqual(internalResolver.SearchDir, Statics.EntryPath.Directory);
            Test.If.Value.IsEqual(internalResolver.SearchOption, SearchOption.TopDirectoryOnly);
        }

        [TestMethod]
        void TryResolveName_Wiring() {

            Factory.Instance.DefaultResolver().Create(out IDefaultResolver instance, VersionMatchingStrategies.SemVer, SearchOption.TopDirectoryOnly);
            var internalResolver = new DummyInternalResolver();
            ((DefaultResolver) instance).InternalResolver = internalResolver;

            Test.IfNot.Action.ThrowsException(() => instance.TryResolve(Statics.TestAsm.GetName(), out _), out Exception ex);

            Test.If.Value.IsEqual(internalResolver.AssemblyName.FullName, Statics.TestAsm.FullName);
            Test.If.Value.IsEqual(internalResolver.SearchDir, Statics.EntryPath.Directory);
            Test.If.Value.IsEqual(internalResolver.SearchOption, SearchOption.TopDirectoryOnly);
            Test.If.Value.IsEqual(internalResolver.MatchingStrategy, VersionMatchingStrategies.SemVer);

        }

        #endregion

        private class DummyInternalResolver : IInternalDefaultResolver {

            internal AssemblyName AssemblyName { get; private set; }
            internal DirectoryInfo SearchDir { get; private set; }
            internal SearchOption SearchOption { get; private set; }
            internal VersionMatchingStrategies MatchingStrategy { get; private set; }

            public IEnumerable<FileInfo> Resolve(AssemblyName assemblyName, DirectoryInfo searchDir, SearchOption searchOption, VersionMatchingStrategies strategy) {
                AssemblyName = assemblyName;
                SearchDir = searchDir;
                SearchOption = searchOption;
                MatchingStrategy = strategy;

                return Enumerable.Empty<FileInfo>();
            }

        }

    }
}
