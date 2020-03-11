using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day18 : BaseDay
    {
        public Day18() : base(2016, 18)
        {
        }

        public Day18(IEnumerable<string> inputLines) : base(2016, 18, inputLines)
        {
        }

        protected override IConvertible PartOne() => GenerateMap(ParseInput(inputLines), 40).Sum(l => l.Count(c => c == false));

        protected override IConvertible PartTwo() => GenerateMap(ParseInput(inputLines), 400000).Sum(l => l.Count(c => c == false));

        private List<bool[]> GenerateMap(bool[] initial, int rows)
        {
            var map = new List<bool[]>() { initial };

            var current = initial;

            for (int i = 0; i < rows - 1; i++)
            {
                var next = NextRow(current);
                map.Add(next);
                current = next;
            }

            return map;
        }

        private static bool[] NextRow(bool[] current)
        {
            var next = new bool[current.Length];

            next[0] = IsTrap(false, current[0], current[1]);

            for (int i = 1; i < current.Length - 1; i++)
            {
                next[i] = IsTrap(current[i - 1], current[i], current[i + 1]);
            }

            next[^1] = IsTrap(current[^2], current[^1], false);

            return next;
        }

        private static bool IsTrap(bool left, bool center, bool right) =>
            (left && center && !right)
            || (!left && center && right)
            || (left && !center && !right)
            || (!left && !center && right);


        private static bool[] ParseInput(IEnumerable<string> inputLines) => inputLines.Single().Select(c => c == '^').ToArray();
    }
}
