using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Sample
    {
        public int[] Before { get; set; }
        public InstructionResult Instruction { get; set; }
        public int[] After { get; set; }

        public Sample(int[] before, InstructionResult instruction, int[] after)
        {
            Before = before;
            Instruction = instruction;
            After = after;
        }
    }
}
