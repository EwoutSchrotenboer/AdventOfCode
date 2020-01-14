using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day06 : BaseDay
    {
        public Day06() : base(2015, 6)
        {
        }

        public Day06(IEnumerable<string> inputLines) : base(2015, 6, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var instructions = ParseInput(inputLines);
            return ExecuteInstructions(instructions, true);
        }

        protected override IConvertible PartTwo()
        {
            var instructions = ParseInput(inputLines);
            return ExecuteInstructions(instructions, false);
        }

        private static int ExecuteInstructions(List<LightingInstruction> instructions, bool partOne)
        {
            var lights = new int[1000, 1000];

            foreach (var instruction in instructions)
            {
                for (var xPos = instruction.Origin.X; xPos <= instruction.End.X; xPos++)
                {
                    for (var yPos = instruction.Origin.Y; yPos <= instruction.End.Y; yPos++)
                    {
                        lights[xPos, yPos] = ExecuteInstruction(lights[xPos, yPos], instruction.Switch, partOne);
                    }
                }
            }

            return lights.Cast<int>().Sum();
        }

        private static int ExecuteInstruction(int current, Switch change, bool partOne) => partOne ? FirstInstructionSet(current, change) : SecondInstructionSet(current, change);

        private static int FirstInstructionSet(int current, Switch change) =>
            change switch
            {
                Switch.Off => 0,
                Switch.On => 1,
                Switch.Toggle => current != 0 ? 0 : 1,
                _ => throw new NotSupportedException("Off, On and Toggle are the only supported values.")
            };

        private static int SecondInstructionSet(int current, Switch change) =>
            change switch
            {
                Switch.Off => current > 0 ? current - 1 : 0,
                Switch.On => current + 1,
                Switch.Toggle => current + 2,
                _ => throw new NotSupportedException("Off, On and Toggle are the only supported values.")
            };

        private static List<LightingInstruction> ParseInput(IEnumerable<string> inputLines)
        {
            var instructions = new List<LightingInstruction>();

            foreach (var inputLine in inputLines)
            {
                var split = inputLine.Split(" ");
                if (split.Length == 5) { split = split.Skip(1).ToArray(); }

                var origin = split[1].Split(",").Select(x => int.Parse(x)).ToList();
                var end = split[3].Split(",").Select(x => int.Parse(x)).ToList();

                instructions.Add(new LightingInstruction(origin[0], origin[1], end[0], end[1], split[0]));
            }

            return instructions;
        }
    }
}
