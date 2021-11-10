using System;
using System.Collections.Generic;
using System.IO;

using Nuclear.Assemblies.Factories;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class NugetResolverFactory_iTests {

        private static readonly FileInfo _nonExistentAssembly = new FileInfo(@"C:\NonExistentFile.txt");

        private static readonly FileInfo _validAssembly = new FileInfo(Path.Combine(Statics.FakeNugetCache.FullName, Statics.SimpleFakePackageName, "1.1.0", "lib", "netstandard2.1", $"{Statics.SimpleFakePackageName}.dll"));

        IEnumerable<Object[]> CreateResolverData_Data() {
            return new List<Object[]>() {
                new Object[] { new FileInfo(Statics.TestAsm.Location), false },
                new Object[] { _validAssembly, true },
            };
        }

        #region CreateResolverData

        [TestMethod]
        void CreateResolverDataThrows() {

            var creator = Factory.Instance.NugetResolver();

            Test.If.Action.ThrowsException(() => creator.Create(out _, _nonExistentAssembly), out ArgumentException ex);

            Test.If.String.StartsWith(ex.Message, $"Could not resolve the AssemblyName of file '{_nonExistentAssembly}'.");
            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        [TestMethod]
        [TestData(nameof(CreateResolverData_Data))]
        void CreateResolverData(FileInfo in1, Boolean isValid) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolverData obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, in1), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, in1);
            Test.If.Value.IsEqual(obj.IsValid, isValid);

        }

        #endregion

        #region TryCreateResolverData

        [TestMethod]
        void TryCreateResolverDataDoesNotThrow() {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolverData obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, _nonExistentAssembly), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        [TestData(nameof(CreateResolverData_Data))]
        void TryCreateResolverData(FileInfo in1, Boolean isValid) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolverData obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, in1);
            Test.If.Value.IsEqual(obj.IsValid, isValid);

        }

        #endregion

        #region TryCreateResolverDataWithExOut

        [TestMethod]
        void TryCreateResolverDataWithExOutDoesNotThrow() {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolverData obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, _nonExistentAssembly, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsNull(obj);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);
            Test.If.String.StartsWith(((ArgumentException) ex).Message, $"Could not resolve the AssemblyName of file '{_nonExistentAssembly}'.");
            Test.If.Value.IsEqual(((ArgumentException) ex).ParamName, "file");

        }

        [TestMethod]
        [TestData(nameof(CreateResolverData_Data))]
        void TryCreateResolverDataWithExOut(FileInfo in1, Boolean isValid) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolverData obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, in1);
            Test.If.Value.IsEqual(obj.IsValid, isValid);

        }

        #endregion

    }
}
