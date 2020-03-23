using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;

namespace AoC.Y2017.Days
{
    public class Day21 : BaseDay
    {
        private static readonly char[,] Fractal = new char[3, 3] {
            { '.', '#', '.' },
            { '.', '.', '#' },
            { '#', '#', '#' },
        };

        public Day21() : base(2017, 21)
        {
        }

        public Day21(IEnumerable<string> inputLines) : base(2017, 21, inputLines)
        {
        }

        protected override IConvertible PartOne() => GenerateFractal(Fractal, ParseInput(inputLines), 5).active;

        protected override IConvertible PartTwo() => GenerateFractal(Fractal, ParseInput(inputLines), 18).active;

        private static char[,] FromRuleString(string rulestring)
        {
            var items = rulestring.Split('/');
            var size = items.Length;
            var pattern = new char[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    pattern[y, x] = items[y][x];
                }
            }

            return pattern;
        }

        private static (int active, char[,] fractal) GenerateFractal(char[,] input, Dictionary<string, string> rules, int iterations)
        {
            var current = input;

            for (int i = 0; i < iterations; i++)
            {
                current = IterateFractal(current, rules);
            }

            return (GetActivePixels(current), current);
        }

        private static int GetActivePixels(char[,] input)
        {
            var count = 0;
            var size = input.GetLength(0);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    count += input[y, x] == '#' ? 1 : 0;
                }
            }

            return count;
        }

        private static char[,] GetNextBlock(char[,] current, Dictionary<string, string> rules)
        {
            var newPattern = rules[ToRuleString(current)];
            return FromRuleString(newPattern);
        }

        private static List<string> GetPatternStrings(char[,] current)
        {
            var patternStrings = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                if (i == 4)
                {
                    current = current.Flip();
                    patternStrings.Add(ToRuleString(current));
                }

                current = current.Rotate();
                patternStrings.Add(ToRuleString(current));
            }

            return patternStrings;
        }

        private static char[,] IterateFractal(char[,] current, Dictionary<string, string> rules)
        {
            var size = current.GetLength(0);
            var blockSize = size % 2 == 0 ? 2 : 3;
            var blocks = SplitFractal(current, size, blockSize);
            var nextBlocks = new List<char[,]>();

            foreach (var block in blocks)
            {
                nextBlocks.Add(GetNextBlock(block, rules));
            }

            var nextBlockSize = blockSize == 2 ? 3 : 4;
            var nextSize = (size / blockSize) * nextBlockSize;
            return MergeFractal(nextBlocks, nextSize, nextBlockSize);
        }

        private static char[,] MergeFractal(List<char[,]> blocks, int size, int blockSize)
        {
            var next = new char[size, size];
            var blockIndex = 0;

            for (int y = 0; y < size; y += blockSize)
            {
                for (int x = 0; x < size; x += blockSize)
                {
                    next.SetSubArray(blocks[blockIndex], y, x);
                    blockIndex++;
                }
            }

            return next;
        }

        private static Dictionary<string, string> ParseInput(IEnumerable<string> inputLines)
        {
            var rules = new Dictionary<string, string>();

            foreach (var line in inputLines)
            {
                var items = line.Split(" => ");

                var ruleArr = FromRuleString(items[0]);

                var variations = GetPatternStrings(ruleArr);

                foreach (var variation in variations)
                {
                    rules.TryAdd(variation, items[1]);
                }
            }

            return rules;
        }

        private static List<char[,]> SplitFractal(char[,] current, int size, int blockSize)
        {
            var blocks = new List<char[,]>();

            for (int y = 0; y < size; y += blockSize)
            {
                for (int x = 0; x < size; x += blockSize)
                {
                    blocks.Add(current.GetSubArray(y, x, blockSize));
                }
            }

            return blocks;
        }

        private static string ToRuleString(char[,] pattern)
        {
            var size = pattern.GetLength(0);
            var rows = new List<string>();

            for (int y = 0; y < size; y++)
            {
                var row = string.Empty;

                for (int x = 0; x < size; x++)
                {
                    row += pattern[y, x];
                }

                rows.Add(row);
            }

            return string.Join("/", rows);
        }
    }
}
