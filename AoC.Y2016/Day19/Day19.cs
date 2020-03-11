using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day19 : BaseDay
    {
        public Day19() : base(2016, 19)
        {
        }

        public Day19(IEnumerable<string> inputLines) : base(2016, 19, inputLines)
        {
        }

        protected override IConvertible PartOne() => StealLeft(int.Parse(inputLines.Single()));

        protected override IConvertible PartTwo() => StealAcross(int.Parse(inputLines.Single()));

        // https://en.wikipedia.org/wiki/Josephus_problem
        private static int StealLeft(int elves) => ~(elves * 2).HighestOneBit() & ((elves << 1) | 1);

        // In 1997, Lorenz Halbeisen and Norbert Hungerbühler discovered a closed-form for the case k=3.
        // Along with some internet help, this is the optimized version
        private static int StealAcross(int elves)
        {
            var section = (int)Math.Pow(3, (int)Math.Log(elves - 1, 3));
            return elves - section + Math.Max(0, elves - 2 * section);
        }
    }
}
