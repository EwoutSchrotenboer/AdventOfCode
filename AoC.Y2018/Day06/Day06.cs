using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using static AoC.Helpers.Utils.Manhattan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AoC.Helpers.Input;

namespace AoC.Y2018.Days
{
    public class Day06 : BaseDay
    {
        private int safety;

        public Day06() : base(2018, 6)
        {
            safety = 10000;
        }

        public Day06(IEnumerable<string> inputLines) : base(2018, 6, inputLines)
        {
            safety = 32;
        }

        protected override IConvertible PartOne()
        {
            var coordinates = InputParser.GetFileDataCoordinates(inputLines);
            var (upperLeft, downRight) = coordinates.GetDimensions();
            var (pointOwners, edgeOwners) = GetOwners(coordinates, upperLeft, downRight);
            return GetLargestGroupSize(pointOwners, edgeOwners);
        }

        protected override IConvertible PartTwo()
        {
            var safety = this.safety;
            var coordinates = InputParser.GetFileDataCoordinates(inputLines);
            var (upperLeft, downRight) = coordinates.GetDimensions();
            return GetSmallestDistanceRegionSize(coordinates, upperLeft, downRight, safety);
        }

        private static (Dictionary<Point, Point> pointOwners, HashSet<Point> edgeOwners) GetOwners(Point[] data, Point origin, Point max)
        {
            var pointOwners = new Dictionary<Point, Point>();
            var edgeOwners = new HashSet<Point>();

            for (var x = origin.X; x <= max.X; x++)
            {
                for (var y = origin.Y; y <= max.Y; y++)
                {
                    var manhattanDistances = data.Select(p => new KeyValuePair<Point, int>(p, GetManhattanDistance(p, x, y))).ToArray();

                    var minDistance = manhattanDistances.Min(d => d.Value);

                    var closestPoints = manhattanDistances.Where(kvp => kvp.Value == minDistance).ToArray();

                    if (closestPoints.Count() == 1)
                    {
                        var owner = closestPoints.Single().Key;
                        pointOwners.Add(new Point(x, y), owner);

                        if (x == origin.X || x == max.X || y == origin.Y || y == max.Y)
                        {
                            edgeOwners.Add(owner);
                        }
                    }
                }
            }

            return (pointOwners, edgeOwners);
        }

        private static int GetLargestGroupSize(Dictionary<Point, Point> pointOwners, HashSet<Point> edgeOwners)
        {
            var groups = pointOwners.Where(po => !edgeOwners.Contains(po.Value)) // if it owns an edge, it is not encapsulated
                                    .GroupBy(po => po.Value);

            var maxSize = groups.Select(g => g.Count()).Max();

            return maxSize;
        }

        private static int GetSmallestDistanceRegionSize(Point[] data, Point origin, Point max, int safety)
        {
            var regionSize = 0;

            for (var x = origin.X; x <= max.X; x++)
            {
                for (var y = origin.Y; y <= max.Y; y++)
                {
                    if (data.Select(p => GetManhattanDistance(p, x, y)).Sum() < safety)
                    {
                        regionSize++;
                    }
                }
            }

            return regionSize;
        }
    }
}