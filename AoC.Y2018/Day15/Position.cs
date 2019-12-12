using System.Collections.Generic;
using System.Drawing;

namespace AoC.Y2018.Days
{
    internal class Position
    {
        public int ReadingOrderValue { get; set; }
        public Point Point { get; }
        public Unit Unit { get; set; }
        public bool HasCreature => Unit != null;

        public bool HasEnemyFor(Unit other) => Unit?.IsEnemyFor(other) ?? false;

        public Position Up { get; set; }
        public Position Left { get; set; }
        public Position Right { get; set; }
        public Position Down { get; set; }

        public Position(int x, int y, int readingOrderValue, Unit creature = null)
        {
            ReadingOrderValue = readingOrderValue;
            Point = new Point(x, y);
            Unit = creature;
            if (creature != null) creature.Position = this;
        }

        public void ConnectToPositionAbove(Position other)
        {
            other.Down = this;
            this.Up = other;
        }

        public void ConnectToPositionToTheLeft(Position other)
        {
            other.Right = this;
            this.Left = other;
        }

        public List<Position> EnumerateAdjacentPositionsInReadingOrder()
        {
            var list = new List<Position>();
            if (Up != null) list.Add(Up);
            if (Left != null) list.Add(Left);
            if (Right != null) list.Add(Right);
            if (Down != null) list.Add(Down);
            return list;
        }

        public List<Unit> EnumerateAdjacentUnits()
        {
            var list = new List<Unit>();
            if (Up?.Unit != null) list.Add(Up.Unit);
            if (Left?.Unit != null) list.Add(Left.Unit);
            if (Right?.Unit != null) list.Add(Right.Unit);
            if (Down?.Unit != null) list.Add(Down.Unit);
            return list;
        }
    }
}