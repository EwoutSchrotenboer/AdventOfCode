using System;

namespace AoC.Helpers.Chronal
{
    public static class ChronalInstructionSet
    {
        // (add register) stores into register C the result of adding register A and register B.
        public static readonly Func<int[], int, int, int> ADDR = (reg, a, b) => reg[a] + reg[b];

        // (add immediate) stores into register C the result of adding register A and value B.
        public static readonly Func<int[], int, int, int> ADDI = (reg, a, b) => reg[a] + b;

        // (multiply register) stores into register C the result of multiplying register A and register B.
        public static readonly Func<int[], int, int, int> MULR = (reg, a, b) => reg[a] * reg[b];

        // (multiply immediate) stores into register C the result of multiplying register A and value B.
        public static readonly Func<int[], int, int, int> MULI = (reg, a, b) => reg[a] * b;

        // (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
        public static readonly Func<int[], int, int, int> BANR = (reg, a, b) => reg[a] & reg[b];

        // (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
        public static readonly Func<int[], int, int, int> BANI = (reg, a, b) => reg[a] & b;

        // (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
        public static readonly Func<int[], int, int, int> BORR = (reg, a, b) => reg[a] | reg[b];

        // (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
        public static readonly Func<int[], int, int, int> BORI = (reg, a, b) => reg[a] | b;

        // (set register) copies the contents of register A into register C. (Input B is ignored.)
        public static readonly Func<int[], int, int, int> SETR = (reg, a, b) => reg[a];

        // (set immediate) stores value A into register C. (Input B is ignored.)
        public static readonly Func<int[], int, int, int> SETI = (reg, a, b) => a;

        // (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
        public static readonly Func<int[], int, int, int> GTIR = (reg, a, b) => a > reg[b] ? 1 : 0;

        // (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
        public static readonly Func<int[], int, int, int> GTRI = (reg, a, b) => reg[a] > b ? 1 : 0;

        // (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.
        public static readonly Func<int[], int, int, int> GTRR = (reg, a, b) => reg[a] > reg[b] ? 1 : 0;

        // (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
        public static readonly Func<int[], int, int, int> EQIR = (reg, a, b) => a == reg[b] ? 1 : 0;

        // (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
        public static readonly Func<int[], int, int, int> EQRI = (reg, a, b) => reg[a] == b ? 1 : 0;

        // (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
        public static readonly Func<int[], int, int, int> EQRR = (reg, a, b) => reg[a] == reg[b] ? 1 : 0;
    }

    public enum OpCode
    {
        ADDI,
        EQRR,
        BORR,
        GTRI,
        ADDR,
        SETI,
        MULI,
        BANI,
        BANR,
        GTRR,
        SETR,
        GTIR,
        BORI,
        EQRI,
        EQIR,
        MULR
    }
}
