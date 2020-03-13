using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day07 : BaseDay
    {
        public Day07() : base(2017, 7)
        {
        }

        public Day07(IEnumerable<string> inputLines) : base(2017, 7, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetRootProgram(ParseInput(inputLines)).Name;

        protected override IConvertible PartTwo()
        {
            var programs = ParseInput(inputLines);
            var root = GetRootProgram(programs);
            var mismatchParent = GetMismatchingProgramParent(root);
            return GetNewWeight(mismatchParent);
        }

        private static BalanceProgram? GetMismatchingProgramParent(BalanceProgram program)
        {
            var weightGroups = program.Children.GroupBy(ch => ch.GetStackWeight());

            if (weightGroups.Count() > 1)
            {
                var mismatch = weightGroups.SingleOrDefault(g => g.Count() == 1).Single();
                var mismatchResult = GetMismatchingProgramParent(mismatch);
                return mismatchResult != null ? mismatchResult : program;
            }

            return null;
        }

        private static int GetNewWeight(BalanceProgram parent)
        {
            var weightGroups = parent.Children.GroupBy(ch => ch.GetStackWeight());

            var desiredWeight = weightGroups.Single(g => g.Count() > 1).Key;
            var mismatchingProgram = weightGroups.Single(g => g.Count() == 1).Single();
            var difference = desiredWeight - mismatchingProgram.GetStackWeight();

            return mismatchingProgram.Weight + difference;
        }

        private static BalanceProgram GetRootProgram(List<BalanceProgram> programs) => programs.Where(p => p.Children.Any()).Single(p => !programs.SelectMany(p => p.ChildNames).Contains(p.Name));

        private static List<BalanceProgram> ParseInput(IEnumerable<string> inputLines)
        {
            var programs = new List<BalanceProgram>();

            foreach (var l in inputLines)
            {
                programs.Add(new BalanceProgram(l));
            }

            foreach (var p in programs.Where(p => p.ChildNames.Any()))
            {
                foreach (var n in p.ChildNames)
                {
                    p.Children.Add(programs.Single(c => c.Name == n));
                }
            }

            return programs;
        }
    }
}
