using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day16 : BaseDay
    {
        public Day16() : base(2016, 16)
        {
        }

        public Day16(IEnumerable<string> inputLines) : base(2016, 16, inputLines)
        {
        }

		protected override IConvertible PartOne() => CalculateChecksum(ParseInput(inputLines), 272);


		protected override IConvertible PartTwo() => CalculateChecksum(ParseInput(inputLines), 35651584);

		private static string CalculateChecksum(bool[] input, int requiredLength)
		{
			var data = input;

			while (data.Length < requiredLength)
			{
				data = NextDragon(data);
			}

			var truncatedData = data.Take(requiredLength).ToArray();

			return GetChecksum(truncatedData);
		}

		private static string GetChecksum(bool[] data)
		{
			while (true)
			{
				var checkSum = new List<bool>();

				for (int i = 0; i < data.Length - 1; i += 2)
				{
					checkSum.Add(data[i] == data[i + 1]);
				}

				if (checkSum.Count() % 2 != 0)
				{
					return new string(checkSum.Select(s => s ? '1' : '0').ToArray());
				}

				data = checkSum.ToArray();
			}
		}

		private static bool[] NextDragon(bool[] current)
		{
			var next = new bool[current.Length * 2 + 1];

			current.CopyTo(next, 0);
			next[current.Length] = false;
			var reversed = current.Reverse();
			var reversedInversed = reversed.Select(i => !i).ToArray();
			reversedInversed.CopyTo(next, current.Length + 1);

			return next;
		}

		bool[] ParseInput(IEnumerable<string> inputLines) => inputLines.Single().Select(i => i == '1').ToArray();
    }
}
