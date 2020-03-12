using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day06 : BaseDay
    {
        public Day06() : base(2017, 6)
        {
        }

        public Day06(IEnumerable<string> inputLines) : base(2017, 6, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetCycles(ParseInput(inputLines)).cycles;

        protected override IConvertible PartTwo() => GetCycles(ParseInput(inputLines)).firstRepeat;

        private static (int cycles, int firstRepeat) GetCycles(int[] memorybank)
        {
            var cycles = 0;
            var states = new Dictionary<string, int>
            {
                [string.Join(' ', memorybank)] = cycles
            };

            while (true)
            {
                cycles++;

                var index = GetIndex(memorybank);
                Redistribute(memorybank, index);
                var state = string.Join(' ', memorybank);

                if (states.ContainsKey(state))
                {
                    return (cycles, cycles - states[state]);
                }

                states.Add(state, cycles);
            }
        }

        private static int GetIndex(int[] memorybank)
        {
            var max = 0;
            var maxIndex = 0;

            for (int i = 0; i < memorybank.Length; i++)
            {
                if (memorybank[i] > max)
                {
                    max = memorybank[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static void Redistribute(int[] memorybank, int startIndex)
        {
            var value = memorybank[startIndex];
            memorybank[startIndex] = 0;
            var index = startIndex + 1;

            while (value > 0)
            {
                memorybank[index % memorybank.Length]++;
                value--;
                index++;
            }
        }

        private static int[] ParseInput(IEnumerable<string> inputLines) => inputLines.Single().Split('\t').Select(i => int.Parse(i)).ToArray();
    }
}
