using System;

using Nuclear.Assemblies.Factory;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers {
    class DefaultResolverFactory_uTests {

        [TestMethod]
        void Implementation() {

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

    }
}
