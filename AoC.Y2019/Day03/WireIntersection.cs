using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class WireIntersection
    {
        public Point Location { get; set; }
        public int StepsA { get; set; }
        public int StepsB { get; set; }
        public int ManhattanToSource { get; set; }

        public WireIntersection(WirePoint pointA, WirePoint pointB)
        {
            Location = pointA.Location;
            StepsA = pointA.Step;
            StepsB = pointB.Step;
            ManhattanToSource = Location.ManhattanDistanceTo(new Point(0, 0));
        }
    }
}
