using System;

using Nuclear.TestSite;

namespace Nuclear.Creation.Internal {
    class Factory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<Factory, IFactory>();

        }

        [TestMethod]
        void Creator() {

            ICreatorFactory fac1 = default;
            ICreatorFactory fac2 = default;

            Test.IfNot.Action.ThrowsException(() => fac1 = Creation.Factory.Instance.Creator, out Exception _);
            Test.IfNot.Action.ThrowsException(() => fac2 = Creation.Factory.Instance.Creator, out Exception _);

            Test.IfNot.Object.IsNull(fac1);
            Test.IfNot.Object.IsNull(fac2);
            Test.IfNot.Reference.IsEqual(fac1, fac2);

        }

    }
}
