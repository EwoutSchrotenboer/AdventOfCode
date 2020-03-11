using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day01 : BaseDay
    {
        public Day01() : base(2017, 1)
        {
        }

        public Day01(IEnumerable<string> input) : base(2017, 1, input)
        {
        }

        protected override IConvertible PartOne() => GetInverseCaptcha(inputLines.Single(), false);

        protected override IConvertible PartTwo() => GetInverseCaptcha(inputLines.Single(), true);

        private static int GetInverseCaptcha(string input, bool partTwo)
        {
            var sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var compareIndex = (partTwo ? (i + input.Length / 2) : (i + 1)) % input.Length;

                if (input[i] == input[compareIndex])
                {
                    sum += (int)char.GetNumericValue(input[i]);
                }
            }

            return sum;
        }
    }
}
