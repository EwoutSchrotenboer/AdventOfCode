using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Clay
    {
        public Clay(HashSet<Point> coords)
        {
            this.Coords = coords;
            MinX = coords.Select(p => p.X).Min();
            MaxX = coords.Select(p => p.X).Max();
            MinY = coords.Select(p => p.Y).Min();
            MaxY = coords.Select(p => p.Y).Max();
        }

        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }
        public HashSet<Point> Coords { get; }
    }
}
