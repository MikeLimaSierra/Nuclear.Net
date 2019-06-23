using System;
using Nuclear.TestSite.Attributes;
using Nuclear.TestSite.Tests;

namespace Nuclear.Arguments {

    class ArgumentCollectorTests {

        [TestMethod]
        void TestImplementation() {

#pragma warning disable IDE0022 // Use expression body for methods
            Test.If.TypeImplements<ArgumentCollector, IArgumentCollector>();
#pragma warning restore IDE0022 // Use expression body for methods

        }

        [TestMethod]
        void TestConstructors() {

            IArgumentCollector argC = null;

            Test.IfNot.ThrowsException(() => { argC = new ArgumentCollector(); }, out Exception ex);
            Test.If.ValuesEqual(argC.SwitchIndicator, '-');
            Test.If.ValuesEqual(argC.ValueSeparator, ';');

            Test.IfNot.ThrowsException(() => { argC = new ArgumentCollector('_', '$'); }, out ex);
            Test.If.ValuesEqual(argC.SwitchIndicator, '_');
            Test.If.ValuesEqual(argC.ValueSeparator, '$');

        }

        [TestMethod]
        void TestCollect() {

            IArgumentCollector argC = new ArgumentCollector();

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "-z" }); }, out Exception ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 1);

            Test.If.True(argC.Arguments[0].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.False(argC.Arguments[0].HasValue);

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "added_value" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 1);

            Test.If.True(argC.Arguments[0].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.True(argC.Arguments[0].HasValue);
            Test.If.ValuesEqual(argC.Arguments[0].Value, "added_value");

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "-n", "42" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 2);

            Test.If.True(argC.Arguments[1].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[1].SwitchName, "n");
            Test.If.True(argC.Arguments[1].HasValue);
            Test.If.ValuesEqual(argC.Arguments[1].Value, "42");

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "--force" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 3);

            Test.If.True(argC.Arguments[2].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[2].SwitchName, "force");
            Test.If.False(argC.Arguments[2].HasValue);

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "added_value2" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 3);

            Test.If.True(argC.Arguments[2].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[2].SwitchName, "force");
            Test.If.True(argC.Arguments[2].HasValue);
            Test.If.ValuesEqual(argC.Arguments[2].Value, "added_value2");

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "--unforce", "what_was_forced_before" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 4);

            Test.If.True(argC.Arguments[3].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[3].SwitchName, "unforce");
            Test.If.True(argC.Arguments[3].HasValue);
            Test.If.ValuesEqual(argC.Arguments[3].Value, "what_was_forced_before");

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { @"file:\\some\path" }); }, out ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 5);

            Test.If.False(argC.Arguments[4].IsSwitch);
            Test.If.True(argC.Arguments[4].HasValue);
            Test.If.ValuesEqual(argC.Arguments[4].Value, @"file:\\some\path");

        }

        [TestMethod]
        void TestCollectCombined() {

            IArgumentCollector argC = new ArgumentCollector();

            Test.IfNot.ThrowsException(() => { argC.Collect(new String[] { "-z", "--all", "your_base_are_belong_to_us", "unicorn", "--asdf" }); }, out Exception ex);
            Test.If.ValuesEqual(argC.Arguments.Count, 4);

            Test.If.True(argC.Arguments[0].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[0].SwitchName, "z");
            Test.If.False(argC.Arguments[0].HasValue);
            Test.If.Null(argC.Arguments[0].Value);

            Test.If.True(argC.Arguments[1].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[1].SwitchName, "all");
            Test.If.True(argC.Arguments[1].HasValue);
            Test.If.ValuesEqual(argC.Arguments[1].Value, "your_base_are_belong_to_us");

            Test.If.False(argC.Arguments[2].IsSwitch);
            Test.If.Null(argC.Arguments[2].SwitchName);
            Test.If.True(argC.Arguments[2].HasValue);
            Test.If.ValuesEqual(argC.Arguments[2].Value, "unicorn");

            Test.If.True(argC.Arguments[3].IsSwitch);
            Test.If.ValuesEqual(argC.Arguments[3].SwitchName, "asdf");
            Test.If.False(argC.Arguments[3].HasValue);
            Test.If.Null(argC.Arguments[3].Value);

        }

    }
}
