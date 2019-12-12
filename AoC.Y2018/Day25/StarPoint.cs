using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class StarPoint
    {
        public int[] Coordinates { get; } = Array.Empty<int>();
        public HashSet<StarPoint> Neighbors { get; } = new HashSet<StarPoint>();

        public StarPoint(int x, int y, int z, int t)
        {
            Coordinates = new int[] { x, y, z, t };
        }

        public int Distance(StarPoint other) => 
                Math.Abs(Coordinates[0] - other.Coordinates[0])
                + Math.Abs(Coordinates[1] - other.Coordinates[1])
                + Math.Abs(Coordinates[2] - other.Coordinates[2])
                + Math.Abs(Coordinates[3] - other.Coordinates[3]);
    }
}
