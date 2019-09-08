using System;
using System.Collections.Generic;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Arguments {

    class ArgumentCollectorTests {

        [TestMethod]
        void TestConstructors() {

            ArgumentCollector argC = null;

            Test.Note("new ArgumentCollector()");
            Test.IfNot.ThrowsException(() => { argC = new ArgumentCollector(); }, out Exception ex);
            Test.If.ValuesEqual(argC.SwitchIndicator, '-');
            Test.If.ValuesEqual(argC.ValueSeparator, ';');

            Test.Note("new ArgumentCollector('_', '$')");
            Test.IfNot.ThrowsException(() => { argC = new ArgumentCollector('_', '$'); }, out ex);
            Test.If.ValuesEqual(argC.SwitchIndicator, '_');
            Test.If.ValuesEqual(argC.ValueSeparator, '$');

        }

        [TestMethod]
        void TestCollect() {

            ArgumentCollector argC = new ArgumentCollector();

            Test.Note("-z");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "-z" }); }, out Exception ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 1);

            Test.If.True(argC.Arguments[0].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.False(argC.Arguments[0].HasValue);

            Test.Note("added_value");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "added_value" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 1);

            Test.If.True(argC.Arguments[0].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.True(argC.Arguments[0].HasValue);
            Test.If.ValuesEqual(argC.Arguments[0].Value, "added_value");

            Test.Note("-n, 42");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "-n", "42" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 2);

            Test.If.True(argC.Arguments[1].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[1].SwitchName, "n");
            Test.If.True(argC.Arguments[1].HasValue);
            Test.If.ValuesEqual(argC.Arguments[1].Value, "42");

            Test.Note("--force");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "--force" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 3);

            Test.If.True(argC.Arguments[2].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[2].SwitchName, "force");
            Test.If.False(argC.Arguments[2].HasValue);

            Test.Note("added_value2");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "added_value2" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 3);

            Test.If.True(argC.Arguments[2].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[2].SwitchName, "force");
            Test.If.True(argC.Arguments[2].HasValue);
            Test.If.ValuesEqual(argC.Arguments[2].Value, "added_value2");

            Test.Note("--unforce, what_was_forced_before");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "--unforce", "what_was_forced_before" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 4);

            Test.If.True(argC.Arguments[3].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[3].SwitchName, "unforce");
            Test.If.True(argC.Arguments[3].HasValue);
            Test.If.ValuesEqual(argC.Arguments[3].Value, "what_was_forced_before");

            Test.Note(@"file:\\some\path");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { @"file:\\some\path" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 5);

            Test.If.False(argC.Arguments[4].IsSwitch);
            Test.If.True(argC.Arguments[4].HasValue);
            Test.If.ValuesEqual(argC.Arguments[4].Value, @"file:\\some\path");

            Test.Note("-wasd");
            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "-wasd" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 9);

            Test.If.True(argC.Arguments[5].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[5].SwitchName, "w");
            Test.If.False(argC.Arguments[5].HasValue);

            Test.If.True(argC.Arguments[6].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[6].SwitchName, "a");
            Test.If.False(argC.Arguments[6].HasValue);

            Test.If.True(argC.Arguments[7].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[7].SwitchName, "s");
            Test.If.False(argC.Arguments[7].HasValue);

            Test.If.True(argC.Arguments[8].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[8].SwitchName, "d");
            Test.If.False(argC.Arguments[8].HasValue);

        }

        [TestMethod]
        void TestCollectCombined() {

            ArgumentCollector argC = new ArgumentCollector();

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "-z", "--all", "your_base_are_belong_to_us", "unicorn", "--asdf" }); }, out Exception ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 4);

            Test.Note("z");
            Test.If.True(argC.Arguments[0].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.False(argC.Arguments[0].HasValue);
            Test.If.Null(argC.Arguments[0].Value);

            Test.Note("all");
            Test.If.True(argC.Arguments[1].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[1].SwitchName, "all");
            Test.If.True(argC.Arguments[1].HasValue);
            Test.If.ValuesEqual(argC.Arguments[1].Value, "your_base_are_belong_to_us");

            Test.Note("unicorn");
            Test.If.False(argC.Arguments[2].IsSwitch);
            Test.If.Null(argC.Arguments[2].SwitchName);
            Test.If.True(argC.Arguments[2].HasValue);
            Test.If.ValuesEqual(argC.Arguments[2].Value, "unicorn");

            Test.Note("asdf");
            Test.If.True(argC.Arguments[3].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[3].SwitchName, "asdf");
            Test.If.False(argC.Arguments[3].HasValue);
            Test.If.Null(argC.Arguments[3].Value);

        }

        [TestMethod]
        void TestTryGetSwitch() {

            ArgumentCollector argC = new ArgumentCollector();
            argC.Collect(new String[] { "-z", "-Z", "some value of -Z", "-wasd", "--asdf" });
            Boolean result = false;
            Argument arg = null;

            Test.Note("z");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("z", out arg), out Exception ex);
            Test.If.True(result);
            Test.IfNot.Null(arg);
            Test.If.False(arg.HasValue);

            Test.Note("Z");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("Z", out arg), out ex);
            Test.If.True(result);
            Test.IfNot.Null(arg);
            Test.If.True(arg.HasValue);
            Test.If.ValuesEqual(arg.Value, "some value of -Z");

            Test.Note("some");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("some", out arg), out ex);
            Test.If.False(result);
            Test.If.Null(arg);

            Test.Note("some value of -Z");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("some value of -Z", out arg), out ex);
            Test.If.False(result);
            Test.If.Null(arg);

            Test.Note("w");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("w", out arg), out ex);
            Test.If.True(result);
            Test.IfNot.Null(arg);
            Test.If.False(arg.HasValue);

            Test.Note("a");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("a", out arg), out ex);
            Test.If.True(result);
            Test.IfNot.Null(arg);
            Test.If.False(arg.HasValue);

            Test.Note("s");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("s", out arg), out ex);
            Test.If.True(result);
            Test.IfNot.Null(arg);
            Test.If.False(arg.HasValue);

            Test.Note("d");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("d", out arg), out ex);
            Test.If.True(result);
            Test.IfNot.Null(arg);
            Test.If.False(arg.HasValue);

            Test.Note("wasd");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("wasd", out arg), out ex);
            Test.If.False(result);
            Test.If.Null(arg);

            Test.Note("asdf");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("asdf", out arg), out ex);
            Test.If.True(result);
            Test.IfNot.Null(arg);
            Test.If.False(arg.HasValue);

            Test.Note("f");
            Test.IfNot.ThrowsException(() => result = argC.TryGetSwitch("f", out arg), out ex);
            Test.If.False(result);
            Test.If.Null(arg);

        }

        [TestMethod]
        void TestGetSeparatedValues() {

            ArgumentCollector argC = new ArgumentCollector();
            Argument arg = new Argument();
            List<String> values = null;

            arg.Value = "one;two;three";
            Test.Note("one;two;three");
            Test.IfNot.ThrowsException(() => values = argC.GetSeparatedValues(arg), out Exception ex);
            Test.IfNot.Null(values);
            Test.If.ValuesEqual(values.Count, 3);
            Test.If.ValuesEqual(values[0], "one");
            Test.If.ValuesEqual(values[1], "two");
            Test.If.ValuesEqual(values[2], "three");

            arg.Value = "one;;three";
            Test.Note("one;;three");
            Test.IfNot.ThrowsException(() => values = argC.GetSeparatedValues(arg), out ex);
            Test.IfNot.Null(values);
            Test.If.ValuesEqual(values.Count, 2);
            Test.If.ValuesEqual(values[0], "one");
            Test.If.ValuesEqual(values[1], "three");

            arg.Value = ";;;";
            Test.Note(";;;");
            Test.IfNot.ThrowsException(() => values = argC.GetSeparatedValues(arg), out ex);
            Test.IfNot.Null(values);
            Test.If.ValuesEqual(values.Count, 0);

            arg.Value = "just_this_one";
            Test.Note("just_this_one");
            Test.IfNot.ThrowsException(() => values = argC.GetSeparatedValues(arg), out ex);
            Test.IfNot.Null(values);
            Test.If.ValuesEqual(values.Count, 1);
            Test.If.ValuesEqual(values[0], "just_this_one");

        }

    }
}
