using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day09 : BaseDay
    {
        public Day09() : base(2016, 9)
        {
        }

        public Day09(IEnumerable<string> inputLines) : base(2016, 9, inputLines)
        {
        }

		protected override IConvertible PartOne() => Decompress(inputLines.Single(), false);

        protected override IConvertible PartTwo() => Decompress(inputLines.Single(), true);

		private static long Decompress(string input, bool recursive)
		{
			var charCount = 0L;
			var pos = 0;

			while (pos < input.Length)
			{
				var closingIndex = input.IndexOf(')', pos);
				var parameters = input.Substring(pos + 1, closingIndex - (pos + 1)).Split('x');

				var length = int.Parse(parameters[0]);

				var data = input.Substring(closingIndex + 1, length);
				long dataLength = data.Length;

				if (recursive && data.Contains('(') && data.Contains(')'))
				{
					dataLength = Decompress(data, true);
				}

				for (var r = 0; r < int.Parse(parameters[1]); r++)
				{
					charCount += dataLength;
				}

				pos = closingIndex + 1 + length;
			}

			return charCount;
		}
	}
}
