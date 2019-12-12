using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Marble
    {
        public Marble CounterClockwise { get; set; }
        public Marble Clockwise { get; set; }
        public bool Current { get; set; } = true;
        public long Value { get; set; } = 0;

        public Marble()
        {
            CounterClockwise = this;
            Clockwise = this;
        }

        public Marble(Marble counterClockwise, Marble clockwise, long value)
        {
            CounterClockwise = counterClockwise;
            Clockwise = clockwise;
            Value = value;
        }

        public Marble RegularTurn(long value)
        {
            var pos1 = this.GetRelative(1, true);
            var pos2 = this.GetRelative(2, true);
            var newMarble = new Marble(pos1, pos2, value);

            pos1.Clockwise = newMarble;
            pos2.CounterClockwise = newMarble;

            this.Current = false;
            return newMarble;
        }

        public (long score, Marble current) SpecialTurn(long value)
        {
            var score = value;
            var marbleToRemove = this.GetRelative(7, false);
            score += marbleToRemove.Value;

            var counterClockwise = marbleToRemove.GetRelative(1, false);
            var clockWise = marbleToRemove.GetRelative(1, true);

            counterClockwise.Clockwise = clockWise;
            clockWise.CounterClockwise = counterClockwise;
            clockWise.Current = true;

            return (score, clockWise);
        }


        private Marble GetRelative(long steps, bool clockwise)
        {
            if (steps <= 0) { return this; }

            var next = clockwise ? this.Clockwise : this.CounterClockwise;
            return next.GetRelative(steps - 1, clockwise);
        }
    }
}
