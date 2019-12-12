using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day09 : BaseDay
    {
        public Day09() : base(2018, 9)
        {

        }

        public Day09(IEnumerable<string> inputLines) : base(2018, 9, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var (players, lastMarble) = PrepareGame(inputLines.Single());
            return PlayGame(players, lastMarble);
        }

        protected override IConvertible PartTwo()
        {
            var (players, lastMarble) = PrepareGame(inputLines.Single());
            return PlayGame(players, lastMarble * 100);
        }

        private static (long players, long lastMarble) PrepareGame(string inputLine)
        {
            var splitString = inputLine.Split(' ');
            var players = long.Parse(splitString[0]);
            var lastMarble = long.Parse(splitString[6]);

            return (players, lastMarble);
        }

        private static long PlayGame(long players, long lastMarble)
        {
            var playerScores = new long[players + 1];
            var marble = new Marble();

            for (long i = 1; i <= lastMarble; i++)
            {
                var currentPlayer = i % players;

                if (i % 23 == 0)
                {
                    var (score, newCurrent) = marble.SpecialTurn(i);

                    playerScores[currentPlayer] += score;
                    marble = newCurrent;
                }
                else
                {
                    marble = marble.RegularTurn(i);
                }
            }

            return playerScores.Max();
        }
    }
}