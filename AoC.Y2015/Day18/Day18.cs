using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day18 : BaseDay
    {
        public Day18() : base(2015, 18)
        {
        }

        public Day18(IEnumerable<string> inputLines) : base(2015, 18, inputLines)
        {
        }

        protected override IConvertible PartOne() => Conway(ParseInput(inputLines.ToList()), 100, false);

        protected override IConvertible PartTwo() => Conway(ParseInput(inputLines.ToList()), 100, true);

        private static int Conway(Dictionary<(int x, int y), int> grid, int steps, bool partTwo)
        {
            var width = grid.Last().Key.x;
            var height = grid.Last().Key.y;

            if (partTwo)
            {
                grid[(0, 0)] = 1;
                grid[(0, width)] = 1;
                grid[(height, 0)] = 1;
                grid[(height, width)] = 1;
            }

            for (int step = 0; step < steps; step++)
            {
                var nextGrid = new Dictionary<(int, int), int>();

                foreach (var kvp in grid)
                {
                    var (x, y) = kvp.Key;

                    if (partTwo && (x == 0 || x == width) && (y == 0 || y == height))
                    {
                        nextGrid.Add(kvp.Key, 1);
                        continue;
                    }

                    var adjacentOnCount = GetAdjacentCount(grid, x, y);

                    if (kvp.Value == 1 && (adjacentOnCount == 2 || adjacentOnCount == 3)) { nextGrid.Add(kvp.Key, 1); }
                    else if (kvp.Value == 0 && adjacentOnCount == 3) { nextGrid.Add(kvp.Key, 1); }
                    else { nextGrid.Add(kvp.Key, 0); }
                }

                grid = nextGrid;
            }

            return grid.Values.Count(l => l == 1);
        }

        private static int GetAdjacentCount(Dictionary<(int x, int y), int> grid, int x, int y)
        {
            var positions = new List<(int xz, int yz)>()
            {
                (-1, -1), (-1, 0), (-1, 1),
                ( 0, -1),          ( 0, 1),
                ( 1, -1), ( 1, 0), ( 1, 1)
            };

            var count = 0;

            foreach (var (xz, yz) in positions)
            {
                grid.TryGetValue((x + xz, y + yz), out int value);
                count += value;
            }

            return count;
        }

        private static Dictionary<(int, int), int> ParseInput(List<string> inputLines)
        {
            var grid = new Dictionary<(int, int), int>();

            for (var yPos = 0; yPos < inputLines.Count(); yPos++)
            {
                for (var xPos = 0; xPos < inputLines[0].Length; xPos++)
                {
                    grid.Add((xPos, yPos), inputLines[yPos][xPos] == '#' ? 1 : 0);
                }
            }

            return grid;
        }
    }
}
