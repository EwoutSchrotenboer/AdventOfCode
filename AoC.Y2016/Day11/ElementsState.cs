using System;

namespace AoC.Y2016.Days
{
    internal class ElementsState : IEquatable<ElementsState>
    {
        public int Elevator { get; set; }
        public ulong Items { get; set; }
        public int Steps { get; set; }

        public ElementsState(ulong items, int elevator, int steps)
        {
            Items = items;
            Elevator = elevator;
            Steps = steps;
        }

        public ElementsState(ulong items) : this(items, 0, 0)
        {
        }

        public bool Equals(ElementsState other) => Items == other.Items && Elevator == other.Elevator;

        public override int GetHashCode() => Elevator ^ Items.GetHashCode();
    }
}
