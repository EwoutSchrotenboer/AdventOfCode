using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.IntComputer
{
    public class State
    {
        public long[] Memory { get; }
        public OpCode OpCode { get; }
        public long InstructionPointer { get; }
        public long RelativeBase { get; }
        public string Instruction { get; }

        public State(long[] memory, OpCode opCode, long instructionPointer, long relativeBase, string instruction)
        {
            Memory = memory;
            OpCode = opCode;
            InstructionPointer = instructionPointer;
            RelativeBase = relativeBase;
            Instruction = instruction;
        }
    }
}
