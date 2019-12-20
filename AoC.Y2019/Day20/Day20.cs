using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day20 : BaseDay
    {
        public Day20() : base(2019, 20)
        {
        }

        public Day20(IEnumerable<string> inputLines) : base(2019, 20, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (points, portals, start, end) = ParseInput(inputLines.ToList());
            return TraverseMaze(points, portals, start, end, false);
        }

        protected override IConvertible PartTwo()
        {
            var (points, portals, start, end) = ParseInput(inputLines.ToList());
            return TraverseMaze(points, portals, start, end, true);
        }

        private static (bool active, int adjustDepth) GetDepth(int minOuterX, int minOuterY, int maxOuterX, int maxOuterY, AoCPoint portal, int depth)
        {
            if (portal.X == minOuterX || portal.X == maxOuterX || portal.Y == minOuterY || portal.Y == maxOuterY)
            {
                // Depth 0 does not enable outer portals
                if (depth == 0) { return (false, 0); }
                else { return (true, -1); }
            }
            else { return (true, 1); }
        }

        private static (HashSet<AoCPoint> points, Dictionary<AoCPoint, AoCPoint> portals, AoCPoint source, AoCPoint destination) ParseInput(List<string> inputLines)
        {
            var height = inputLines.Count;
            var width = inputLines.First().Count();

            var points = new HashSet<AoCPoint>();
            var portalList = new Dictionary<string, List<AoCPoint>>();

            for (int yPos = 0; yPos < height; yPos++)
            {
                for (int xPos = 0; xPos < width; xPos++)
                {
                    if (inputLines[yPos][xPos] == '.')
                    {
                        var p = new AoCPoint(xPos, yPos);
                        points.Add(p);

                        foreach (var (near, far, dir) in PossiblePortals(p))
                        {
                            var (portal, name) = PortalName(inputLines[near.Y][near.X], inputLines[far.Y][far.X], dir);

                            if (portal)
                            {
                                if (!portalList.ContainsKey(name)) { portalList.Add(name, new List<AoCPoint>()); }
                                portalList[name].Add(p);
                            }
                        }
                    }
                }
            }

            var portals = new Dictionary<AoCPoint, AoCPoint>();

            foreach (var portalset in portalList.Where(p => p.Value.Count == 2))
            {
                portals.Add(portalset.Value[0], portalset.Value[1]);
                portals.Add(portalset.Value[1], portalset.Value[0]);
            }

            var source = portalList["AA"].Single();
            var destination = portalList["ZZ"].Single();

            return (points, portals, source, destination);
        }

        private static (bool portal, string name) PortalName(char first, char second, Direction direction)
        {
            if (char.IsUpper(first) && char.IsUpper(second))
            {
                switch (direction)
                {
                    case Direction.Up: return (true, $"{second}{first}");
                    case Direction.Left: return (true, $"{second}{first}");
                    case Direction.Down: return (true, $"{first}{second}");
                    case Direction.Right: return (true, $"{first}{second}");
                }
            }

            return (false, string.Empty);
        }

        private static IEnumerable<(AoCPoint near, AoCPoint far, Direction dir)> PossiblePortals(AoCPoint point)
        {
            yield return (point.Up(), point.Up().Up(), Direction.Up);
            yield return (point.Right(), point.Right().Right(), Direction.Right);
            yield return (point.Down(), point.Down().Down(), Direction.Down);
            yield return (point.Left(), point.Left().Left(), Direction.Left);
        }

        private static int TraverseMaze(HashSet<AoCPoint> points, Dictionary<AoCPoint, AoCPoint> portals, AoCPoint source, AoCPoint destination, bool recursive)
        {
            int minOuterX = 2, minOuterY = 2, maxOuterX = points.Max(p => p.X), maxOuterY = points.Max(p => p.Y);

            var seen = new HashSet<(AoCPoint, int)>();
            var queue = new Queue<(AoCPoint, int, int)>();
            queue.Enqueue((source, 0, 0));

            while (queue.Any())
            {
                var (point, steps, depth) = queue.Dequeue();

                if (point.Equals(destination) && depth == 0) { return steps; }
                if (seen.Contains((point, depth))) { continue; }

                seen.Add((point, depth));

                foreach (var adjacent in point.Adjacent())
                {
                    if (points.Contains(adjacent)) { queue.Enqueue((adjacent, steps + 1, depth)); }
                }

                if (portals.ContainsKey(point))
                {
                    if (recursive)
                    {
                        var (active, adjustDepth) = GetDepth(minOuterX, minOuterY, maxOuterX, maxOuterY, point, depth);
                        if (active) { queue.Enqueue((portals[point], steps + 1, depth + adjustDepth)); }
                    }
                    else { queue.Enqueue((portals[point], steps + 1, depth)); }
                }
            }

            return 0;
        }
    }
}
