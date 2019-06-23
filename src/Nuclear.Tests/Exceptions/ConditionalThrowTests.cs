﻿using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Exceptions {

    class ConditionalThrowTests {

        private static readonly String _paramName = "fake_param_name";

        private static readonly String _message = "fake_exception_message";

        #region Null

        [TestMethod]
        void TestThrowIfNull() {

            Test.If.ThrowsException(() =>
                Throw.If.Null(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.ValuesEqual(_paramName, ex1.ParamName);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.Null(new Object(), _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotNull() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.Null(null, _paramName, _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.Null(new Object(), _paramName, _message), out ArgumentNullException ex2);
            Test.If.ValuesEqual(_paramName, ex2.ParamName);
            Test.If.StringStartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void TestThrowIfNullGeneric() {

            Test.If.ThrowsException(() =>
                Throw.If.Null<NotImplementedException>(null, _message), out NotImplementedException ex1);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.Null<NotImplementedException>(new Object(), _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotNullGeneric() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.Null<NotImplementedException>(null, _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.Null<NotImplementedException>(new Object(), _message), out NotImplementedException ex2);
            Test.If.StringStartsWith(ex2.Message, _message);

        }

        #endregion

        #region OfType

        [TestMethod]
        void TestThrowIfOfType() {

            Test.If.ThrowsException(() =>
                Throw.If.OfType<String>("STRING", _paramName, _message), out ArgumentException ex1);
            Test.If.ValuesEqual(_paramName, ex1.ParamName);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.OfType<String>(42, _paramName, _message), out Exception ex2);

            Test.If.ThrowsException(() =>
                Throw.If.OfType<String>(null, _paramName, _message), out ArgumentNullException ex3);

        }

        [TestMethod]
        void TestThrowIfNotOfType() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.OfType<String>("STRING", _paramName, _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.OfType<String>(42, _paramName, _message), out ArgumentException ex2);
            Test.If.ValuesEqual(_paramName, ex2.ParamName);
            Test.If.StringStartsWith(ex2.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.IfNot.OfType<String>(null, _paramName, _message), out ArgumentNullException ex3);

        }

        [TestMethod]
        void TestThrowIfOfTypeGeneric() {

            Test.If.ThrowsException(() =>
                Throw.If.OfType<NotImplementedException, String>("STRING", _message), out NotImplementedException ex1);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.OfType<NotImplementedException, String>(42, _message), out Exception ex2);

            Test.If.ThrowsException(() =>
                Throw.If.OfType<NotImplementedException, String>(null, _message), out ArgumentNullException ex3);

        }

        [TestMethod]
        void TestThrowIfNotOfTypeGeneric() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.OfType<NotImplementedException, String>("STRING", _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.OfType<NotImplementedException, String>(42, _message), out NotImplementedException ex2);
            Test.If.StringStartsWith(ex2.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.IfNot.OfType<NotImplementedException, String>(null, _message), out ArgumentNullException ex3);

        }

        #endregion

        #region NullOrEmpty

        [TestMethod]
        void TestThrowIfNullOrEmpty() {

            Test.If.ThrowsException(() =>
                Throw.If.NullOrEmpty(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.ValuesEqual(_paramName, ex1.ParamName);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.If.NullOrEmpty(String.Empty, _paramName, _message), out ArgumentException ex2);
            Test.If.ValuesEqual(_paramName, ex2.ParamName);
            Test.If.StringStartsWith(ex2.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.NullOrEmpty(" ", _paramName, _message), out Exception ex3);

            Test.IfNot.ThrowsException(() =>
                Throw.If.NullOrEmpty("STRING", _paramName, _message), out Exception ex4);

        }

        [TestMethod]
        void TestThrowIfNotNullOrEmpty() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty(null, _paramName, _message), out Exception ex1);

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty(String.Empty, _paramName, _message), out Exception ex2);

            Test.If.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty(" ", _paramName, _message), out ArgumentException ex3);
            Test.If.ValuesEqual(_paramName, ex3.ParamName);
            Test.If.StringStartsWith(ex3.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty("STRING", _paramName, _message), out ArgumentException ex4);
            Test.If.ValuesEqual(_paramName, ex4.ParamName);
            Test.If.StringStartsWith(ex4.Message, _message);

        }

        [TestMethod]
        void TestThrowIfNullOrEmptyGeneric() {

            Test.If.ThrowsException(() =>
                Throw.If.NullOrEmpty<NotImplementedException>(null, _message), out NotImplementedException ex1);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.If.NullOrEmpty<NotImplementedException>(String.Empty, _message), out NotImplementedException ex2);
            Test.If.StringStartsWith(ex2.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.NullOrEmpty<NotImplementedException>(" ", _message), out Exception ex3);

            Test.IfNot.ThrowsException(() =>
                Throw.If.NullOrEmpty<NotImplementedException>("STRING", _message), out Exception ex4);

        }

        [TestMethod]
        void TestThrowIfNotNullOrEmptyGeneric() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty<NotImplementedException>(null, _message), out Exception ex1);

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty<NotImplementedException>(String.Empty, _message), out Exception ex2);

            Test.If.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty<NotImplementedException>(" ", _message), out NotImplementedException ex3);
            Test.If.StringStartsWith(ex3.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.IfNot.NullOrEmpty<NotImplementedException>("STRING", _message), out NotImplementedException ex4);
            Test.If.StringStartsWith(ex4.Message, _message);

        }

        #endregion

        #region NullOrWhiteSpace

        [TestMethod]
        void TestThrowIfNullOrWhiteSpace() {

            Test.If.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace(null, _paramName, _message), out ArgumentNullException ex1);
            Test.If.ValuesEqual(_paramName, ex1.ParamName);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace(String.Empty, _paramName, _message), out ArgumentException ex2);
            Test.If.ValuesEqual(_paramName, ex2.ParamName);
            Test.If.StringStartsWith(ex2.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace(" ", _paramName, _message), out ArgumentException ex3);
            Test.If.ValuesEqual(_paramName, ex3.ParamName);
            Test.If.StringStartsWith(ex3.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace("STRING", _paramName, _message), out Exception ex4);

        }

        [TestMethod]
        void TestThrowIfNotNullOrWhiteSpace() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace(null, _paramName, _message), out Exception ex1);

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace(String.Empty, _paramName, _message), out Exception ex2);

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace(" ", _paramName, _message), out Exception ex3);

            Test.If.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace("STRING", _paramName, _message), out ArgumentException ex4);
            Test.If.ValuesEqual(_paramName, ex4.ParamName);
            Test.If.StringStartsWith(ex4.Message, _message);

        }

        [TestMethod]
        void TestThrowIfNullOrWhiteSpaceGeneric() {

            Test.If.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace<NotImplementedException>(null, _message), out NotImplementedException ex1);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace<NotImplementedException>(String.Empty, _message), out NotImplementedException ex2);
            Test.If.StringStartsWith(ex2.Message, _message);

            Test.If.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace<NotImplementedException>(" ", _message), out NotImplementedException ex3);
            Test.If.StringStartsWith(ex3.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.NullOrWhiteSpace<NotImplementedException>("STRING", _message), out Exception ex4);

        }

        [TestMethod]
        void TestThrowIfNotNullOrWhiteSpaceGeneric() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace<NotImplementedException>(null, _message), out Exception ex1);

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace<NotImplementedException>(String.Empty, _message), out Exception ex2);

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace<NotImplementedException>(" ", _message), out Exception ex3);

            Test.If.ThrowsException(() =>
                Throw.IfNot.NullOrWhiteSpace<NotImplementedException>("STRING", _message), out NotImplementedException ex4);
            Test.If.StringStartsWith(ex4.Message, _message);

        }

        #endregion

        #region True

        [TestMethod]
        void TestThrowIfTrue() {

            Test.If.ThrowsException(() =>
                Throw.If.True(true, _paramName, _message), out ArgumentException ex1);
            Test.If.ValuesEqual(_paramName, ex1.ParamName);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.True(false, _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotTrue() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.True(true, _paramName, _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.True(false, _paramName, _message), out ArgumentException ex2);
            Test.If.ValuesEqual(_paramName, ex2.ParamName);
            Test.If.StringStartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void TestThrowIfTrueGeneric() {

            Test.If.ThrowsException(() =>
                Throw.If.True<NotImplementedException>(true, _message), out NotImplementedException ex1);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.True<NotImplementedException>(false, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotTrueGeneric() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.True<NotImplementedException>(true, _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.True<NotImplementedException>(false, _message), out NotImplementedException ex2);
            Test.If.StringStartsWith(ex2.Message, _message);

        }

        #endregion

        #region False

        [TestMethod]
        void TestThrowIfFalse() {

            Test.If.ThrowsException(() =>
                Throw.If.False(false, _paramName, _message), out ArgumentException ex1);
            Test.If.ValuesEqual(_paramName, ex1.ParamName);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.False(true, _paramName, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotFalse() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.False(false, _paramName, _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.False(true, _paramName, _message), out ArgumentException ex2);
            Test.If.ValuesEqual(_paramName, ex2.ParamName);
            Test.If.StringStartsWith(ex2.Message, _message);

        }

        [TestMethod]
        void TestThrowIfFalseGeneric() {

            Test.If.ThrowsException(() =>
                Throw.If.False<NotImplementedException>(false, _message), out NotImplementedException ex1);
            Test.If.StringStartsWith(ex1.Message, _message);

            Test.IfNot.ThrowsException(() =>
                Throw.If.False<NotImplementedException>(true, _message), out Exception ex2);

        }

        [TestMethod]
        void TestThrowIfNotFalseGeneric() {

            Test.IfNot.ThrowsException(() =>
                Throw.IfNot.False<NotImplementedException>(false, _message), out Exception ex1);

            Test.If.ThrowsException(() =>
                Throw.IfNot.False<NotImplementedException>(true, _message), out NotImplementedException ex2);
            Test.If.StringStartsWith(ex2.Message, _message);

        }

        #endregion

    }
}
