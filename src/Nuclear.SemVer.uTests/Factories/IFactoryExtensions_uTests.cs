using System;

using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.SemVer.Factories {
    class IFactoryExtensions_uTests {

        [TestMethod]
        void Implementation() {

            ISemVerFactory factory1 = default;
            ISemVerFactory factory2 = default;

            Test.IfNot.Action.ThrowsException(() => factory1 = Factory.Instance.SemVer(), out Exception ex);
            Test.IfNot.Action.ThrowsException(() => factory2 = Factory.Instance.SemVer(), out ex);

            Test.IfNot.Object.IsNull(factory1);
            Test.IfNot.Object.IsNull(factory2);
            Test.IfNot.Reference.IsEqual(factory1, factory2);

        }

    }
}
