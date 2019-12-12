using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AoC.Y2018.Days
{
    public class Day18 : BaseDay
    {
        public Day18() : base(2018, 18)
        {
        }

        public Day18(IEnumerable<string> inputLines) : base(2018, 18, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            return CalculateTreesAfterMinutes(10);
        }

        protected override IConvertible PartTwo()
        {
            return CalculateTreesAfterMinutes(1_000_000_000);
        }

        private int CalculateTreesAfterMinutes(int iterations)
        {
            var sourceGrid = inputLines.To2DCharArray();
            var destGrid = inputLines.To2DCharArray();

            var width = sourceGrid.GetLength(0);
            var height = sourceGrid.GetLength(1);

            var previousStates = new List<string>();

            for (int i = 0; i < iterations; i++)
            {
                var sb = new StringBuilder();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        sb.Append(sourceGrid[x, y]);

                        int treecount = 0;
                        int yardcount = 0;

                        for (int n = Math.Max(0, x - 1); n < Math.Min(width, x + 2); n++)
                        {
                            for (int m = Math.Max(0, y - 1); m < Math.Min(height, y + 2); m++)
                            {
                                if (n == x && y == m) continue;
                                if (sourceGrid[n, m] == '|') treecount++;
                                if (sourceGrid[n, m] == '#') yardcount++;
                            }
                        }

                        if (sourceGrid[x, y] == '.' && treecount >= 3)
                        {
                            destGrid[x, y] = '|';
                        }

                        if (sourceGrid[x, y] == '|' && yardcount >= 3)
                        {
                            destGrid[x, y] = '#';
                        }

                        if (sourceGrid[x, y] == '#')
                        {
                            if (yardcount >= 1 && treecount >= 1) destGrid[x, y] = '#';
                            else destGrid[x, y] = '.';
                        }
                    }
                }

                // Determine the cycle size, taking a shortcut
                var state = sb.ToString();
                var idx = previousStates.IndexOf(state);
                if (idx >= 0)
                {
                    var cycleSize = i - idx;
                    var skipCount = (iterations - i) / cycleSize;
                    i += skipCount * cycleSize;
                    previousStates.Clear();
                }
                previousStates.Add(state);

                Array.Copy(destGrid, sourceGrid, sourceGrid.Length);
            }

            return sourceGrid.Cast<char>().Count(c => c == '|') * sourceGrid.Cast<char>().Count(c => c == '#');
        }
    }
}