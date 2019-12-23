using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;

namespace AoC.Y2019.Days
{
    public class Day14 : BaseDay
    {
        private const string Fuel = "FUEL";
        private const string Ore = "ORE";
        private const long OreCount = 1000000000000;

        private readonly Dictionary<string, Reaction> reactions = new Dictionary<string, Reaction>();
        private readonly Dictionary<string, long> storage = new Dictionary<string, long>();

        public Day14() : base(2019, 14)
        {
        }

        public Day14(IEnumerable<string> inputLines) : base(2019, 14, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            storage.Clear();
            reactions.Clear();
            ParseInput(inputLines);
            storage.Add(Ore, 0);
            CreateReagent(Fuel, 1);

            return storage[Ore];
        }

        protected override IConvertible PartTwo()
        {
            storage.Clear();
            reactions.Clear();
            ParseInput(inputLines);
            storage.Add(Ore, OreCount);

            long maxFuel = 1, oreNeeded = 0;

            // get an estimate range
            while (oreNeeded <= OreCount)
            {
                maxFuel *= 10;
                storage.Clear();
                storage.Add(Ore, 0);

                CreateReagent(Fuel, maxFuel);
                oreNeeded = storage[Ore];
            }

            var minFuel = maxFuel / 10;

            // get the exact count
            while (minFuel != maxFuel)
            {
                storage.Clear();
                storage.Add(Ore, 0);

                var currentFuelGoal = (long)Math.Ceiling((maxFuel + minFuel) / 2.0);
                CreateReagent(Fuel, currentFuelGoal);

                if (storage[Ore] <= OreCount) { minFuel = currentFuelGoal; }
                else { maxFuel = currentFuelGoal - 1; }
            }

            return minFuel;
        }

        private void CreateReagent(string output, long amount)
        {
            var reaction = reactions[output];
            var multiplier = (long)Math.Ceiling(amount / (double)reaction.Output.Amount);

            foreach (var input in reaction.Inputs)
            {
                if (input.Name == Ore) { storage[Ore] += multiplier * input.Amount; }
                else
                {
                    var storedReagent = storage.GetOrCreate(input.Name);
                    if (storedReagent < multiplier * input.Amount)
                    {
                        CreateReagent(input.Name, multiplier * input.Amount - storage[input.Name]);
                    }

                    storage[input.Name] -= multiplier * input.Amount;
                }
            }

            storage.GetOrCreate(output);
            storage[output] += multiplier * reaction.Output.Amount;
        }

        private void ParseInput(IEnumerable<string> inputLines)
        {
            foreach (var inputLine in inputLines)
            {
                var reaction = new Reaction(inputLine);
                reactions.Add(reaction.Output.Name, reaction);
            }
        }
    }
}
