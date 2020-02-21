using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day14 : BaseDay
    {
		private static int raceLength;

        public Day14() : base(2015, 14)
        {
			raceLength = 2503;
        }

        public Day14(IEnumerable<string> inputLines) : base(2015, 14, inputLines)
        {
			raceLength = 1000;
        }

        protected override IConvertible PartOne()
		{
			var reindeers = ParseInput(inputLines);
			var (longestDistance, _) = RunRace(reindeers, raceLength);

			return longestDistance;
		}

        protected override IConvertible PartTwo()
		{
			var reindeers = ParseInput(inputLines);
			var (_, highestScore) = RunRace(reindeers, raceLength);

			return highestScore;
		}
    
        private static (int, int) RunRace(List<Reindeer> reindeers, int raceLength)
		{
			for (int i = 0; i < raceLength; i++)
			{
				foreach (var reindeer in reindeers)
				{
					if (reindeer.RestRemaining > 0)
					{
						reindeer.RestRemaining--;
						continue;
					}

					reindeer.BurstRemaining--;
					reindeer.Distance += reindeer.Speed;

					if (reindeer.BurstRemaining == 0)
					{
						reindeer.RestRemaining = reindeer.Rest;
						reindeer.BurstRemaining = reindeer.Burst;
					}
				}

				var lead = reindeers.OrderByDescending(r => r.Distance).First();
				lead.Score++;
			}

			return (reindeers.Max(r => r.Distance), reindeers.Max(r => r.Score));
		}

		private static List<Reindeer> ParseInput(IEnumerable<string> inputLines) => inputLines.Select(l => new Reindeer(l)).ToList();

	}
}
