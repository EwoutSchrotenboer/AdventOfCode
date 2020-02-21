using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2015.Days
{
    public class Day10 : BaseDay
    {
        public Day10() : base(2015, 10)
        {
        }

        public Day10(IEnumerable<string> inputLines) : base(2015, 10, inputLines)
        {
        }

		protected override IConvertible PartOne() => LookAndSay(inputLines.Single(), 40).Length;

        protected override IConvertible PartTwo() => LookAndSay(inputLines.Single(), 50).Length;

		private static string LookAndSay(string input, int count)
		{
			var current = input;

			for (int i = 0; i < count; i++)
			{
				var sb = new StringBuilder();

				var currentCount = 0;
				var currentChar = '0';

				foreach (var digit in current)
				{
					if (digit == currentChar) { currentCount++; }
					else
					{
						if (currentCount > 0) { sb.Append(currentCount).Append(currentChar); }

						currentChar = digit;
						currentCount = 1;
					}
				}

				if (currentCount > 0) { sb.Append(currentCount).Append(currentChar); }

				current = sb.ToString();
			}

			return current;
		}
	}
}
