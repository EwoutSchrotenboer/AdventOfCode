using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day21 : BaseDay
    {
        public Day21() : base(2016, 21)
        {
        }

        public Day21(IEnumerable<string> inputLines) : base(2016, 21, inputLines)
        {
        }

        protected override IConvertible PartOne() => Scramble("abcdefgh", inputLines.ToList(), false);

		protected override IConvertible PartTwo() => Scramble("fbgdceah", inputLines.ToList(), true);

		private static string Scramble(string input, List<string> scrambleList, bool inverse)
		{
			var current = input.ToCharArray();

			if (inverse)
			{
				scrambleList.Reverse();
			}

			foreach (var scrambleInstruction in scrambleList)
			{
				current = Execute(current, scrambleInstruction.Split(' '), inverse);
			}

			return new string(current);
		}

		private static char[] Execute(char[] input, string[] scrambleItems, bool inverse) =>
			(scrambleItems[0], scrambleItems[1]) switch
			{
				("rotate", "right") => Rotate(input, int.Parse(scrambleItems[2]), !inverse),
				("rotate", "left") => Rotate(input, int.Parse(scrambleItems[2]), inverse),
				("rotate", "based") => BasedRotate(input, scrambleItems[6][0], inverse),
				("swap", "letter") => Swap(input, Array.IndexOf(input, scrambleItems[2][0]), Array.IndexOf(input, scrambleItems[5][0])),
				("swap", "position") => Swap(input, int.Parse(scrambleItems[2]), int.Parse(scrambleItems[5])),
				("reverse", _) => Reverse(input, int.Parse(scrambleItems[2]), int.Parse(scrambleItems[4])),
				("move", _) => Move(input, int.Parse(scrambleItems[2]), int.Parse(scrambleItems[5]), inverse),
				_ => throw new Exception("Invalid Scramble")
			};

		static char[] Move(char[] input, int first, int second, bool inverse)
		{
			var src = inverse ? second : first;
			var dst = inverse ? first : second;
			var inputList = input.ToList();

			var tmp = input[src];
			inputList.Remove(tmp);
			inputList.Insert(dst, tmp);

			return inputList.ToArray();
		}

		private static char[] Reverse(char[] input, int startIndex, int endIndex)
		{
			for (int i = 0; i < (endIndex - startIndex + 1) / 2; i++)
			{
				input = Swap(input, startIndex + i, endIndex - i);
			}

			return input;
		}

		private static char[] Swap(char[] input, int first, int second)
		{
			var tmp = input[first];
			input[first] = input[second];
			input[second] = tmp;

			return input;
		}


		private static char[] BasedRotate(char[] input, char c, bool inverse)
		{
			if (inverse)
			{
				for (int i = 0; i < input.Length; i++)
				{
					var candidate = Rotate(input, i, false);
					var positions = Array.IndexOf(candidate, c);

					if (Rotate(candidate, 1 + positions + (positions >= 4 ? 1 : 0), true).SequenceEqual(input))
					{
						return candidate;
					}
				}

				throw new Exception("Could not correctly reverse char based rotation");
			}
			else
			{
				var positions = Array.IndexOf(input, c);
				return Rotate(input, 1 + positions + (positions >= 4 ? 1 : 0), true);
			}
		}

		private static char[] Rotate(char[] input, int positions, bool rotateRight)
		{
			var next = new string(input).ToCharArray();
			next.Rotate(rotateRight ? positions : (positions * -1));
			return next;
		}
	}
}
