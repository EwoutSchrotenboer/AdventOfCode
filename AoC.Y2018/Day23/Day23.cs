using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day23 : BaseDay
    {
        public Day23() : base(2018, 23)
        {
        }

        public Day23(IEnumerable<string> inputLines) : base(2018, 23, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var swarmBots = ParseInput(inputLines);
            var strongestBot = swarmBots.OrderByDescending(s => s.SignalStrength).First();

            return BotsInRange(strongestBot, swarmBots);
        }

        protected override IConvertible PartTwo()
        {
            var bots = ParseInput(inputLines);
            (int x, int y, int z) bestLocation = (0, 0, 0);
            var inRange = 0;
            var maxInRange = 0;
            var bestSum = 0;

            (int minX, int minY, int minZ, int maxX, int maxY, int maxZ) limits;
            int stepSize = (int)Math.Pow(2, 26);

            limits = (bots.Min(bot => bot.X), bots.Min(bot => bot.Y), bots.Min(bot => bot.Z), 
                bots.Max(bot => bot.X), bots.Max(bot => bot.Y), bots.Max(bot => bot.Z));

            var xRange = limits.maxX - limits.minX;
            var yRange = limits.maxY - limits.minY;
            var zRange = limits.maxZ - limits.minZ;

            do
            {
                maxInRange = 0;
                bestSum = int.MaxValue;
                for (int x = limits.minX; x < limits.maxX; x += stepSize)
                    for (int y = limits.minY; y < limits.maxY; y += stepSize)
                        for (int z = limits.minZ; z < limits.maxZ; z += stepSize)
                            if ((inRange = bots.Count(bot => bot.InRange((x, y, z)))) > maxInRange
                            || (inRange == maxInRange && Math.Abs(x) + Math.Abs(y) + Math.Abs(z) < bestSum))
                            {
                                maxInRange = inRange;
                                bestLocation = (x, y, z);
                                bestSum = Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
                            }

                stepSize /= 2;
                xRange /= 2;
                yRange /= 2;
                zRange /= 2;

                limits = (bestLocation.x - xRange / 2, bestLocation.y - yRange / 2, bestLocation.z - zRange / 2, bestLocation.x + xRange / 2, bestLocation.y + yRange / 2, bestLocation.z + zRange / 2);
            } while (stepSize >= 1);


            return bestSum;
        }

        private static int BotsInRange(SwarmBot sourceBot, List<SwarmBot> swarmBots)
        {
            var inRange = 0;

            // Bot itself is counted as in range of itself
            foreach (var swarmBot in swarmBots)
            {
                if (sourceBot.InRange(swarmBot))
                {
                    inRange++;
                }
            }

            return inRange;
        }

        private static List<SwarmBot> ParseInput(IEnumerable<string> inputLines)
        {
            var swarmBots = new List<SwarmBot>();

            foreach (var inputLine in inputLines)
            {
                swarmBots.Add(new SwarmBot(inputLine));
            }

            return swarmBots;
        }
    }
}