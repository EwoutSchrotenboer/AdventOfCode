using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Helpers.Utils
{
    public static class Methods
    {
        public static long LCM(long[] numbers)
        {
            return numbers.Aggregate(Lcm);
        }
        public static long Lcm(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }
        public static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
