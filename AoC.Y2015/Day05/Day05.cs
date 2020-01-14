using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2015.Days
{
    public class Day05 : BaseDay
    {
        public Day05() : base(2015, 5)
        {
        }

        public Day05(IEnumerable<string> inputLines) : base(2015, 5, inputLines)
        {
        }

        protected override IConvertible PartOne() => inputLines.Count(i => FirstNiceCheck(i));

        protected override IConvertible PartTwo() => inputLines.Count(i => SecondNiceCheck(i));
        private static bool FirstNiceCheck(string input)
        {
            if (ContainsDisallowed(input)) { return false; }
            return ContainsThreeVowels(input) && ContainsTwiceInARow(input);
        }

        private static bool ContainsThreeVowels(string input) => input.Count(c => vowels.Contains(c)) >= 3;
        private static bool ContainsDisallowed(string input) => disallowedStrings.Any(d => input.Contains(d));
        private static bool ContainsTwiceInARow(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i+1]) { return true; }
            }

            return false;
        }

        private static bool SecondNiceCheck(string input) => ContainsDoublePair(input) && ContainsSeparatedPair(input);

        private static bool ContainsDoublePair(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int mi = i; mi < input.Length - 1; mi++)
                {
                    if (mi == i - 1 || mi == i || mi == i + 1) { continue; }
                    if (input[i] == input[mi] && input[i + 1] == input[mi + 1])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool ContainsSeparatedPair(string input)
        {
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2]) { return true; }
            }

            return false;
        }

        private static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        private static string[] disallowedStrings = new string[] { "ab", "cd", "pq", "xy" };
    }
}
