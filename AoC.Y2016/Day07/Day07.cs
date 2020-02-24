using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day07 : BaseDay
    {
        public Day07() : base(2016, 7)
        {
        }

        public Day07(IEnumerable<string> inputLines) : base(2016, 7, inputLines)
        {
        }

        protected override IConvertible PartOne() => ParseInput(inputLines).Count(a => SupportsTLS(a));

        protected override IConvertible PartTwo() => ParseInput(inputLines).Count(a => SupportsSSL(a));

        private static bool SupportsTLS((List<string> outers, List<string> inners) addressParts) =>
                addressParts.outers.Any(a => ContainsABBA(a)) && addressParts.inners.All(a => !ContainsABBA(a));

        private static bool ContainsABBA(string input)
        {
            for (int i = 0; i < input.Length - 3; i++)
            {
                if (input[i] != input[i + 1] && input[i] == input[i + 3] && input[i + 1] == input[i + 2]) { return true; }
            }

            return false;
        }

        private static bool SupportsSSL((List<string> outers, List<string> inners) addressParts)
        {
            var babs = addressParts.outers.SelectMany(o => ContainsABA(o));

            foreach (var bab in babs)
            {
                if (addressParts.inners.Any(i => i.Contains(bab))) { return true; }
            }

            return false;
        }

        private static List<string> ContainsABA(string input)
        {
            var babs = new List<string>();

            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] != input[i + 1] && input[i] == input[i + 2])
                {
                    babs.Add(string.Join("", new char[] { input[i + 1], input[i], input[i + 1] }));
                }
            }

            return babs;
        }

        private static List<(List<string>, List<string>)> ParseInput(IEnumerable<string> inputLines)
        {
            var addresses = new List<(List<string>, List<string>)>();

            foreach (var line in inputLines)
            {
                var outer = true;
                var outers = new List<string>(); var inners = new List<string>();
                var current = string.Empty;
                foreach (var c in line)
                {
                    if (outer && c == '[')
                    {
                        outer = false;
                        outers.Add(current);
                        current = string.Empty;
                    }
                    else if (!outer && c == ']')
                    {
                        outer = true;
                        inners.Add(current);
                        current = string.Empty;
                    }
                    else { current += c; }
                }

                if (outer)
                {
                    outers.Add(current);
                }
                else
                {
                    inners.Add(current);
                }

                addresses.Add((outers, inners));
            }

            return addresses;
        }
    }
}
