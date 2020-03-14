using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day11 : BaseDay
    {
        private readonly int serialInput = 3463;

        public Day11() : base(2017, 11)
        {
        }

        public Day11(IEnumerable<string> inputLines) : base(2017, 11, inputLines)
        {
        }

        protected override IConvertible PartOne() => RecreateRoute(ParseInput(inputLines)).distanceToStart;

        protected override IConvertible PartTwo() => RecreateRoute(ParseInput(inputLines)).furthestAway;

        // Mapping hexagons as cubes.
        private static HexPoint GetAdjacent(HexPoint src, string direction) =>
            direction switch
            {
                "n" => src.Adjacent(0, 1, -1),
                "ne" => src.Adjacent(1, 0, -1),
                "se" => src.Adjacent(1, -1, 0),
                "s" => src.Adjacent(0, -1, 1),
                "sw" => src.Adjacent(-1, 0, 1),
                "nw" => src.Adjacent(-1, 1, 0),
                _ => throw new Exception("Invalid direction.")
            };

        // Manhattan distance for a hexagonal grid is the cubed Manhattan distance divided by 2.
        private static int GetHexHattan(HexPoint src, HexPoint dst) =>
            (Math.Abs(src.X - dst.X) + Math.Abs(src.Y - dst.Y) + Math.Abs(src.Z - dst.Z)) / 2;

        private static IEnumerable<string> ParseInput(IEnumerable<string> inputLines) => inputLines.Single().Split(',');

        private static (int distanceToStart, int furthestAway) RecreateRoute(IEnumerable<string> directions)
        {
            var maxDistance = 0;
            var currentDistance = 0;
            var origin = HexPoint.Origin();
            var current = origin;

            foreach (var direction in directions)
            {
                current = GetAdjacent(current, direction);
                currentDistance = GetHexHattan(origin, current);
                maxDistance = Math.Max(maxDistance, currentDistance);
            }

            return (currentDistance, maxDistance);
        }
    }
}
