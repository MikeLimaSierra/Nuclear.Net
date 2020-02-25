using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolver_iTests {

        #region TryResolve

        [TestMethod]
        void TryResolve() {

            DDTTryResolve((ResolveEventArgs) null, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs(null, null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs("", null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs("some name", null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs(typeof(DefaultResolver_iTests).Assembly.FullName, null), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(new ResolveEventArgs(typeof(StringExtensions).Assembly.FullName, null), (true, new FileInfo[] {
                new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
            }));
            DDTTryResolve(new ResolveEventArgs(typeof(DefaultResolver).Assembly.FullName, Statics.TestAsm), (true, new FileInfo[] {
                new FileInfo(Path.Combine(Statics.TestPath.DirectoryName, "Nuclear.Assemblies.dll"))
            }));

            DDTTryResolve((String) null, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve("", (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve("some name", (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(typeof(DefaultResolver_iTests).Assembly.FullName, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(typeof(StringExtensions).Assembly.FullName, (true, new FileInfo[] {
                new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
            }));

            DDTTryResolve((AssemblyName) null, (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(typeof(DefaultResolver_iTests).Assembly.GetName(), (false, Enumerable.Empty<FileInfo>()));
            DDTTryResolve(typeof(StringExtensions).Assembly.GetName(), (true, new FileInfo[] {
                new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))
            }));

        }

        void DDTTryResolve(ResolveEventArgs input, (Boolean result, IEnumerable<FileInfo> files) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IDefaultResolver instance = DefaultResolver.Instance;
            Boolean result = false;
            IEnumerable<FileInfo> files = null;

            Test.Note($"DefaultResolver.TryResolve({input.Format()}, out {expected.files.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out files), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(files, expected.files, Statics.FileInfoComparer, _file, _method);

        }

        void DDTTryResolve(String input, (Boolean result, IEnumerable<FileInfo> files) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IDefaultResolver instance = DefaultResolver.Instance;
            Boolean result = false;
            IEnumerable<FileInfo> files = null;

            Test.Note($"DefaultResolver.TryResolve({input.Format()}, out {expected.files.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out files), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(files, expected.files, Statics.FileInfoComparer, _file, _method);

        }

        void DDTTryResolve(AssemblyName input, (Boolean result, IEnumerable<FileInfo> files) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IDefaultResolver instance = DefaultResolver.Instance;
            Boolean result = false;
            IEnumerable<FileInfo> files = null;

            Test.Note($"DefaultResolver.TryResolve({input.Format()}, out {expected.files.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out files), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Enumerable.Matches(files, expected.files, Statics.FileInfoComparer, _file, _method);

        }

        #endregion

    }
}
