using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class LocationEqualityComparer : IEqualityComparer<WirePoint>
    {
        public bool Equals([AllowNull] WirePoint first, [AllowNull] WirePoint second)
        {
            if (first == null && second == null) return true;
            else if (first == null && second != null) return false;
            else if (first != null && second == null) return false;

            return first.Location.X == second.Location.X
                    && first.Location.Y == second.Location.Y;
        }

        public int GetHashCode([DisallowNull] WirePoint obj)
        {
            return (obj.Location.X ^ obj.Location.Y) * 397;
        }
    }
}
