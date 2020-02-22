using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day03 : BaseDay
    {
        public Day03() : base(2016, 3)
        {
        }

        public Day03(IEnumerable<string> inputLines) : base(2016, 3, inputLines)
        {
        }

        protected override IConvertible PartOne() => CalculateValidTriangles(ParseInput(inputLines));

        protected override IConvertible PartTwo()
        {
            var sets = ParseInput(inputLines);
            var reordered = new List<List<int>>();

            for(int i = 0; i < sets.Count; i += 3)
            {
                reordered.Add(new List<int>() { sets[i][0], sets[i + 1][0], sets[i + 2][0] });
                reordered.Add(new List<int>() { sets[i][1], sets[i + 1][1], sets[i + 2][1] });
                reordered.Add(new List<int>() { sets[i][2], sets[i + 1][2], sets[i + 2][2] });
            }

            return CalculateValidTriangles(reordered);
        }

        private static int CalculateValidTriangles(List<List<int>> numbers)
        {
            var validCount = 0;

            foreach (var set in numbers)
            {
                if (   set[0] + set[1] > set[2]
                    && set[1] + set[2] > set[0]
                    && set[2] + set[0] > set[1])
                {
                    validCount++;
                }
            }

            return validCount;
        }

        private static List<List<int>> ParseInput(IEnumerable<string> inputLines)
        {
            var numbers = new List<List<int>>();

            foreach (var line in inputLines) 
            {
                var items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i));
                numbers.Add(items.ToList());
            }

            return numbers;
        }
    }
}
