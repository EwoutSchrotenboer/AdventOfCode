using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using static AoC.Y2018.Days.Instructions;

namespace AoC.Y2018.Days
{
    public class Day16 : BaseDay
    {
        public Day16() : base(2018, 16)
        {
        }

        public Day16(IEnumerable<string> inputLines) : base(2018, 16, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (part1Input, _) = ParseInput(inputLines.ToList());

            var (threeOrMore, _) = AnalyzeInputs(part1Input);

            return threeOrMore;
        }

        protected override IConvertible PartTwo()
        {
            var (part1Input, part2Input) = ParseInput(inputLines.ToList());

            var (_, opCodes) = AnalyzeInputs(part1Input);
            var opCodeDict = DetermineOpCodes(opCodes);

            var result = ExecuteTestProgram(opCodeDict, part2Input);

            return result[0];
        }

        private int[] ExecuteTestProgram(Dictionary<int, Func<int[], int, int, int>> opCodeDict, List<int[]> part2Input)
        {
            var arr = new int[] { 0, 0, 0, 0 };

            foreach (var parameters in part2Input)
            {
                arr = ExecuteInstruction(arr, parameters[1], parameters[2], parameters[3], opCodeDict[parameters[0]]);
            }

            return arr;
        }

        private Dictionary<int, Func<int[], int, int, int>> DetermineOpCodes(Dictionary<int, List<string>> opCodes)
        {
            var opcodeList = new List<(int, string)>();
            var keysToRemove = new List<int>();

            while (opCodes.Any())
            {
                foreach (var opCode in opCodes)
                {
                    var distinct = opCode.Value.Distinct();
                    if (distinct.Count() == 1)
                    {
                        var first = distinct.Single();
                        opcodeList.Add((opCode.Key, first));

                        foreach (var cleanup in opCodes)
                        {
                            if (cleanup.Value.Contains(first))
                            {
                                cleanup.Value.Remove(first);
                            }
                        }

                        keysToRemove.Add(opCode.Key);
                    }
                }

                foreach (var k in keysToRemove)
                {
                    opCodes.Remove(k);
                }
            }

            var finalDict = new Dictionary<int, Func<int[], int, int, int>>();
            var dict = GetInstructionDictionary();

            foreach (var opCodeItem in opcodeList)
            {
                finalDict.Add(opCodeItem.Item1, dict[opCodeItem.Item2]);
            }

            return finalDict;
        }

        private (int threeOrMore, Dictionary<int, List<string>> opCodes) AnalyzeInputs(List<Sample> inputs)
        {
            var opCodes = new Dictionary<int, List<string>>();

            var instructionDictionary = GetInstructionDictionary();
            var matchedInstructions = new List<InstructionResult>();
            var matchesThreeOrMore = 0;

            foreach (var input in inputs)
            {
                var matches = 0;

                var before = input.Before;
                var instr = input.Instruction;
                var after = input.After;

                foreach (var instruction in instructionDictionary)
                {

                    var instructionResult = ExecuteInstruction(before, instr.Input1, instr.Input2, instr.Output, instruction.Value);

                    if (instructionResult[0] == after[0]
                    && instructionResult[1] == after[1]
                    && instructionResult[2] == after[2]
                    && instructionResult[3] == after[3])
                    {
                        if (!opCodes.Keys.Contains(instr.OpCode))
                        {
                            opCodes.Add(instr.OpCode, new List<string>());
                        }

                        if (!opCodes[instr.OpCode].Contains(instruction.Key))
                        {
                            opCodes[instr.OpCode].Add(instruction.Key);
                        }


                        matches++;
                    }
                }

                if (matches >= 3 && !matchedInstructions.Contains(instr))
                {
                    matchesThreeOrMore++;
                    matchedInstructions.Add(instr);
                }
            }

            return (matchesThreeOrMore, opCodes);
        }

        private (List<Sample>, List<int[]>) ParseInput(List<string> inputLines)
        {
            var sampleList = new List<Sample>();

            for (int firstIndex = 0; firstIndex < inputLines.Count; firstIndex += 3)
            {
                var beforeLine = inputLines[firstIndex];
                var instructionLine = inputLines[firstIndex + 1];
                var afterLine = inputLines[firstIndex + 2];

                if (!beforeLine.StartsWith("Before"))
                {
                    break;
                }

                var parsedBefore = ParseRegisters(beforeLine);
                var parsedInstruction = ParseInstruction(instructionLine);
                var parsedAfter = ParseRegisters(afterLine);

                sampleList.Add(new Sample(parsedBefore, parsedInstruction, parsedAfter));
            }

            var startIndex = sampleList.Count * 3;
            var instructionList = new List<int[]>();

            for (int secondIndex = startIndex; secondIndex < inputLines.Count; secondIndex++)
            {
                var line = inputLines[secondIndex];

                var items = line.Split(' ');
                instructionList.Add(new int[] { int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), int.Parse(items[3]) });
            }
        

            return (sampleList, instructionList);
        }

        private int[] ParseRegisters(string registerString)
        {
            var registerList = new List<int>();
            var startPoint = registerString.IndexOf('[');
            var endPoint = registerString.IndexOf(']');

            var registerSubString = registerString.Substring(startPoint + 1, endPoint - startPoint - 1);

            var splitNumbers = registerSubString.Split(',');

            foreach (var splitNumber in splitNumbers)
            {
                registerList.Add(int.Parse(splitNumber.Trim()));
            }

            return registerList.ToArray();
        }

        private InstructionResult ParseInstruction(string instructionLine)
        {
            var items = instructionLine.Split(' ');

            return new InstructionResult(int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]), int.Parse(items[3]));
        }

        private static int[] ExecuteInstruction(int[] register, int a, int b, int c, Func<int[], int, int, int> instruction)
        {
            var newRegister = new int[4];
            register.CopyTo(newRegister, 0);
            newRegister[c] = instruction(register, a, b);
            return newRegister;
        }
    }
}