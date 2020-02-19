using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day20 : BaseDay
    {
        public Day20() : base(2015, 20)
        {
        }

        public Day20(IEnumerable<string> inputLines) : base(2015, 20, inputLines)
        {
        }

        protected override IConvertible PartOne() => DetermineHouse(int.Parse(inputLines.Single()), false);

        protected override IConvertible PartTwo() => DetermineHouse(int.Parse(inputLines.Single()), true);

        private static int DetermineHouse(int giftLimit, bool partTwo)
        {
            var gifts = 0;
            var house = 0;

            // Get general area, then finetune
            while (gifts < giftLimit)
            {
                house += 20;
                gifts = GetGiftCount(house, partTwo);
            }

            house -= 20;
            gifts = 0;

            while (gifts < giftLimit)
            {
                house++;
                gifts = GetGiftCount(house, partTwo);
            }

            return house;
        }

        private static int GetGiftCount(int house, bool partTwo)
        {
            var gifts = 0;
            var max = (int)Math.Sqrt(house);
            for (int elf = 1; elf <= max; elf++)
            {
                if (house % elf == 0)
                {
                    if (house % elf != elf)
                    {
                        var otherElf = house / elf;

                        if (!partTwo || house / 50 <= otherElf)
                        {
                            gifts += otherElf * (partTwo ? 11 : 10);
                        }
                    }
                    if (!partTwo || house / 50 <= elf)
                    {
                        gifts += elf * (partTwo ? 11 : 10);
                    }
                }

            }

            return gifts;
        }
    }
}
