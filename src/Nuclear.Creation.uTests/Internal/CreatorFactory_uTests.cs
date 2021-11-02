using System;

using Nuclear.TestSite;

namespace Nuclear.Creation.Internal {
    class CreatorFactory_uTests {

        [TestMethod]
        void Implementation() {

            Test.If.Type.Implements<CreatorFactory, ICreatorFactory>();

        }

        #region Create

        [TestMethod]
        void Create_P0() {

            ICreator<Object> creator1 = default;
            ICreator<Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object>(() => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object>(() => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);


        }

        [TestMethod]
        void Create_P1() {

            ICreator<Object, Object> creator1 = default;
            ICreator<Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object>((_) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object>((_) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        [TestMethod]
        void Create_P2() {

            ICreator<Object, Object, Object> creator1 = default;
            ICreator<Object, Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object, Object>((_, _) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object, Object>((_, _) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        [TestMethod]
        void Create_P3() {

            ICreator<Object, Object, Object, Object> creator1 = default;
            ICreator<Object, Object, Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object, Object, Object>((_, _, _) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object, Object, Object>((_, _, _) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        [TestMethod]
        void Create_P4() {

            ICreator<Object, Object, Object, Object, Object> creator1 = default;
            ICreator<Object, Object, Object, Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object>((_, _, _, _) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object>((_, _, _, _) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        [TestMethod]
        void Create_P5() {

            ICreator<Object, Object, Object, Object, Object, Object> creator1 = default;
            ICreator<Object, Object, Object, Object, Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object>((_, _, _, _, _) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object>((_, _, _, _, _) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        [TestMethod]
        void Create_P6() {

            ICreator<Object, Object, Object, Object, Object, Object, Object> creator1 = default;
            ICreator<Object, Object, Object, Object, Object, Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        [TestMethod]
        void Create_P7() {

            ICreator<Object, Object, Object, Object, Object, Object, Object, Object> creator1 = default;
            ICreator<Object, Object, Object, Object, Object, Object, Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _, _) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _, _) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        [TestMethod]
        void Create_P8() {

            ICreator<Object, Object, Object, Object, Object, Object, Object, Object, Object> creator1 = default;
            ICreator<Object, Object, Object, Object, Object, Object, Object, Object, Object> creator2 = default;

            Test.IfNot.Action.ThrowsException(() => creator1 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _, _, _) => null), out Exception _);
            Test.IfNot.Action.ThrowsException(() => creator2 = Factory.Instance.Creator.Create<Object, Object, Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _, _, _) => null), out Exception _);

            Test.IfNot.Object.IsNull(creator1);
            Test.IfNot.Object.IsNull(creator2);
            Test.IfNot.Reference.IsEqual(creator1, creator2);

        }

        #endregion

    }
}
