using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day13 : BaseDay
    {
        public Day13() : base(2018, 13)
        {
        }

        public Day13(IEnumerable<string> inputLines) : base(2018, 13, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (map, trains) = ParseMap(this.inputLines.ToList());

            while(!trains.Any(t => t.Crashed))
            {
                UpdateMap(1, map, trains);
            }

            var crashedTrain = trains.Where(t => t.Crashed).First();

            return $"{crashedTrain.X},{crashedTrain.Y}";
        }

        protected override IConvertible PartTwo()
        {
            var (map, trains) = ParseMap(this.inputLines.ToList());

            while (trains.Count() > 1)
            {
                UpdateMap(1, map, trains);

                trains = trains.Where(t => t.Crashed == false).ToList();
            }

            var finalTrain = trains.Single();

            return $"{finalTrain.X},{finalTrain.Y}";
        }

        private static (char[,] map, List<Train> trains) ParseMap(List<string> input)
        {
            var maxWidth = input.Max(i => i.Length);
            var maxHeight = input.Count();
            var trains = new List<Train>();
            var trainChars = new char[] { Constants.north, Constants.south, Constants.west, Constants.east };

            var map = new char[maxWidth, maxHeight];

            for (int heightIndex = 0; heightIndex < maxHeight; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < maxWidth; widthIndex++)
                {
                    var character = input[heightIndex][widthIndex];

                    if (trainChars.Contains(character))
                    {
                        var train = new Train(widthIndex, heightIndex, character);
                        trains.Add(train);

                        map[widthIndex, heightIndex] = (train.Direction == Direction.South || train.Direction == Direction.North)
                            ? Constants.vertical
                            : Constants.horizontal;
                    }
                    else
                    {
                        map[widthIndex, heightIndex] = input[heightIndex][widthIndex];
                    }
                }
            }

            return (map, trains);
        }

        private static void UpdateMap(int ticks, char[,] map, List<Train> trains)
        {
            for (int i = 0; i < ticks; i++)
            {
                var orderedTrains = trains.OrderBy(t => t.Y).ThenBy(t => t.X);

                foreach (var orderedTrain in orderedTrains)
                {
                    orderedTrain.Move(map);

                    var collisionTrains = orderedTrains.Where(o => o.X == orderedTrain.X && o.Y == orderedTrain.Y);

                    if (collisionTrains.Count() > 1)
                    {
                        // map[orderedTrain.X, orderedTrain.Y] = Constants.collision;

                        foreach (var ct in collisionTrains)
                        {
                            ct.Crashed = true;
                            ct.CrashTick = i;
                        }
                    }
                }
            }
        }
    }
}