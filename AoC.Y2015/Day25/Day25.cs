using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day25 : BaseDay
    {
        public Day25() : base(2015, 25)
        {
        }

        public Day25(IEnumerable<string> inputLines) : base(2015, 25, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (row, column) = ParseInput(inputLines);
            return CalculateCode(row, column);
        }

        protected override IConvertible PartTwo() => "Merry christmas!";

        private static long CalculateCode(int rowTarget, int columnTarget)
        {
            int col = 1, row = 1, count = 1;
            var num = 20151125L;

            while (true)
            {
                for (int innerIndex = 1; innerIndex <= count; innerIndex++)
                {
                    if (row == rowTarget && col == columnTarget)
                    {
                        return num;
                    }

                    num = ((num * 252533) % 33554393);
                    col++; row--;
                }

                count++;
                col = 1;
                row = count;
            }
        }

        private static (int row, int column) ParseInput(IEnumerable<string> inputLines)
        {
            var items = inputLines.Single().Split(' ');
            var column = items[^1].Replace(".", string.Empty);
            var row = items[^3].Replace(",", string.Empty);
            return (int.Parse(row), int.Parse(column));
        }
    }
}
