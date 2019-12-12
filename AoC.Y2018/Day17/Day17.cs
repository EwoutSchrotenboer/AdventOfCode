using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day17 : BaseDay
    {
        public Point Spring => new Point(500, 0);

        public Day17() : base(2018, 17)
        {
        }

        public Day17(IEnumerable<string> inputLines) : base(2018, 17, inputLines)
        {

        }

        protected override IConvertible PartOne()
        {
            var clay = new Clay(GetClayCoordinates(inputLines.ToList()));
            var (reservoir, waterfall) = SimulateWaterFLow(clay);
            return waterfall.Union(reservoir).Count(p => p.Y <= clay.MaxY && p.Y >= clay.MinY);
        }

        protected override IConvertible PartTwo()
        {
            var clay = new Clay(GetClayCoordinates(inputLines.ToList()));
            var (reservoir, waterfall) = SimulateWaterFLow(clay);
            return reservoir.Count(p => p.Y <= clay.MaxY && p.Y >= clay.MinY);
        }

        private (HashSet<Point> reservoir, HashSet<Point> waterfall) SimulateWaterFLow(Clay clay)
        {
            var reservoir = new HashSet<Point>();
            var flowingWater = new HashSet<Point> { new Point(500, 1) };
            var edges = new HashSet<Point> { new Point(500, 1) };

            while (edges.Any())
            {
                var newEdges = new HashSet<Point>();

                foreach (var edge in edges)
                {
                    if (edge.Y > clay.MaxY) continue;

                    var down = edge.Down();

                    if (IsOpenSand(down, clay, reservoir, flowingWater))
                    {
                        flowingWater.Add(down);
                        newEdges.Add(down);
                    }
                    else if (IsClay(down, clay) || reservoir.Contains(down))
                    {
                        FillReservoir(clay, reservoir, flowingWater, newEdges, edge);
                    }
                }

                edges = newEdges;
            }

            return (reservoir, flowingWater);
        }

        private static void FillReservoir(Clay clay, HashSet<Point> reservoir, HashSet<Point> flowingWater, HashSet<Point> newEdges, Point edge)
        {
            var rowToFlood = edge;
            var isContained = true;

            while (isContained)
            {
                flowingWater.Remove(rowToFlood);
                var stuffToAdd = new HashSet<Point> { rowToFlood };

                var left = rowToFlood.Left();
                while (!IsClay(left, clay))
                {
                    if (IsOpenSand(left.Down(), clay, reservoir, flowingWater))
                    {
                        flowingWater.Add(left);
                        newEdges.Add(left);
                        isContained = false;
                        break;
                    }
                    else
                    {
                        stuffToAdd.Add(left);
                        left = left.Left();
                    }
                }

                var right = rowToFlood.Right();
                while (!IsClay(right, clay))
                {
                    if (IsOpenSand(right.Down(), clay, reservoir, flowingWater))
                    {
                        flowingWater.Add(right);
                        newEdges.Add(right);
                        isContained = false;
                        break;
                    }
                    else
                    {
                        stuffToAdd.Add(right);
                        right = right.Right();
                    }
                }

                if (isContained)
                {
                    reservoir.UnionWith(stuffToAdd);
                    rowToFlood = rowToFlood.Up();
                }
                else
                {
                    flowingWater.UnionWith(stuffToAdd);
                }
            }
        }

        private static HashSet<Point> GetClayCoordinates(List<string> input)
        {
            var clayPoints = new HashSet<Point>();

            foreach (var inputLine in input)
            {
                var splitLines = inputLine.Split(',');

                var first = splitLines[0].Split('=')[1];
                var range = splitLines[1].Split('=')[1].Split("..");
                var startRange = range[0];
                var endRange = range[1];

                var points = ParsePoints(first, startRange, endRange);

                for (int i = points.start; i <= points.end; i++)
                {
                    if (splitLines[0][0] == 'x') { clayPoints.Add(new Point(points.pos, i)); }
                    else { clayPoints.Add(new Point(i, points.pos)); }
                }
            }

            return clayPoints;
        }

        private static bool IsOpenSand(Point p, Clay clay, HashSet<Point> reservoir, HashSet<Point> flowingWater) => !clay.Coords.Contains(p) && !flowingWater.Contains(p) && !reservoir.Contains(p);
        private static bool IsClay(Point p, Clay clay) => clay.Coords.Contains(p);
        private static (int pos, int start, int end) ParsePoints(string a, string b, string c) => (int.Parse(a), int.Parse(b), int.Parse(c));
    }
}