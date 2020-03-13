using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day08 : BaseDay
    {
        public Day08() : base(2017, 8)
        {
        }

        public Day08(IEnumerable<string> inputLines) : base(2017, 8, inputLines)
        {
        }

        protected override IConvertible PartOne() => RunProgram(inputLines).largest;

        protected override IConvertible PartTwo() => RunProgram(inputLines).allStatesLargest;

        private static bool EvaluateCondition(int registerValue, string comparator, int value) =>
            comparator switch
            {
                "==" => registerValue == value,
                "!=" => registerValue != value,
                "<" => registerValue < value,
                "<=" => registerValue <= value,
                ">" => registerValue > value,
                ">=" => registerValue >= value,
                _ => throw new Exception($"Invalid comparator: {comparator}")
            };

        private static (Dictionary<string, int> registers, List<UnusualInstruction> instructions) ParseInput(IEnumerable<string> inputLines)
        {
            var registers = new Dictionary<string, int>();
            var instructions = new List<UnusualInstruction>();

            foreach (var line in inputLines)
            {
                var items = line.Split(' ');

                registers.TryAdd(items[0], 0);
                registers.TryAdd(items[4], 0);

                instructions.Add(new UnusualInstruction(line));
            }

            return (registers, instructions);
        }

        private static (int largest, int allStatesLargest) RunProgram(IEnumerable<string> inputLines)
        {
            var (registers, instructions) = ParseInput(inputLines);

            var highestValue = 0;

            foreach (var i in instructions)
            {
                if (EvaluateCondition(registers[i.ComparisonRegister], i.Comparator, i.ComparisonValue))
                {
                    if (i.Increase)
                    {
                        registers[i.Register] += i.Value;
                    }
                    else
                    {
                        registers[i.Register] -= i.Value;
                    }
                }

                highestValue = Math.Max(highestValue, registers.Values.Max());
            }

            return (registers.Values.Max(), highestValue);
        }
    }
}
