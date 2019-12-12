using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.IntComputer
{
    public class Instruction
    {
        public long[] Memory { get; }
        public OpCode OpCode { get; }
        public long InstructionPointer { get; }
        public long RelativeBase { get; }
        public string Instr { get; }
        public ParamMode FirstMode { get; }
        public ParamMode SecondMode { get; }
        public ParamMode ThirdMode { get; }
        public long Input { get; set; }

        public Instruction(long[] memory, long instructionPointer, long relativeBase)
        {
            Instr = memory[instructionPointer].ToString("D5");

            InstructionPointer = instructionPointer;
            Memory = memory;
            OpCode = (OpCode)Instr.GetPart(3, 2);
            FirstMode = (ParamMode)Instr.GetPart(2, 1);
            SecondMode = (ParamMode)Instr.GetPart(1, 1);
            ThirdMode = (ParamMode)Instr.GetPart(0, 1);
            RelativeBase = relativeBase;
        }
    }
}
