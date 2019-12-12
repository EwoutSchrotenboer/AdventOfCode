using System;
using System.Linq;

namespace AoC.Y2018.Days
{
    internal class Note
    {
        public string Raw { get; }
        public bool[] Condition { get; }
        public bool GrowsPlant { get; }

        public Note(string raw)
        {
            Raw = raw;
            Condition = TranslateStringToBoolArr(raw.Substring(0, 5));
            GrowsPlant = TranslateStringToBool(raw.Substring(9, 1));
        }

        private static bool[] TranslateStringToBoolArr(string input)
        {
            var arr = new bool[input.Length];
            var charArray = input.ToCharArray();

            for (long i = 0; i < arr.Length; i++) { arr[i] = charArray[i] == '#'; }
            return arr;
        }

        private static bool TranslateStringToBool(string input) => input == "#";

        public bool InputProducesPlant(bool[] input) => input.SequenceEqual(Condition) ? GrowsPlant : !GrowsPlant;
    }
}
