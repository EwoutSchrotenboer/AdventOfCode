using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day22 : BaseDay
    {
        public Day22() : base(2016, 22)
        {
        }

        public Day22(IEnumerable<string> inputLines) : base(2016, 22, inputLines)
        {
        }

        protected override IConvertible PartOne() => CountViablePairs(ParseInput(inputLines));

		protected override IConvertible PartTwo() => ShortestDataRoute(ParseInput(inputLines));

		private static int ShortestDataRoute(List<StorageNode> nodes)
		{
			var src = nodes.Single(n => n.X == nodes.Max(n => n.X) && n.Y == 0);
			var dst = nodes.Single(n => n.X == 0 && n.Y == 0);
			var empty = nodes.Single(n => n.Used == 0);

			// Note: no support for blocking big drives at this time.
			var steps = 0;

			// move empty disk to the left of the source disk
			if (empty.X < src.X) { steps += src.X - 1 - empty.X; }
			else { steps += empty.X - src.X + 1; }

			steps += empty.Y - 1;

			// calculate how many steps it is to the destination (0 in this case)
			var repeats = src.X - dst.X;
			// 1.    | 2.    | 3.    | 4.    | 5.    |
			// . S _ | . S . | . S . | . S . | _ S . |
			// . . . | . . _ | . _ . | _ . . | . . . |

			steps += repeats * 5;

			// Last step, we do not need the five steps
			steps += 1;

			return steps;
		}

		private static int CountViablePairs(List<StorageNode> nodes)
		{
			var count = 0;

			for (int a = 0; a < nodes.Count(); a++)
			{
				if (nodes[a].Used == 0) { continue; }

				for (int b = 0; b < nodes.Count(); b++)
				{
					if (nodes[a].X == nodes[b].X && nodes[a].Y == nodes[b].Y) { continue; }
					if (nodes[a].Used <= nodes[b].Available) { count++; }
				}
			}

			return count;
		}

		private static List<StorageNode> ParseInput(IEnumerable<string> inputLines) => inputLines.Skip(2).Select(l => new StorageNode(l)).ToList();
	}
}
