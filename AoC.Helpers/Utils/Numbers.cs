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
    }
}
