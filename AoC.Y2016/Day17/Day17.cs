using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AoC.Y2016.Days
{
    public class Day17 : BaseDay
    {
        public Point Spring => new Point(500, 0);

        public Day17() : base(2016, 17)
        {
        }

        public Day17(IEnumerable<string> inputLines) : base(2016, 17, inputLines)
        {
        }

		protected override IConvertible PartOne() => GetValidPaths(inputLines.Single()).OrderBy(p => p.Length).First();

		protected override IConvertible PartTwo() => GetValidPaths(inputLines.Single()).Max(p => p.Length);

		private static List<string> GetValidPaths(string passcode)
		{
			var destination = new AoCPoint(3, 3);
			var md5 = MD5.Create();
			var validPaths = new List<string>();

			var pathQueue = new Queue<(AoCPoint, string)>();
			pathQueue.Enqueue((AoCPoint.Origin(), string.Empty));

			while (pathQueue.Any())
			{
				var (point, route) = pathQueue.Dequeue();

				if (point.Equals(destination))
				{
					validPaths.Add(route);
					continue;
				}

				var input = Encoding.ASCII.GetBytes(passcode + route);
				var hash = md5.ComputeHash(input);
				var hexHash = BitConverter.ToString(hash);

				foreach (var step in GetSteps(point, route, hexHash))
				{
					if (step.point != null) { pathQueue.Enqueue(step); }
				}
			}

			return validPaths;
		}

		private static IEnumerable<(AoCPoint point, string route)> GetSteps(AoCPoint current, string route, string hexHash)
		{
			yield return GetValidStep(current.Up(), route, hexHash[0], 'U');
			yield return GetValidStep(current.Down(), route, hexHash[1], 'D');
			yield return GetValidStep(current.Left(), route, hexHash[3], 'L');
			yield return GetValidStep(current.Right(), route, hexHash[4], 'R');
		}

		private static (AoCPoint point, string route) GetValidStep(AoCPoint point, string route, char check, char direction)
		{
			if (check >= 'B' && check <= 'F'
				&& point.Y >= 0	&& point.Y <= 3
				&& point.X >= 0	&& point.X <= 3)
			{
				return (point, route + direction);
			}

			return (null, null);
		}
	}
}
