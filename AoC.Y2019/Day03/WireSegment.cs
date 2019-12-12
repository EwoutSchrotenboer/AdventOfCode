using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class WireSegment
    {
        public Direction Direction { get; set; }
        public int Length { get; set; }

        public WireSegment(char direction, int length)
        {
            Direction = GetDirection(direction);
            Length = length;
        }

        private static Direction GetDirection(char direction) =>
            direction switch
            {
                'U' => Direction.Up,
                'R' => Direction.Right,
                'D' => Direction.Down,
                'L' => Direction.Left,
                _ => throw new Exception("Invalid direction")
            };
    }
}
