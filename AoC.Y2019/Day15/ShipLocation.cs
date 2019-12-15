using AoC.Helpers.Utils;
using System.Drawing;

namespace AoC.Y2019.Days
{
    public class ShipLocation
    {
        public Point Location { get; private set; }
        public long Scratch { get; set; } = 0;
        public bool OxygenSystem { get; set; } = false;
        public bool Start { get; set; } = false;
        public ShipLocationType Type { get; }
        public bool Visited { get; set; } = false;

        public ShipLocation(Point location, ShipLocationType type, bool start = false)
        {
            Location = location;
            Type = type;
            Start = start;

            if (Type == ShipLocationType.OxygenSystem)
            {
                OxygenSystem = true;
            }
        }

        public DroidMovement Move(DroidDirection robotDirection) =>
            robotDirection switch
            {
                DroidDirection.North => new DroidMovement(Location.Up(), DroidDirection.North, DroidDirection.South),
                DroidDirection.South => new DroidMovement(Location.Down(), DroidDirection.South, DroidDirection.North),
                DroidDirection.West => new DroidMovement(Location.Left(), DroidDirection.West, DroidDirection.East),
                DroidDirection.East => new DroidMovement(Location.Right(), DroidDirection.East, DroidDirection.West)
            };

        public void UpdateLocationOffset(int offsetX, int offsetY)
        {
            Location = new Point(Location.X + offsetX, Location.Y + offsetY);
        }
    }
}
