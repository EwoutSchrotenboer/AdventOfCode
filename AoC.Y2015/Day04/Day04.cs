using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2015.Days
{
    public class Day04 : BaseDay
    {
        public Day04() : base(2015, 4)
        {
        }

        public Day04(IEnumerable<string> inputLines) : base(2015, 4, inputLines)
        {
        }

        protected override IConvertible PartOne() => LeadingZeros(inputLines.Single(), 5);

        protected override IConvertible PartTwo() => LeadingZeros(inputLines.Single(), 6);


        private static int LeadingZeros(string input, int zeroCount)
        {
            var num = 0;
            var md5 = System.Security.Cryptography.MD5.Create();

            while (true)
            {
                var inputBytes = Encoding.ASCII.GetBytes($"{input}{num}");
                var hash = md5.ComputeHash(inputBytes);

                var match = true;

                for (int i = 0; i < zeroCount / 2; i++)
                {
                    match &= hash[i] == 0;
                }

                if (zeroCount % 2 != 0)
                {
                    // To check if the first four values are 0, shift them to the right, AND the number with 00001111, check if this equals 0
                    match &= (hash[zeroCount / 2] >> 4 & 0xF) == 0;
                }

                if (match) { return num; }

                num++;
            }
        }
    }
}
