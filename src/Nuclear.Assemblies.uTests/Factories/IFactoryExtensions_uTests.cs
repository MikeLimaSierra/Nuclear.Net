using System;

using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.Assemblies.Factories {
    class IFactoryExtensions_uTests {

        #region DefaultResolver

        [TestMethod]
        public void DefaultResolver() {

            DefaultResolverFactory fac1 = default;
            DefaultResolverFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Factory.Instance.DefaultResolver(), out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Factory.Instance.DefaultResolver(), out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

        #endregion

        #region NugetResolver

        [TestMethod]
        public void NugetResolver() {

            NugetResolverFactory fac1 = default;
            NugetResolverFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Factory.Instance.NugetResolver(), out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Factory.Instance.NugetResolver(), out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

        #endregion

    }
}
