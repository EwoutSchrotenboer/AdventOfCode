using AoC.Helpers.Days;
using AoC.Helpers.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day01 : BaseDay
    {
        public Day01() : base(2019, 1) { }

        protected override IConvertible PartOne() => ParseInput(inputLines).Sum(m => (m / 3) - 2);

        protected override IConvertible PartTwo() => ParseInput(inputLines).Sum(m => AddModuleFuel(m));

        private static int AddModuleFuel(int module)
        {
            var currentFuel = module / 3 - 2;
            var totalFuel = currentFuel;

            while (currentFuel > 0)
            {
                var fuelForFuel = currentFuel / 3 - 2;

                if (fuelForFuel > 0)
                {
                    totalFuel += fuelForFuel;
                }

                currentFuel = fuelForFuel;
            }

            return totalFuel;            
        }

        private IEnumerable<int> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(i => int.Parse(i));
    }
}
