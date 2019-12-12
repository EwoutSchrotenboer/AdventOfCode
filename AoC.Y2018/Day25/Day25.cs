using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day25 : BaseDay
    {
        public Day25() : base(2018, 25)
        {
        }

        public Day25(IEnumerable<string> inputLines) : base(2018, 25, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var constellations = ParseInput(inputLines);
            var neighbors = new Dictionary<StarPoint, HashSet<StarPoint>>();

            foreach (var current in constellations)
            {
                var starPoint = current.StarPoints.Single();
                neighbors[starPoint] = new HashSet<StarPoint>();

                foreach (var other in constellations)
                {
                    if (current == other) continue;

                    var dist = starPoint.Distance(other.StarPoints.Single());
                    if (dist <= 3)
                    {
                        neighbors[starPoint].Add(other.StarPoints.Single());
                    }
                }
            }

            var didWork = true;
            while (didWork)
            {
                didWork = false;
                var newConstellations = new HashSet<Constellation>();
                var joinedConstellations = new HashSet<Constellation>();

                foreach (var current in constellations)
                {
                    if (joinedConstellations.Contains(current)) continue;

                    newConstellations.Add(current);

                    foreach (var other in constellations)
                    {
                        if (current == other) continue;
                        if (joinedConstellations.Contains(other)) continue;
                        if (newConstellations.Contains(other)) continue;

                        if (current.StarPoints.Any(s => neighbors[s].Any(n => other.StarPoints.Contains(n))))
                        {
                            joinedConstellations.Add(other);

                            foreach (var starPoint in other.StarPoints)
                            {
                                current.StarPoints.Add(starPoint);
                            }

                            didWork = true;
                        }
                    }
                }

                constellations = newConstellations;
            }

            return constellations.Count();
        }

        protected override IConvertible PartTwo()
        {
            return "Finished!";
        }

        private static HashSet<Constellation> ParseInput(IEnumerable<string> inputLines)
        {
            var constellations = new HashSet<Constellation>();

            foreach (var inputLine in inputLines)
            {
                var split = inputLine.Split(',');
                var constellation = new Constellation()
                {
                    StarPoints = new HashSet<StarPoint>() { new StarPoint(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3])) }
                };

                constellations.Add(constellation);
            }

            return constellations;
        }
    }
}