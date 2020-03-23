using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    internal class Coprocessor
    {
        private readonly Dictionary<string, int> registers = new Dictionary<string, int>()
        {
            ["a"] = 0,
            ["b"] = 0,
            ["c"] = 0,
            ["d"] = 0,
            ["e"] = 0,
            ["f"] = 0,
            ["g"] = 0,
            ["h"] = 0
        };

        private int instructionPointer = 0;
        private List<CoInstruction> program;
        public int MulInvoked { get; set; }

        public Coprocessor(List<CoInstruction> program, bool debugMode)
        {
            this.program = program;

            if (!debugMode)
            {
                registers["a"] = 1;
            }
        }

        public int GetRegisterValue(string register) => registers[register];

        // Running
        public void Run()
        {
            while (instructionPointer >= 0 && instructionPointer < program.Count())
            {
                Execute(program[instructionPointer]);
            }
        }

        private void Execute(CoInstruction instruction)
        {
            switch (instruction.Name)
            {
                case "set": Set(instruction); break;
                case "sub": Subtract(instruction); break;
                case "mul": Multiply(instruction); MulInvoked++; break;
                case "jnz": JumpNotZero(instruction); return;
                default: break;
            }

            instructionPointer++;
        }

        private int GetValue(string a)
        {
            if (!int.TryParse(a, out var value)) { value = registers[a]; }
            return value;
        }

        private void JumpNotZero(CoInstruction instruction) => instructionPointer += (GetValue(instruction.A) != 0 ? (int)GetValue(instruction.B) : 1);

        private void Multiply(CoInstruction instruction) => registers[instruction.A] *= GetValue(instruction.B);

        private void Set(CoInstruction instruction) => registers[instruction.A] = GetValue(instruction.B);

        private void Subtract(CoInstruction instruction) => registers[instruction.A] -= GetValue(instruction.B);
    }
}
