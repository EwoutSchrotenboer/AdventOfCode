using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day12 : BaseDay
    {
        private static List<Moon> moons;
        private static int stepCount;

        public Day12() : base(2019, 12)
        {
            stepCount = 1000;
        }

        public Day12(IEnumerable<string> inputLines) : base(2019, 12, inputLines)
        {
            stepCount = 100;
        }

        protected override IConvertible PartOne()
        {
            ParseInput(inputLines);

            for (int i = 0; i < stepCount; i++)
            {
                ApplyTimeStep();
            }

            return moons.Sum(m => m.TotalEnergy());
        }

        protected override IConvertible PartTwo()
        {
            ParseInput(inputLines);
            var xStates = GetFirstPlaneClash(0);

            ParseInput(inputLines);
            var yStates = GetFirstPlaneClash(1);

            ParseInput(inputLines);
            var zStates = GetFirstPlaneClash(2);

            var lcd = Methods.LCM(new long[] { xStates.Count, yStates.Count, zStates.Count });

            return lcd;
        }

        private static HashSet<(int, int, int, int, int, int, int, int)> GetFirstPlaneClash(int plane)
        {
            var duplicate = false;
            var states = new HashSet<(int, int, int, int, int, int, int, int)>();

            while (!duplicate)
            {
                var state = ApplyPlaneTimeStep(plane);

                if (states.Contains(state))
                {
                    duplicate = true;
                }
                else
                {
                    states.Add(state);
                }
            }

            return states;
        }

        private static void ApplyTimeStep()
        {
            foreach (var (first, second) in GetPairs())
            {
                UpdateVelocity(first, second);
            }

            foreach (var moon in moons)
            {
                moon.UpdateCoordinates();
            }
        }

        private static (int, int, int, int, int, int, int, int) ApplyPlaneTimeStep(int plane)
        {
            foreach (var (first, second) in GetPairs())
            {
                switch (plane)
                {
                    case 0: UpdateXVelocity(first, second); break;
                    case 1: UpdateYVelocity(first, second); break;
                    case 2: UpdateZVelocity(first, second); break;
                }
            }

            foreach (var moon in moons)
            {
                moon.UpdateCoordinates();
            }

            return plane switch
            {
                0 => (moons[0].X, moons[1].X, moons[2].X, moons[3].X, moons[0].VX, moons[1].VX, moons[2].VX, moons[3].VX),
                1 => (moons[0].Y, moons[1].Y, moons[2].Y, moons[3].Y, moons[0].VY, moons[1].VY, moons[2].VY, moons[3].VY),
                2 => (moons[0].Z, moons[1].Z, moons[2].Z, moons[3].Z, moons[0].VZ, moons[1].VZ, moons[2].VZ, moons[3].VZ),
                _ => (0, 0, 0, 0, 0, 0, 0, 0)
            };
        }

        private static void UpdateVelocity(Moon first, Moon second)
        {
            UpdateXVelocity(first, second);
            UpdateYVelocity(first, second);
            UpdateZVelocity(first, second);
        }

        private static void UpdateXVelocity(Moon first, Moon second)
        {
            if (first.X != second.X)
            {
                if (first.X > second.X) { first.DXV(-1); second.DXV(1); }
                else { first.DXV(1); second.DXV(-1); }
            }
        }

        private static void UpdateYVelocity(Moon first, Moon second)
        {
            if (first.Y != second.Y)
            {
                if (first.Y > second.Y) { first.DYV(-1); second.DYV(1); }
                else { first.DYV(1); second.DYV(-1); }
            }
        }

        private static void UpdateZVelocity(Moon first, Moon second)
        {
            if (first.Z != second.Z)
            {
                if (first.Z > second.Z) { first.DZV(-1); second.DZV(1); }
                else { first.DZV(1); second.DZV(-1); }
            }
        }

        private static List<(Moon first, Moon second)> GetPairs()
        {
            var pairs = new List<(Moon, Moon)>();

            for (int i = 0; i < moons.Count(); i++)
            {
                var first = moons[i];

                foreach (var other in moons.Skip(i + 1))
                {
                    pairs.Add((first, other));
                }
            }

            return pairs;
        }

        private static void ParseInput(IEnumerable<string> inputLines)
        {
            moons = new List<Moon>();

            foreach (var inputLine in inputLines)
            {
                moons.Add(new Moon(inputLine));
            }
        }
    }
}