using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day09 : BaseDay
    {
        public Day09() : base(2019, 9)
        {

        }

        public Day09(IEnumerable<string> inputLines) : base(2019, 9, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var program = inputLines.First();
            var computer = new Computer(program, 1);
            var (_, outputs) = computer.Run();

            return outputs.Last();
        }

        protected override IConvertible PartTwo()
        {
            var program = inputLines.First();
            var computer = new Computer(program, 2);
            var (_, outputs) = computer.Run();

            return outputs.Last();
        }
    }
}