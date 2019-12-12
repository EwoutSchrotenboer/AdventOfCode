using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Train
    {
        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public Turn Turn { get; set; } = Turn.Left;
        public Direction Direction { get; set; }
        public bool Crashed { get; set; } = false; // X
        public int CrashTick { get; set; } = -1;

        public Train(int x, int y, char character)
        {
            X = x;
            Y = y;

            switch (character)
            {
                case '^':
                    Direction = Direction.North;
                    break;
                case '>':
                    Direction = Direction.East;
                    break;
                case 'v':
                    Direction = Direction.South;
                    break;
                case '<':
                    Direction = Direction.West;
                    break;
            }
        }

        public void Move(char[,] map)
        {
            if (Crashed)
            {
                return;
            }

            switch (Direction)
            {
                case Direction.North: Y -= 1; break;
                case Direction.South: Y += 1; break;
                case Direction.West:  X -= 1; break;
                case Direction.East:  X += 1; break;
            }

            var newMapPosChar = map[X, Y];

            switch (newMapPosChar)
            {
                case Constants.crossing:
                    this.SetDirection(Turn);
                    this.SetNextTurn();
                    break;
                case Constants.SWNE:
                case Constants.SENW:
                    this.SetDirection(newMapPosChar);
                    break;
                default:
                    // do nothing
                    break;
            }
        }

        private void SetDirection(Turn turn)
        {
            if (turn == Turn.Straight) { return; }
            Direction = GetDirection(Direction, turn);
        }

        private void SetDirection (char bend)
        {
            // SWNE: S <-> E, N <-> W
            // SENW: S <-> W, N <-> E
            switch (Direction, bend)
            {
                case (Direction.North, Constants.SWNE): Direction = Direction.West; break;
                case (Direction.East, Constants.SWNE): Direction = Direction.South; break;
                case (Direction.South, Constants.SWNE): Direction = Direction.East; break;
                case (Direction.West, Constants.SWNE): Direction = Direction.North; break;
                case (Direction.North, Constants.SENW): Direction = Direction.East; break;
                case (Direction.East, Constants.SENW): Direction = Direction.North; break;
                case (Direction.South, Constants.SENW): Direction = Direction.West; break;
                case (Direction.West, Constants.SENW): Direction = Direction.South; break;
                case (_, _): break;
            }
        }

        private void SetNextTurn()
        {
            switch (Turn)
            {
                case Turn.Left:
                    Turn = Turn.Straight;
                    break;
                case Turn.Straight:
                    Turn = Turn.Right;
                    break;
                case Turn.Right:
                    Turn = Turn.Left;
                    break;
            }
        }

        private Direction GetDirection(Direction current, Turn turn)
        {
            var left = turn == Turn.Left;

            return current switch
            {
                Direction.North => left ? Direction.West : Direction.East,
                Direction.South => left ? Direction.East : Direction.West,
                Direction.West => left ? Direction.South : Direction.North,
                Direction.East => left ? Direction.North : Direction.South,
                _ => current,
            };
        }
    }
}
