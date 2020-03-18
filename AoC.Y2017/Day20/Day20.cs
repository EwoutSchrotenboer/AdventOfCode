using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day20 : BaseDay
    {
        public Day20() : base(2017, 20)
        {
        }

        public Day20(IEnumerable<string> inputLines) : base(2017, 20, inputLines)
        {
        }

        protected override IConvertible PartOne() => ParseInput(inputLines)
            .OrderBy(c => c.Manhattan(c.Acceleration))
            .ThenBy(c => c.Manhattan(c.Velocity))
            .ThenBy(c => c.Manhattan(c.Position))
            .First().Id;

        protected override IConvertible PartTwo()
        {
            var particles = ParseInput(inputLines);

            var turnsWithoutCollision = 0;
            var particleCount = particles.Count;

            while (turnsWithoutCollision < 10)
            {
                particleCount = particles.Count;
                particles.ForEach(p => p.Update());
                particles.RemoveAll(p => particles.Count(particle => particle.Position == p.Position) > 1);

                if (particleCount == particles.Count) { turnsWithoutCollision++; }
                else { turnsWithoutCollision = 0; }
            }

            return particles.Count;
        }

        private List<Particle> ParseInput(IEnumerable<string> inputLines) => inputLines.Select((l, i) => new Particle(i, l)).ToList();
    }
}
