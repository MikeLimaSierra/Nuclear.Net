using System;

using Nuclear.TestSite;

namespace Nuclear.Creation.Internal {
    class InternalCreator_uTests {

        [TestMethod]
        [TestParameters(typeof(InternalCreator<Object>), typeof(ICreator<Object>))]
        [TestParameters(typeof(InternalCreator<Object, Int32>), typeof(ICreator<Object, Int32>))]
        [TestParameters(typeof(InternalCreator<Object, Int32, Int32>), typeof(ICreator<Object, Int32, Int32>))]
        [TestParameters(typeof(InternalCreator<Object, Int32, Int32, Int32>), typeof(ICreator<Object, Int32, Int32, Int32>))]
        [TestParameters(typeof(InternalCreator<Object, Int32, Int32, Int32, Int32>), typeof(ICreator<Object, Int32, Int32, Int32, Int32>))]
        [TestParameters(typeof(InternalCreator<Object, Int32, Int32, Int32, Int32, Int32>), typeof(ICreator<Object, Int32, Int32, Int32, Int32, Int32>))]
        [TestParameters(typeof(InternalCreator<Object, Int32, Int32, Int32, Int32, Int32, Int32>), typeof(ICreator<Object, Int32, Int32, Int32, Int32, Int32, Int32>))]
        [TestParameters(typeof(InternalCreator<Object, Int32, Int32, Int32, Int32, Int32, Int32, Int32>), typeof(ICreator<Object, Int32, Int32, Int32, Int32, Int32, Int32, Int32>))]
        [TestParameters(typeof(InternalCreator<Object, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>), typeof(ICreator<Object, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>))]
        void Implementation<TType, TInterface>() {

            Test.If.Type.Implements<TType, TInterface>();

        }

        #region Ctors

        [TestMethod]
        void CtorThrows_P0() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P1() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P2() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P3() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P4() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P5() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P6() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P7() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object, Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void CtorThrows_P8() {

            Test.If.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object, Object, Object, Object>(null), out ArgumentNullException ex);

            Test.If.Value.IsEqual(ex.ParamName, "func");

        }

        [TestMethod]
        void Ctor_P0() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object>(() => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P1() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object>((_) => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P2() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object, Object>((_, _) => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P3() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object>((_, _, _) => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P4() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object>((_, _, _, _) => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P5() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object>((_, _, _, _, _) => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P6() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _) => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P7() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _, _) => null), out ArgumentNullException ex);

        }

        [TestMethod]
        void Ctor_P8() {

            Test.IfNot.Action.ThrowsException(() => new InternalCreator<Object, Object, Object, Object, Object, Object, Object, Object, Object>((_, _, _, _, _, _, _, _) => null), out ArgumentNullException ex);

        }

        #endregion

        #region Create

        [TestMethod]
        void CreateThrows_P0() {

            var creator = new InternalCreator<String>(() => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P1() {

            var creator = new InternalCreator<String, Int32>((_) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P2() {

            var creator = new InternalCreator<String, Int32, Int32>((_, _) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1, 2), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P3() {

            var creator = new InternalCreator<String, Int32, Int32, Int32>((_, _, _) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1, 2, 3), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P4() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32>((_, _, _, _) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1, 2, 3, 4), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P5() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1, 2, 3, 4, 5), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P6() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1, 2, 3, 4, 5, 6), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P7() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1, 2, 3, 4, 5, 6, 7), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void CreateThrows_P8() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));

            Test.If.Action.ThrowsException(() => creator.Create(out _, 1, 2, 3, 4, 5, 6, 7, 8), out NotImplementedException ex);

            Test.If.Value.IsEqual(ex.Message, "Dummy message");

        }

        [TestMethod]
        void Create_P0() {

            var creator = new InternalCreator<String>(() => "0");
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj), out Exception _);

            Test.If.Value.IsEqual(obj, "0");

        }

        [TestMethod]
        void Create_P1() {

            var creator = new InternalCreator<String, Int32>((in1) => (in1).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1), out Exception _);

            Test.If.Value.IsEqual(obj, "1");

        }

        [TestMethod]
        void Create_P2() {

            var creator = new InternalCreator<String, Int32, Int32>((in1, in2) => (in1 + in2).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1, 2), out Exception _);

            Test.If.Value.IsEqual(obj, "3");

        }

        [TestMethod]
        void Create_P3() {

            var creator = new InternalCreator<String, Int32, Int32, Int32>((in1, in2, in3) => (in1 + in2 + in3).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1, 2, 3), out Exception _);

            Test.If.Value.IsEqual(obj, "6");

        }

        [TestMethod]
        void Create_P4() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32>((in1, in2, in3, in4) => (in1 + in2 + in3 + in4).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1, 2, 3, 4), out Exception _);

            Test.If.Value.IsEqual(obj, "10");

        }

        [TestMethod]
        void Create_P5() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5) => (in1 + in2 + in3 + in4 + in5).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1, 2, 3, 4, 5), out Exception _);

            Test.If.Value.IsEqual(obj, "15");

        }

        [TestMethod]
        void Create_P6() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6) => (in1 + in2 + in3 + in4 + in5 + in6).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1, 2, 3, 4, 5, 6), out Exception _);

            Test.If.Value.IsEqual(obj, "21");

        }

        [TestMethod]
        void Create_P7() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6, in7) => (in1 + in2 + in3 + in4 + in5 + in6 + in7).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1, 2, 3, 4, 5, 6, 7), out Exception _);

            Test.If.Value.IsEqual(obj, "28");

        }

        [TestMethod]
        void Create_P8() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6, in7, in8) => (in1 + in2 + in3 + in4 + in5 + in6 + in7 + in8).ToString());
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => creator.Create(out obj, 1, 2, 3, 4, 5, 6, 7, 8), out Exception _);

            Test.If.Value.IsEqual(obj, "36");

        }

        #endregion

        #region TryCreate

        [TestMethod]
        void TryCreateDoesNotThrow_P0() {

            var creator = new InternalCreator<String>(() => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P1() {

            var creator = new InternalCreator<String, Int32>((_) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P2() {

            var creator = new InternalCreator<String, Int32, Int32>((_, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P3() {

            var creator = new InternalCreator<String, Int32, Int32, Int32>((_, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P4() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32>((_, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P5() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P6() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P7() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreateDoesNotThrow_P8() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7, 8), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);

        }

        [TestMethod]
        void TryCreate_P0() {

            var creator = new InternalCreator<String>(() => "0");
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "0");

        }

        [TestMethod]
        void TryCreate_P1() {

            var creator = new InternalCreator<String, Int32>((in1) => (in1).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "1");

        }

        [TestMethod]
        void TryCreate_P2() {

            var creator = new InternalCreator<String, Int32, Int32>((in1, in2) => (in1 + in2).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "3");

        }

        [TestMethod]
        void TryCreate_P3() {

            var creator = new InternalCreator<String, Int32, Int32, Int32>((in1, in2, in3) => (in1 + in2 + in3).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "6");

        }

        [TestMethod]
        void TryCreate_P4() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32>((in1, in2, in3, in4) => (in1 + in2 + in3 + in4).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "10");

        }

        [TestMethod]
        void TryCreate_P5() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5) => (in1 + in2 + in3 + in4 + in5).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "15");

        }

        [TestMethod]
        void TryCreate_P6() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6) => (in1 + in2 + in3 + in4 + in5 + in6).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "21");

        }

        [TestMethod]
        void TryCreate_P7() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6, in7) => (in1 + in2 + in3 + in4 + in5 + in6 + in7).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "28");

        }

        [TestMethod]
        void TryCreate_P8() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6, in7, in8) => (in1 + in2 + in3 + in4 + in5 + in6 + in7 + in8).ToString());
            Boolean result = default;
            String obj = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7, 8), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "36");

        }

        #endregion

        #region TryCreateWithExOut

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P0() {

            var creator = new InternalCreator<String>(() => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P1() {

            var creator = new InternalCreator<String, Int32>((_) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P2() {

            var creator = new InternalCreator<String, Int32, Int32>((_, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P3() {

            var creator = new InternalCreator<String, Int32, Int32, Int32>((_, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P4() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32>((_, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P5() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P6() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P7() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOutDoesNotThrow_P8() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((_, _, _, _, _, _, _, _) => throw new NotImplementedException("Dummy message"));
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7, 8, out ex), out Exception _);

            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(obj);
            Test.IfNot.Object.IsNull(ex);
            Test.If.Object.IsOfExactType<NotImplementedException>(ex);
            Test.If.Value.IsEqual(((NotImplementedException) ex).Message, "Dummy message");

        }

        [TestMethod]
        void TryCreateWithExOut_P0() {

            var creator = new InternalCreator<String>(() => "0");
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "0");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P1() {

            var creator = new InternalCreator<String, Int32>((in1) => (in1).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "1");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P2() {

            var creator = new InternalCreator<String, Int32, Int32>((in1, in2) => (in1 + in2).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "3");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P3() {

            var creator = new InternalCreator<String, Int32, Int32, Int32>((in1, in2, in3) => (in1 + in2 + in3).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "6");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P4() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32>((in1, in2, in3, in4) => (in1 + in2 + in3 + in4).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "10");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P5() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5) => (in1 + in2 + in3 + in4 + in5).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "15");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P6() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6) => (in1 + in2 + in3 + in4 + in5 + in6).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "21");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P7() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6, in7) => (in1 + in2 + in3 + in4 + in5 + in6 + in7).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "28");
            Test.If.Object.IsNull(ex);

        }

        [TestMethod]
        void TryCreateWithExOut_P8() {

            var creator = new InternalCreator<String, Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32>((in1, in2, in3, in4, in5, in6, in7, in8) => (in1 + in2 + in3 + in4 + in5 + in6 + in7 + in8).ToString());
            Boolean result = default;
            String obj = default;
            Exception ex = default;

            Test.IfNot.Action.ThrowsException(() => result = creator.TryCreate(out obj, 1, 2, 3, 4, 5, 6, 7, 8, out ex), out Exception _);

            Test.If.Value.IsTrue(result);
            Test.If.Value.IsEqual(obj, "36");
            Test.If.Object.IsNull(ex);

        }

        #endregion

    }
}
