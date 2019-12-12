using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Helpers.Chronal
{
    public class ChronalDevice
    {
        private List<string> input = new List<string>();
        private int ipRegister = -1;
        private readonly bool useIpRegister = false;

        private readonly List<ChronalOperation> instructions;

        private static readonly List<ChronalOperation> chronalOperations = new List<ChronalOperation>()
        {
            new ChronalOperation(OpCode.ADDI, ChronalInstructionSet.ADDI),
            new ChronalOperation(OpCode.EQRR, ChronalInstructionSet.EQRR),
            new ChronalOperation(OpCode.BORR, ChronalInstructionSet.BORR),
            new ChronalOperation(OpCode.GTRI, ChronalInstructionSet.GTRI),
            new ChronalOperation(OpCode.ADDR, ChronalInstructionSet.ADDR),
            new ChronalOperation(OpCode.SETI, ChronalInstructionSet.SETI),
            new ChronalOperation(OpCode.MULI, ChronalInstructionSet.MULI),
            new ChronalOperation(OpCode.BANI, ChronalInstructionSet.BANI),
            new ChronalOperation(OpCode.BANR, ChronalInstructionSet.BANR),
            new ChronalOperation(OpCode.GTRR, ChronalInstructionSet.GTRR),
            new ChronalOperation(OpCode.SETR, ChronalInstructionSet.SETR),
            new ChronalOperation(OpCode.GTIR, ChronalInstructionSet.GTIR),
            new ChronalOperation(OpCode.BORI, ChronalInstructionSet.BORI),
            new ChronalOperation(OpCode.EQRI, ChronalInstructionSet.EQRI),
            new ChronalOperation(OpCode.EQIR, ChronalInstructionSet.EQIR),
            new ChronalOperation(OpCode.MULR, ChronalInstructionSet.MULR)
        };

        public ChronalDevice(List<string> input, bool useIpRegister)
        {
            this.input = input;
            this.useIpRegister = useIpRegister;
            instructions = ParseInput(this.input);
        }

        public static ChronalOperation Get(OpCode opCode) => chronalOperations.Single(i => i.OpCode == opCode);

        public(int lowest, int highest) DetermineUnderflowWindow(int[] registers, int watchRegister, int watchInstruction, bool getHighest)
        {
            var ip = 0;
            var seen = new HashSet<int>();
            int lastWatched = -1, lowest = -1, highest = -1;
            while (ip < instructions.Count)
            {
                registers[ipRegister] = ip;
                registers = ProcessInstruction(registers, registers[ipRegister]);

                if (ip == watchInstruction)
                {
                    var current = registers[watchRegister];
                    if (lastWatched == -1)
                    {
                        lowest = current;

                        if (!getHighest) { return (lowest, highest); }
                    }

                    if (seen.Contains(current)) { return (lowest, lastWatched); }
                    else
                    {
                        seen.Add(current);
                        lastWatched = current;
                    }
                }

                ip = registers[ipRegister];
                ip++;
            }

            return (lowest, highest);
        }

        public (int[] registers, int executedInstructionCount) Run(int[] registers) => useIpRegister ? RunWithInstructionPointer(registers) : RunWithoutInstructionPointer(registers);

        private (int[] registers, int executedInstructionCount) RunWithInstructionPointer(int[] registers)
        {
            var ip = 0;
            var count = 0;

            while (ip < instructions.Count)
            {
                registers[ipRegister] = ip;
                registers = ProcessInstruction(registers, registers[ipRegister]);

                ip = registers[ipRegister];
                ip++;
                count++;
            }

            registers[ipRegister] = ip;

            return (registers, count);
        }

        private (int[] registers, int executedInstructionCount) RunWithoutInstructionPointer(int[] registers)
        {
            var count = 0;

            foreach (var instruction in instructions)
            {
                registers = instruction.Execute(registers);
                count++;
            }

            return (registers, count);
        }

        private int[] ProcessInstruction(int[] registers, int instructionIndex) => instructions[instructionIndex].Execute(registers);

        private List<ChronalOperation> ParseInput(List<string> input)
        {
            var firstLine = true;

            var instructions = new List<ChronalOperation>();

            foreach (var inputLine in input)
            {
                if (firstLine && this.useIpRegister)
                {
                    ipRegister = int.Parse(inputLine.Split(' ')[1]);
                    firstLine = false;
                }
                else
                {
                    instructions.Add(ParseLine(inputLine));
                }
            }

            return instructions;
        }

        // Create specific implementations of the operations.
        private ChronalOperation ParseLine(string input)
        {
            var splitLine = input.Split(' ');
            var opCode = Enum.Parse<OpCode>(splitLine[0], true);
            var operation = Get(opCode).Operation;
            return new ChronalOperation(opCode, operation, int.Parse(splitLine[1]), int.Parse(splitLine[2]), int.Parse(splitLine[3]));
        }
    }
}