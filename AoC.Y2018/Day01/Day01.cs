using AoC.Helpers.Days;
using AoC.Helpers.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day01 : BaseDay
    {
        public Day01() : base(2018, 1) { }

        protected override IConvertible PartOne() => this.ParseData(base.inputLines).Sum();

        protected override IConvertible PartTwo()
        {
            var hashSet = new HashSet<long>();

            long currentFrequency = 0;
            var index = 0;
            var arrayNumbers = this.ParseData(base.inputLines).ToArray();

            while (true)
            {
                currentFrequency += arrayNumbers[index % arrayNumbers.Length];

                if (!hashSet.Add(currentFrequency))
                {
                    return currentFrequency;
                }

                index++;
            }
        }

        private IEnumerable<long> ParseData(IEnumerable<string> inputData) => inputData.Select(i => long.Parse(i));
    }
}
