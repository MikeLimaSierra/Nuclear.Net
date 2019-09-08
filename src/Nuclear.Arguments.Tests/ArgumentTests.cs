﻿using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Arguments {

    class ArgumentTests {

        [TestMethod]
        void TestDefaultConstructor() {

            Argument arg = null;

            Test.IfNot.ThrowsException(() => { arg = new Argument(); }, out Exception ex);
            Test.If.False(arg.IsSwitch);
            Test.If.StringIsNullOrWhiteSpace(arg.SwitchName);
            Test.If.False(arg.HasValue);
            Test.If.StringIsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void TestSingleCharConstructor() {

            Argument arg = null;

            Test.Note("new Argument('?');");
            Test.If.ThrowsException(() => { arg = new Argument('?'); }, out ArgumentException ex1);
            Test.If.ValuesEqual(ex1.ParamName, "_switch");
            Test.If.StringStartsWith(ex1.Message, "Single switches can only be letters.");
            Test.If.Null(arg);

            Test.Note("new Argument('f');");
            Test.IfNot.ThrowsException(() => { arg = new Argument('f'); }, out Exception ex);
            Test.If.True(arg.IsSwitch);
            Test.If.ValuesEqual(arg.SwitchName, "f");
            Test.If.False(arg.HasValue);
            Test.If.StringIsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void TestMultiCharConstructor() {

            Argument arg = null;

            Test.Note("new Argument(\"force\");");
            Test.IfNot.ThrowsException(() => { arg = new Argument("force"); }, out Exception ex);
            Test.If.True(arg.IsSwitch);
            Test.If.ValuesEqual(arg.SwitchName, "force");
            Test.If.False(arg.HasValue);
            Test.If.StringIsNullOrWhiteSpace(arg.Value);

            Test.Note("new Argument(String.Empty);");
            Test.IfNot.ThrowsException(() => { arg = new Argument(String.Empty); }, out ex);
            Test.If.False(arg.IsSwitch);
            Test.If.False(arg.HasValue);

            Test.Note("new Argument(\" \");");
            Test.IfNot.ThrowsException(() => { arg = new Argument(" "); }, out ex);
            Test.If.False(arg.IsSwitch);
            Test.If.False(arg.HasValue);

            Test.Note("new Argument(null);");
            Test.IfNot.ThrowsException(() => { arg = new Argument(null); }, out ex);
            Test.If.False(arg.IsSwitch);
            Test.If.False(arg.HasValue);

        }

        [TestMethod]
        void TestValueProperty() {

            Argument arg = new Argument('z');

            Test.Note("some_other_value");
            Test.IfNot.ThrowsException(() => arg.Value = "some_other_value", out Exception ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.ValuesEqual(arg.Value, "some_other_value");

            Test.Note("null");
            Test.IfNot.ThrowsException(() => arg.Value = null, out ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.Null(arg.Value);

            Test.Note("<space>");
            Test.IfNot.ThrowsException(() => arg.Value = " ", out ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.ValuesEqual(arg.Value, " ");

            Test.Note("String.Empty");
            Test.IfNot.ThrowsException(() => arg.Value = String.Empty, out ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.ValuesEqual(arg.Value, String.Empty);

        }

        [TestMethod]
        void TestToString() {

            Argument arg = new Argument('z');
            Test.If.ValuesEqual(arg.ToString(), "-z");

            arg.Value = @"file:\\path\to\file";
            Test.If.ValuesEqual(arg.ToString(), @"-z file:\\path\to\file");

            arg = new Argument();
            Test.If.ValuesEqual(arg.ToString(), "");

            arg.Value = "great_fancy_keyword";
            Test.If.ValuesEqual(arg.ToString(), "great_fancy_keyword");

            arg = new Argument("very_long_switch_name");
            Test.If.ValuesEqual(arg.ToString(), "--very_long_switch_name");

            arg.Value = @"./another/file/path.exe";
            Test.If.ValuesEqual(arg.ToString(), "--very_long_switch_name ./another/file/path.exe");

        }

    }
}
