using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Helpers.Utils
{
    public class AoCPoint : IEquatable<AoCPoint>
    {
        public int X { get; } = -1;
        public int Y { get; } = -1;

        public AoCPoint() { }

        public AoCPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(AoCPoint other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode() => X ^ Y ^ 397;

        public override string ToString() => $"[{X},{Y}]";
    }
}
