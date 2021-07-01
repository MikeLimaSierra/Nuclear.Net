using System;

using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.SemVer.Factories {
    class ISemVerFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ISemVerFactory, ICreator<ISemVer, String>>();

        }

    }
}
