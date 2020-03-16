using System;
using System.Linq;

namespace AoC.Helpers.Utils
{
    public static class KnotHash
    {
        public static string Create(string input)
        {
            var lengths = input.Select(c => Convert.ToByte(c)).ToList();
            lengths.AddRange(new byte[] { 17, 31, 73, 47, 23 });

            return Create(Enumerable.Range(0, 256).Select(i => (byte)i).ToArray(), lengths.ToArray());
        }

        public static string Create(byte[] input) => Create(Enumerable.Range(0, 256).Select(i => (byte)i).ToArray(), input);

        public static string Create(byte[] values, byte[] input)
        {
            var position = 0;
            var skip = 0;

            for (int i = 0; i < 64; i++)
            {
                (values, position, skip) = SingleRound(values, input, position, skip);
            }

            var denseHash = CreateDenseHash(values);

            return BitConverter.ToString(denseHash).Replace("-", "").ToLower();
        }

        private static byte[] CreateDenseHash(byte[] sparseHash)
        {
            var denseHash = new byte[16];

            for (int i = 0; i < 16; i++)
            {
                var sparseBlock = sparseHash.Skip(i * 16).Take(16);
                denseHash[i] = sparseBlock.Aggregate((xor, next) => (byte)(xor ^ next));
            }

            return denseHash;
        }

        public static (byte[] values, int position, int skip) SingleRound(byte[] values, byte[] lengths, int position, int skip)
        {
            foreach (var length in lengths)
            {
                values.ReversePartial(position, position + length - 1);
                position = (position + length + skip) % values.Length;
                skip++;
            }

            return (values, position, skip);
        }
    }
}
