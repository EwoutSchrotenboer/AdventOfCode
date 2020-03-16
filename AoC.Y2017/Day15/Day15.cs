using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
	public class Day15 : BaseDay
    {
		public Day15() : base(2017, 15)
        {
        }

        public Day15(IEnumerable<string> inputLines) : base(2017, 15, inputLines)
        {
        }

        protected override IConvertible PartOne()
		{
			var (a, b) = ParseInput(inputLines);
			return GetScore(a, b, 40_000_000, false);
		}

		protected override IConvertible PartTwo()
		{
			{
				var (a, b) = ParseInput(inputLines);
				return GetScore(a, b, 40_000_000, true);
			}
		}

		private static int GetScore(Generator a, Generator b, int cycles, bool partTwo)
		{
			var score = 0;
			var aValues = a.CalculateSet(cycles, partTwo);
			var bValues = b.CalculateSet(cycles, partTwo);
			var shortest = Math.Min(aValues.Count(), bValues.Count());

			for (int i = 0; i < shortest; i++)
			{
				score += JudgeValues(aValues[i], bValues[i]) ? 1 : 0;
			}

			return score;
		}

		private static bool JudgeValues(ulong valueA, ulong valueB) => (valueA & 0b1111_1111_1111_1111) == (valueB & 0b1111_1111_1111_1111);

		private static (Generator A, Generator B) ParseInput(IEnumerable<string> inputLines)
		{
			var startA = ulong.Parse(inputLines.First().Split(' ')[4]);
			var startB = ulong.Parse(inputLines.Last().Split(' ')[4]);

			return (new Generator(16807, startA, 4), new Generator(48271, startB, 8));
		}
	}
}
