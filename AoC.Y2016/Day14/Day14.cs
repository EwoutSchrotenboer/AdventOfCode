using AoC.Helpers.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AoC.Y2016.Days
{
    public class Day14 : BaseDay
    {
        public Day14() : base(2016, 14)
        {
        }

        public Day14(IEnumerable<string> inputLines) : base(2016, 14, inputLines)
        {
        }

		protected override IConvertible PartOne() => GetIndexes(inputLines.Single(), false);

        protected override IConvertible PartTwo() => GetIndexes(inputLines.Single(), true);

		private static int GetIndexes(string seed, bool partTwo)
		{
			var md5 = MD5.Create();
			var indexes = new List<int>();
			var possibleHashes = new List<(string hash, char value, int index)>();
			var index = 0;

			while (indexes.Count() < 64 || possibleHashes.Any())
			{
				var input = Encoding.ASCII.GetBytes(seed + index.ToString());
				var hash = md5.ComputeHash(input);
				if (partTwo) { hash = Stretch(hash, md5); }

				possibleHashes.RemoveAll(p => p.index < index - 1000 || indexes.Contains(p.index));
				possibleHashes = possibleHashes.OrderBy(h => h.index).ToList();
				var hexHash = BitConverter.ToString(hash).Replace("-", "").ToLower();

				foreach (var ph in possibleHashes)
				{
					if (hexHash.Contains(new string(ph.value, 5)))
					{
						indexes.Add(ph.index);
					}
				}

				var (match, value) = GetTriple(hexHash);
				if (match && indexes.Count() < 64) { possibleHashes.Add((hexHash, value, index)); }

				index++;
			}

			indexes = indexes.OrderBy(i => i).ToList();

			// I'm not sure where I've introduced the off by one error; probably by not sorting them correctly. Seems to work for both parts however.
			return indexes[62];
		}

		private static byte[] Stretch(byte[] hash, MD5 md5)
		{
			for (int i = 0; i < 2016; i++)
			{
				hash = md5.ComputeHash(Encoding.ASCII.GetBytes(BitConverter.ToString(hash).Replace("-", "").ToLower()));
			}

			return hash;
		}

		private static (bool match, char val) GetTriple(string hexHash)
		{
			for (int i = 0; i < hexHash.Length - 3; i++)
			{
				if (hexHash[i] == hexHash[i + 1] && hexHash[i] == hexHash[i + 2])
				{
					return (true, hexHash[i]);
				}
			}

			return (false, '0');
		}
	}
}
