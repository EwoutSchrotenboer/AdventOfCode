using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AoC.Y2019.Days
{
    public class Day22 : BaseDay
    {
        public Day22() : base(2019, 22)
        {
        }

        public Day22(IEnumerable<string> inputLines) : base(2019, 22, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var deck = Shuffle(Enumerable.Range(0, 10007).ToArray(), ParseInput(inputLines));
            return Array.IndexOf(deck, 2019);
        }

        // This was not fun at all. I'm all for learning new things and optimizing solutions, but this was pretty hardcore math.
        // Thanks to u/mcpower_ who posted a great explanation of the algorithm and theory used, I was able to "solve" it. I
        // guess it proves that .. I can google things? Apply things I do not fully grasp? Good thing the other puzzles are great.
        protected override IConvertible PartTwo()
        {
            BigInteger deckSize = 119315717514047;
            BigInteger iterations = 101741582076661;
            BigInteger position = 2020;
            BigInteger shuffleOffset = 0;
            BigInteger shuffleIncrement = 1;

            foreach (var line in inputLines)
            {
                (shuffleIncrement, shuffleOffset) = ShuffleInstruction(shuffleIncrement, shuffleOffset, deckSize, line);
            }

            (BigInteger increment, BigInteger offset) = GetSequence(iterations, shuffleIncrement, shuffleOffset, deckSize);

            var card = GetCardNumber(offset, increment, position, deckSize);

            return (long)card;
        }

        private static BigInteger GetCardNumber(BigInteger offset, BigInteger increment, BigInteger cardPosition, BigInteger deckSize)
        {
            return (offset + cardPosition * increment) % deckSize;
        }

        private static (BigInteger increment, BigInteger offset) GetSequence(BigInteger iterations, BigInteger shuffleIncrement, BigInteger offsetDifference, BigInteger deckSize)
        {
            var increment = shuffleIncrement.ModPow(iterations, deckSize);

            var offset = offsetDifference * (1 - increment) * ((1 - shuffleIncrement) % deckSize).ModInverse(deckSize);

            offset %= deckSize;

            return (increment, offset);
        }

        private static List<(ShuffleAction action, BigInteger q)> ParseInput(IEnumerable<string> inputLines)
        {
            var actionList = new List<(ShuffleAction, BigInteger)>();

            foreach (var line in inputLines)
            {
                var splitLine = line.Split(' ');

                switch (splitLine[0])
                {
                    case "deal":
                        var action = splitLine.Last().Equals("stack")
                            ? (ShuffleAction.New, 0)
                            : (ShuffleAction.Deal, BigInteger.Parse(splitLine.Last()));
                        actionList.Add(action);
                        break;

                    case "cut":
                        actionList.Add((ShuffleAction.Cut, BigInteger.Parse(splitLine.Last())));
                        break;
                }
            }

            return actionList;
        }

        private static int[] Shuffle(int[] deck, List<(ShuffleAction action, BigInteger param)> actions)
        {
            foreach (var (action, q) in actions)
            {
                switch (action)
                {
                    case ShuffleAction.New: Array.Reverse(deck); break;
                    case ShuffleAction.Cut: deck.Rotate((int)(q * -1)); break;
                    case ShuffleAction.Deal: deck.Redistribute((int)q); break;
                }
            }

            return deck;
        }

        private static (BigInteger, BigInteger) ShuffleInstruction(BigInteger shuffleIncrement, BigInteger offsetDifference, BigInteger deckSize, string line)
        {
            var param = line.Split(' ').Last();

            if (line.StartsWith("cut"))
            {
                offsetDifference += int.Parse(param) * shuffleIncrement;
            }
            else if (line.StartsWith("deal into"))
            {
                shuffleIncrement *= -1;
                offsetDifference += shuffleIncrement;
            }
            else
            {
                shuffleIncrement *= new BigInteger(int.Parse(param)).ModInverse(deckSize);
            }

            shuffleIncrement = shuffleIncrement.Modulo(deckSize);
            offsetDifference = offsetDifference.Modulo(deckSize);

            return (shuffleIncrement, offsetDifference);
        }
    }
}
