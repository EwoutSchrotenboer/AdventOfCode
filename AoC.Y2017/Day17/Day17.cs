using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day17 : BaseDay
    {
        public Point Spring => new Point(500, 0);

        public Day17() : base(2017, 17)
        {
        }

        public Day17(IEnumerable<string> inputLines) : base(2017, 17, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetShortCircuitValue(2017, int.Parse(inputLines.Single()));

		protected override IConvertible PartTwo() => GetLargeShortCircuitValue(50_000_000, int.Parse(inputLines.Single()));

		private static int GetLargeShortCircuitValue(int cycles, int steps)
		{
			var position = 0;
			var result = 0;
			var currentCycle = 0;

			while (currentCycle < cycles)
			{
				if (position == 1)
				{
					result = currentCycle;
				}

				var timesStepsFit = (currentCycle - position) / steps;
				currentCycle += (timesStepsFit + 1);
				position = (position + (timesStepsFit + 1) * (steps + 1) - 1) % currentCycle + 1;
			}

			return result;
		}

		private static int GetShortCircuitValue(int cycles, int steps)
		{
			var spinlock = GenerateSpinlockList(cycles, steps);
			var lastIndex = spinlock.IndexOf(cycles);
			return spinlock[lastIndex + 1];
		}

		private static List<int> GenerateSpinlockList(int cycles, int steps)
		{
			var spinlock = new List<int>() { 0 };
			var position = 0;

			for (int i = 1; i <= cycles; i++)
			{
				position = ((position + steps) % spinlock.Count) + 1;
				if (position == spinlock.Count) { spinlock.Add(i); }
				else { spinlock.Insert(position, i); }
			}

			return spinlock;
		}
	}
}
