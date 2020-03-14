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

            var (result, _, _) = KnotHashRound(values, lengths, 0, 0);
            return result[0] * result[1];
        }

        protected override IConvertible PartTwo()
        {
            var lengths = ParseInputChars(inputLines);
            lengths.AddRange(new byte[] { 17, 31, 73, 47, 23 });
            var values = Enumerable.Range(0, partTwohashLength).Select(i => (byte)i).ToList();

            return GenerateKnotHash(values.ToArray(), lengths.ToArray());
        }

        private static byte[] GenerateDenseHash(byte[] sparseHash)
        {
            var denseHash = new byte[16];

            for (int i = 0; i < 16; i++)
            {
                var sparseBlock = sparseHash.Skip(i * 16).Take(16);
                denseHash[i] = sparseBlock.Aggregate((xor, next) => (byte)(xor ^ next));
            }

            return denseHash;
        }

        private static string GenerateKnotHash(byte[] values, byte[] input)
        {
            var position = 0;
            var skip = 0;

            for (int i = 0; i < 64; i++)
            {
                (values, position, skip) = KnotHashRound(values, input, position, skip);
            }

            var denseHash = GenerateDenseHash(values);

            return BitConverter.ToString(denseHash).Replace("-", "").ToLower();
        }

        private static (byte[] values, int position, int skip) KnotHashRound(byte[] values, byte[] lengths, int position, int skip)
        {
            foreach (var length in lengths)
            {
                values.ReversePartial(position, position + length - 1);
                position = (position + length + skip) % values.Length;
                skip++;
            }

            return (values, position, skip);
        }

        private static List<byte> ParseInput(IEnumerable<string> inputLines) => inputLines.Single().Split(',').Select(i => (byte)int.Parse(i)).ToList();

        private static List<byte> ParseInputChars(IEnumerable<string> inputLines) => inputLines.Single().Select(c => Convert.ToByte(c)).ToList();
    }
}
