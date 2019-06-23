using System;

namespace Nuclear.Maths {
    public static class Maths {

        #region sqrt

        public static Single Sqrt(Single value) => (Single) Math.Sqrt(value);

        public static Double Sqrt(Double value) => Math.Sqrt(value);

        #endregion

        #region angle maths

        public static Single Acos(Single value) => (Single) Math.Acos(value);

        public static Double Acos(Double value) => Math.Acos(value);

        public static Single Asin(Single value) => (Single) Math.Asin(value);

        public static Double Asin(Double value) => Math.Asin(value);

        public static Single Atan(Single value) => (Single) Math.Atan(value);

        public static Double Atan(Double value) => Math.Atan(value);

        public static Single Atan2(Single value1, Single value2) => (Single) Math.Atan2(value1, value2);

        public static Double Atan2(Double value1, Double value2) => Math.Atan2(value1, value2);

        public static Single Cos(Single value) => (Single) Math.Cos(value);

        public static Double Cos(Double value) => Math.Cos(value);

        public static Single Cosh(Single value) => (Single) Math.Cosh(value);

        public static Double Cosh(Double value) => Math.Cosh(value);

        public static Single Sin(Single value) => (Single) Math.Sin(value);

        public static Double Sin(Double value) => Math.Sin(value);

        public static Single Sinh(Single value) => (Single) Math.Sinh(value);

        public static Double Sinh(Double value) => Math.Sinh(value);

        public static Single Tan(Single value) => (Single) Math.Tan(value);

        public static Double Tan(Double value) => Math.Tan(value);

        public static Single Tanh(Single value) => (Single) Math.Tanh(value);

        public static Double Tanh(Double value) => Math.Tanh(value);

        #endregion

    }
}
