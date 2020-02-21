using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day24 : BaseDay
    {
        public Day24() : base(2015, 24)
        {
        }

        public Day24(IEnumerable<string> inputLines) : base(2015, 24, inputLines)
        {
        }

		protected override IConvertible PartOne() => BalancePackages(ParseInput(inputLines), 3);

		protected override IConvertible PartTwo() => BalancePackages(ParseInput(inputLines), 4);

		private static long BalancePackages(List<int> packages, int containers)
		{
			var space = packages.Sum() / containers;
			var containerCombinations = new List<List<long>>();

			for (int i = 0; i < packages.Count(); i++)
			{
				var set = packages.Where((p, pi) => pi != i).Select(p => p).ToList();

				var (match, combination) = GetCombination(set, space);

				if (match)
				{
					containerCombinations.Add(combination);
				}
			}

			var products = new List<long>();
			var minCount = containerCombinations.Min(c => c.Count());

			foreach (var combination in containerCombinations.Where(c => c.Count() == minCount))
			{
				products.Add(combination.Aggregate((product, item) => product *= item));
			}

			return products.Min();
		}

		private static (bool fit, List<long> packages) GetCombination(List<int> packages, int target)
		{
			var container = new List<long>();

			while (target - container.Sum() > 0)
			{
				var fittingPackages = packages.Where(p => p <= target - container.Sum());

				if (!fittingPackages.Any())
				{
					return (false, container);
				}

				var fittingPackage = fittingPackages.OrderByDescending(p => p).First();
				container.Add(fittingPackage);
				packages.Remove(fittingPackage);
			}

			return (true, container);
		}

		private static List<int> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(l => int.Parse(l)).ToList();
	}
}
