using AoC.Helpers.Assembunny;
using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day23 : BaseDay
    {
        public Day23() : base(2016, 23)
        {
        }

        public Day23(IEnumerable<string> inputLines) : base(2016, 23, inputLines)
        {
        }

        protected override IConvertible PartOne() => BunnyVM.RunProgram(ParseInput(inputLines), (0, 7), false);

        protected override IConvertible PartTwo() => BunnyVM.RunProgram(ParseInput(inputLines), (0, 12), true);

        private static List<BunnyInstruction> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(i => new BunnyInstruction(i)).ToList();
    }
}
