using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2016.Days
{
    public class Day06 : BaseDay
    {
        public Day06() : base(2016, 6)
        {
        }

        public Day06(IEnumerable<string> inputLines) : base(2016, 6, inputLines)
        {
        }

        protected override IConvertible PartOne() => GetMessage(inputLines.ToList(), true);

        protected override IConvertible PartTwo() => GetMessage(inputLines.ToList(), false);

        private static string GetMessage(List<string> messages, bool getMostCommon)
        {
            var columns = new List<char[]>();
            var message = string.Empty;

            for (int i = 0; i < messages[0].Length; i++)
            {
                columns.Add(messages.Select(m => m[i]).ToArray());
            }

            foreach (var column in columns)
            {
                var characters = new Dictionary<char, int>();

                foreach (var character in column)
                {
                    if (!characters.ContainsKey(character)) { characters.Add(character, 0); }
                    characters[character]++;
                }

                if (getMostCommon)
                {
                    message += characters.OrderByDescending(c => c.Value).First().Key;
                }
                else
                {
                    message += characters.OrderBy(c => c.Value).First().Key;
                }
            }

            return message;
        }
    }
}
