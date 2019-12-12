using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.IntComputer
{
    public class Response
    {
        public long[] Memory { get; }
        public long NextInstructionPointer { get; }
        public long NextRelativeBase { get; }
        public bool Halt { get; }
        public long? Value { get; }
        public bool BreakProcess { get; }
        public Response(long[] memory, long nextIp, long nextRelBase, bool halt, long? value, bool breakProcess = false)
        {
            Memory = memory;
            NextInstructionPointer = nextIp;
            NextRelativeBase = nextRelBase;
            Halt = halt;
            Value = value;
            BreakProcess = breakProcess;
        }
    }
}
