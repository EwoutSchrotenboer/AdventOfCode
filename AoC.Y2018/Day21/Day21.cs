using AoC.Helpers.Chronal;
using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day21 : BaseDay
    {
        public Day21() : base(2018, 21)
        {
        }

        public Day21(IEnumerable<string> inputLines) : base(2018, 21, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            // Register 3 and 0 are compared in instruction 29, this triggers the endpoint. First value is the lowest count, last value is the value before the first duplicate.
            var chronalDevice = new ChronalDevice(inputLines.ToList(), true);
            var (lowest, _) = chronalDevice.DetermineUnderflowWindow(new int[6], 3, 29, false);

            return lowest;
        }

        protected override IConvertible PartTwo()
        {
            // Register 3 and 0 are compared in instruction 29, this triggers the endpoint. First value is the lowest count, last value is the value before the first duplicate.
            var chronalDevice = new ChronalDevice(inputLines.ToList(), true);
            var (_, highest) = chronalDevice.DetermineUnderflowWindow(new int[6], 3, 29, true);

            return highest;
        }
    }
}