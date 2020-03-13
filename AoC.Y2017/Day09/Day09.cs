using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day09 : BaseDay
    {
        public Day09() : base(2017, 9)
        {
        }

        public Day09(IEnumerable<string> inputLines) : base(2017, 9, inputLines)
        {
        }

        protected override IConvertible PartOne() => AnalyzeStream(inputLines.Single()).groupScore;

        protected override IConvertible PartTwo() => AnalyzeStream(inputLines.Single()).garbageScore;

        private static (int groupScore, int garbageScore) AnalyzeStream(string input)
        {
            var groupScore = 0;
            var garbageScore = 0;

            var depth = 0;
            var inGarbage = false;
            var cancelled = false;

            foreach (var c in input)
            {
                switch (c, inGarbage, cancelled)
                {
                    // oustide of garbage
                    case ('{', false,     _): depth++;                      break;
                    case ('}', false,     _): groupScore += depth; depth--; break;
                    case ('<', false,     _): inGarbage = true;             break;

                    // inside of garbage
                    case ('>',  true, false): inGarbage = false;            break;
                    case ('!',  true, false): cancelled = true;             break;
                    case (_  ,  true, false): garbageScore++;               break;

                    // inside of garbage and cancelled
                    case (_  ,  true,  true): cancelled = false;            break;

                }
            }

            return (groupScore, garbageScore);
        }
    }
}
