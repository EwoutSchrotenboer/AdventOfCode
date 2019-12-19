using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2019.Days
{
    internal static class RouteCompressor
    {
        public static (string main, List<Subroutine> subroutines) GenerateCompressedRoute(Dictionary<Point, char> map)
        {
            var route = GetRouteFromMap(map);
            var allSubroutines = GetPossibleSubroutines(route);
            var (main, subroutines) = GetSubRoutines(allSubroutines, route);

            return (main, subroutines);
        }

        private static IEnumerable<Subroutine> GetPossibleSubroutines(string[] directions)
        {
            var sets = new List<Subroutine>();
            var subroutines = 3;

            for (int start = 0; start < directions.Length; start++)
            {
                for (int length = 2; length < (directions.Length / subroutines); length++)
                {
                    var partial = directions.Skip(start).Take(length).ToArray();

                    for (int curr = start + length; curr < directions.Length + length; curr++)
                    {
                        var check = directions.Skip(curr).Take(partial.Count());

                        if (partial.SequenceEqual(check))
                        {
                            var set = sets.SingleOrDefault(s => s.Index == start && s.Set.SequenceEqual(partial));
                            if (set == null)
                            {
                                set = new Subroutine() { Index = start, Set = partial.ToList(), SetString = string.Join(",", partial) };
                                sets.Add(set);
                            }

                            set.Matches.Add(curr);
                        }
                    }
                }
            }

            return sets.Where(s => string.Join(",", s.Set).Length + s.Set.Count <= 20);
        }

        private static (string main, List<Subroutine> subroutines) GetSubRoutines(IEnumerable<Subroutine> subroutines, string[] route)
        {
            var routeString = string.Join(",", route);

            foreach (var a in subroutines.Where(s => s.Index == 0))
            {
                var current = routeString;
                var acurrent = current.Replace(a.SetString, "A");

                var bindex = a.Set.Count;
                foreach (var b in subroutines.Where(s => s.Index == bindex))
                {
                    var bcurrent = acurrent.Replace(b.SetString, "B");
                    var cindex = bindex + b.Set.Count;

                    foreach (var c in subroutines.Where(s => s.Index >= cindex))
                    {
                        var ccurrent = bcurrent.Replace(c.SetString, "C");
                        if (!ccurrent.Contains("L") && !ccurrent.Contains("R") && ccurrent.Length <= 20)
                        {
                            return ($"{ccurrent}\n", new List<Subroutine>() { a, b, c });
                        }
                    }
                }
            }

            throw new Exception("The robot did not want to stop and ask for directions.");
        }

        private static string[] GetRouteFromMap(Dictionary<Point, char> map)
        {
            var current = map.Single(m => m.Value != '#' && m.Value != '.').Key;
            var direction = map[current].GetDirection();

            var finished = false;
            var currentSteps = 0;

            var directions = new List<string>();
            var previousTurn = Turn.Left;

            while (!finished)
            {
                if (NextIsValid(map, current.MoveTo(direction)))
                {
                    current = current.MoveTo(direction);
                    currentSteps++;
                }
                else
                {
                    var left = direction.TurnTo(Turn.Left);
                    var right = direction.TurnTo(Turn.Right);
                    var turnedLeft = false;

                    if (NextIsValid(map, current.MoveTo(left))) { turnedLeft = true; }
                    else if (NextIsValid(map, current.MoveTo(right))) { turnedLeft = false; }
                    else
                    {
                        finished = true;
                        directions.Add($"{(previousTurn == Turn.Left ? 'L' : 'R')}{currentSteps}");
                        continue;
                    }

                    if (currentSteps > 0)
                    {
                        directions.Add($"{(previousTurn == Turn.Left ? 'L' : 'R')}{currentSteps}");
                        currentSteps = 0;
                    }

                    direction = turnedLeft ? left : right;
                    previousTurn = turnedLeft ? Turn.Left : Turn.Right;
                }
            }

            return directions.ToArray();
        }

        private static bool NextIsValid(Dictionary<Point, char> map, Point current) => map.ContainsKey(current) && map[current] == '#';
    }
}
