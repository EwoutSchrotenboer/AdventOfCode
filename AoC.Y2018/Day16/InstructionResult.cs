using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class InstructionResult
    {
        public int OpCode { get; set; }
        public int Input1 { get; set; }
        public int Input2 { get; set; }
        public int Output { get; set; }

        public InstructionResult(int opCode, int input1, int input2, int output)
        {
            OpCode = opCode;
            Input1 = input1;
            Input2 = input2;
            Output = output;
        }
    }
}
