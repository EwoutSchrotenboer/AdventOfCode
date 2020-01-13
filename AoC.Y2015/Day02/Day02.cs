using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day02 : BaseDay
    {
        public Day02(IEnumerable<string> input) : base(2015, 2, input)
        {
        }

        public Day02() : base(2015, 2)
        {
        }

        protected override IConvertible PartOne()
        {
            var boxes = ParseInput(inputLines);
            var sum = 0;

            foreach (var (l, w, h) in boxes)
            {
                // surface
                sum += 2 * l * w;
                sum += 2 * w * h;
                sum += 2 * h * l;

                // slack
                var orderedBySize = new List<int>() { l, w, h }.OrderBy(p => p).ToList();
                sum += orderedBySize[0] * orderedBySize[1];
            }

            return sum;
        }

        protected override IConvertible PartTwo()
        {
            var boxes = ParseInput(inputLines);
            var sum = 0;

            foreach (var (l, w, h) in boxes)
            {
                var orderedBySize = new List<int>() { l, w, h }.OrderBy(p => p).ToList();
                sum += orderedBySize[0] * 2 + orderedBySize[1] * 2;
                sum += l * w * h;
            }

            return sum;
        }

        private static List<(int l, int w, int h)> ParseInput(IEnumerable<string> inputLines)
        {
            var boxes = new List<(int l, int w, int h)>();

            foreach (var line in inputLines)
            {
                var d = line.Split("x");
                boxes.Add((int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2])));
            }

            return boxes;
        }
    }
}
