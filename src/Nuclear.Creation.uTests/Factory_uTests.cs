using System;

using Nuclear.TestSite;

namespace Nuclear.Creation {
    class Factory_uTests {

        [TestMethod]
        void New() {

            IFactory fac1 = default;
            IFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Factory.New, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => fac2 = Factory.New, out ex);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

        [TestMethod]
        void Instance() {

            IFactory fac1 = default;
            IFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Factory.Instance, out Exception ex);
            Test.IfNot.Action.ThrowsException(() => fac2 = Factory.Instance, out ex);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.If.Reference.IsEqual(fac1, fac2);

        }

    }
}
