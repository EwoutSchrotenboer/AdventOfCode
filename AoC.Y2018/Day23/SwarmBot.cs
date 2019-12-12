using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class SwarmBot
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public int SignalStrength { get; }

        public SwarmBot(string raw)
        {
            // "pos=<0,0,0>, r=4"
            var split = raw.Split(' ');
            var pos = split[0].Split('=')[1].RemoveChars(new char[] { '<', '>' });
            var positions = pos.Split(',');

            X = int.Parse(positions[0]);
            Y = int.Parse(positions[1]);
            Z = int.Parse(positions[2]);
            SignalStrength = int.Parse(split[1].Split('=')[1]);
        }

        public SwarmBot(int x, int y, int z, int strength)
        {
            X = x;
            Y = y;
            Z = z;
            SignalStrength = strength;
        }

        public int Distance(int otherX, int otherY, int otherZ) => Manhattan.GetManhattanDistance(X, Y, Z, otherX, otherY, otherZ);
        public int Distance(SwarmBot other) => Distance(other.X, other.Y, other.Z);
        public bool InRange((int x, int y, int z) coordinate) => Distance(coordinate.x, coordinate.y, coordinate.z) <= SignalStrength;
        public bool InRange(SwarmBot other) => InRange((other.X, other.Y, other.Z));
    }
}
