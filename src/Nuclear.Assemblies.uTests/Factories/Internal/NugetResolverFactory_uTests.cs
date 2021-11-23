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

            Test.If.Type.IsSubClass<NugetResolverFactory, Factories.NugetResolverFactory>();

        }

        #region CreateResolver

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer)]
        void CreateResolver(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, in1, in2), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.PackageMatchingStrategy, in2);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, VersionMatchingStrategies.Strict, "assemblyMatchingStrategy", "Given strategy is not defined '42'")]
        [TestParameters(VersionMatchingStrategies.Strict, (VersionMatchingStrategies) 21, "packageMatchingStrategy", "Given strategy is not defined '21'")]
        void CreateResolver_Throws(VersionMatchingStrategies in1, VersionMatchingStrategies in2, String paramName, String message) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.If.Action.ThrowsException(() => creator.Create(out obj, in1, in2), out ArgumentException ex);

            Test.If.Object.IsNull(obj);
            Test.If.Value.IsEqual(ex.ParamName, paramName);
            Test.If.String.Contains(ex.Message, message);

        }

        #endregion

        #region TryCreateResolver

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer)]
        void TryCreateResolver(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.PackageMatchingStrategy, in2);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.Strict, (VersionMatchingStrategies) 21)]
        void TryCreateResolver_DoesNotThrow(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        #endregion

        #region TryCreateResolverWithExOut

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer)]
        void TryCreateResolverWithExOut(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.PackageMatchingStrategy, in2);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, VersionMatchingStrategies.Strict, "assemblyMatchingStrategy", "Given strategy is not defined '42'")]
        [TestParameters(VersionMatchingStrategies.Strict, (VersionMatchingStrategies) 21, "packageMatchingStrategy", "Given strategy is not defined '21'")]
        void TryCreateResolverWithExOut_DoesNotThrow(VersionMatchingStrategies in1, VersionMatchingStrategies in2, String paramName, String message) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
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

        #region CreateResolverWithCaches

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer)]
        void CreateResolverWithCaches(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, in1, in2, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.PackageMatchingStrategy, in2);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, VersionMatchingStrategies.Strict, "assemblyMatchingStrategy", "Given strategy is not defined '42'")]
        [TestParameters(VersionMatchingStrategies.Strict, (VersionMatchingStrategies) 21, "packageMatchingStrategy", "Given strategy is not defined '21'")]
        void CreateResolverWithCaches_Throws(VersionMatchingStrategies in1, VersionMatchingStrategies in2, String paramName, String message) {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.If.Action.ThrowsException(() => creator.Create(out obj, in1, in2, new DirectoryInfo[] { Statics.FakeNugetCache }), out ArgumentException ex);

            Test.If.Object.IsNull(obj);
            Test.If.Value.IsEqual(ex.ParamName, paramName);
            Test.If.String.Contains(ex.Message, message);

        }

        #endregion

        #region TryCreateResolverWithCaches

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer)]
        void TryCreateResolverWithCaches(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.PackageMatchingStrategy, in2);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.Strict, (VersionMatchingStrategies) 21)]
        void TryCreateResolverWithCaches_DoesNotThrow(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        #endregion

        #region TryCreateResolverWithCachesWithExOut

        [TestMethod]
        [TestParameters(VersionMatchingStrategies.Strict, VersionMatchingStrategies.Strict)]
        [TestParameters(VersionMatchingStrategies.SemVer, VersionMatchingStrategies.SemVer)]
        void TryCreateResolverWithExOutWithCaches(VersionMatchingStrategies in1, VersionMatchingStrategies in2) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2, new DirectoryInfo[] { Statics.FakeNugetCache }, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.AssemblyMatchingStrategy, in1);
            Test.If.Value.IsEqual(obj.PackageMatchingStrategy, in2);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        [TestMethod]
        [TestParameters((VersionMatchingStrategies) 42, VersionMatchingStrategies.Strict, "assemblyMatchingStrategy", "Given strategy is not defined '42'")]
        [TestParameters(VersionMatchingStrategies.Strict, (VersionMatchingStrategies) 21, "packageMatchingStrategy", "Given strategy is not defined '21'")]
        void TryCreateResolverWithExOutWithCaches_DoesNotThrow(VersionMatchingStrategies in1, VersionMatchingStrategies in2, String paramName, String message) {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, in1, in2, new DirectoryInfo[] { Statics.FakeNugetCache }, out ex), out Exception _);

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
