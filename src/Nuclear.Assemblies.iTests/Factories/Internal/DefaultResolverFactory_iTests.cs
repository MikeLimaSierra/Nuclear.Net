using System;
using System.IO;

using Nuclear.Assemblies.ResolverData;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Factories.Internal {
    class DefaultResolverFactory_iTests {

        private static readonly FileInfo _nonExistentAssembly = new FileInfo(@"C:\NonExistent.dll");

        private static readonly FileInfo _existingAssembly = new FileInfo(Statics.TestAsm.Location);

        #region CreateResolverData

        [TestMethod]
        void CreateResolverDataThrows() {

            var creator = Factory.Instance.DefaultResolver();

            Test.If.Action.ThrowsException(() => creator.Create(out _, _nonExistentAssembly), out ArgumentException ex);

            Test.If.String.StartsWith(ex.Message, $"Could not resolve the AssemblyName of file '{_nonExistentAssembly}'.");
            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        [TestMethod]
        void CreateResolverData() {

            var creator = Factory.Instance.DefaultResolver();
            IDefaultResolverData obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, _existingAssembly), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, _existingAssembly);
            Test.If.Value.IsTrue(obj.IsValid);

        }

        #endregion

        #region TryCreateResolverData

        [TestMethod]
        void TryCreateResolverDataDoesNotThrow() {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, _nonExistentAssembly), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateResolverData() {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, _existingAssembly), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, _existingAssembly);
            Test.If.Value.IsTrue(obj.IsValid);

        }

        #endregion

        #region TryCreateResolverDataWithExOut

        [TestMethod]
        void TryCreateResolverDataWithExOutDoesNotThrow() {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, _nonExistentAssembly, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsNull(obj);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);
            Test.If.String.StartsWith(ex.Message, $"Could not resolve the AssemblyName of file '{_nonExistentAssembly}'.");
            Test.If.Value.IsEqual(((ArgumentException) ex).ParamName, "file");

        }

        [TestMethod]
        void TryCreateResolverDataWithExOut() {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, _existingAssembly, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, _existingAssembly);
            Test.If.Value.IsTrue(obj.IsValid);

        }

        #endregion

    }
}
