using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC.Y2015.Days
{
    public class Day08 : BaseDay
    {
        public Day08() : base(2015, 8)
        {
        }

        public Day08(IEnumerable<string> inputLines) : base(2015, 8, inputLines)
        {
        }

        protected override IConvertible PartOne() => inputLines.Sum(i => DetermineDecodedDifference(i));

        protected override IConvertible PartTwo() => inputLines.Sum(i => DetermineEncodedDifference(i));

        private static int DetermineDecodedDifference(string input) => input.Length + 2 - Regex.Unescape(input).Length;

        private int DetermineEncodedDifference(string input)
        {
            var temp = input.Replace("\"", "QUOT").Replace("\\", "SLASH");
            var output = temp.Replace("QUOT", "\\\"").Replace("SLASH", "\\\\");
            return output.Length + 2 - input.Length;
        }
    }
}
