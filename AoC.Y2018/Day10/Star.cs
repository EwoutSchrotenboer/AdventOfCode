    using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Star
    {
        public long InitialX { get; set; }
        public long InitialY { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long VX { get; set; }
        public long VY { get; set; }

        public Star(long x, long y, long vx, long vy)
        {
            X = x;
            InitialX = x;
            Y = y;
            InitialY = y;
            VX = vx;
            VY = vy;
        }
    }
}
