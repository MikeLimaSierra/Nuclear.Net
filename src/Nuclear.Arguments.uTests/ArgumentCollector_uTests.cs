using System;
using System.Collections.Generic;
using Nuclear.TestSite;

namespace Nuclear.Arguments {

    class ArgumentCollector_uTests {

        [TestMethod]
        void Constructors() {

            ArgumentCollector argC = null;

            Test.Note("new ArgumentCollector()");
            Test.IfNot.Action.ThrowsException(() => { argC = new ArgumentCollector(); }, out Exception ex);
            Test.If.Value.IsEqual(argC.SwitchIndicator, '-');
            Test.If.Value.IsEqual(argC.ValueSeparator, ';');

            Test.Note("new ArgumentCollector('_', '$')");
            Test.IfNot.Action.ThrowsException(() => { argC = new ArgumentCollector('_', '$'); }, out ex);
            Test.If.Value.IsEqual(argC.SwitchIndicator, '_');
            Test.If.Value.IsEqual(argC.ValueSeparator, '$');

        }

        [TestMethod]
        void Collect() {

            ArgumentCollector argC = new ArgumentCollector();

            Test.Note("-z");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "-z" }); }, out Exception ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 1);

            Test.If.Value.IsTrue(argC.Arguments[0].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.Value.IsFalse(argC.Arguments[0].HasValue);

            Test.Note("added_value");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "added_value" }); }, out ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 1);

            Test.If.Value.IsTrue(argC.Arguments[0].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.Value.IsTrue(argC.Arguments[0].HasValue);
            Test.If.Value.IsEqual(argC.Arguments[0].Value, "added_value");

            Test.Note("-n, 42");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "-n", "42" }); }, out ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 2);

            Test.If.Value.IsTrue(argC.Arguments[1].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[1].SwitchName, "n");
            Test.If.Value.IsTrue(argC.Arguments[1].HasValue);
            Test.If.Value.IsEqual(argC.Arguments[1].Value, "42");

            Test.Note("--force");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "--force" }); }, out ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 3);

            Test.If.Value.IsTrue(argC.Arguments[2].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[2].SwitchName, "force");
            Test.If.Value.IsFalse(argC.Arguments[2].HasValue);

            Test.Note("added_value2");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "added_value2" }); }, out ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 3);

            Test.If.Value.IsTrue(argC.Arguments[2].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[2].SwitchName, "force");
            Test.If.Value.IsTrue(argC.Arguments[2].HasValue);
            Test.If.Value.IsEqual(argC.Arguments[2].Value, "added_value2");

            Test.Note("--unforce, what_was_forced_before");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "--unforce", "what_was_forced_before" }); }, out ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 4);

            Test.If.Value.IsTrue(argC.Arguments[3].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[3].SwitchName, "unforce");
            Test.If.Value.IsTrue(argC.Arguments[3].HasValue);
            Test.If.Value.IsEqual(argC.Arguments[3].Value, "what_was_forced_before");

            Test.Note(@"file:\\some\path");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { @"file:\\some\path" }); }, out ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 5);

            Test.If.Value.IsFalse(argC.Arguments[4].IsSwitch);
            Test.If.Value.IsTrue(argC.Arguments[4].HasValue);
            Test.If.Value.IsEqual(argC.Arguments[4].Value, @"file:\\some\path");

            Test.Note("-wasd");
            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "-wasd" }); }, out ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 9);

            Test.If.Value.IsTrue(argC.Arguments[5].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[5].SwitchName, "w");
            Test.If.Value.IsFalse(argC.Arguments[5].HasValue);

            Test.If.Value.IsTrue(argC.Arguments[6].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[6].SwitchName, "a");
            Test.If.Value.IsFalse(argC.Arguments[6].HasValue);

            Test.If.Value.IsTrue(argC.Arguments[7].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[7].SwitchName, "s");
            Test.If.Value.IsFalse(argC.Arguments[7].HasValue);

            Test.If.Value.IsTrue(argC.Arguments[8].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[8].SwitchName, "d");
            Test.If.Value.IsFalse(argC.Arguments[8].HasValue);

        }

        [TestMethod]
        void CollectCombined() {

            ArgumentCollector argC = new ArgumentCollector();

            Test.IfNot.Action.ThrowsException(() => { argC.Collect(new String[] { "-z", "--all", "your_base_are_belong_to_us", "unicorn", "--asdf" }); }, out Exception ex);
            Test.If.Value.IsEqual(argC.Arguments.Count, 4);

            Test.Note("z");
            Test.If.Value.IsTrue(argC.Arguments[0].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.Value.IsFalse(argC.Arguments[0].HasValue);
            Test.If.Object.IsNull(argC.Arguments[0].Value);

            Test.Note("all");
            Test.If.Value.IsTrue(argC.Arguments[1].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[1].SwitchName, "all");
            Test.If.Value.IsTrue(argC.Arguments[1].HasValue);
            Test.If.Value.IsEqual(argC.Arguments[1].Value, "your_base_are_belong_to_us");

            Test.Note("unicorn");
            Test.If.Value.IsFalse(argC.Arguments[2].IsSwitch);
            Test.If.Object.IsNull(argC.Arguments[2].SwitchName);
            Test.If.Value.IsTrue(argC.Arguments[2].HasValue);
            Test.If.Value.IsEqual(argC.Arguments[2].Value, "unicorn");

            Test.Note("asdf");
            Test.If.Value.IsTrue(argC.Arguments[3].IsSwitch);
            Test.If.Value.IsEqual(argC.Arguments[3].SwitchName, "asdf");
            Test.If.Value.IsFalse(argC.Arguments[3].HasValue);
            Test.If.Object.IsNull(argC.Arguments[3].Value);

        }

        [TestMethod]
        void TryGetSwitch() {

            ArgumentCollector argC = new ArgumentCollector();
            argC.Collect(new String[] { "-z", "-Z", "some value of -Z", "-wasd", "--asdf" });
            Boolean result = false;
            Argument arg = null;

            Test.Note("z");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("z", out arg), out Exception ex);
            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(arg);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("Z");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("Z", out arg), out ex);
            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(arg);
            Test.If.Value.IsTrue(arg.HasValue);
            Test.If.Value.IsEqual(arg.Value, "some value of -Z");

            Test.Note("some");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("some", out arg), out ex);
            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(arg);

            Test.Note("some value of -Z");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("some value of -Z", out arg), out ex);
            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(arg);

            Test.Note("w");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("w", out arg), out ex);
            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(arg);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("a");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("a", out arg), out ex);
            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(arg);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("s");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("s", out arg), out ex);
            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(arg);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("d");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("d", out arg), out ex);
            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(arg);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("wasd");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("wasd", out arg), out ex);
            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(arg);

            Test.Note("asdf");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("asdf", out arg), out ex);
            Test.If.Value.IsTrue(result);
            Test.IfNot.Object.IsNull(arg);
            Test.If.Value.IsFalse(arg.HasValue);

            Test.Note("f");
            Test.IfNot.Action.ThrowsException(() => result = argC.TryGetSwitch("f", out arg), out ex);
            Test.If.Value.IsFalse(result);
            Test.If.Object.IsNull(arg);

        }

        [TestMethod]
        void GetSeparatedValues() {

            ArgumentCollector argC = new ArgumentCollector();
            Argument arg = new Argument();
            List<String> values = null;

            arg.Value = "one;two;three";
            Test.Note("one;two;three");
            Test.IfNot.Action.ThrowsException(() => values = argC.GetSeparatedValues(arg), out Exception ex);
            Test.IfNot.Object.IsNull(values);
            Test.If.Value.IsEqual(values.Count, 3);
            Test.If.Value.IsEqual(values[0], "one");
            Test.If.Value.IsEqual(values[1], "two");
            Test.If.Value.IsEqual(values[2], "three");

            arg.Value = "one;;three";
            Test.Note("one;;three");
            Test.IfNot.Action.ThrowsException(() => values = argC.GetSeparatedValues(arg), out ex);
            Test.IfNot.Object.IsNull(values);
            Test.If.Value.IsEqual(values.Count, 2);
            Test.If.Value.IsEqual(values[0], "one");
            Test.If.Value.IsEqual(values[1], "three");

            arg.Value = ";;;";
            Test.Note(";;;");
            Test.IfNot.Action.ThrowsException(() => values = argC.GetSeparatedValues(arg), out ex);
            Test.IfNot.Object.IsNull(values);
            Test.If.Value.IsEqual(values.Count, 0);

            arg.Value = "just_this_one";
            Test.Note("just_this_one");
            Test.IfNot.Action.ThrowsException(() => values = argC.GetSeparatedValues(arg), out ex);
            Test.IfNot.Object.IsNull(values);
            Test.If.Value.IsEqual(values.Count, 1);
            Test.If.Value.IsEqual(values[0], "just_this_one");

        }

    }
}
