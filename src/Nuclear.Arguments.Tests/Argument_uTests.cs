using System;
using Nuclear.TestSite;

namespace Nuclear.Arguments {

    class Argument_uTests {

        [TestMethod]
        void TestDefaultConstructor() {

            Argument arg = null;

            Test.IfNot.Action.ThrowsException(() => { arg = new Argument(); }, out Exception ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.String.IsNullOrWhiteSpace(arg.SwitchName);
            Test.If.Value.IsFalse(arg.HasValue);
            Test.If.String.IsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void TestSingleCharConstructor() {

            Argument arg = null;

            Test.Note("new Argument('?');");
            Test.If.Action.ThrowsException(() => { arg = new Argument('?'); }, out ArgumentException ex1);
            Test.If.Value.Equals(ex1.ParamName, "_switch");
            Test.If.String.StartsWith(ex1.Message, "Single switches can only be letters.");
            Test.If.Object.IsNull(arg);

            Test.Note("new Argument('f');");
            Test.IfNot.Action.ThrowsException(() => { arg = new Argument('f'); }, out Exception ex);
            Test.If.Value.IsTrue(arg.IsSwitch);
            Test.If.Value.Equals(arg.SwitchName, "f");
            Test.If.Value.IsFalse(arg.HasValue);
            Test.If.String.IsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void TestMultiCharConstructor() {

            Argument arg = null;

            Test.Note("new Argument(\"force\");");
            Test.IfNot.Action.ThrowsException(() => { arg = new Argument("force"); }, out Exception ex);
            Test.If.Value.IsTrue(arg.IsSwitch);
            Test.If.Value.Equals(arg.SwitchName, "force");
            Test.If.Value.IsFalse(arg.HasValue);
            Test.If.String.IsNullOrWhiteSpace(arg.Value);

            Test.Note("new Argument(String.Empty);");
            Test.IfNot.Action.ThrowsException(() => { arg = new Argument(String.Empty); }, out ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("new Argument(\" \");");
            Test.IfNot.Action.ThrowsException(() => { arg = new Argument(" "); }, out ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("new Argument(null);");
            Test.IfNot.Action.ThrowsException(() => { arg = new Argument(null); }, out ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.Value.IsFalse(arg.HasValue);

        }

        [TestMethod]
        void TestValueProperty() {

            Argument arg = new Argument('z');

            Test.Note("some_other_value");
            Test.IfNot.Action.ThrowsException(() => arg.Value = "some_other_value", out Exception ex);
            Test.If.Value.Equals(arg.SwitchName, "z");
            Test.If.Value.Equals(arg.Value, "some_other_value");

            Test.Note("null");
            Test.IfNot.Action.ThrowsException(() => arg.Value = null, out ex);
            Test.If.Value.Equals(arg.SwitchName, "z");
            Test.If.Object.IsNull(arg.Value);

            Test.Note("<space>");
            Test.IfNot.Action.ThrowsException(() => arg.Value = " ", out ex);
            Test.If.Value.Equals(arg.SwitchName, "z");
            Test.If.Value.Equals(arg.Value, " ");

            Test.Note("String.Empty");
            Test.IfNot.Action.ThrowsException(() => arg.Value = String.Empty, out ex);
            Test.If.Value.Equals(arg.SwitchName, "z");
            Test.If.Value.Equals(arg.Value, String.Empty);

        }

        [TestMethod]
        void TestToString() {

            Argument arg = new Argument('z');
            Test.If.Value.Equals(arg.ToString(), "-z");

            arg.Value = @"file:\\path\to\file";
            Test.If.Value.Equals(arg.ToString(), @"-z file:\\path\to\file");

            arg = new Argument();
            Test.If.Value.Equals(arg.ToString(), "");

            arg.Value = "great_fancy_keyword";
            Test.If.Value.Equals(arg.ToString(), "great_fancy_keyword");

            arg = new Argument("very_long_switch_name");
            Test.If.Value.Equals(arg.ToString(), "--very_long_switch_name");

            arg.Value = @"./another/file/path.exe";
            Test.If.Value.Equals(arg.ToString(), "--very_long_switch_name ./another/file/path.exe");

        }

    }
}
