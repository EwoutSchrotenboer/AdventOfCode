using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AoC.Y2016.Days
{
    public class Day08 : BaseDay
    {
        public Day08() : base(2016, 8)
        {
        }

        public Day08(IEnumerable<string> inputLines) : base(2016, 8, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetDisplayValue(ParseInput(inputLines)).sum;

        protected override IConvertible PartTwo() => GetDisplayValue(ParseInput(inputLines)).letters;

		private static (int sum, string letters) GetDisplayValue(List<(string instruction, int a, int b)> instructions)
		{
			var rect = new int[6, 50];

			foreach (var (instruction, a, b) in instructions)
			{
				rect = instructionMap[instruction](rect, a, b);
			}

			var sum = 0;
			var points = new Dictionary<Point, int>();

			for (var y = 0; y < 6; y++)
			{
				for (var x = 0; x < 50; x++)
				{
					sum += rect[y, x];
					points.Add(new Point(x, y), rect[y, x]);
				}
			}

			return (sum, Letters.ParseLetters(points));
		}

		private static int[,] RowInstruction(int[,] rect, int row, int shift)
		{
			var nextRow = new int[50];
			for (int x = 0; x < 50; x++) { nextRow[(x + shift) % 50] = rect[row, x]; }
			for (int x = 0; x < 50; x++) { rect[row, x] = nextRow[x]; }
			return rect;
		}

		private static int[,] ColumnInstruction(int[,] rect, int col, int shift)
		{
			var nextCol = new int[6];
			for (int x = 0; x < 6; x++) { nextCol[(x + shift) % 6] = rect[x, col]; }
			for (int x = 0; x < 6; x++) { rect[x, col] = nextCol[x]; }
			return rect;
		}

		private static int[,] RectInstruction(int[,] rect, int width, int height)
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					rect[y, x] = 1;
				}
			}
			return rect;
		}

		private static Dictionary<string, Func<int[,], int, int, int[,]>> instructionMap = new Dictionary<string, Func<int[,], int, int, int[,]>>()
		{
			["rect"] = RectInstruction,
			["row"] = RowInstruction,
			["column"] = ColumnInstruction
		};



		private static List<(string inst, int a, int b)> ParseInput(IEnumerable<string> inputLines)
		{
			var instructions = new List<(string, int, int)>();

			foreach (var line in inputLines)
			{
				var split = line.Split(' ');

				if (split[0].Equals("rect"))
				{
					var area = split[1].Split('x');
					instructions.Add((split[0], int.Parse(area[0]), int.Parse(area[1])));
				}
				else
				{
					var shift = split[2].Split('=');
					instructions.Add((split[1], int.Parse(shift[1]), int.Parse(split[4])));
				}
			}

			return instructions;
		}
	}
}
