using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day09 : BaseDay
    {
        public Day09() : base(2015, 9)
        {
        }

        public Day09(IEnumerable<string> inputLines) : base(2015, 9, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetRoute(ParseInput(inputLines), true);

        protected override IConvertible PartTwo() => GetRoute(ParseInput(inputLines), false);

        private static int GetRoute(Dictionary<int, Dictionary<int, int>> edges, bool getShortest)
        {
			var target = 0;
			for (var i = 0; i < edges.Count; ++i) { target |= (int)Math.Pow(2, i); }

			var visited = new Dictionary<(int, int), int>();
			var routeQueue = new Queue<(int, int, int)>();

			foreach (var location in edges.Keys) { routeQueue.Enqueue((location, location, 0)); }

			var returnValue = getShortest ? int.MaxValue : int.MinValue;

			while (routeQueue.Any())
			{
				var (currPosition, currVisited, currDistance) = routeQueue.Dequeue();
				var value = (currPosition, currVisited);
				if (visited.TryGetValue(value, out var distance))
				{
					if ((distance <= currDistance && getShortest) || (distance >= currDistance && !getShortest)) { continue; }
					visited[value] = distance;
				}
				else
				{
					visited.Add(value, currDistance);
				}

				if (currVisited == target)
				{
					returnValue = getShortest ? Math.Min(returnValue, currDistance) : Math.Max(returnValue, currDistance);
					continue;
				}

				foreach (var edge in edges[currPosition])
				{
					if ((currVisited & edge.Key) == edge.Key) { continue; }
					routeQueue.Enqueue((edge.Key, currVisited | edge.Key, currDistance + edge.Value));
				}
			}

			return returnValue;
		}

        private static Dictionary<int, Dictionary<int, int>> ParseInput(IEnumerable<string> inputLines)
        {
            var positions = new Dictionary<int, Dictionary<int, int>>();
            var splitLines = inputLines.Select(l => l.Split(' '));
            var positionNames = splitLines.SelectMany(l => new string[] { l[0], l[2] }).Distinct().ToArray();

            var mapping = new Dictionary<string, int>();
            for (int i = 0; i < positionNames.Length; i++) { mapping.Add(positionNames[i], (int)Math.Pow(2, i)); }

            foreach (var line in splitLines)
            {
                var src = mapping[line[0]];
                var dst = mapping[line[2]];
                var dist = int.Parse(line[4]);

                if (!positions.ContainsKey(src)) { positions.Add(src, new Dictionary<int, int>()); }
                positions[src].Add(dst, dist);

                if (!positions.ContainsKey(dst)) { positions.Add(dst, new Dictionary<int, int>()); }
                positions[dst].Add(src, dist);
            }

            return positions;
        }
    }
}
