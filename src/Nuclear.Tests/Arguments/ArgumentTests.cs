using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Arguments {

    class ArgumentTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.TypeImplements<Argument, IArgument>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void TestDefaultConstructor() {

            IArgument arg = null;

            Test.IfNot.ThrowsException(() => { arg = new Argument(); }, out Exception ex);
            Test.If.False(arg.IsSwitch);
            Test.If.StringIsNullOrWhiteSpace(arg.SwitchName);
            Test.If.False(arg.HasValue);
            Test.If.StringIsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void TestSingleCharConstructor() {

            IArgument arg = null;

            Test.If.ThrowsException(() => { arg = new Argument('?'); }, out ArgumentException ex1);
            Test.If.ValuesEqual(ex1.ParamName, "_switch");
            Test.If.StringStartsWith(ex1.Message, "Single switches can only be letters.");
            Test.If.Null(arg);

            Test.IfNot.ThrowsException(() => { arg = new Argument('f'); }, out Exception ex);
            Test.If.True(arg.IsSwitch);
            Test.If.ValuesEqual(arg.SwitchName, "f");
            Test.If.False(arg.HasValue);
            Test.If.StringIsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void TestMultiCharConstructor() {

            IArgument arg = null;

            Test.IfNot.ThrowsException(() => { arg = new Argument("force"); }, out Exception ex);
            Test.If.True(arg.IsSwitch);
            Test.If.ValuesEqual(arg.SwitchName, "force");
            Test.If.False(arg.HasValue);
            Test.If.StringIsNullOrWhiteSpace(arg.Value);

            Test.IfNot.ThrowsException(() => { arg = new Argument(String.Empty); }, out ex);
            Test.If.False(arg.IsSwitch);
            Test.If.False(arg.HasValue);

            Test.IfNot.ThrowsException(() => { arg = new Argument(" "); }, out ex);
            Test.If.False(arg.IsSwitch);
            Test.If.False(arg.HasValue);

            Test.IfNot.ThrowsException(() => { arg = new Argument(null); }, out ex);
            Test.If.False(arg.IsSwitch);
            Test.If.False(arg.HasValue);

        }

        [TestMethod]
        void TestValueProperty() {

            IArgument arg = new Argument('z');

            Test.IfNot.ThrowsException(() => arg.Value = "some_other_value", out Exception ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.ValuesEqual(arg.Value, "some_other_value");

            Test.IfNot.ThrowsException(() => arg.Value = null, out ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.Null(arg.Value);

            Test.IfNot.ThrowsException(() => arg.Value = " ", out ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.ValuesEqual(arg.Value, " ");

            Test.IfNot.ThrowsException(() => arg.Value = String.Empty, out ex);
            Test.If.ValuesEqual(arg.SwitchName, "z");
            Test.If.ValuesEqual(arg.Value, String.Empty);

        }

        [TestMethod]
        void TestToString() {

            IArgument arg = new Argument('z');
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
