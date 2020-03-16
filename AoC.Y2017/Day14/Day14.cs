using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2017.Days
{
    public class Day14 : BaseDay
    {
        public Day14() : base(2017, 14)
        {
        }

        public Day14(IEnumerable<string> inputLines) : base(2017, 14, inputLines)
        {
        }

        protected override IConvertible PartOne() => GenerateDisk(inputLines.Single()).Values.Count(v => v);

        protected override IConvertible PartTwo()
        {
            var input = inputLines.Single();
            var disk = GenerateDisk(input);
            return GetRegions(disk);
        }

        private static Dictionary<AoCPoint, bool> GenerateDisk(string key)
        {
            var disk = new Dictionary<AoCPoint, bool>();

            for (int y = 0; y < 128; y++)
            {
                var knotHash = KnotHash.Create($"{key}-{y}");
                var binary = string.Join(string.Empty, knotHash.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

                for (int x = 0; x < 128; x++)
                {
                    disk.Add(new AoCPoint(x, y), binary[x] == '1');
                }
            }

            return disk;
        }

        private static int GetRegions(Dictionary<AoCPoint, bool> disk)
        {
            var regions = 0;

            var dataQueue = new Queue<AoCPoint>(disk.Where(d => d.Value).Select(d => d.Key));
            var seen = new HashSet<AoCPoint>();

            while (dataQueue.Any())
            {
                var regionQueue = new Queue<AoCPoint>();
                var regionStart = dataQueue.Dequeue();

                if (!seen.Contains(regionStart))
                {
                    regionQueue.Enqueue(regionStart);

                    while (regionQueue.Any())
                    {
                        var current = regionQueue.Dequeue();

                        if (seen.Contains(current)) { continue; }

                        seen.Add(current);

                        foreach (var adjacent in current.Adjacent())
                        {
                            if (dataQueue.Contains(adjacent) && !seen.Contains(adjacent))
                            {
                                regionQueue.Enqueue(adjacent);
                            }
                        }
                    }

                    regions++;
                }
            }

            return regions;
        }
    }
}
