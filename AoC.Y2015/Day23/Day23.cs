using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day23 : BaseDay
    {
        public Day23() : base(2015, 23)
        {
        }

        public Day23(IEnumerable<string> inputLines) : base(2015, 23, inputLines)
        {
        }

		protected override IConvertible PartOne() => RunProgram(ParseInput(inputLines), 0);

        protected override IConvertible PartTwo() => RunProgram(ParseInput(inputLines), 1);

		private static int RunProgram(List<(string name, int reg, int val)> instructions, int input)
		{
			var registers = new int[2] { input, 0 };
			var ip = 0;

			while (ip >= 0 && ip < instructions.Count())
			{
				var (name, reg, val) = instructions[ip];
				switch (name)
				{
					case "hlf": registers[reg] /= 2; ip++; break;
					case "tpl": registers[reg] *= 3; ip++; break;
					case "inc": registers[reg]++; ip++; break;
					case "jmp": ip += val; break;
					case "jie": ip += registers[reg] % 2 == 0 ? val : 1; break;
					case "jio": ip += registers[reg] == 1 ? val : 1; break;
				}
			}

			return registers[1];
		}

		private static List<(string name, int reg, int val)> ParseInput(IEnumerable<string> inputLines)
		{
			var instructions = new List<(string, int, int)>();

			foreach (var line in inputLines)
			{
				var items = line.Replace(",", "").Split(' ');
				switch (items[0])
				{
					case "jmp":
						instructions.Add((items[0], -1, int.Parse(items[1])));
						break;
					case "jie":
					case "jio":
						instructions.Add((items[0], items[1] == "a" ? 0 : 1, int.Parse(items[2])));
						break;
					default:
						instructions.Add((items[0], items[1] == "a" ? 0 : 1, -1));
						break;
				}
			}

			return instructions;
		}
	}
}
