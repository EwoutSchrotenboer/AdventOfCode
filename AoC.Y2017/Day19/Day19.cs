using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day19 : BaseDay
    {
        public Day19() : base(2017, 19)
        {
        }

        public Day19(IEnumerable<string> inputLines) : base(2017, 19, inputLines)
        {
        }

		protected override IConvertible PartOne() => FollowRoute(ParseInput(inputLines)).output;

        protected override IConvertible PartTwo() => FollowRoute(ParseInput(inputLines)).steps;

		private static (string output, int steps) FollowRoute(Dictionary<AoCPoint, char> map)
		{
			var visitedLetters = string.Empty;
			var steps = 0;

			var currentPoint = map.Keys.Single(k => k.Y == 0);
			var currentDirection = Direction.Down;
			var currentValue = map[currentPoint];
			var lines = new char[] { '|', '-', '+' };

			while (true)
			{
				steps++;
				(currentPoint, currentDirection) = GetNextPosition(currentPoint, currentValue, currentDirection, map);

				if (!map.TryGetValue(currentPoint, out currentValue))
				{
					return (visitedLetters, steps);
				}

				if (!lines.Contains(currentValue))
				{
					visitedLetters += currentValue;
				}
			}
		}

		private static (AoCPoint nextPoint, Direction nextDirection) GetNextPosition(AoCPoint currentPoint, char currentValue, Direction currentDirection, Dictionary<AoCPoint, char> map)
		{
			if (currentValue == '+')
			{
				// turn
				var left = currentDirection.TurnTo(Turn.Left);
				var right = currentDirection.TurnTo(Turn.Right);

				if (map.ContainsKey(currentPoint.MoveTo(left))) { return (currentPoint.MoveTo(left), left); }
				else if (map.ContainsKey(currentPoint.MoveTo(right))) { return (currentPoint.MoveTo(right), right); }
			}

			return (currentPoint.MoveTo(currentDirection), currentDirection);
		}

		private static Dictionary<AoCPoint, char> ParseInput(IEnumerable<string> inputLines)
		{
			var map = new Dictionary<AoCPoint, char>();

			var inputList = inputLines.ToList();

			for (int y = 0; y < inputList.Count; y++)
			{
				for (int x = 0; x < inputList[0].Length; x++)
				{
					var value = inputList[y][x];

					if (value != ' ')
					{
						map.Add(new AoCPoint(x, y), value);
					}
				}
			}

			return map;
		}
	}
}
