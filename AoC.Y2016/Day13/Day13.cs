using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day13 : BaseDay
    {
        public Day13() : base(2016, 13)
        {
        }

        public Day13(IEnumerable<string> inputLines) : base(2016, 13, inputLines)
        {
        }

        protected override IConvertible PartOne() => SolveRoute(new AoCPoint(1, 1), ParseInput(inputLines), 0, new AoCPoint(31, 39));

        protected override IConvertible PartTwo() => SolveRoute(new AoCPoint(1, 1), ParseInput(inputLines), 50, null);

		private static int SolveRoute(AoCPoint origin, int favorite, int reach, AoCPoint? destination)
		{
			var reachPoint = destination != null;
			var countWithinReach = reach != 0;

			var visited = new HashSet<AoCPoint>();
			var queue = new Queue<(AoCPoint, int)>();
			queue.Enqueue((origin, 0));

			var inReach = 0;

			while (queue.Any())
			{
				var (current, currentSteps) = queue.Dequeue();

				if (reachPoint && current.Equals(destination)) { return currentSteps; }
				if (currentSteps <= reach && !visited.Contains(current)) { inReach++; }

				foreach (var adjacent in current.Adjacent())
				{
					if (visited.Contains(adjacent)) { continue; }

					if (adjacent.X >= 0 && adjacent.Y >= 0 && IsOpenSpace(adjacent, favorite))
					{
						if (countWithinReach && currentSteps + 1 > reach) { continue; }

						queue.Enqueue((adjacent, currentSteps + 1));
					}
				}

				visited.Add(current);
			}

			return inReach;
		}

		private static bool IsOpenSpace(AoCPoint point, int favorite)
		{
			var (x, y) = point.GetCoords();
			var combined = (x * x) + (3 * x) + (2 * x * y) + y + (y * y) + favorite;
			return combined.CountSetBits() % 2 == 0;
		}

		private static int ParseInput(IEnumerable<string> lines) => int.Parse(lines.Single());
    }
}
