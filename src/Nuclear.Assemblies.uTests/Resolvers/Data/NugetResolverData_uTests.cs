using System;

using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Data {
    class NugetResolverData_uTests {

        #region ctors

        [TestMethod]
        void Ctor_Throws() {

            INugetResolverData data = default;

            Test.If.Action.ThrowsException(() => data = new NugetResolverData(null), out ArgumentNullException ex);

            Test.If.String.StartsWith(ex.Message, "Parameter 'file' must not be null.");

        }

        #endregion

    }

}
