using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using AoC.Helpers.Chronal;

namespace AoC.Y2018.Days
{
    public class Day19 : BaseDay
    {
        public Day19() : base(2018, 19)
        {
        }

        public Day19(IEnumerable<string> inputLines) : base(2018, 19, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var registers = new int[6];
            var chronalDevice = new ChronalDevice(inputLines.ToList(), true);
            var (output, _) = chronalDevice.Run(registers);

            return output[0];
        }

        protected override IConvertible PartTwo()
        {
            // instructions 3-6 and 8-11 were called a lot, figured out the logic for that:
            // while R5 <= R4
            // if (R3 * R5 == R4) => Execute 7, jump out -> R5 gets added to R0
            // if (R3 * R5 != R4) => Continue loop
            // R4 = 10551370 (checked by stopping at a breakpoint after 10k loops

            var reg0 = 0;
            var reg4 = 10551370;

            for (int reg5 = 1; reg5 <= reg4; reg5++)
            {
                if (reg4 % reg5 == 0) reg0 += reg5;
            }

            return reg0;
        }
    }
}