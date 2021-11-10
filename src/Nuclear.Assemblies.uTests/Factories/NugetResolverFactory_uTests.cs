using System;
using System.IO;
using System.Linq;

using Nuclear.Assemblies.Factories;
using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class NugetResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<NugetResolverFactory, INugetResolverFactory>();

        }

        #region CreateResolver

        [TestMethod]
        void CreateResolver() {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        #endregion

        #region TryCreateResolver

        [TestMethod]
        void TryCreateResolver() {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        #endregion

        #region TryCreateResolverWithExOut

        [TestMethod]
        void TryCreateResolverWithExOut() {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), NugetResolver.GetCaches().Select(_ => _.FullName));

        }

        #endregion

        #region CreateResolverWithCaches

        [TestMethod]
        void CreateResolverWithCaches() {

            var creator = Factory.Instance.NugetResolver();
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        #endregion

        #region TryCreateResolverWithCaches

        [TestMethod]
        void TryCreateResolverWithCaches() {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, new DirectoryInfo[] { Statics.FakeNugetCache }), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        #endregion

        #region TryCreateResolverWithCachesWithExOut

        [TestMethod]
        void TryCreateResolverWithExOutWithCaches() {

            var creator = Factory.Instance.NugetResolver();
            Boolean result = default;
            INugetResolver obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, new DirectoryInfo[] { Statics.FakeNugetCache }, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Object.IsNull(ex);
            Test.IfNot.Object.IsNull(obj);
            Test.If.Enumerable.Matches(obj.NugetCaches.Select(_ => _.FullName), new String[] { Statics.FakeNugetCache.FullName });

        }

        #endregion

    }
}
