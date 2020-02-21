using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day17 : BaseDay
    {
        public Point Spring => new Point(500, 0);

        public Day17() : base(2015, 17)
        {
        }

        public Day17(IEnumerable<string> inputLines) : base(2015, 17, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetCombinations(ParseInput(inputLines), 150).Count();

        protected override IConvertible PartTwo()
        {
            var combinations = GetCombinations(ParseInput(inputLines), 150);
            var leastContainersCount = combinations.Min(c => c.Count);
            return combinations.Where(c => c.Count == leastContainersCount).Count();
        }

        private static IEnumerable<List<int>> GetCombinations(List<int> containers, int eggnog)
        {
            // Create a bitmask to test the various sets of containers.
            return Enumerable.Range(1, (1 << containers.Count) - 1)
                .Select(maskIndex => containers.Where((item, containersIndex) => ((1 << containersIndex) & maskIndex) != 0).ToList())
                .Where(c => c.Sum() == eggnog);
        }

        private static List<int> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(i => int.Parse(i)).ToList();
    }
}
