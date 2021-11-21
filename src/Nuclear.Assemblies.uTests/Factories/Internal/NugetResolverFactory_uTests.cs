using System;
using System.IO;
using System.Linq;

using Nuclear.Assemblies.Resolvers;
using Nuclear.Assemblies.Resolvers.Internal;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Factories.Internal {
    class NugetResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<NugetResolverFactory, INugetResolverFactory>();

        }

        #region CreateResolver

        [TestMethod]
        [TestParameters(MatchingStrategies.Strict)]
        [TestParameters(MatchingStrategies.SemVer)]
        void CreateResolver(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, input), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, input);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown, "Strategy must not be 'Unknown'")]
        [TestParameters((MatchingStrategies) 42, "Given strategy is not defined '42'")]
        void CreateResolver_Throws(MatchingStrategies input, String message) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.If.Action.ThrowsException(() => creator.Create(out obj, input), out ArgumentException ex);

            Test.If.Object.IsNull(obj);
            Test.If.Value.IsEqual(ex.ParamName, "assemblyStrategy");
            Test.If.String.Contains(ex.Message, message);

        }

        #endregion

        #region TryCreateResolver

        [TestMethod]
        [TestParameters(MatchingStrategies.Strict)]
        [TestParameters(MatchingStrategies.SemVer)]
        void TryCreateResolver(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, input);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown)]
        [TestParameters((MatchingStrategies) 42)]
        void TryCreateResolver_DoesNotThrow(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        #endregion

        #region TryCreateResolverWithExOut

        [TestMethod]
        [TestParameters(MatchingStrategies.Strict)]
        [TestParameters(MatchingStrategies.SemVer)]
        void TryCreateResolverWithExOut(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, input);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown, "Strategy must not be 'Unknown'")]
        [TestParameters((MatchingStrategies) 42, "Given strategy is not defined '42'")]
        void TryCreateResolverWithExOut_DoesNotThrow(MatchingStrategies input, String message) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);
            Test.If.Value.IsEqual(((ArgumentException) ex).ParamName, "assemblyStrategy");
            Test.If.String.Contains(ex.Message, message);
            Test.If.Object.IsNull(obj);

        }

        #endregion

        #region CreateResolverWithCaches

        [TestMethod]
        [TestParameters(MatchingStrategies.Strict)]
        [TestParameters(MatchingStrategies.SemVer)]
        void CreateResolverWithCaches(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, input, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, input);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown, "Strategy must not be 'Unknown'")]
        [TestParameters((MatchingStrategies) 42, "Given strategy is not defined '42'")]
        void CreateResolverWithCaches_Throws(MatchingStrategies input, String message) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.If.Action.ThrowsException(() => creator.Create(out obj, input, new DirectoryInfo[] { Statics.FakeNugetCache }), out ArgumentException ex);

            Test.If.Object.IsNull(obj);
            Test.If.Value.IsEqual(ex.ParamName, "assemblyStrategy");
            Test.If.String.Contains(ex.Message, message);

        }

        #endregion

        #region TryCreateResolverWithCaches

        [TestMethod]
        [TestParameters(MatchingStrategies.Strict)]
        [TestParameters(MatchingStrategies.SemVer)]
        void TryCreateResolverWithCaches(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, input);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown)]
        [TestParameters((MatchingStrategies) 42)]
        void TryCreateResolverWithCaches_DoesNotThrow(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        #endregion

        #region TryCreateResolverWithCachesWithExOut

        [TestMethod]
        [TestParameters(MatchingStrategies.Strict)]
        [TestParameters(MatchingStrategies.SemVer)]
        void TryCreateResolverWithExOutWithCaches(MatchingStrategies input) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input, new DirectoryInfo[] { Statics.FakeNugetCache }, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, input);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        [TestMethod]
        [TestParameters(MatchingStrategies.Unknown, "Strategy must not be 'Unknown'")]
        [TestParameters((MatchingStrategies) 42, "Given strategy is not defined '42'")]
        void TryCreateResolverWithExOutWithCaches_DoesNotThrow(MatchingStrategies input, String message) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, input, new DirectoryInfo[] { Statics.FakeNugetCache }, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<ArgumentException>(ex);
            Test.If.Value.IsEqual(((ArgumentException) ex).ParamName, "assemblyStrategy");
            Test.If.String.Contains(ex.Message, message);
            Test.If.Object.IsNull(obj);

        }

        #endregion

    }
}
