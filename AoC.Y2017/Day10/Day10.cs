using AoC.Helpers.Days;
using AoC.Helpers.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Y2017.Days
{
    public class Day10 : BaseDay
    {
        private static int partOneHashLength = 256;
        private static int partTwohashLength = 256;

        public Day10() : base(2017, 10)
        {
        }

        public Day10(IEnumerable<string> inputLines) : base(2017, 10, inputLines)
        {
            partOneHashLength = 5;
        }

        protected override IConvertible PartOne()
        {
            var lengths = ParseInput(inputLines).ToArray();
            var values = Enumerable.Range(0, partOneHashLength).Select(i => (byte)i).ToArray();

            var (result, _, _) = KnotHash.SingleRound(values, lengths, 0, 0);
            return result[0] * result[1];
        }

        protected override IConvertible PartTwo()
        {
            var lengths = ParseInputChars(inputLines);
            lengths.AddRange(new byte[] { 17, 31, 73, 47, 23 });
            return KnotHash.Create(lengths.ToArray());
        }

        private static List<byte> ParseInput(IEnumerable<string> inputLines) => inputLines.Single().Split(',').Select(i => (byte)int.Parse(i)).ToList();

        private static List<byte> ParseInputChars(IEnumerable<string> inputLines) => inputLines.Single().Select(c => Convert.ToByte(c)).ToList();
    }
}
