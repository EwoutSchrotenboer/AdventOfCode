using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day19 : BaseDay
    {
        public Day19() : base(2019, 19)
        {
        }

        public Day19(IEnumerable<string> inputLines) : base(2019, 19, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            return GetTractorBeamAffected(inputLines.Single(), 50);
        }

        protected override IConvertible PartTwo()
        {
            return FirstPositionForSquare(inputLines.Single(), 100);
        }

        private static int FirstPositionForSquare(string program, int size)
        {
            var x = 25;
            var y = 0;

            while (true)
            {
                if (InTractorBeam(program, x, y))
                {
                    if (InTractorBeam(program, x - (size - 1), y + (size - 1)))
                    {
                        return 10000 * (x - (size - 1)) + y;
                    }

                    x++;
                }
                else
                {
                    y++;
                }
            }
        }

        private static int GetTractorBeamAffected(string program, int range)
        {
            var sum = 0;

            for (int yPos = 0; yPos < range; yPos++)
            {
                for (int xPos = 0; xPos < range; xPos++)
                {
                    if (InTractorBeam(program, xPos, yPos)) { sum++; }
                }
            }

            return sum;
        }

        private static bool InTractorBeam(string program, int x, int y)
        {
            var drone = new Computer(program, new int[] { x, y });
            var (_, outputs) = drone.Run();
            return outputs.Last() == 1;
        }
    }
}
