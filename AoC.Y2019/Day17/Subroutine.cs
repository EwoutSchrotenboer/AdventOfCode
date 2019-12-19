using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC.Y2019.Days
{
    internal class Subroutine
    {
        public int Index { get; set; }
        public List<string> Set { get; set; } = new List<string>();
        public string SetString { get; set; }
        public List<int> Matches { get; set; } = new List<int>();

        public int[] ParsableSubroutine()
        {
            var updatedStrings = new List<string>();

            foreach (var item in Set)
            {
                updatedStrings.Add($"{item[0]},{item.Substring(1)}");
            }

            var final = string.Join(',', updatedStrings);
            return $"{final}\n".Select(c => (int)c).ToArray();
        }
    }
}
