using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class ReplicantPositions : IEquatable<ReplicantPositions>
    {
        public AoCPoint RickDeckard { get; set; }
        public AoCPoint RoyBatty { get; set; }
        public AoCPoint LeonKowalski { get; set; }
        public AoCPoint SapperMorton { get; set; }

        public AoCPoint this[int index]
        {
            get => index switch
            {
                1 => RickDeckard,
                2 => RoyBatty,
                3 => LeonKowalski,
                4 => SapperMorton,
                _ => throw new Exception("Witty name generator ran out")
            };
            set
            {
                switch (index)
                {
                    case 1: RickDeckard = value; break;
                    case 2: RoyBatty = value; break;
                    case 3: LeonKowalski = value; break;
                    case 4: SapperMorton = value; break;
                }
            }
        }

        public ReplicantPositions Clone() => new ReplicantPositions
        {
            RickDeckard = RickDeckard,
            RoyBatty = RoyBatty,
            LeonKowalski = LeonKowalski,
            SapperMorton = SapperMorton
        };

        public bool Equals(ReplicantPositions other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(RickDeckard, other.RickDeckard) 
                && Equals(RoyBatty, other.RoyBatty) 
                && Equals(LeonKowalski, other.LeonKowalski) 
                && Equals(SapperMorton, other.SapperMorton);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RickDeckard, RoyBatty, LeonKowalski, SapperMorton);
        }
    }
}
