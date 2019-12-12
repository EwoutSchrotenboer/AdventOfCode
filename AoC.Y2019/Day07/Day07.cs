using AoC.Helpers.Days;
using AoC.Helpers.IntComputer;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2019.Days
{
    public class Day07 : BaseDay
    {
        public Day07() : base(2019, 7)
        {
        }
        public Day07(IEnumerable<string> inputLines) : base(2019, 7, inputLines)
        {
        }

        protected override IConvertible PartOne()
        {
            var program = inputLines.First();

            long maxOutput = 0;
            var phases = new long[] { 0, 1, 2, 3, 4 };

            var permutations = phases.GetPermutations(5);


            foreach (var permutation in permutations)
            {
                var currentPhases = InitPhases(permutation.ToArray());
                var stackOutput = GetAmplifierStackOutput(program, currentPhases);

                if (stackOutput > maxOutput)
                {
                    maxOutput = stackOutput;
                }
            }

            return maxOutput;
        }

        protected override IConvertible PartTwo()
        {
            var program = inputLines.First();

            long maxOutput = 0;
            var phases = new long[] { 5, 6, 7, 8, 9 };
            var permutations = phases.GetPermutations(5);

            foreach (var permutation in permutations)
            {
                var currentPhases = InitPhases(permutation.ToArray());
                var stackOutput = GetFeedbackLoopOutput(program, currentPhases);

                if (stackOutput > maxOutput)
                {
                    maxOutput = stackOutput;
                }
            }

            return maxOutput;
        }

        private static long GetAmplifierStackOutput(string program, (long first, long second, long third, long fourth, long fifth) phases)
        {
            var firstOutput = GetAmplifierOutput(program, phases.first, 0);
            var secondOutput = GetAmplifierOutput(program, phases.second, firstOutput);
            var thirdOutput = GetAmplifierOutput(program, phases.third, secondOutput);
            var fourthOutput = GetAmplifierOutput(program, phases.fourth, thirdOutput);
            return GetAmplifierOutput(program, phases.fifth, fourthOutput);
        }

        private static long GetAmplifierOutput(string program, long phaseSetting, long inputSignal)
        {
            var inputs = new List<long> { phaseSetting, inputSignal };
            var computer = new Computer(program, inputs);
            var (_, outputs) = computer.Run();
            return outputs.Single();
        }

        private static long GetFeedbackLoopOutput(string program, (long first, long second, long third, long fourth, long fifth) phases)
        {
            var firstComputer = new Computer(program, new List<long>() { phases.first });
            var secondComputer = new Computer(program, new List<long>() { phases.second });
            var thirdComputer = new Computer(program, new List<long>() { phases.third });
            var fourthComputer = new Computer(program, new List<long>() { phases.fourth });
            var fifthComputer = new Computer(program, new List<long>() { phases.fifth });

            long output = 0;

            while (!firstComputer.Finished)
            {
                output = firstComputer.Resume(output).outputs.Last();
                output = secondComputer.Resume(output).outputs.Last();
                output = thirdComputer.Resume(output).outputs.Last();
                output = fourthComputer.Resume(output).outputs.Last();
                output = fifthComputer.Resume(output).outputs.Last();
            }

            return output;
        }

        private static (long first, long second, long third, long fourth, long fifth) InitPhases(long[] currentPhases) => (currentPhases[0], currentPhases[1], currentPhases[2], currentPhases[3], currentPhases[4]);
    }
}