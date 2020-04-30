using System;
using System.Collections.Generic;

using Nuclear.TestSite;

namespace Nuclear.Arguments {

    class Argument_uTests {

        [TestMethod]
        void DefaultConstructor() {

            Argument arg = null;

            Test.IfNot.Action.ThrowsException(() => arg = new Argument(), out Exception ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.String.IsNullOrWhiteSpace(arg.SwitchName);
            Test.If.Value.IsFalse(arg.HasValue);
            Test.If.String.IsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void SingleCharConstructor() {

            Argument arg = null;

            Test.Note("new Argument('?');");
            Test.If.Action.ThrowsException(() => arg = new Argument('?'), out ArgumentException ex1);
            Test.If.Value.IsEqual(ex1.ParamName, "_switch");
            Test.If.String.StartsWith(ex1.Message, "Single switches can only be letters.");
            Test.If.Object.IsNull(arg);

            Test.Note("new Argument('f');");
            Test.IfNot.Action.ThrowsException(() => arg = new Argument('f'), out Exception ex);
            Test.If.Value.IsTrue(arg.IsSwitch);
            Test.If.Value.IsEqual(arg.SwitchName, "f");
            Test.If.Value.IsFalse(arg.HasValue);
            Test.If.String.IsNullOrWhiteSpace(arg.Value);

        }

        [TestMethod]
        void MultiCharConstructor() {

            Argument arg = null;

            Test.Note("new Argument(\"force\");");
            Test.IfNot.Action.ThrowsException(() => arg = new Argument("force"), out Exception ex);
            Test.If.Value.IsTrue(arg.IsSwitch);
            Test.If.Value.IsEqual(arg.SwitchName, "force");
            Test.If.Value.IsFalse(arg.HasValue);
            Test.If.String.IsNullOrWhiteSpace(arg.Value);

            Test.Note("new Argument(String.Empty);");
            Test.IfNot.Action.ThrowsException(() => arg = new Argument(String.Empty), out ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("new Argument(\" \");");
            Test.IfNot.Action.ThrowsException(() => arg = new Argument(" "), out ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("new Argument(null);");
            Test.IfNot.Action.ThrowsException(() => arg = new Argument(null), out ex);
            Test.If.Value.IsFalse(arg.IsSwitch);
            Test.If.Value.IsFalse(arg.HasValue);

        }

        [TestMethod]
        [TestData(nameof(ValuePropertyData))]
        void ValueProperty(String input, String expected) {

            Argument arg = new Argument('z');

            Test.IfNot.Action.ThrowsException(() => arg.Value = input, out Exception ex);
            Test.If.Value.IsEqual(arg.SwitchName, "z");
            Test.If.Value.IsEqual(arg.Value, expected);

        }

        IEnumerable<Object[]> ValuePropertyData() {
            return new List<Object[]>() {
                new Object[] { "some_other_value", "some_other_value" },
                new Object[] { null, null },
                new Object[] { " ", " " },
                new Object[] { "", "" },
            };
        }

        [TestMethod]
        [TestData(nameof(ToStringData))]
        void ToString(Argument input, String expected) {

            String _toString = default;

            Test.IfNot.Action.ThrowsException(() => _toString = input.ToString(), out Exception ex);

            Test.If.Value.IsEqual(_toString, expected);

        }

        IEnumerable<Object[]> ToStringData() {
            return new List<Object[]>() {
                new Object[] { new Argument('z'), "-z" },
                new Object[] { new Argument('z') { Value = @"file:\\path\to\file" }, @"-z file:\\path\to\file" },
                new Object[] { new Argument(), "" },
                new Object[] { new Argument() { Value = "great_fancy_keyword" }, "great_fancy_keyword" },
                new Object[] { new Argument("very_long_switch_name"), "--very_long_switch_name" },
                new Object[] { new Argument("very_long_switch_name") { Value = "./another/file/path.exe" }, @"--very_long_switch_name ./another/file/path.exe" },
            };
        }

    }
}
