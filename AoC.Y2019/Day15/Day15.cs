using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day15 : BaseDay
    {
        private readonly Dictionary<Point, long> visited = new Dictionary<Point, long>();
        private Computer computer;

        private long[,] maze;
        private long[,] oxygenated;
        private bool[,] seen;

        private Point oxygenSystem;
        private Point start;


        public Day15() : base(2019, 15)
        {
        }

        public Day15(IEnumerable<string> inputLines) : base(2019, 15, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            computer = new Computer(inputLines.First());
            InitializeMaze(computer);
            BreadthFirst(start);
            return oxygenated[oxygenSystem.Y, oxygenSystem.X];
        }

        protected override IConvertible PartTwo()
        {
            computer = new Computer(inputLines.First());
            InitializeMaze(computer);
            BreadthFirst(oxygenSystem);
            return oxygenated.Cast<long>().Max();
        }

        private void BreadthFirst(Point startPoint)
        {
            var pointsToExplore = new Stack<Point>();

            pointsToExplore.Push(startPoint);

            while (pointsToExplore.Count > 0)
            {
                var p = pointsToExplore.Pop();

                Point[] possiblePoints = new Point[] { p.Up(), p.Right(), p.Down(), p.Left() };

                foreach (var point in possiblePoints)
                {
                    if (maze[point.Y, point.X] != 0)
                    {
                        if (seen[point.Y, point.X] == false)
                        {
                            oxygenated[point.Y, point.X] = oxygenated[p.Y, p.X] + 1;
                            pointsToExplore.Push(point);
                        }
                    }
                }

                seen[p.Y, p.X] = true;
            }
        }

        private void InitializeMaze(Computer computer)
        {
            computer.Run();
            var origin = new Point(0, 0);
            start = origin;

            Map(origin);

            var (sizeX, sizeY, offsetX, offsetY) = visited.Keys.GetSizesAndOffsets();

            start = new Point(start.X + offsetX, this.start.Y + offsetY);
            oxygenSystem = new Point(oxygenSystem.X + offsetX, oxygenSystem.Y + offsetY);

            maze = new long[sizeY + 1, sizeX + 1];
            oxygenated = new long[sizeY + 1, sizeX + 1];
            seen = new bool[sizeY + 1, sizeX + 1];

            foreach (var location in visited)
            {
                maze[location.Key.Y + offsetY, location.Key.X + offsetX] = location.Value;
            }
        }

        private void Map(Point origin)
        {
            MapAdjacent(origin.Up(), RobotDirection.North, RobotDirection.South);
            MapAdjacent(origin.Down(), RobotDirection.South, RobotDirection.North);
            MapAdjacent(origin.Left(), RobotDirection.West, RobotDirection.East);
            MapAdjacent(origin.Right(), RobotDirection.East, RobotDirection.West);
        }

        private void MapAdjacent(Point destination, RobotDirection direction, RobotDirection oppositeDirection)
        {
            if (!visited.ContainsKey(destination))
            {
                var destinationType = Move(direction);
                visited.Add(destination, (long)destinationType);

                if (destinationType == ShipLocationType.Wall) { return; }

                Map(destination);

                if (destinationType == ShipLocationType.OxygenSystem)
                {
                    visited[destination] = (long)ShipLocationType.Empty;
                    oxygenSystem = destination;
                }

                Move(oppositeDirection);
            }
        }

        private ShipLocationType Move(RobotDirection direction)
        {
            var (_, outputs) = computer.Resume((int)direction);
            return (ShipLocationType)outputs.Last();
        }
    }
}
