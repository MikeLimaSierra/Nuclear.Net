using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Nuclear.Extensions;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Data {
    class DefaultResolverData_iTests {

        #region ctors

        [TestMethod]
        void Ctor_Throws() {

            IDefaultResolverData data = default;
            FileInfo file = new FileInfo(@"C:\NonExistentFile.txt");

            Test.If.Action.ThrowsException(() => data = new DefaultResolverData(file), out ArgumentException ex);

            Test.If.String.StartsWith(ex.Message, $"Could not resolve the AssemblyName of file {file.Format()}.");

        }

        [TestMethod]
        [TestData(nameof(Ctor_Data))]
        void Ctor(FileInfo input, Boolean expected) {

            IDefaultResolverData data = default;

            Test.IfNot.Action.ThrowsException(() => data = new DefaultResolverData(input), out Exception ex);

            Test.IfNot.Object.IsNull(data.Name);
            Test.If.Value.IsEqual(data.IsValid, expected);

        }

        IEnumerable<Object[]> Ctor_Data() {
            return new List<Object[]>() {
                new Object[] { new FileInfo(Assembly.GetEntryAssembly().Location), true },
                new Object[] { new FileInfo(typeof(IDefaultResolver).Assembly.Location), true }
            };
        }

        #endregion

    }
}
