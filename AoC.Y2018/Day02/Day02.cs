using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2018.Days
{
    public class Day02 : BaseDay
    {
        public Day02(IEnumerable<string> input) : base(2018, 2, input) { }

        public Day02() : base(2018, 2) { }

        protected override IConvertible PartOne()
        {
            (int two, int three) count = (0, 0);

            foreach (var line in this.inputLines)
            {
                var (two, three) = this.ParseLine(line);

                if (two) count.two++;
                if (three) count.three++;
            }

            return count.two * count.three;
        }

        protected override IConvertible PartTwo()
        {
            var input = this.GetBoxIds(this.inputLines);

            foreach (var inputItem in input)
            {
                var intersect = this.GetIntersection(inputItem, input);

                if (intersect != null)
                {
                    return intersect;
                }
            }

            return null;
        }

        private string GetIntersection(string leftBox, IEnumerable<string> rightBoxes)
        {
            foreach (var rightBox in rightBoxes)
            {
                if (leftBox == rightBox) continue;

                var intersection = new List<char>();

                for (int i = 0; i < leftBox.Length; i++)
                {
                    if (leftBox[i] == rightBox[i])
                    {
                        intersection.Add(leftBox[i]);
                    }
                }

                if (intersection.Count + 1 == leftBox.Length)
                {
                    return string.Concat(intersection);
                }
            }

            return null;
        }

        private IEnumerable<string> GetBoxIds(IEnumerable<string> input)
        {
            var boxIds = new List<string>();

            foreach (var line in input)
            {
                var (two, three) = this.ParseLine(line);

                if (two || three)
                {
                    boxIds.Add(line);
                }
            }

            return boxIds;
        }

        private (bool two, bool three) ParseLine(string line)
        {
            var countDict = new Dictionary<char, int>();

            foreach (var c in line)
            {
                countDict.GetOrCreate(c);
                countDict[c]++;
            }

            return (countDict.Values.Any(c => c == 2), countDict.Values.Any(c => c == 3));
        }
    }
}