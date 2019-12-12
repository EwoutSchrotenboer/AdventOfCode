using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.Chronal
{
    public class ChronalOperation
    {
        public OpCode OpCode { get; }
        public Func<int[], int, int, int> Operation { get; }
        private readonly int a = -1;
        private readonly int b = -1;
        private readonly int c = -1;

        public ChronalOperation(OpCode opCode, Func<int[], int, int, int> operation, int a, int b, int c) 
        {
            this.a = a;
            this.b = b;
            this.c = c;
            OpCode = opCode;
            Operation = operation;
        }

        public ChronalOperation(OpCode opCode, Func<int[], int, int, int> operation)
        {
            OpCode = opCode;
            Operation = operation;
        }

        public int[] Execute(int[] registers) => Execute(registers, this.a, this.b, this.c);

        public int[] Execute(int[] registers, int a, int b, int c)
        {
            var updatedRegisters = new int[registers.Length];
            registers.CopyTo(updatedRegisters, 0);
            updatedRegisters[c] = Operation(registers, a, b);
            return updatedRegisters;
        } 
    }
}
