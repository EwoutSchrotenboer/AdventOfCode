using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day09 : BaseDay
    {
        public Day09() : base(2015, 9)
        {
        }

        public Day09(IEnumerable<string> inputLines) : base(2015, 9, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetRoutePermutations(ParseInput(inputLines)).Min();

        protected override IConvertible PartTwo() => GetRoutePermutations(ParseInput(inputLines)).Max();

        private static List<int> GetRoutePermutations(Dictionary<(string src, string dst), int> edges)
        {
            var vertices = edges.Keys.Select(e => e.src).Distinct().OrderBy(v => v).ToList();
            var permutations = vertices.GetPermutations(vertices.Count());
            var distances = new List<int>();

            // note, the brute force only works because of the small sample set
            foreach (var p in permutations)
            {
                var route = p.ToList();
                var distance = 0;

                for (int i = 0; i < p.Count() - 1; i++)
                {
                    distance += edges[(route[i], route[i + 1])];
                }

                distances.Add(distance);
            }

            return distances;
        }

        private static Dictionary<(string src, string dst), int> ParseInput(IEnumerable<string> inputLines)
        {
            var edges = new Dictionary<(string, string), int>();

            foreach (var line in inputLines)
            {
                var items = line.Split(' ');
                edges.Add((items[0], items[2]), int.Parse(items[4]));
                edges.Add((items[2], items[0]), int.Parse(items[4]));
            }

            return edges;
        }
    }
}
