using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AoC.Helpers.Utils;

namespace AoC.Y2019.Days
{
    public class Day03 : BaseDay
    {
        public Day03() : base(2019, 3) { }

        public Day03(IEnumerable<string> inputLines) : base(2019, 3, inputLines) { }

        protected override IConvertible PartOne()
        {
            var wires = ParseInput(inputLines);
            var wireA = GetWirePoints(wires.First());
            var wireB = GetWirePoints(wires.Last());
            var intersections = GetIntersections(wireA, wireB);
            var closest = GetClosestIntersection(intersections);

            return closest.ManhattanToSource;
        }

        protected override IConvertible PartTwo()
        {
            var wires = ParseInput(inputLines);
            var wireA = GetWirePoints(wires.First());
            var wireB = GetWirePoints(wires.Last());
            var intersections = GetIntersections(wireA, wireB);
            var leastSteps = intersections.OrderBy(i => i.StepsA + i.StepsB).First();

            return leastSteps.StepsA + leastSteps.StepsB;
        }

        private List<WirePoint> GetWirePoints(List<WireSegment> wireSegments)
        {
            var wirePoints = new List<WirePoint>();
            var startPoint = new Point(0, 0);
            var startStep = 0;

            foreach (var wireSegment in wireSegments)
            {
                var segmentPoints = GetSegmentPoints(startPoint, startStep, wireSegment);
                wirePoints.AddRange(segmentPoints);

                var lastSegment = segmentPoints.Last();
                startPoint = lastSegment.Location;
                startStep = lastSegment.Step;
            }

            return wirePoints;
        }

        private static List<WirePoint> GetSegmentPoints(Point startPoint, int startStep, WireSegment wireSegment)
        {
            var segmentPoints = new List<WirePoint>();
            var currentStep = startStep + 1;
            var currentPoint = startPoint;

            for (int i = 0; i < wireSegment.Length; i++)
            {
                switch (wireSegment.Direction)
                {
                    case Direction.Up: currentPoint = currentPoint.Up(); break;
                    case Direction.Right: currentPoint = currentPoint.Right(); break;
                    case Direction.Down: currentPoint = currentPoint.Down(); break;
                    case Direction.Left: currentPoint = currentPoint.Left(); break;
                }

                segmentPoints.Add(new WirePoint(currentPoint, currentStep));
                currentStep++;
            }

            return segmentPoints;
        }

        private static WireIntersection GetClosestIntersection(List<WireIntersection> wi) => wi.OrderBy(w => w.ManhattanToSource).First();

        private static List<WireIntersection> GetIntersections(List<WirePoint> wireA, List<WirePoint> wireB)
        {
            var wireIntersections = new List<WireIntersection>();
            var intersections = wireA.Intersect(wireB, new LocationEqualityComparer());

            foreach (var intersection in intersections)
            {
                var itemA = wireA.First(i => i.Location == intersection.Location);
                var itemB = wireB.First(i => i.Location == intersection.Location);

                wireIntersections.Add(new WireIntersection(itemA, itemB));
            }

            return wireIntersections;
        }

        private static List<List<WireSegment>> ParseInput(IEnumerable<string> inputLines)
        {
            var wires = new List<List<WireSegment>>();

            foreach (var line in inputLines)
            {
                wires.Add(SplitWire(line));
            }

            return wires;
        }

        private static List<WireSegment> SplitWire(string wire)
        {
            var split = wire.Split(',');
            var wireSegments = new List<WireSegment>();

            foreach (var val in split)
            {
                var direction = val[0];
                var length = int.Parse(val.Substring(1));

                wireSegments.Add(new WireSegment(direction, length));
            }

            return wireSegments;
        }
    }
}