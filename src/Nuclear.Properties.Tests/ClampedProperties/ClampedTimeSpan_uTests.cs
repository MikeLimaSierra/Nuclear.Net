﻿using System;
using Nuclear.TestSite;

namespace Nuclear.Properties.ClampedProperties {
    class ClampedTimeSpan_uTests {

        [TestMethod]
        void TestImplementation() {

            Test.If.Type.Implements<IClampedTimeSpan, IClampedPropertyT<TimeSpan>>();
            Test.If.Type.Implements<ClampedTimeSpan, IClampedTimeSpan>();

        }

        [TestMethod]
        void TestConstructors() {

            IClampedTimeSpan prop = null;
            TimeSpan value = DateTime.Now.TimeOfDay;
            TimeSpan min = TimeSpan.MinValue;
            TimeSpan max = TimeSpan.MaxValue;

            Test.IfNot.Action.ThrowsException(() => prop = new ClampedTimeSpan(value, min, max), out Exception ex);
            Test.IfNot.Object.IsNull(prop);
            Test.If.Value.Equals(prop.Value, value);
            Test.If.Value.Equals(prop.Minimum, min);
            Test.If.Value.Equals(prop.Maximum, max);

        }

    }
}