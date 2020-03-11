using AoC.Helpers.Assembunny;
using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day25 : BaseDay
    {
        public Day25() : base(2016, 25)
        {
        }

        public Day25(IEnumerable<string> inputLines) : base(2016, 25, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var input = 1;

            while (true)
            {
                var val = BunnyVM.RunProgram(ParseInput(inputLines), (0, input), false);
                if (val != -1) { return val; }
                input++;
            }
        }

        protected override IConvertible PartTwo() => "Merry Christmas!";

        private static List<BunnyInstruction> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(i => new BunnyInstruction(i)).ToList();
    }
}
