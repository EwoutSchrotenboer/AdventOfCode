using AoC.Helpers.Utils;
using System.Drawing;

namespace AoC.Y2019.Days
{
    public class Tile
    {
        public Point Position { get; }
        public int Score { get; } = 0;
        public TileType TileType { get; }

        public Tile(long x, long y, long type) : this((int)x, (int)y, (int)type)
        {
        }

        public Tile(int x, int y, int type)
        {
            if (x == -1 && y == 0)
            {
                TileType = TileType.Score;
                Score = type;
            }
            else
            {
                TileType = (TileType)type;
                Position = new Point(x, y);
            }
        }

        public override string ToString()
        {
            return $"[{Position.X},{Position.Y}] {TileType}";
        }
    }
}