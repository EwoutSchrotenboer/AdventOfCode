using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day24 : BaseDay
    {
        public Day24() : base(2016, 24)
        {
        }

        public Day24(IEnumerable<string> inputLines) : base(2016, 24, inputLines)
        {
        }

        protected override IConvertible PartOne() => CalculateDistance(ParseInput(inputLines), false);

        protected override IConvertible PartTwo() => CalculateDistance(ParseInput(inputLines), true);

        private static int CalculateDistance(Dictionary<AoCPoint, int> points, bool partTwo)
        {
            var distances = GetDistances(points);
            return GetShortestDistance(distances, partTwo);
        }

        private static List<(int a, int b, int steps)> GetDistances(Dictionary<AoCPoint, int> points)
        {
            var distances = new List<(int, int, int)>();
            var locations = points.Where(p => p.Value != -1).OrderBy(p => p.Value).ToList();

            for (int i = 0; i < locations.Count(); i++)
            {
                var distancesFromPoint = GetPointDistances(points, locations[i].Key);

                foreach (var (dst, steps) in distancesFromPoint)
                {
                    distances.Add((locations[i].Value, dst, steps));
                }
            }

            return distances;
        }

        private static List<(int dst, int steps)> GetPointDistances(Dictionary<AoCPoint, int> points, AoCPoint src)
        {
            var distances = new List<(int, int)>();
            var seen = new HashSet<AoCPoint>();
            var pointVal = points[src];
            var pointCount = points.Count(p => p.Value != -1) - 1;

            var pointQueue = new Queue<(AoCPoint point, int steps)>();
            pointQueue.Enqueue((src, 0));

            while (pointQueue.Any())
            {
                var (current, steps) = pointQueue.Dequeue();

                if (seen.Contains(current)) { continue; }
                seen.Add(current);

                foreach (var adjacent in current.Adjacent())
                {
                    if (points.TryGetValue(adjacent, out var value))
                    {
                        if (value != -1 && value != pointVal)
                        {
                            if (!seen.Contains(adjacent))
                            {
                                distances.Add((value, steps + 1));
                            }

                            if (distances.Count() == pointCount) { return distances; }
                        }

                        pointQueue.Enqueue((adjacent, steps + 1));
                    }
                }
            }

            return distances;
        }

        private static int GetShortestDistance(List<(int a, int b, int steps)> distances, bool partTwo)
        {
            var locations = distances.Where(d => d.a != 0).Select(d => d.a).Distinct().ToList();

            var permutations = locations.GetPermutations(locations.Count());

            var stepsList = new List<int>();

            foreach (var p in permutations)
            {
                var steps = 0;
                var permutationSteps = p.ToList();
                steps += distances.Single(d => d.a == 0 && d.b == permutationSteps.First()).steps;

                for (int i = 0; i < permutationSteps.Count() - 1; i++)
                {
                    steps += distances.Single(d => d.a == permutationSteps[i] && d.b == permutationSteps[i + 1]).steps;
                }

                if (partTwo)
                {
                    steps += distances.Single(d => d.a == permutationSteps.Last() && d.b == 0).steps;
                }

                stepsList.Add(steps);
            }

            return stepsList.Min();
        }

        private static Dictionary<AoCPoint, int> ParseInput(IEnumerable<string> inputLines)
        {
            var coords = new Dictionary<AoCPoint, int>();

            var lines = inputLines.ToList();

            for (int yPos = 0; yPos < lines.Count(); yPos++)
            {
                for (int xPos = 0; xPos < lines[0].Length; xPos++)
                {
                    var val = lines[yPos][xPos];
                    if (val != '#')
                    {
                        coords.Add(new AoCPoint(xPos, yPos), val == '.' ? -1 : (int)char.GetNumericValue(val));
                    }
                }
            }

            return coords;
        }
    }
}
