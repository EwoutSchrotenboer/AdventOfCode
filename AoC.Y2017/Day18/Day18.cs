using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day18 : BaseDay
    {
        public Day18() : base(2017, 18)
        {
        }

        public Day18(IEnumerable<string> inputLines) : base(2017, 18, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var program = inputLines.Select(l => new DuetInstruction(l)).ToList();
            var assembler = new Assembler(0, program, false);
            assembler.Run();
            return assembler.Output.Dequeue();
        }

        protected override IConvertible PartTwo()
        {
            var program = inputLines.Select(l => new DuetInstruction(l)).ToList();
            var a = new Assembler(0, program, true);
            var b = new Assembler(1, program, true);
            a.Output = b.Input;
            b.Output = a.Input;

            while (true)
            {
                a.Run();
                b.Run();

                if (!a.Input.Any() && !b.Input.Any())
                {
                    return b.ValuesSent;
                }
            }
        }
    }
}
