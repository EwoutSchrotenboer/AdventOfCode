using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day01 : BaseDay
    {
        public Day01() : base(2015, 1)
        {
        }

        public Day01(IEnumerable<string> input) : base(2015, 1, input)
        {
        }

        protected override IConvertible PartOne()
        {
            var input = inputLines.First();

            return input.Count(i => i == '(') - input.Count(i => i == ')');
        }

        protected override IConvertible PartTwo()
        {
            var input = inputLines.First();
            var floor = 0;

            for (int i = 0; i < input.Length; i++)
            {
                floor += input[i] == '(' ? 1 : -1;

                if (floor == -1)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
