using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day16 : BaseDay
    {
        public Day16() : base(2019, 16)
        {
        }

        public Day16(IEnumerable<string> inputLines) : base(2019, 16, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var signal = ParseInput(inputLines).ToList();
            var output = ApplyFFT(signal, 100);

            return string.Join("", output.Take(8));
        }

        protected override IConvertible PartTwo()
        {
            var signal = ParseInput(inputLines).ToList();

            var trueSignal = new List<int>();

            for (int i = 0; i < 10000; i++) { trueSignal.AddRange(signal); }
            var output = ApplyOptimizedFFT(trueSignal, 100);

            return string.Join("", output);
        }

        private static List<int> ApplyFFT(List<int> signal, int phases)
        {
            for (int phaseIndex = 0; phaseIndex < phases; phaseIndex++)
            {
                signal = ApplyPhase(signal);
            }

            return signal;
        }

        private static List<int> ApplyOptimizedFFT(List<int> signal, int phases)
        {
            var offset = int.Parse(string.Join("", signal.Take(7)));

            for (int phaseIndex = 0; phaseIndex < phases; phaseIndex++)
            {
                signal = ApplyOptimizedPhase(signal);
            }

            return signal.Skip(offset).Take(8).ToList();
        }

        private static List<int> ApplyOptimizedPhase(List<int> signal)
        {
            // last value stays the same, so we can work backwards here
            for (int sigIndex = signal.Count - 2; sigIndex > signal.Count / 2; sigIndex--)
            {
                signal[sigIndex] = Math.Abs(signal[sigIndex] + signal[sigIndex + 1]) % 10;
            }

            return signal;
        }

        private static List<int> ApplyPhase(List<int> signal)
        {
            var outputSignal = new List<int>();

            for (int signalIndex = 0; signalIndex < signal.Count; signalIndex++)
            {
                var sum = 0;
                var pattern = GetPattern(signalIndex);

                for (int i = 0; i < signal.Count; i++)
                {
                    if (pattern[i % pattern.Count] != 0)
                    {
                        sum += signal[i] * pattern[i % pattern.Count];
                    }
                }

                outputSignal.Add(Math.Abs(sum) % 10);
            }

            return outputSignal;
        }

        private static List<int> GetPattern(int index)
        {
            var basePattern = new List<int> { 0, 1, 0, -1 };
            var pattern = new List<int>();

            foreach (var item in basePattern)
            {
                for (int i = 0; i < index + 1; i++)
                {
                    pattern.Add(item);
                }
            }

            pattern.Add(pattern.First());
            return pattern.Skip(1).ToList();
        }

        private static IEnumerable<int> ParseInput(IEnumerable<string> inputLines) => inputLines.First().GetNumbers();
    }
}
