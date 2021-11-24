using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.ResolverData;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Internal {
    class NugetResolver_iTests {

        #region TryResolve

        [TestMethod]
        [TestData(nameof(TryResolveArgs_Data))]
        void TryResolveArgs(ResolveEventArgs input, Boolean expected, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict, new DirectoryInfo[] { Statics.FakeNugetCache });
            Boolean result = false;
            IEnumerable<INugetResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveArgs_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs(null, null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs("", null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs("some name", null), false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { new ResolveEventArgs(Statics.TestAsm.FullName, null), false, Enumerable.Empty<FileInfo>() };
        }

        [TestMethod]
        [TestData(nameof(TryResolveString_Data))]
        void TryResolveString(String input, Boolean expected, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict, new DirectoryInfo[] { Statics.FakeNugetCache });
            Boolean result = false;
            IEnumerable<INugetResolverData> _files = null;

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveString_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { "", false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { "some name", false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.FullName, false, Enumerable.Empty<FileInfo>() };
        }

        [TestMethod]
        [TestData(nameof(TryResolveName_Data))]
        void TryResolveName(AssemblyName input, Boolean expected, IEnumerable<FileInfo> files) {

            Creation.Factory.Instance.NugetResolver().Create(out INugetResolver instance, VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict, new DirectoryInfo[] { Statics.FakeNugetCache });
            Boolean result = default;
            IEnumerable<INugetResolverData> _files = default;

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out _files), out Exception ex);

            Test.If.Value.IsEqual(result, expected);
            Test.If.Enumerable.MatchesExactly(_files.Select(_ => _.File), files, Statics.FileInfoComparer);

        }

        IEnumerable<Object[]> TryResolveName_Data() {
            yield return new Object[] { null, false, Enumerable.Empty<FileInfo>() };
            yield return new Object[] { Statics.TestAsm.GetName(), false, Enumerable.Empty<FileInfo>() };
        }

        #endregion

        #region GetCaches

        [TestMethod]
        void GetCaches() {

            IEnumerable<DirectoryInfo> caches = default;

            String userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages");

            Test.IfNot.Action.ThrowsException(() => caches = NugetResolver.GetCaches(), out Exception ex);

            Test.If.Value.IsEqual(caches.Count(), 1);
            Test.If.Value.IsEqual(caches.First().FullName, userPath);

        }

        #endregion

    }
}
