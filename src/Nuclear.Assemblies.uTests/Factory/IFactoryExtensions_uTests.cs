using System;

using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Factory {
    class IFactoryExtensions_uTests {

        #region SemVer

        [TestMethod]
        public void DefaultResolver() {

            IDefaultResolverFactory fac1 = default;
            IDefaultResolverFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Creation.Factory.Instance.DefaultResolver(), out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Creation.Factory.Instance.DefaultResolver(), out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

        #endregion

        #region SemVer

        [TestMethod]
        public void NugetResolver() {

            INugetResolverFactory fac1 = default;
            INugetResolverFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Creation.Factory.Instance.NugetResolver(), out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Creation.Factory.Instance.NugetResolver(), out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

        #endregion

    }
}
