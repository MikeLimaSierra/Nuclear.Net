using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolver_iTests {

        #region TryResolve

        [TestMethod]
        void TryResolve() {

            DDTTryResolve((ResolveEventArgs) null, (false, null));
            DDTTryResolve(new ResolveEventArgs(null, null), (false, null));
            DDTTryResolve(new ResolveEventArgs("", null), (false, null));
            DDTTryResolve(new ResolveEventArgs("some name", null), (false, null));
            DDTTryResolve(new ResolveEventArgs(typeof(DefaultResolver_iTests).Assembly.FullName, null), (false, null));
            DDTTryResolve(new ResolveEventArgs(typeof(StringExtensions).Assembly.FullName, null), (true, new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))));
            DDTTryResolve(new ResolveEventArgs(typeof(DefaultResolver).Assembly.FullName, Statics.TestAsm), (true, new FileInfo(Path.Combine(Statics.TestPath.DirectoryName, "Nuclear.Assemblies.dll"))));

            DDTTryResolve((String) null, (false, null));
            DDTTryResolve("", (false, null));
            DDTTryResolve("some name", (false, null));
            DDTTryResolve(typeof(DefaultResolver_iTests).Assembly.FullName, (false, null));
            DDTTryResolve(typeof(StringExtensions).Assembly.FullName, (true, new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))));

            DDTTryResolve((AssemblyName) null, (false, null));
            DDTTryResolve(typeof(DefaultResolver_iTests).Assembly.GetName(), (false, null));
            DDTTryResolve(typeof(StringExtensions).Assembly.GetName(), (true, new FileInfo(Path.Combine(Statics.EntryPath.DirectoryName, "Nuclear.Extensions.dll"))));

        }

        void DDTTryResolve(ResolveEventArgs input, (Boolean result, FileInfo file) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IAssemblyResolver instance = DefaultResolver.Instance;
            Boolean result = false;
            FileInfo file = null;

            Test.Note($"DefaultResolver.TryResolve({input.Format()}, out {expected.file.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out file), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(file, expected.file, Statics.FileInfoComparer, _file, _method);

        }

        void DDTTryResolve(String input, (Boolean result, FileInfo file) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IAssemblyResolver instance = DefaultResolver.Instance;
            Boolean result = false;
            FileInfo file = null;

            Test.Note($"DefaultResolver.TryResolve({input.Format()}, out {expected.file.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out file), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(file, expected.file, Statics.FileInfoComparer, _file, _method);

        }

        void DDTTryResolve(AssemblyName input, (Boolean result, FileInfo file) expected,
            [CallerFilePath] String _file = null, [CallerMemberName] String _method = null) {

            IAssemblyResolver instance = DefaultResolver.Instance;
            Boolean result = false;
            FileInfo file = null;

            Test.Note($"DefaultResolver.TryResolve({input.Format()}, out {expected.file.Format()}) == {expected.result.Format()}", _file, _method);

            Test.IfNot.Action.ThrowsException(() => result = instance.TryResolve(input, out file), out Exception ex, _file, _method);

            Test.If.Value.IsEqual(result, expected.result, _file, _method);
            Test.If.Value.IsEqual(file, expected.file, Statics.FileInfoComparer, _file, _method);

        }

        #endregion

    }
}
