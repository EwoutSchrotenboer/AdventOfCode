using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day13 : BaseDay
    {
        public Day13() : base(2015, 13)
        {
        }

        public Day13(IEnumerable<string> inputLines) : base(2015, 13, inputLines)
        {
        }

        protected override IConvertible PartOne() => DetermineBestScore(ParseInput(inputLines), false);

		protected override IConvertible PartTwo() => DetermineBestScore(ParseInput(inputLines), true);

		private static int DetermineBestScore(Dictionary<(string first, string second), int> relations, bool partTwo)
		{
			var names = relations.Select(r => r.Key.first).Distinct().ToList();

			if (partTwo)
			{
				foreach (var name in names)
				{
					relations.Add((name, "X"), 0);
					relations.Add(("X", name), 0);
				}

				names.Add("X");
			}

			var permutations = names.GetPermutations(names.Count());
			var bestScore = int.MinValue;

			// Pretty much brute force, might optimize later if I feel like it.
			foreach (var permutation in permutations)
			{
				var permutationScore = 0;
				var seating = permutation.ToList();
				var lastElementIndex = seating.Count() - 1;

				for (int i = 0; i < seating.Count(); i++)
				{
					permutationScore += relations[(seating[i], i == 0 ? seating[lastElementIndex] : seating[i - 1])];
					permutationScore += relations[(seating[i], i == lastElementIndex ? seating[0] : seating[i + 1])];
				}

				bestScore = Math.Max(bestScore, permutationScore);
			}

			return bestScore;
		}

		private static Dictionary<(string first, string second), int> ParseInput(IEnumerable<string> inputLines)
		{
			var relations = new Dictionary<(string, string), int>();

			var splitLines = inputLines.Select(l => l.Split(' '));

			foreach (var line in splitLines)
			{
				relations.Add((line[0], line[10].Replace(".", "")), int.Parse(line[3]) * (line[2] == "gain" ? 1 : -1));
			}

			return relations;
		}
	}
}
