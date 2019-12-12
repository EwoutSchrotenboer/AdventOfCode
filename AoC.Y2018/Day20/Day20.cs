using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using AoC.Helpers.Utils;
using System.Linq;
using System.Drawing;
using System.Text;

namespace AoC.Y2018.Days
{
    public class Day20 : BaseDay
    {
        public Day20() : base(2018, 20)
        {
        }

        public Day20(IEnumerable<string> inputLines) : base(2018, 20, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (_, startingRoom) = TraverseInput(inputLines.First());
            var distances = GetDistances(startingRoom);
            return distances.Values.Max();
        }

        protected override IConvertible PartTwo()
        {
            var (Rooms, startingRoom) = TraverseInput(inputLines.First());
            var distances = GetDistances(startingRoom);
            return distances.Values.Count(d => d >= 1000);
        }

        private static Dictionary<Room, int> GetDistances(Room startingRoom)
        {
            var visited = new HashSet<Room>();
            var distances = new Dictionary<Room, int> { { startingRoom, 0 } };
            var edges = new HashSet<Room> { startingRoom };
            var dist = 0;

            while (edges.Any())
            {
                var newEdges = new HashSet<Room>();
                foreach (var edge in edges)
                {
                    if (visited.Contains(edge)) continue;
                    visited.Add(edge);
                    distances[edge] = dist;
                    if (edge.North != null) newEdges.Add(edge.North);
                    if (edge.East != null) newEdges.Add(edge.East);
                    if (edge.South != null) newEdges.Add(edge.South);
                    if (edge.West != null) newEdges.Add(edge.West);
                }

                dist++;
                edges = newEdges;
            }

            return distances;
        }

        private readonly HashSet<char> directions = new HashSet<char> { 'N', 'E', 'S', 'W' };

        private (HashSet<Room> Rooms, Room startingRoom) TraverseInput(string input)
        {
            var startingRoom = new Room { Point = new Point(0, 0) };
            var Rooms = new HashSet<Room> { startingRoom };
            var data = input.Substring(1, input.Length - 2);

            TraverseInput(data, startingRoom, Rooms);
            return (Rooms, startingRoom);
        }

        private void TraverseInput(string input, Room position, HashSet<Room> Rooms)
        {
            if (input == "") return;
            if (input[0] == ')') return;

            Room find(Room from, char dir)
            {
                if (dir == 'N') return Rooms.SingleOrDefault(n => n.Point == from.Point.Up());
                if (dir == 'E') return Rooms.SingleOrDefault(n => n.Point == from.Point.Right());
                if (dir == 'S') return Rooms.SingleOrDefault(n => n.Point == from.Point.Down());
                if (dir == 'W') return Rooms.SingleOrDefault(n => n.Point == from.Point.Left());
                throw new NotSupportedException();
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (directions.Contains(input[i]))
                {
                    var Room = find(position, input[i]) ?? position.CreateNewRoom(input[i]);
                    position.Link(Room, input[i]);
                    position = Room;
                    Rooms.Add(position);
                }
                else if (input[i] == '(')
                {
                    var parenStack = 1;
                    var sb = new StringBuilder();

                    while (parenStack > 0)
                    {
                        i++;
                        if (input[i] == '(') parenStack++;
                        else if (input[i] == ')') parenStack--;

                        if (input[i] == '|' && parenStack == 1) sb.Append(Environment.NewLine);
                        else sb.Append(input[i]);
                    }

                    foreach (var slice in sb.ToString().Split('\n'))
                    {
                        TraverseInput(slice, position, Rooms);
                    }
                }
            }
        }
    }
}