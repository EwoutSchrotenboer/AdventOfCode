using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day05 : BaseDay
    {
        public Day05() : base(2017, 5)
        {
        }

        public Day05(IEnumerable<string> inputLines) : base(2017, 5, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetExitInstructionIndex(ParseInput(inputLines), false);

        protected override IConvertible PartTwo() => GetExitInstructionIndex(ParseInput(inputLines), true);

        private static int GetExitInstructionIndex(List<int> instructions, bool partTwo)
        {
            var index = 0;
            var steps = 0;

            while (index >= 0 && index < instructions.Count())
            {
                var offset = instructions[index];
                instructions[index] += partTwo && offset >= 3 ? -1 : 1;
                index += offset;
                steps++;
            }

            return steps;
        }

        private static List<int> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(l => int.Parse(l)).ToList();
    }
}
