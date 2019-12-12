using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day11 : BaseDay
    {
        private readonly int serialInput = 3463;

        public Day11() : base(2018, 11)
        {
        }

        public Day11(IEnumerable<string> inputLines) : base(2018, 11, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var serial = serialInput;
            var (coord, max) = CalculateHighestPower(3, serial);

            return $"{coord.x},{coord.y}";
        }

        protected override IConvertible PartTwo()
        {
            var serial = serialInput;

            var largestValue = -1;
            var optimalGridSize = -1;
            var optimalCoord = (x: -1, y: -1);

            for (int i = 3; i < 300; ++i)
            {
                var (coord, total) = CalculateHighestPower(i, 3463);

                if (total > largestValue)
                {
                    largestValue = total;
                    optimalGridSize = i;
                    optimalCoord = coord;
                }

                if (total == 0)
                {
                    break;
                }
            }

            return $"{optimalCoord.x},{optimalCoord.y},{optimalGridSize}";
        }

        private static ((int x, int y), int power) CalculateHighestPower(int gridSize, int serial)
        {
            int largestGridValue = 0;
            int yAtLargest = 0;
            int xAtLargest = 0;

            for (int y = 1; y < 300; y++)
            {
                for (int x = 1; x < 300; x++)
                {
                    var total = GetGridPower(x, y, gridSize, serial);

                    if (total > largestGridValue)
                    {
                        largestGridValue = total;
                        yAtLargest = y;
                        xAtLargest = x;
                    }
                }
            }

            return ((xAtLargest, yAtLargest), largestGridValue);
        }

        private static int GetGridPower(int x, int y, int size, int serial)
        {
            var total = 0;

            for (int innerY = 0; innerY < size; ++innerY)
            {
                for (int innerX = 0; innerX < size; ++innerX)
                {
                    total += PowerAtCoord(x + innerX, y + innerY, serial);
                }
            }

            return total;
        }

        private static int PowerAtCoord(int x, int y, int serial)
        {
            var rackId = x + 10;

            var powerLevel = rackId * y;
            powerLevel += serial;
            powerLevel *= rackId;
            powerLevel = (powerLevel / 100) % 10;

            return powerLevel - 5;
        }
    }
}