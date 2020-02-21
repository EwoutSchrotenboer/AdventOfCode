using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day01 : BaseDay
    {
        public Day01() : base(2016, 1)
        {
        }

        public Day01(IEnumerable<string> input) : base(2016, 1, input)
        {
        }

        protected override IConvertible PartOne() => GetRoute(ParseInput(inputLines), false);

        protected override IConvertible PartTwo() => GetRoute(ParseInput(inputLines), true);

        private static int GetRoute(IEnumerable<(Turn, int)> directions, bool stopAtFirstRevisit)
        {
            var visited = new HashSet<AoCPoint>();
            var currentDirection = Direction.Up;
            var location = AoCPoint.Origin();
            visited.Add(location);

            foreach (var (turn, distance) in directions)
            {
                currentDirection = currentDirection.TurnTo(turn);

                for (int i = 0; i < distance; i++)
                {
                    location = location.MoveTo(currentDirection);

                    if (visited.Contains(location))
                    {
                        if (stopAtFirstRevisit) { return GetDistance(location); }
                        else { continue; }
                    }

                    visited.Add(location);
                }
            }

            return GetDistance(location);
        }

        private static int GetDistance(AoCPoint point) => Math.Abs(point.X) + Math.Abs(point.Y);

        private static IEnumerable<(Turn, int)> ParseInput(IEnumerable<string> inputLines) {
            var items = inputLines.First().Split(", ");
            var directions = new List<(Turn, int)>();

            foreach (var item in items)
            {
                var turn = item[0] == 'L' ? Turn.Left : Turn.Right;
                var distance = int.Parse(item.Substring(1));
                directions.Add((turn, distance));
            }

            return directions;
        }
    }
}
