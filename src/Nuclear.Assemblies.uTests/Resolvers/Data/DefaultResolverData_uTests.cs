using System;

using Nuclear.TestSite;

namespace Nuclear.Assemblies.Resolvers.Data {
    class DefaultResolverData_uTests {

        #region ctors

        [TestMethod]
        void Ctor_Throws() {

            IDefaultResolverData data = default;

            Test.If.Action.ThrowsException(() => data = new DefaultResolverData(null), out ArgumentNullException ex);

            Test.If.String.StartsWith(ex.Message, "Parameter 'file' must not be null.");

        }

        #endregion

    }
}
