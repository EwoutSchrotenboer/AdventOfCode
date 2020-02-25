using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day10 : BaseDay
    {
        public Day10() : base(2016, 10)
        {
        }

        public Day10(IEnumerable<string> inputLines) : base(2016, 10, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var bots = ParseInput(inputLines);
            var (_, updatedBots) = RunRobots(bots);

            return updatedBots.Single(b => b.Values.Contains(61) && b.Values.Contains(17)).Id;
        }

        protected override IConvertible PartTwo()
        {
            var bots = ParseInput(inputLines);
            var (outputs, _) = RunRobots(bots);

            var values = outputs.Where(o => o.id == 0 || o.id == 1 || o.id == 2).Select(o => o.value);
            var product = 1;

            foreach (var v in values)
            {
                product *= v;
            }

            return product;
        }

        private static (List<(int id, int value)> outputs, List<BalanceBot> bots) RunRobots(List<BalanceBot> bots)
        {
            var outputs = new List<(int, int)>();
            while (bots.Any(b => b.Values.Count < 2))
            {
                foreach (var b in bots.Where(b => b.Values.Count == 2 && b.Processed == false))
                {
                    var lowVal = b.Values.Min();
                    var highVal = b.Values.Max();

                    if (b.LowOutput.type == "output") { outputs.Add((b.LowOutput.id, lowVal)); }
                    else { bots.Single(t => t.Id == b.LowOutput.id).Values.Add(lowVal); }

                    if (b.HighOutput.type == "output") { outputs.Add((b.HighOutput.id, highVal)); }
                    else { { bots.Single(t => t.Id == b.HighOutput.id).Values.Add(highVal); } }

                    b.Processed = true;
                }
            }

            return (outputs, bots);
        }

        private static List<BalanceBot> ParseInput(IEnumerable<string> inputLines)
        {
            var bots = new List<BalanceBot>();
            var values = new List<(int, int)>();

            foreach (var line in inputLines)
            {
                if (line.StartsWith("value"))
                {
                    var items = line.Split(' ');
                    values.Add((int.Parse(items[1]), int.Parse(items[5])));
                }
                else
                {
                    bots.Add(new BalanceBot(line));
                }
            }

            foreach (var (value, botId) in values)
            {
                bots.Single(b => b.Id == botId).Values.Add(value);
            }

            return bots;
        }
    }
}
