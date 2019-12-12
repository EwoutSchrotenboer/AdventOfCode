using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2018.Days
{
    internal class Pot
    {
        public long Index { get; set; }
        public bool Plant { get; set; }

        public Pot(long index, bool plant)
        {
            Index = index;
            Plant = plant;
        }

        public Pot Clone()
        {
            return new Pot(Index, Plant);
        }

        public override string ToString()
        {
            return Plant ? "#" : ".";
        }
    }
}
