using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC.Helpers.Utils
{
    public static partial class Extensions
    {
        public static Point Up(this Point point) => new Point(point.X, point.Y - 1);

        public static Point Left(this Point point) => new Point(point.X - 1, point.Y);

        public static Point Right(this Point point) => new Point(point.X + 1, point.Y);

        public static Point Down(this Point point) => new Point(point.X, point.Y + 1);

        public static Point MoveTo(this Point current, Direction direction) =>
           direction switch
           {
               Direction.Up => current.Up(),
               Direction.Left => current.Left(),
               Direction.Down => current.Down(),
               Direction.Right => current.Right(),
               _ => throw new Exception("Invalid direction")
           };

        public static Direction TurnTo(this Direction current, Turn turn) =>
            (current, turn) switch
            {
                (Direction.Up, Turn.Left) => Direction.Left,
                (Direction.Up, Turn.Right) => Direction.Right,
                (Direction.Right, Turn.Left) => Direction.Up,
                (Direction.Right, Turn.Right) => Direction.Down,
                (Direction.Down, Turn.Left) => Direction.Right,
                (Direction.Down, Turn.Right) => Direction.Left,
                (Direction.Left, Turn.Left) => Direction.Down,
                (Direction.Left, Turn.Right) => Direction.Up,
                _ => throw new Exception($"invalid input ({turn})")
            };

        public static Direction GetDirection(this char character) =>
            character switch 
            {
                '^' => Direction.Up,
                '>' => Direction.Right,
                'v' => Direction.Down,
                '<' => Direction.Left,
                _ => throw new Exception("Could not determine direction.")
            };

        public static AoCPoint Up(this AoCPoint point) => new AoCPoint(point.X, point.Y - 1);
        public static AoCPoint Left(this AoCPoint point) => new AoCPoint(point.X - 1, point.Y);
        public static AoCPoint Right(this AoCPoint point) => new AoCPoint(point.X + 1, point.Y);
        public static AoCPoint Down(this AoCPoint point) => new AoCPoint(point.X, point.Y + 1);

        public static IEnumerable<AoCPoint> Adjacent(this AoCPoint point)
        {
            yield return point.Up();
            yield return point.Right();
            yield return point.Down();
            yield return point.Left();
        }
    }
}
