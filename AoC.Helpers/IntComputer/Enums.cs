using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.IntComputer
{
    public enum OpCode
    {
        ADD = 1,
        MUL = 2,
        SET = 3,
        GET = 4,
        JIT = 5,
        JIF = 6,
        LT = 7,
        EQ = 8,
        REL = 9,
        EXIT = 99
    }

    public enum ParamMode
    {
        Position,
        Immediate,
        Relative
    }
}
