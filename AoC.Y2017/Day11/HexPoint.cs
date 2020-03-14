using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2017.Days
{
    internal class HexPoint : IEquatable<HexPoint>
    {
        public static HexPoint Origin() => new HexPoint(0, 0, 0);

        public int X { get; } = -1;
        public int Y { get; } = -1;
        public int Z { get; } = -1;


        public HexPoint() { }

        public HexPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public (int, int, int) GetCoords() => (X, Y, Z);

        public bool Equals(HexPoint other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public HexPoint Adjacent(int xOffset, int yOffset, int zOffset) => new HexPoint(X + xOffset, Y + yOffset, Z + zOffset);

        public override int GetHashCode() => X ^ Y ^ Z ^ 397;

        public override string ToString() => $"[{X},{Y},{Z}]";
    }
}
