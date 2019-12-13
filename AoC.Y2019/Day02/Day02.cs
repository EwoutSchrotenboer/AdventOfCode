using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day02 : BaseDay
    {
        public Day02(IEnumerable<string> input) : base(2019, 2, input)
        {
        }

        public Day02() : base(2019, 2)
        {
        }

        protected override IConvertible PartOne()
        {
            var computer = new Computer(inputLines.First());
            computer.SetAddress(1, 12);
            computer.SetAddress(2, 2);

            var (states, _) = computer.Run();

            return states.Last().Memory[0];
        }

        protected override IConvertible PartTwo()
        {
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var computer = new Computer(inputLines.First());
                    computer.SetAddress(1, noun);
                    computer.SetAddress(2, verb);

                    var (states, _) = computer.Run();

                    if (states.Last().Memory[0] == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return 0;
        }
    }
}