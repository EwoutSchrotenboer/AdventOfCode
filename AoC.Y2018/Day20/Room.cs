using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Room
    {
        public Point Point { get; set; }
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }

        public Room CreateNewRoom(char dir)
        {
            if (dir == 'N') return CreateNewRoomNorth();
            if (dir == 'E') return CreateNewRoomEast();
            if (dir == 'S') return CreateNewRoomSouth();
            if (dir == 'W') return CreateNewRoomWest();
            throw new NotSupportedException();
        }

        public Room Link(Room other, char dir)
        {
            if (dir == 'N') { other.South = this; North = other; }
            if (dir == 'E') { other.West = this; East = other; }
            if (dir == 'S') { other.North = this; South = other; }
            if (dir == 'W') { other.East = this; West = other; }
            return other;
        }

        public Room CreateNewRoomNorth() => North = new Room { Point = Point.Up(), South = this };
        public Room CreateNewRoomEast() => East = new Room { Point = Point.Right(), West = this };
        public Room CreateNewRoomSouth() => South = new Room { Point = Point.Down(), North = this };
        public Room CreateNewRoomWest() => West = new Room { Point = Point.Left(), East = this };
    }
}
