using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day05 : BaseDay
    {
        public Day05() : base(2019, 5)
        {
        }

        public Day05(IEnumerable<string> inputLines) : base(2019, 5, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var program = inputLines.First();
            return GetDiagnosticOutput(program, 1);
        }

        protected override IConvertible PartTwo()
        {
            var program = inputLines.First();
            return GetDiagnosticOutput(program, 5);
        }

        private static long GetDiagnosticOutput(string program, long input)
        {          
            var computer = new Computer(program, input);

            var (_, outputs) = computer.Run();

            return outputs.Last();
        }
    }
}