using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day04 : BaseDay
    {
        public Day04() : base(2017, 4)
        {
        }

        public Day04(IEnumerable<string> inputLines) : base(2017, 4, inputLines)
        {
        }

        protected override IConvertible PartOne() => inputLines.Count(i => WordsAreUnique(i));

        protected override IConvertible PartTwo() => inputLines.Count(i => WordsAreUnique(i) && PhraseContainsNoAnagrams(i));

		private static bool WordsAreUnique(string input) => input.Split(' ').Count() == input.Split(' ').Distinct().Count();
		
		private static bool PhraseContainsNoAnagrams(string input)
		{
			var items = input.Split(' ').Select(i => i.ToCharArray().OrderBy(c => c)).ToList();

			for (int i = 0; i < items.Count() - 1; i++)
			{
				for (int j = i + 1; j < items.Count(); j++)
				{
					if (items[i].SequenceEqual(items[j]))
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
