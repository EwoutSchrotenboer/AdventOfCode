using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC.Helpers.Utils
{
    public static class Manhattan
    {
        public static int ManhattanDistanceTo(this Point p1, Point p2) => GetManhattanDistance(p1.X, p1.Y, p2.X, p2.Y);
        public static int ManhattanDistanceTo(this AoCPoint p1, AoCPoint p2) => GetManhattanDistance(p1.X, p1.Y, p2.X, p2.Y);
        public static int GetManhattanDistance(Point p1, Point p2) => GetManhattanDistance(p1.X, p1.Y, p2.X, p2.Y);
        public static int GetManhattanDistance(AoCPoint p1, AoCPoint p2) => GetManhattanDistance(p1.X, p1.Y, p2.X, p2.Y);
        public static int GetManhattanDistance(Point p, int x, int y) => GetManhattanDistance(p.X, p.Y, x, y);
        public static int GetManhattanDistance(AoCPoint p, int x, int y) => GetManhattanDistance(p.X, p.Y, x, y);
        public static int GetManhattanDistance(int x1, int y1, int x2, int y2) => Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        public static int GetManhattanDistance(int x1, int y1, int z1, int x2, int y2, int z2) => Math.Abs(x1 - x2) + Math.Abs(y1 - y2) + Math.Abs(z1 - z2);
    }
}
