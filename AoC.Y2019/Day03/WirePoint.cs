using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class WirePoint
    {
        public Point Location { get; set; }
        public int Step { get; set; }

        public WirePoint(Point location, int step)
        {
            Location = location;
            Step = step;
        }
    }
}
