using System;
using System.IO;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Internal;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Factories.Internal {
    class DefaultResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<DefaultResolverFactory, IDefaultResolverFactory>();

        }

        #region CreateResolver

        [TestMethod]
        [TestParameters(MatchingStrategies.Strict, SearchOption.AllDirectories)]
        [TestParameters(MatchingStrategies.SemVer, SearchOption.TopDirectoryOnly)]
        void CreateResolver(MatchingStrategies in1, SearchOption in2) {

            var creator = Factory.Instance.DefaultResolver();
            IDefaultResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, in1, in2), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.SearchOption, in2);
            Test.If.Object.IsOfExactType<InternalDefaultResolver>(((DefaultResolver) obj).InternalResolver);

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown, SearchOption.AllDirectories, "assemblyStrategy", "Strategy must not be 'Unknown'")]
        [TestParameters((MatchingStrategies) 42, SearchOption.AllDirectories, "assemblyStrategy", "Given strategy is not defined '42'")]
        [TestParameters(MatchingStrategies.Strict, (SearchOption) 42, "searchOption", "Given search option is not defined '42'")]
        void CreateResolver_Throws(MatchingStrategies in1, SearchOption in2, String paramName, String message) {

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
        [TestParameters(MatchingStrategies.Strict, SearchOption.AllDirectories)]
        [TestParameters(MatchingStrategies.SemVer, SearchOption.TopDirectoryOnly)]
        void TryCreateResolver(MatchingStrategies in1, SearchOption in2) {

            var creator = Factory.Instance.DefaultResolver();
            Boolean result = default;
            IDefaultResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.SearchOption, in2);
            Test.If.Object.IsOfExactType<InternalDefaultResolver>(((DefaultResolver) obj).InternalResolver);

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown, SearchOption.AllDirectories)]
        [TestParameters((MatchingStrategies) 42, SearchOption.AllDirectories)]
        [TestParameters(MatchingStrategies.Strict, (SearchOption) 42)]
        void TryCreateResolver_DoesNotThrow(MatchingStrategies in1, SearchOption in2) {

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
        [TestParameters(MatchingStrategies.Strict, SearchOption.AllDirectories)]
        [TestParameters(MatchingStrategies.SemVer, SearchOption.TopDirectoryOnly)]
        void TryCreateResolverWithExOut(MatchingStrategies in1, SearchOption in2) {

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
            Test.If.Object.IsOfExactType<InternalDefaultResolver>(((DefaultResolver) obj).InternalResolver);

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown, SearchOption.AllDirectories, "assemblyStrategy", "Strategy must not be 'Unknown'")]
        [TestParameters((MatchingStrategies) 42, SearchOption.AllDirectories, "assemblyStrategy", "Given strategy is not defined '42'")]
        [TestParameters(MatchingStrategies.Strict, (SearchOption) 42, "searchOption", "Given search option is not defined '42'")]
        void TryCreateResolverWithExOut_DoesNotThrow(MatchingStrategies in1, SearchOption in2, String paramName, String message) {

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
