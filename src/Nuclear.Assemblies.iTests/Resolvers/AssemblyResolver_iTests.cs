using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class AssemblyResolver_iTests {

        #region ResolveInternal

        [TestMethod]
        void ResolveInternal() {

            DDTResolveInternal((null, null, (SearchOption) 1000), Enumerable.Empty<FileInfo>());
            DDTResolveInternal((typeof(AssemblyResolver_iTests).Assembly.GetName(), null, (SearchOption) 1000), Enumerable.Empty<FileInfo>());
            DDTResolveInternal((typeof(AssemblyResolver_iTests).Assembly.GetName(), Statics.EntryPath.Directory, (SearchOption) 1000), Enumerable.Empty<FileInfo>());
            DDTResolveInternal((typeof(AssemblyResolver_iTests).Assembly.GetName(), Statics.EntryPath.Directory, SearchOption.AllDirectories), Enumerable.Empty<FileInfo>());

            DDTResolveInternal((typeof(StringExtensions).Assembly.GetName(), Statics.EntryPath.Directory, SearchOption.AllDirectories), new FileInfo[] {
                new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
            });

            DDTResolveInternal((null, (SearchOption) 1000), Enumerable.Empty<FileInfo>());
            DDTResolveInternal((typeof(AssemblyResolver_iTests).Assembly.GetName(), (SearchOption) 1000), Enumerable.Empty<FileInfo>());
            DDTResolveInternal((typeof(AssemblyResolver_iTests).Assembly.GetName(), (SearchOption) 1000), Enumerable.Empty<FileInfo>());
            DDTResolveInternal((typeof(AssemblyResolver_iTests).Assembly.GetName(), SearchOption.AllDirectories), Enumerable.Empty<FileInfo>());

            DDTResolveInternal((typeof(StringExtensions).Assembly.GetName(), SearchOption.AllDirectories), new FileInfo[] {
                new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
            });

        }

        void DDTResolveInternal((AssemblyName assemblyName, SearchOption searchOption) input, IEnumerable<FileInfo> expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IEnumerable<FileInfo> files = null;

            Test.Note($"AssemblyResolver.ResolveInternal({input.assemblyName.Format()}, {input.searchOption.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => files = AssemblyResolver.ResolveInternal(input.assemblyName, input.searchOption), out Exception ex, _file, _method);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer, _file, _method);

        }

        void DDTResolveInternal((AssemblyName assemblyName, DirectoryInfo searchDir, SearchOption searchOption) input, IEnumerable<FileInfo> expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IEnumerable<FileInfo> files = null;

            Test.Note($"AssemblyResolver.ResolveInternal({input.assemblyName.Format()}, {input.searchDir.Format()}, {input.searchOption.Format()}) == {expected.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => files = AssemblyResolver.ResolveInternal(input.assemblyName, input.searchDir, input.searchOption), out Exception ex, _file, _method);

            Test.If.Enumerable.Matches(files, expected, Statics.FileInfoComparer, _file, _method);

        }

        #endregion

    }
}
