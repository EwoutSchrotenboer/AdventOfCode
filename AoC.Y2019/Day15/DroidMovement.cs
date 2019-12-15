using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC.Y2019.Days
{
    public class DroidMovement
    {
        public Point Destination { get; }
        public DroidDirection Direction { get; }
        public DroidDirection ReturnDirection { get; }

        public DroidMovement(Point destination, DroidDirection direction, DroidDirection returnDirection)
        {
            Destination = destination;
            Direction = direction;
            ReturnDirection = returnDirection;
        }
    }
}
