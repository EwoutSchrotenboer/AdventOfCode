using AoC.Helpers.Assembunny;
using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day12 : BaseDay
    {
        public Day12() : base(2016, 12)
        {
        }

        public Day12(IEnumerable<string> inputLines) : base(2016, 12, inputLines)
        {
        }

        protected override IConvertible PartOne() => BunnyVM.RunProgram(ParseInput(inputLines), (2, 0), false);

        protected override IConvertible PartTwo() => BunnyVM.RunProgram(ParseInput(inputLines), (2, 1), false);

        private static List<BunnyInstruction> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(i => new BunnyInstruction(i)).ToList();
    }
}
