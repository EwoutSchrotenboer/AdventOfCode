using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day05 : BaseDay
    {
        public Day05() : base(2018, 5)
        {
        }

        public Day05(IEnumerable<string> inputLines) : base(2018, 5, inputLines)
        {
        }

        public bool OppositeMatch(char left, char right) => left <= 95 ? left + 32 == right : left - 32 == right;

        protected override IConvertible PartOne()
        {
            var input = this.inputLines.Single();
            return this.GetPolymer(input.ToList()).Count;
        }

        protected override IConvertible PartTwo()
        {
            var results = new List<int>();

            for (int i = 65; i <= 90; i++)
            {
                var input = this.inputLines.Single();
                input = input.RemoveChar((char)i);
                input = input.RemoveChar((char)(i + 32));
                results.Add(this.GetPolymer(input.ToList()).Count);
            }

            return results.Min();
        }

        private List<char> GetPolymer(List<char> polymer)
        {
            for (int i = 0; i < polymer.Count - 1; i++)
            {
                if (OppositeMatch(polymer[i], polymer[i + 1]))
                {
                    polymer.RemoveAt(i);
                    polymer.RemoveAt(i);
                    i -= 2;

                    if (i < -1)
                    {
                        i = -1;
                    }
                }
            }

            return polymer;
        }
    }
}