using System;
using System.IO;

using Nuclear.Assemblies.Factory;
using Nuclear.Assemblies.Resolvers.Data;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<IDefaultResolverFactory, ICreator<IDefaultResolver>>();
            Test.If.Type.Implements<IDefaultResolverFactory, ICreator<IDefaultResolverData, FileInfo>>();

            Test.If.Type.Implements<DefaultResolverFactory, IDefaultResolverFactory>();

        }

        #region CreateResolver

        [TestMethod]
        void CreateResolver() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            IDefaultResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj), out Exception _);

            Test.IfNot.Object.IsNull(obj);

        }

        #endregion

        #region TryCreateResolver

        [TestMethod]
        void TryCreateResolver() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);

        }

        #endregion

        #region TryCreateResolverWithExOut

        [TestMethod]
        void TryCreateResolverWithExOut() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);

        }

        #endregion

        #region CreateResolverData

        [TestMethod]
        void CreateResolverDataThrows() {

            var creator = Creation.Factory.Instance.DefaultResolver();

            Test.If.Action.ThrowsException(() => creator.Create(out _, new FileInfo(@"C:\NonExistentFile.txt")), out ArgumentException ex);

            Test.If.String.StartsWith(ex.Message, @"Could not resolve the AssemblyName of file 'C:\NonExistentFile.txt'.");
            Test.If.Value.IsEqual(ex.ParamName, "file");

        }

        [TestMethod]
        void CreateResolverData() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            IDefaultResolverData obj = default;
            FileInfo in1 = new FileInfo(typeof(Statics).Assembly.Location);

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, in1), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, in1);
            Test.If.Value.IsTrue(obj.IsValid);

        }

        #endregion

        #region TryCreateResolverData

        [TestMethod]
        void TryCreateResolverDataDoesNotThrow() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, new FileInfo(@"C:\NonExistentFile.txt")), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateResolverData() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;
            FileInfo in1 = new FileInfo(typeof(Statics).Assembly.Location);

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, in1);
            Test.If.Value.IsTrue(obj.IsValid);

        }

        #endregion

        #region TryCreateResolverDataWithExOut

        [TestMethod]
        void TryCreateResolverDataWithExOutDoesNotThrow() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, new FileInfo(@"C:\NonExistentFile.txt"), out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsNull(obj);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);
            Test.If.String.StartsWith(((ArgumentException) ex).Message, @"Could not resolve the AssemblyName of file 'C:\NonExistentFile.txt'.");
            Test.If.Value.IsEqual(((ArgumentException) ex).ParamName, "file");

        }

        [TestMethod]
        void TryCreateResolverDataWithExOut() {

            var creator = Creation.Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolverData obj = default;
            FileInfo in1 = new FileInfo(typeof(Statics).Assembly.Location);
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.File, in1);
            Test.If.Value.IsTrue(obj.IsValid);

        }

        #endregion

    }
}
