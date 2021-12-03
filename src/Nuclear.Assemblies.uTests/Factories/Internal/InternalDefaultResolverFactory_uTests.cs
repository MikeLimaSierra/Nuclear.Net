using System;
using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Internal;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Factories.Internal {
    class InternalDefaultResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.IsSubClass<DefaultResolverFactory, Factories.DefaultResolverFactory>();

        }

        #region CreateResolver

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, SearchOption.AllDirectories)]
        [TestParameters(VersionMatchingStrategies.SemVer, SearchOption.TopDirectoryOnly)]
        void CreateResolver(VersionMatchingStrategies in1, SearchOption in2) {

            var creator = Factory.Instance.DefaultResolver();
            IDefaultResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, in1, in2), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.SearchOption, in2);
            Test.If.Object.IsOfExactType<CoreDefaultResolver>(((DefaultResolver) obj).CoreResolver);

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, SearchOption.AllDirectories, "assemblyMatchingStrategy", "Given strategy is not defined '42'")]
        [TestParameters(VersionMatchingStrategies.Strict, (SearchOption) 42, "searchOption", "Given search option is not defined '42'")]
        void CreateResolver_Throws(VersionMatchingStrategies in1, SearchOption in2, String paramName, String message) {

            var creator = Factory.Instance.DefaultResolver();
            IDefaultResolver obj = default;

            Test.If.Action.ThrowsException(() => creator.Create(out obj, in1, in2), out ArgumentException ex);

            Test.If.Object.IsNull(obj);
            Test.If.Value.IsEqual(ex.ParamName, paramName);
            Test.If.String.Contains(ex.Message, message);

        }

        #endregion

        #region TryCreateResolver

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, SearchOption.AllDirectories)]
        [TestParameters(VersionMatchingStrategies.SemVer, SearchOption.TopDirectoryOnly)]
        void TryCreateResolver(VersionMatchingStrategies in1, SearchOption in2) {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.SearchOption, in2);
            Test.If.Object.IsOfExactType<CoreDefaultResolver>(((DefaultResolver) obj).CoreResolver);

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, SearchOption.AllDirectories)]
        [TestParameters(VersionMatchingStrategies.Strict, (SearchOption) 42)]
        void TryCreateResolver_DoesNotThrow(VersionMatchingStrategies in1, SearchOption in2) {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        #endregion

        #region TryCreateResolverWithExOut

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, SearchOption.AllDirectories)]
        [TestParameters(VersionMatchingStrategies.SemVer, SearchOption.TopDirectoryOnly)]
        void TryCreateResolverWithExOut(VersionMatchingStrategies in1, SearchOption in2) {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.SearchOption, in2);
            Test.If.Object.IsOfExactType<CoreDefaultResolver>(((DefaultResolver) obj).CoreResolver);

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, SearchOption.AllDirectories, "assemblyMatchingStrategy", "Given strategy is not defined '42'")]
        [TestParameters(VersionMatchingStrategies.Strict, (SearchOption) 42, "searchOption", "Given search option is not defined '42'")]
        void TryCreateResolverWithExOut_DoesNotThrow(VersionMatchingStrategies in1, SearchOption in2, String paramName, String message) {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);
            Test.If.Value.IsEqual(((ArgumentException) ex).ParamName, paramName);
            Test.If.String.Contains(ex.Message, message);
            Test.If.Object.IsNull(obj);

        }

        #endregion

    }
}
