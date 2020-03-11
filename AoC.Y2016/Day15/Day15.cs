using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day15 : BaseDay
    {
        public Day15() : base(2016, 15)
        {
        }

        public Day15(IEnumerable<string> inputLines) : base(2016, 15, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetCapsule(ParseInput(inputLines), false);

        protected override IConvertible PartTwo() => GetCapsule(ParseInput(inputLines), true);

        private int GetCapsule(List<Disc> discs, bool partTwo)
        {
            var time = 0;

            if (partTwo) { discs.Add(new Disc(7, 11, 0)); }

            while (true)
            {
                if (discs.Where((disc, discIndex) => disc.GetPosition(time + discIndex + 1) == 0).Count() == discs.Count()) { return time; }
                time++;
            }
        }

        private static List<Disc> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(l => new Disc(l)).ToList();
    }
}
