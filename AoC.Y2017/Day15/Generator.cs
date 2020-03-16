using System;
using System.Collections.Generic;
using System.Text;

namespace AoC.Y2017.Days
{
	internal class Generator
	{
		public ulong StartNumber { get; set; }
		private const ulong modulus = 2147483647;
		private readonly ulong factor;
		private readonly ulong divisor;

		public Generator(ulong factor, ulong startNumber, ulong divisor)
		{
			this.factor = factor;
			StartNumber = startNumber;
			this.divisor = divisor;
		}

		public ulong Calculate(ulong input) => (input * factor) % modulus;

		public List<ulong> CalculateSet(int count, bool partTwo)
		{
			var set = new List<ulong>();
			var current = Calculate(StartNumber);
			set.Add(current);

			for (int i = 0; i < count; i++)
			{
				current = Calculate(current);

				if (!partTwo || current % divisor == 0)
				{
					set.Add(current);
				}
			}

			return set;
		}
	}
}
