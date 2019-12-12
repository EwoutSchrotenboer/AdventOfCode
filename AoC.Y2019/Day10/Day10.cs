using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day10 : BaseDay
    {
        public Day10() : base(2019, 10)
        {
        }

        public Day10(IEnumerable<string> inputLines) : base(2019, 10, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var asteroidField = ParseInput(inputLines.ToList());
            var (count, _) = CountVisibleAsteroidsForAll(asteroidField);
            return count;
        }

        protected override IConvertible PartTwo()
        {
            var asteroidField = ParseInput(inputLines.ToList());
            var (_, monitoringStation) = CountVisibleAsteroidsForAll(asteroidField);

            var goal = 200;

            while (monitoringStation.Visible.Count < goal)
            {
                goal -= monitoringStation.Visible.Count;

                foreach (Asteroid asteroid in monitoringStation.Visible)
                {
                    asteroidField.Remove(asteroid);
                }

                CountVisibleAsteroids(monitoringStation, asteroidField);
            }

            foreach (Asteroid asteroid in monitoringStation.Visible)
            {
                asteroid.Angle = -Math.Atan2(asteroid.X - monitoringStation.X, asteroid.Y - monitoringStation.Y);
            }
            monitoringStation.Visible.Sort((a, b) => a.Angle.CompareTo(b.Angle));

            Asteroid target = monitoringStation.Visible[goal - 1];

            return target.X * 100 + target.Y;
        }

        private static int Absolute(int x) => Math.Abs(x);

        private static void CountVisibleAsteroids(Asteroid source, List<Asteroid> asteroidField)
        {
            foreach (Asteroid destination in asteroidField)
            {
                if (destination != source && InLineOfSight(source, destination, asteroidField)) { source.Visible.Add(destination); }
            }
        }

        private static (int max, Asteroid bestAsteroid) CountVisibleAsteroidsForAll(List<Asteroid> asteroidField)
        {
            foreach (Asteroid asteroid in asteroidField)
            {
                CountVisibleAsteroids(asteroid, asteroidField);
            }

            var best = asteroidField[0];

            foreach (Asteroid asteroid in asteroidField)
            {
                if (asteroid.Visible.Count > best.Visible.Count) { best = asteroid; }
            }

            return (best.Visible.Count, best);
        }

        private static bool InLineOfSight(Asteroid source, Asteroid destination, List<Asteroid> asteroidField)
        {
            int dx = Absolute(destination.X - source.X);
            int dy = Absolute(destination.Y - source.Y);
            foreach (Asteroid a in asteroidField)
            {
                if (a != source && a != destination)
                {
                    int dxa = a.X - source.X;
                    int dya = a.Y - source.Y;
                    if (Absolute(dxa) <= dx && Absolute(dya) <= dy && SameAngle(source, destination, a))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool SameAngle(Asteroid source, Asteroid first, Asteroid second)
        {
            if (State(first.X - source.X) != State(second.X - source.X)) return false;
            if (State(first.Y - source.Y) != State(second.Y - source.Y)) return false;
            if (first.X == source.X && second.X == source.X) return true;
            if (first.Y == source.Y && second.Y == source.Y) return true;
            return ((first.X - source.X) * (second.Y - source.Y) == (second.X - source.X) * (first.Y - source.Y));
        }

        private static int State(int x) => (x > 0) ? 1 : (x < 0) ? -1 : 0;

        private List<Asteroid> ParseInput(List<string> inputLines)
        {
            var asteroidField = new List<Asteroid>();

            for (int y = 0; y < inputLines.Count(); y++)
            {
                var line = inputLines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#') { asteroidField.Add(new Asteroid(x, y)); }
                }
            }

            return asteroidField;
        }
    }
}