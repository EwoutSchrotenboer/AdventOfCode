using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day02 : BaseDay
    {
        public Day02(IEnumerable<string> input) : base(2017, 2, input)
        {
        }

        public Day02() : base(2017, 2)
        {
        }

        protected override IConvertible PartOne() => GetCorruptionChecksum(ParseInput(inputLines));

        protected override IConvertible PartTwo() => GetDivisibleChecksum(ParseInput(inputLines));

        private static int GetCorruptionChecksum(List<List<int>> lines) => lines.Sum(l => l.Max() - l.Min());

        private static int GetDivisibleChecksum(List<List<int>> lines) => lines.Sum(l => GetDivisibleLineChecksum(l));

        private static int GetDivisibleLineChecksum(List<int> line)
        {
            var items = line.OrderByDescending(l => l).ToList();

            for (int i = 0; i < items.Count; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    if (items[i] % items[j] == 0)
                    {
                        return items[i] / items[j];
                    }
                }
            }

            return 0;
        }

        private static List<List<int>> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(l => l.Split('\t').Select(i => int.Parse(i)).ToList()).ToList();

    }
}
