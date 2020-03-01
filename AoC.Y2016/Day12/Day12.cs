using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day12 : BaseDay
    {
        public Day12() : base(2016, 12)
        {
        }

        public Day12(IEnumerable<string> inputLines) : base(2016, 12, inputLines)
        {
        }

        protected override IConvertible PartOne() => RunProgram(ParseInput(inputLines), 0);

        protected override IConvertible PartTwo() => RunProgram(ParseInput(inputLines), 1);

        private static int RunProgram(List<BunnyInstruction> instructions, int registerCValue)
        {
            var registers = new int[] { 0, 0, registerCValue, 0 };
            var instructionPointer = 0;

            while (instructionPointer >= 0 && instructionPointer < instructions.Count)
            {
                var instruction = instructions[instructionPointer];

                switch (instruction.Name)
                {
                    case "cpy":
                        registers[instruction.B] = instruction.AIsReg ? registers[instruction.A] : instruction.A;
                        break;
                    case "inc":
                        registers[instruction.A] += 1;
                        break;
                    case "dec":
                        registers[instruction.A] -= 1;
                        break;
                    case "jnz":
                        if ((instruction.AIsReg ? registers[instruction.A] : instruction.A) != 0)
                        {
                            instructionPointer += instruction.BIsReg ? registers[instruction.B] : instruction.B;
                            continue;
                        }
                        break;
                }

                instructionPointer++;
            }

            return registers[0];
        }

        private static List<BunnyInstruction> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(i => new BunnyInstruction(i)).ToList();
    }
}
