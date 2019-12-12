using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    public static class Instructions
    {
        // (add register) stores into register C the result of adding register A and register B.
        public static Func<int[], int, int, int> AddR = (reg, a, b) => reg[a] + reg[b];
        // (add immediate) stores into register C the result of adding register A and value B.
        public static Func<int[], int, int, int> AddI = (reg, a, b) => reg[a] + b;
        // (multiply register) stores into register C the result of multiplying register A and register B.
        public static Func<int[], int, int, int> MulR = (reg, a, b) => reg[a] * reg[b];
        // (multiply immediate) stores into register C the result of multiplying register A and value B.
        public static Func<int[], int, int, int> MulI = (reg, a, b) => reg[a] * b;
        // (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
        public static Func<int[], int, int, int> BanR = (reg, a, b) => reg[a] & reg[b];
        // (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
        public static Func<int[], int, int, int> BanI = (reg, a, b) => reg[a] & b;
        // (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
        public static Func<int[], int, int, int> BorR = (reg, a, b) => reg[a] | reg[b];
        // (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
        public static Func<int[], int, int, int> BorI = (reg, a, b) => reg[a] | b;
        // (set register) copies the contents of register A into register C. (Input B is ignored.)
        public static Func<int[], int, int, int> SetR = (reg, a, b) => reg[a];
        // (set immediate) stores value A into register C. (Input B is ignored.)
        public static Func<int[], int, int, int> SetI = (reg, a, b) => a;
        // (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
        public static Func<int[], int, int, int> GtIR = (reg, a, b) => a > reg[b] ? 1 : 0;
        // (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
        public static Func<int[], int, int, int> GtRI = (reg, a, b) => reg[a] > b ? 1 : 0;
        // (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.
        public static Func<int[], int, int, int> GtRR = (reg, a, b) => reg[a] > reg[b] ? 1 : 0;
        // (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
        public static Func<int[], int, int, int> EqIR = (reg, a, b) => a == reg[b] ? 1 : 0;
        // (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
        public static Func<int[], int, int, int> EqRI = (reg, a, b) => reg[a] == b ? 1 : 0;
        // (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
        public static Func<int[], int, int, int> EqRR = (reg, a, b) => reg[a] == reg[b] ? 1 : 0;

        public static Dictionary<string, Func<int[], int, int, int>> GetInstructionDictionary()
        {
            var dict = new Dictionary<string, Func<int[], int, int, int>>();

            dict.Add("AddR", AddR);
            dict.Add("AddI", AddI);
            dict.Add("MulR", MulR);
            dict.Add("MulI", MulI);
            dict.Add("BanR", BanR);
            dict.Add("BanI", BanI);
            dict.Add("BorR", BorR);
            dict.Add("BorI", BorI);
            dict.Add("SetR", SetR);
            dict.Add("SetI", SetI);
            dict.Add("GtIR", GtIR);
            dict.Add("GtRI", GtRI);
            dict.Add("GtRR", GtRR);
            dict.Add("EqIR", EqIR);
            dict.Add("EqRI", EqRI);
            dict.Add("EqRR", EqRR);

            return dict;
        }
    }
}
