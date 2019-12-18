using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class VaultKey
    {
        public char Name { get; }
        public int Steps { get; }

        // More internet-inspired optimalisation, comparing ints is faster than strings/objects
        public int Obstacles { get; set; }

        public VaultKey(char name, int steps, int obstacles)
        {
            Name = name;
            Steps = steps;
            Obstacles = obstacles;
        }
    }
}

