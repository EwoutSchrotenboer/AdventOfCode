using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal enum Track
    {
        Vertical, // |
        Horizontal, // -
        Intersection, // +
        SWNE, // /
        SENW, // \
    }

    internal enum Direction
    {
        North, // ^
        East, // >
        South, // v
        West // <
    }

    internal enum Turn
    {
        Left,
        Straight,
        Right
    }
}
