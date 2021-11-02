using System;

using Nuclear.TestSite;

namespace Nuclear.Creation {
    class InternalFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<InternalFactory, IFactory>();

        }

        [TestMethod]
        void Creator() {

            ICreatorFactory fac1 = default;
            ICreatorFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Factory.Instance.Creator, out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Factory.Instance.Creator, out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

    }
}
