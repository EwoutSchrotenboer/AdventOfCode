using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AoC.Helpers.Utils
{
    public static class Numbers
    {
        public static BigInteger Modulo(this BigInteger x, BigInteger m)
        {
            return (x % m + m) % m;
        }

        public static BigInteger ModInverse(this BigInteger num, BigInteger size)
        {
            return num.ModPow(size - 2, size);
        }

        public static BigInteger CastToBigInt(this int num)
        {
            return new BigInteger(num);
        }

        public static BigInteger ModPow(this BigInteger bigInteger, BigInteger pow, BigInteger mod)
        {
            return BigInteger.ModPow(bigInteger, pow, mod);
        }

        public static int CountSetBits(this int n)
        {
            var count = 0;

            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }

            return count;
        }

        public static int HighestOneBit(this int number)
        {
            return (int)Math.Pow(2, Convert.ToString(number, 2).Length - 1);
        }
    }
}
