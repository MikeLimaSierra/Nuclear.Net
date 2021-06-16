using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Data {
    class DefaultResolverData_uTests {

        #region ctors

        [TestMethod]
        [TestData(nameof(CtorThrowsData))]
        void CtorThrows<TException>(FileInfo input, String message) where TException : Exception {

            IDefaultResolverData data = default;

            Test.If.Action.ThrowsException(() => data = new DefaultResolverData(input), out TException ex);

            Test.IfNot.Object.IsNull(ex);
            Test.If.String.StartsWith(ex.Message, message);

        }

        IEnumerable<Object[]> CtorThrowsData() {
            FileInfo file = new FileInfo(@"C:\NonExistentFile.txt");

            return new List<Object[]>() {
                new Object[] { typeof(ArgumentNullException), null, "Parameter 'file' must not be null." },
                new Object[] { typeof(ArgumentException), file, $"Could not resolve the AssemblyName of file {file.Format()}." }
            };
        }

        [TestMethod]
        [TestData(nameof(CtorData))]
        void Ctor(FileInfo input, Boolean expected) {

            IDefaultResolverData data = default;

            Test.IfNot.Action.ThrowsException(() => data = new DefaultResolverData(input), out Exception ex);

            Test.IfNot.Object.IsNull(data.Name);
            Test.If.Value.IsEqual(data.IsValid, expected);

        }

        IEnumerable<Object[]> CtorData() {
            return new List<Object[]>() {
                new Object[] { new FileInfo(Assembly.GetEntryAssembly().Location), true },
                new Object[] { new FileInfo(typeof(IDefaultResolver).Assembly.Location), true }
            };
        }

        #endregion

    }
}
