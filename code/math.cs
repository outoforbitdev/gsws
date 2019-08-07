using System;

namespace GSWS {
    class Math {
        public static int Parse(string input) {
            int trying;
            if (Int32.TryParse(input, out trying)) return trying;
            return 0;
        }
        // Functions required to avoid conflicts with System.Math
        public static double Log10(double value) {
            return System.Math.Log10(value);
        }
        public static double Round(double value, Int32 digits) {
            return System.Math.Round(value, digits);
        }
    }
}