using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day13 : BaseDay
    {
        public Day13() : base(2017, 13)
        {
        }

        public Day13(IEnumerable<string> inputLines) : base(2017, 13, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetSeverity(ParseInput(inputLines));

        protected override IConvertible PartTwo() => GetDelay(ParseInput(inputLines));

        private static int GetSeverity(Dictionary<int, int> scanners)
        {
            var picoSecond = 0;
            var severity = 0;

            while (picoSecond <= scanners.Keys.Max())
            {
                if (scanners.TryGetValue(picoSecond, out var depth))
                {
                    if (picoSecond % (depth * 2 - 2) == 0)
                    {
                        severity += picoSecond * depth;
                    }
                }

                picoSecond++;
            }

            return severity;
        }

        private static int GetDelay(Dictionary<int, int> scanners)
        {
            var delay = 0;

            while(true)
            {
                if (scanners.All(s => (delay + s.Key) % (s.Value * 2 - 2) != 0))
                {
                    return delay;
                }

                delay++;
            }
        }

        private static Dictionary<int, int> ParseInput(IEnumerable<string> inputLines)
        {
            var scanners = new Dictionary<int, int>();

            foreach (var line in inputLines)
            {
                var items = line.Replace(":", "").Split(' ');
                scanners.Add(int.Parse(items[0]), int.Parse(items[1]));
            }

            return scanners;
        }
    }
}
