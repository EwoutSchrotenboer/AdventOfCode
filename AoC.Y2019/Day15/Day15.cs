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
        public Day15() : base(2019, 15)
        {
        }

        public Day15(IEnumerable<string> inputLines) : base(2019, 15, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var computer = new Computer(inputLines.First());
            var shipLocations = Initialize(computer);

            var start = shipLocations.Single(l => l.Start);
            var oxygenSystem = shipLocations.Single(l => l.OxygenSystem);

            MapRoute(shipLocations, start);
            return oxygenSystem.Scratch;
        }

        protected override IConvertible PartTwo()
        {
            var computer = new Computer(inputLines.First());
            var shipLocations = Initialize(computer);

            var oxygenSystem = shipLocations.Single(l => l.OxygenSystem);

            MapRoute(shipLocations, oxygenSystem);
            return shipLocations.Max(l => l.Scratch);
        }

        private void MapRoute(List<ShipLocation> shipLocations, ShipLocation start)
        {
            var locationsLeft = new Stack<ShipLocation>();
            locationsLeft.Push(start);

            while (locationsLeft.Count > 0)
            {
                var currentLocation = locationsLeft.Pop();

                Point[] adjacentLocations = new Point[] { 
                    currentLocation.Location.Up(), 
                    currentLocation.Location.Down(), 
                    currentLocation.Location.Right(), 
                    currentLocation.Location.Left() 
                };

                foreach (var adjacentLocation in adjacentLocations)
                {
                    var adjacent = shipLocations.Single(l => l.Location == adjacentLocation);
                    if (adjacent.Type != ShipLocationType.Wall && adjacent.Visited != true) 
                    {
                        adjacent.Scratch = currentLocation.Scratch + 1;
                        locationsLeft.Push(adjacent);
                    }
                }

                currentLocation.Visited = true;
            }
        }

        private List<ShipLocation> Initialize(Computer repairDroid)
        {
            repairDroid.Run();

            var origin = new ShipLocation(new Point(0, 0), ShipLocationType.Empty, true);
            var shipLocations = new List<ShipLocation>() { origin };

            MapRoom(repairDroid, shipLocations, origin);

            var (sizeX, sizeY, offsetX, offsetY) = shipLocations.Select(s => s.Location).GetSizesAndOffsets();

            foreach (var location in shipLocations)
            {
                location.UpdateLocationOffset(offsetX, offsetY);
            }

            return shipLocations;
        }

        private void MapRoom(Computer repairDroid, List<ShipLocation> shipLocations, ShipLocation origin)
        {
            MapAdjacent(repairDroid, shipLocations, origin.Move(DroidDirection.North));
            MapAdjacent(repairDroid, shipLocations, origin.Move(DroidDirection.South));
            MapAdjacent(repairDroid, shipLocations, origin.Move(DroidDirection.West));
            MapAdjacent(repairDroid, shipLocations, origin.Move(DroidDirection.East));
        }

        private void MapAdjacent(Computer repairDroid, List<ShipLocation> shipLocations, DroidMovement movement)
        {

            if (!shipLocations.Any(l => l.Location == movement.Destination))
            {
                var destinationType = Move(repairDroid, movement.Direction);
                var destinationLocation = new ShipLocation(movement.Destination, destinationType);
                shipLocations.Add(destinationLocation);

                if (destinationType == ShipLocationType.Wall) { return; }

                MapRoom(repairDroid, shipLocations, destinationLocation);
                Move(repairDroid, movement.ReturnDirection);
            }
        }

        private ShipLocationType Move(Computer repairDroid, DroidDirection direction)
        {
            var (_, outputs) = repairDroid.Resume((int)direction);
            return (ShipLocationType)outputs.Last();
        }
    }
}
