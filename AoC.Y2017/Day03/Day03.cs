using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day03 : BaseDay
    {
        public Day03() : base(2017, 3)
        {
        }

        public Day03(IEnumerable<string> inputLines) : base(2017, 3, inputLines)
        {
        }

        protected override IConvertible PartOne() => StepsToData(int.Parse(inputLines.Single()));

        protected override IConvertible PartTwo() => StressTest(int.Parse(inputLines.Single()));

        private static int StepsToData(int input)
        {
            var memory = GenerateSpiralMemory(input, false);
            var position = memory.Single(m => m.Value == input).Key;
            var origin = memory.Keys.Single(k => k.X == 0 && k.Y == 0);
            return origin.ManhattanDistanceTo(position);
        }

        private static int StressTest(int input)
        {
            var memory = GenerateSpiralMemory(input, true);
            return memory.Where(m => m.Value > input).Single().Value;
        }

		private static Dictionary<AoCPoint, int> GenerateSpiralMemory(int targetValue, bool stressTest)
		{
			var memory = new Dictionary<AoCPoint, int>
			{
				[AoCPoint.Origin()] =  1
			};

			var currentPoint = new AoCPoint(1, 0);
			var value = stressTest ? 1 : 2;

			memory.Add(currentPoint, value);
			var currentDirection = Direction.Up;

			while (value < targetValue)
			{
				(currentPoint, currentDirection) = GetNextPoint(memory, currentPoint, currentDirection);
				value = stressTest ? GetAdjacentSum(memory, currentPoint) : value + 1;
				memory.Add(currentPoint, value);
			}

			return memory;
		}

		private static int GetAdjacentSum(Dictionary<AoCPoint, int> memory, AoCPoint current)
		{
			var sum = 0;

			foreach (var adjacent in current.Adjacent(true))
			{
				if (memory.TryGetValue(adjacent, out var val))
				{
					sum += val;
				}
			}

			return sum;
		}

		private static (AoCPoint, Direction) GetNextPoint(Dictionary<AoCPoint, int> memory, AoCPoint current, Direction direction) =>
			direction switch
			{
				Direction.Up => memory.ContainsKey(current.Left()) ? (current.Up(), Direction.Up) : (current.Left(), Direction.Left),
				Direction.Left => memory.ContainsKey(current.Down()) ? (current.Left(), Direction.Left) : (current.Down(), Direction.Down),
				Direction.Down => memory.ContainsKey(current.Right()) ? (current.Down(), Direction.Down) : (current.Right(), Direction.Right),
				Direction.Right => memory.ContainsKey(current.Up()) ? (current.Right(), Direction.Right) : (current.Up(), Direction.Up),
				_ => throw new Exception("Invalid direction.")
			};
	}
}
