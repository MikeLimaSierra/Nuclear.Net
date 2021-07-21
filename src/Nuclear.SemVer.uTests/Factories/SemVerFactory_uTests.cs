using System;
using System.Collections.Generic;

using Nuclear.Creation;
using Nuclear.TestSite;

namespace Nuclear.SemVer.Factories {
    [TestClass("asdf")]
    class SemVerFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<ISemVerFactory, ICreator<ISemVer, String>>();
            Test.If.Type.Implements<SemVerFactory, ISemVerFactory>();

        }

        #region Create

        [TestMethod]
        [TestParameters(typeof(ArgumentNullException), null)]
        [TestParameters(typeof(ArgumentException), "")]
        [TestParameters(typeof(FormatException), "1")]
        void CreateThrows<TException>(String input) where TException : Exception {

            ISemVerFactory factory = Factory.Instance.SemVer();
            ISemVer obj = default;

            Test.If.Action.ThrowsException(() => factory.Create(out obj, input), out TException ex);

            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        [TestData(nameof(CreateData))]
        void Create(String input, (Int32 major, Int32 minor, Int32 patch, String pr, String md) expected) {

            ISemVerFactory factory = Factory.Instance.SemVer();
            ISemVer obj = default;

            Test.IfNot.Action.ThrowsException(() => factory.Create(out obj, input), out Exception ex);

            Test.IfNot.Object.IsNull(obj);
            Test.If.Value.IsEqual(obj.Major, expected.major);
            Test.If.Value.IsEqual(obj.Minor, expected.minor);
            Test.If.Value.IsEqual(obj.Patch, expected.patch);
            Test.If.Value.IsEqual(obj.PreRelease, expected.pr);
            Test.If.Value.IsEqual(obj.MetaData, expected.md);

        }

        IEnumerable<Object[]> CreateData(){
            return new List<Object[]>() {
                new Object[] { "1.0.0", (1, 0, 0, (String) null, (String) null) },
                new Object[] { "1.0.0-beta+123", (1, 0, 0, "beta", "123") }
            };
        }

        #endregion

        #region TryCreate

        #endregion

    }
}
